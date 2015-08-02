﻿namespace AngleSharp.Scripting.JavaScript.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;

    [TestFixture]
    public class ScriptEvalTests
    {
        public static async Task<String> EvaluateComplexScriptAsync(params String[] sources)
        {
            var cfg = Configuration.Default.WithJavaScript();
            var scripts = "<script>" + String.Join("</script><script>", sources) + "</script>";
            var html = "<!doctype html><div id=result></div>" + scripts;
            var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(html));
            return document.GetElementById("result").InnerHtml;
        }

        public static String SetResult(String eval)
        {
            return "document.querySelector('#result').textContent = " + eval + ";";
        }

        [Test]
        public async Task AccessUndefinedGlobalVariable()
        {
            var result = await EvaluateComplexScriptAsync(SetResult("$.toString()"));
            Assert.AreEqual("", result);
        }

        [Test]
        public async Task AccessGlobalVariablesFromOtherScriptShouldWork()
        {
            var result = await EvaluateComplexScriptAsync("var a = 5;", SetResult("a.toString()"));
            Assert.AreEqual("5", result);
        }

        [Test]
        public async Task AccessLocalVariablesFromOtherScriptShouldNotWork()
        {
            var result = await EvaluateComplexScriptAsync("(function () { var a = 5; })();", SetResult("a.toString()"));
            Assert.AreEqual("", result);
        }
    }
}
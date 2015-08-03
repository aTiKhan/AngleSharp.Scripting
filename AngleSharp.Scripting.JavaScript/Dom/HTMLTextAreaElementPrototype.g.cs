namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Html;
    using Jint;
    using Jint.Native;
    using Jint.Native.Object;
    using Jint.Runtime;
    using Jint.Runtime.Descriptors;
    using Jint.Runtime.Interop;
    using System;

    sealed partial class HTMLTextAreaElementPrototype : HTMLTextAreaElementInstance
    {
        public HTMLTextAreaElementPrototype(Engine engine)
            : base(engine)
        {
            FastAddProperty("toString", Engine.AsValue(ToString), true, true, true);
            FastAddProperty("select", Engine.AsValue(Select), true, true, true);
            FastAddProperty("setSelectionRange", Engine.AsValue(SetSelectionRange), true, true, true);
            FastAddProperty("append", Engine.AsValue(Append), true, true, true);
            FastAddProperty("prepend", Engine.AsValue(Prepend), true, true, true);
            FastAddProperty("querySelector", Engine.AsValue(QuerySelector), true, true, true);
            FastAddProperty("querySelectorAll", Engine.AsValue(QuerySelectorAll), true, true, true);
            FastAddProperty("before", Engine.AsValue(Before), true, true, true);
            FastAddProperty("after", Engine.AsValue(After), true, true, true);
            FastAddProperty("replace", Engine.AsValue(Replace), true, true, true);
            FastAddProperty("remove", Engine.AsValue(Remove), true, true, true);
            FastSetProperty("autofocus", Engine.AsProperty(GetAutofocus, SetAutofocus));
            FastSetProperty("disabled", Engine.AsProperty(GetDisabled, SetDisabled));
            FastSetProperty("form", Engine.AsProperty(GetForm));
            FastSetProperty("labels", Engine.AsProperty(GetLabels));
            FastSetProperty("name", Engine.AsProperty(GetName, SetName));
            FastSetProperty("type", Engine.AsProperty(GetType));
            FastSetProperty("required", Engine.AsProperty(GetRequired, SetRequired));
            FastSetProperty("readOnly", Engine.AsProperty(GetReadOnly, SetReadOnly));
            FastSetProperty("defaultValue", Engine.AsProperty(GetDefaultValue, SetDefaultValue));
            FastSetProperty("value", Engine.AsProperty(GetValue, SetValue));
            FastSetProperty("wrap", Engine.AsProperty(GetWrap, SetWrap));
            FastSetProperty("textLength", Engine.AsProperty(GetTextLength));
            FastSetProperty("rows", Engine.AsProperty(GetRows, SetRows));
            FastSetProperty("cols", Engine.AsProperty(GetCols, SetCols));
            FastSetProperty("maxLength", Engine.AsProperty(GetMaxLength, SetMaxLength));
            FastSetProperty("placeholder", Engine.AsProperty(GetPlaceholder, SetPlaceholder));
            FastSetProperty("selectionDirection", Engine.AsProperty(GetSelectionDirection));
            FastSetProperty("dirName", Engine.AsProperty(GetDirName, SetDirName));
            FastSetProperty("selectionStart", Engine.AsProperty(GetSelectionStart, SetSelectionStart));
            FastSetProperty("selectionEnd", Engine.AsProperty(GetSelectionEnd, SetSelectionEnd));
            FastSetProperty("children", Engine.AsProperty(GetChildren));
            FastSetProperty("firstElementChild", Engine.AsProperty(GetFirstElementChild));
            FastSetProperty("lastElementChild", Engine.AsProperty(GetLastElementChild));
            FastSetProperty("childElementCount", Engine.AsProperty(GetChildElementCount));
            FastSetProperty("nextElementSibling", Engine.AsProperty(GetNextElementSibling));
            FastSetProperty("previousElementSibling", Engine.AsProperty(GetPreviousElementSibling));
            FastSetProperty("style", Engine.AsProperty(GetStyle, SetStyle));
        }

        public static HTMLTextAreaElementPrototype CreatePrototypeObject(EngineInstance engine, HTMLTextAreaElementConstructor constructor)
        {
            var obj = new HTMLTextAreaElementPrototype(engine.Jint)
            {
                Prototype = engine.Constructors.HTMLElement.PrototypeObject,
                Extensible = true,
            };
            obj.FastAddProperty("constructor", constructor, true, false, true);
            return obj;
        }

        JsValue Select(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            reference.SelectAll();
            return JsValue.Undefined;
        }

        JsValue SetSelectionRange(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var selectionStart = TypeConverter.ToInt32(arguments.At(0));
            var selectionEnd = TypeConverter.ToInt32(arguments.At(1));
            var selectionDirection = TypeConverter.ToString(arguments.At(2));
            reference.Select(selectionStart, selectionEnd, selectionDirection);
            return JsValue.Undefined;
        }

        JsValue Append(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Append(nodes);
            return JsValue.Undefined;
        }

        JsValue Prepend(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Prepend(nodes);
            return JsValue.Undefined;
        }

        JsValue QuerySelector(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var selectors = TypeConverter.ToString(arguments.At(0));
            return Engine.Select(reference.QuerySelector(selectors));
        }

        JsValue QuerySelectorAll(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var selectors = TypeConverter.ToString(arguments.At(0));
            return Engine.Select(reference.QuerySelectorAll(selectors));
        }

        JsValue Before(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Before(nodes);
            return JsValue.Undefined;
        }

        JsValue After(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.After(nodes);
            return JsValue.Undefined;
        }

        JsValue Replace(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Replace(nodes);
            return JsValue.Undefined;
        }

        JsValue Remove(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            reference.Remove();
            return JsValue.Undefined;
        }

        JsValue GetAutofocus(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Autofocus);
        }

        void SetAutofocus(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.Autofocus = value;
        }

        JsValue GetDisabled(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.IsDisabled);
        }

        void SetDisabled(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsDisabled = value;
        }

        JsValue GetForm(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Form);
        }


        JsValue GetLabels(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Labels);
        }


        JsValue GetName(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Name);
        }

        void SetName(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.Name = value;
        }

        JsValue GetType(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Type);
        }


        JsValue GetRequired(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.IsRequired);
        }

        void SetRequired(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsRequired = value;
        }

        JsValue GetReadOnly(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.IsReadOnly);
        }

        void SetReadOnly(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsReadOnly = value;
        }

        JsValue GetDefaultValue(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.DefaultValue);
        }

        void SetDefaultValue(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.DefaultValue = value;
        }

        JsValue GetValue(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Value);
        }

        void SetValue(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.Value = value;
        }

        JsValue GetWrap(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Wrap);
        }

        void SetWrap(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.Wrap = value;
        }

        JsValue GetTextLength(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.TextLength);
        }


        JsValue GetRows(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Rows);
        }

        void SetRows(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToInt32(argument);
            reference.Rows = value;
        }

        JsValue GetCols(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Columns);
        }

        void SetCols(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToInt32(argument);
            reference.Columns = value;
        }

        JsValue GetMaxLength(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.MaxLength);
        }

        void SetMaxLength(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToInt32(argument);
            reference.MaxLength = value;
        }

        JsValue GetPlaceholder(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Placeholder);
        }

        void SetPlaceholder(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.Placeholder = value;
        }

        JsValue GetSelectionDirection(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.SelectionDirection);
        }


        JsValue GetDirName(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.DirectionName);
        }

        void SetDirName(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.DirectionName = value;
        }

        JsValue GetSelectionStart(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.SelectionStart);
        }

        void SetSelectionStart(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToInt32(argument);
            reference.SelectionStart = value;
        }

        JsValue GetSelectionEnd(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.SelectionEnd);
        }

        void SetSelectionEnd(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToInt32(argument);
            reference.SelectionEnd = value;
        }

        JsValue GetChildren(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Children);
        }


        JsValue GetFirstElementChild(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.FirstElementChild);
        }


        JsValue GetLastElementChild(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.LastElementChild);
        }


        JsValue GetChildElementCount(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.ChildElementCount);
        }


        JsValue GetNextElementSibling(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.NextElementSibling);
        }


        JsValue GetPreviousElementSibling(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.PreviousElementSibling);
        }


        JsValue GetStyle(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            return Engine.Select(reference.Style);
        }

        void SetStyle(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLTextAreaElementInstance>(Fail).RefHTMLTextAreaElement;
            var value = TypeConverter.ToString(argument);
            reference.Style.CssText = value;
        }

        JsValue ToString(JsValue thisObj, JsValue[] arguments)
        {
            return "[object HTMLTextAreaElement]";
        }

        void Fail(JsValue obsolete)
        {
            throw new JavaScriptException(Engine.TypeError);
        }
    }
}
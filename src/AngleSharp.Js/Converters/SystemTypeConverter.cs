﻿namespace AngleSharp.Js
{
    using Jint.Native;
    using Jint.Runtime;
    using System;
    using System.Collections.Generic;
    using System.IO;

    static class SystemTypeConverter
    {
        public static IDictionary<String, Object> ToObjBag(JsValue arg)
        {
            var obj = arg.AsObject();
            var dict = new Dictionary<String, Object>();
            var properties = obj.GetOwnProperties();

            foreach (var property in properties)
            {
                var value = property.Value.Value.Clr();
                dict.Add(property.Key,value);
            }

            return dict;
        }

        public static Action<Stream> ToStreamTask(JsValue arg)
        {
            return null;
        }

        public static Nullable<Int32> ToOptionalInt32(JsValue arg)
        {
            if (arg.IsNumber())
            {
                return TypeConverter.ToInt32(arg);
            }

            return null;
        }

        public static Nullable<DateTime> ToOptionalDateTime(JsValue arg)
        {
            return null;
        }

        public static Object ToObject(JsValue arg)
        {
            return arg.ToObject();
        }

        static Object Clr(this JsValue arg)
        {
            return arg?.ToObject();
        }
    }
}

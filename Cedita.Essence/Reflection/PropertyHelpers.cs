// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Reflection;

namespace Cedita.Essence.Reflection
{
    public static class PropertyHelpers
    {
        public static PropertyInfo GetProperty(object obj, string propName)
        {
            return obj.GetType().GetProperty(propName);
        }

        public static Type GetPropertyType(object obj, string propName)
        {
            return GetProperty(obj, propName).PropertyType;
        }

        public static object GetPropertyValue(object obj, string propName)
        {
            return GetProperty(obj, propName).GetValue(obj);
        }

        public static T GetPropertyValue<T>(object obj, string propName)
        {
            return (T)GetPropertyValue(obj, propName);
        }

        public static void SetPropertyValue(object obj, string propName, object val)
        {
            GetProperty(obj, propName).SetValue(obj, val);
        }
    }
}

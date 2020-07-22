// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Cedita.Essence.Extensions
{
    public static class ResourceManagerHelperExtensions
    {
        public static string GetResourceName(this ResourceManager resourceManager, string value, CultureInfo cultureInfo, bool ignoreCase = false)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var comparisonType = ignoreCase ? System.StringComparison.OrdinalIgnoreCase : System.StringComparison.Ordinal;
                var entry = resourceManager.GetResourceSet(cultureInfo, true, true)
                                           .OfType<DictionaryEntry>()
                                           .FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString().Equals(value, comparisonType));

                return entry.Key.ToString();
            }
            else
                return string.Empty;
        }
    }
}

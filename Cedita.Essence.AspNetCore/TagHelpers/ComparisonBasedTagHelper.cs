// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cedita.Essence.AspNetCore.TagHelpers
{
    public abstract class ComparisonBasedTagHelper : TagHelper
    {
        protected List<(Func<bool> qualifier, Func<bool> comparison)> comparisons = new List<(Func<bool>, Func<bool>)>();

        protected ComparisonBasedTagHelper()
            : base()
        {
        }

        protected void AddComparison(Func<bool> qualifier, Func<bool> result)
        {
            comparisons.Add((qualifier, result));
        }

        protected IEnumerable<bool> MakeComparisons()
        {
            var results = comparisons
                .Where(m => m.qualifier())
                .Select(m => m.comparison());
            return results;
        }

        protected bool GetComparisonResult(IfOperatorMode operatorMode, IfComparisonMode comparisonMode)
        {
            var results = MakeComparisons();
            var match = operatorMode == IfOperatorMode.And ? results.All(m => m) : results.Any(m => m);
            if (comparisonMode == IfComparisonMode.Negated)
            {
                match = !match;
            }

            return match;
        }
    }
}

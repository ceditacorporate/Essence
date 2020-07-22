// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Cedita.Essence.AspNetCore.TagHelpers;

namespace Cedita.Essence.AspNetCore
{
    public class EssenceTagHelperOptions
    {
        public EssenceTagHelperOptions()
        {
            DefaultOperatorMode = IfOperatorMode.Or;
            DefaultComparisonMode = IfComparisonMode.Match;
        }

        public IfOperatorMode DefaultOperatorMode { get; set; }

        public IfComparisonMode DefaultComparisonMode { get; set; }

        public string DefaultClassIfClass { get; set; }
    }
}

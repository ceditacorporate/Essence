// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace Cedita.Essence.AspNetCore.TagHelpers
{
    [HtmlTargetElement("*", Attributes = TagAttribute)]
    public class BooleanDisplayTagHelper : ComparisonBasedTagHelper
    {
        private const string TagAttribute = "render-if-matches";

        public BooleanDisplayTagHelper(IOptions<EssenceTagHelperOptions> options)
        {
            RenderIfOperator = options.Value.DefaultOperatorMode;
            RenderIfMode = options.Value.DefaultComparisonMode;

            AddComparison(() => RenderIfMatches != null, () => RenderIfMatches.Value);
        }

        public IfOperatorMode RenderIfOperator { get; set; }

        public IfComparisonMode RenderIfMode { get; set; }

        public bool? RenderIfMatches { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var match = GetComparisonResult(RenderIfOperator, RenderIfMode);
            output.TagName = null;

            if (!match)
            {
                output.SuppressOutput();
            }
        }
    }
}

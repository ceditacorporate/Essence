// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Cedita.Essence.AspNetCore.TagHelpers
{
    public abstract class RouteBasedTagHelper : ComparisonBasedTagHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        protected RouteBasedTagHelper(IHttpContextAccessor httpContextAccessor)
            : base()
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected enum RouteOption
        {
            Area,
            Controller,
            Action,
            Page,
        }

        protected void AddRouteMatch(RouteOption option, Func<bool> qualifier, Func<string> matchTo)
        {
            AddComparison(qualifier, () =>
            {
                var optionVal = httpContextAccessor.HttpContext.GetRouteValue(option.ToString().ToLower()) as string;

                // Supporting multiple values, split by ;
                var matchVals = matchTo()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                // Sanitise for Razor Page
                if (option == RouteOption.Page)
                {
                    for (int i = 0; i < matchVals.Length; i++)
                    {
                        if (matchVals[i][0] != '/')
                        {
                            matchVals[i] = "/" + matchVals[i];
                        }
                    }
                }

                return matchVals.Any(m => string.Equals(optionVal, m, StringComparison.InvariantCultureIgnoreCase));
            });
        }
    }
}

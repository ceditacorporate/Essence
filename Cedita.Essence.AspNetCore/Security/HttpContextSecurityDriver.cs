// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Security.Claims;
using Cedita.Essence.Abstractions.Security;
using Microsoft.AspNetCore.Http;

namespace Cedita.Essence.AspNetCore.Security
{
    public class HttpContextSecurityDriver : ISecurityDriver
    {
        private readonly HttpContext httpContext;

        public HttpContextSecurityDriver(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        public TResult GetClaimValue<TResult>(string claimType)
        {
            var claimValue = httpContext.User.FindFirstValue(claimType);
            object returnObj;
            switch (default(TResult))
            {
                case int _:
                    returnObj = int.Parse(claimValue);
                    break;
                case long _:
                    returnObj = long.Parse(claimValue);
                    break;
                case decimal _:
                    returnObj = decimal.Parse(claimValue);
                    break;
                case bool _:
                    returnObj = string.Equals(claimValue, "true", StringComparison.InvariantCultureIgnoreCase) || string.Equals(claimValue, "1");
                    break;
                case double _:
                case float _:
                    returnObj = double.Parse(claimValue);
                    break;
                case string _:
                default:
                    returnObj = claimValue;
                    break;
            }

            return (TResult)returnObj;
        }

        public bool HasClaim(string claimType)
        {
            var claim = httpContext.User.FindFirst(claimType);
            return claim != null;
        }
    }
}

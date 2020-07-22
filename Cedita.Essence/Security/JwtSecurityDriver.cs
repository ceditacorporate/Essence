// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Cedita.Essence.Abstractions.Security;

namespace Cedita.Essence.Security
{
    public class JwtSecurityDriver : ISecurityDriver
    {
        public TResult GetClaimValue<TResult>(string claimType)
        {
            throw new System.NotImplementedException();
        }

        public bool HasClaim(string claimType)
        {
            throw new System.NotImplementedException();
        }
    }
}

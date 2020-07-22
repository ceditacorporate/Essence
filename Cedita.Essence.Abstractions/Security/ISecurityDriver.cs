// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

namespace Cedita.Essence.Abstractions.Security
{
    public interface ISecurityDriver
    {
        bool HasClaim(string claimType);

        TResult GetClaimValue<TResult>(string claimType);
    }
}

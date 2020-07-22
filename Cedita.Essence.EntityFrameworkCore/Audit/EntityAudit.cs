// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Identity;

namespace Cedita.Essence.EntityFrameworkCore.Audit
{
    /// <summary>
    /// Default EntityAudit type for EF Core configured as int for main table keys, and default IdentityUser (with int key) type for link table.
    /// </summary>
    public class EntityAudit : EntityAudit<int, IdentityUser<int>>
    {
    }
}

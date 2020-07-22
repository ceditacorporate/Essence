// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

namespace Cedita.Essence.EntityFrameworkCore.Audit
{
    /// <summary>
    /// Type of audit to be entered.
    /// </summary>
    public enum AuditType
    {
        /// <summary>
        /// Audit Type of Log. Generally used for System related entries.
        /// </summary>
        Log,

        /// <summary>
        /// Audit Type of Comment. Generally used for user-entered notes.
        /// </summary>
        Comment,

        /// <summary>
        /// Audit Type of Audit. Generally used for field changes.
        /// </summary>
        Audit,
    }
}

// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;

namespace Cedita.Essence.Operations
{
    /// <summary>
    /// Encapsulates an error from an operation.
    /// </summary>
    public class OperationError
    {
        /// <summary>
        /// Gets or sets the Code that represents this error.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets or sets the Message for this error.
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// Gets or sets the Exception (if any) for this error.
        /// </summary>
        public virtual Exception Exception { get; set; }
    }
}

// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Cedita.Essence.DependencyInjection
{
    /// <summary>
    /// Holds injection information about a particular type.
    /// </summary>
    public sealed class AutoInjectType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoInjectType"/> class.
        /// </summary>
        /// <param name="type">Type to be injected.</param>
        /// <param name="attribute">Attribute on type.</param>
        public AutoInjectType(Type type, AutoInjectAttribute attribute)
        {
            this.Type = type;
            this.Lifetime = attribute.Lifetime;
            this.Implements = attribute.Implements;
        }

        /// <summary>
        /// Gets type to be injected.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets or sets lifetime of injection from attribute.
        /// </summary>
        public ServiceLifetime Lifetime { get; set; }

        /// <summary>
        /// Gets or sets what this type implements.
        /// </summary>
        public IEnumerable<Type> Implements { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether injected or not.
        /// </summary>
        public bool Injected { get; set; }
    }
}

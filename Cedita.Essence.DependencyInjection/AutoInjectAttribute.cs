// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cedita.Essence.DependencyInjection
{
    /// <summary>
    /// Add this attribute to your classes to enable auto injection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class AutoInjectAttribute : Attribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AutoInjectAttribute"/> class.
        /// </summary>
        /// <param name="lifetime">Lifetime to register this service as.</param>
        /// <param name="implements">Optional types that this Type implements.</param>
        /// <remarks>If you do not pass <paramref name="implements"/> this will be automatically determined from any interface that is not IDisposable.</remarks>
        public AutoInjectAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient, params Type[] implements)
        {
            this.Lifetime = lifetime;
            this.Implements = implements;
        }

        /// <summary>
        /// Gets or sets Lifetime of this injection.
        /// </summary>
        public ServiceLifetime Lifetime { get; set; }

        /// <summary>
        /// Gets or sets the types of which this class implements.
        /// </summary>
        public Type[] Implements { get; set; }
    }
}

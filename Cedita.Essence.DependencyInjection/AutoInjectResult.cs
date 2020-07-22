// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Cedita.Essence.DependencyInjection
{
    /// <summary>
    /// Result of Auto Injection of dependencies.
    /// </summary>
    public sealed class AutoInjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoInjectResult"/> class.
        /// </summary>
        /// <param name="services">Dependency Injection Service Collection.</param>
        /// <param name="assemblies">Assemblies to be scanned.</param>
        /// <param name="types">Types to be injected.</param>
        public AutoInjectResult(IServiceCollection services, IEnumerable<Assembly> assemblies, IEnumerable<AutoInjectType> types)
        {
            this.Services = services;
            this.Assemblies = assemblies;
            this.Types = types;
        }

        /// <summary>
        /// Gets service injection.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets Assemblies being scanned for auto injection.
        /// </summary>
        public IEnumerable<Assembly> Assemblies { get; }

        /// <summary>
        /// Gets the types being injected.
        /// </summary>
        public IEnumerable<AutoInjectType> Types { get; }
    }
}

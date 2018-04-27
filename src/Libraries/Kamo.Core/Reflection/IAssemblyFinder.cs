﻿using System.Collections.Generic;
using System.Reflection;

namespace Kamo.Core.Reflection
{
    public interface IAssemblyFinder
    {
        /// <summary>
        /// Gets all assemblies.
        /// </summary>
        /// <returns>List of assemblies</returns>
        List<Assembly> GetAllAssemblies();

        IList<string> AssemblyNames { get; set; }
    }
}
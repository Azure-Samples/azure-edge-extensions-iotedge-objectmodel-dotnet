// <copyright file="ModuleSpecificationDesiredProperties.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// ModuleSpecificationDesiredProperties.
    /// </summary>
    public class ModuleSpecificationDesiredProperties
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets desiredProperties.
        /// </summary>
        public object DesiredProperties { get; set; }
    }
}
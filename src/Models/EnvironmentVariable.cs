// <copyright file="EnvironmentVariable.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// EnvironmentVariable.
    /// </summary>
    public class EnvironmentVariable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentVariable"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public EnvironmentVariable(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets value.
        /// </summary>
        public string Value { get; }
    }
}
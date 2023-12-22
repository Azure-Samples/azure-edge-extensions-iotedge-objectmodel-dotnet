// <copyright file="EdgeModuleSpecification.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;

    /// <summary>
    /// EdgeModuleSpecification.
    /// </summary>
    public class EdgeModuleSpecification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeModuleSpecification"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="image">Image.</param>
        /// <param name="version">Version.</param>
        /// <param name="restartPolicy">RestartPolicy.</param>
        /// <param name="createOptions">CreateOptions.</param>
        /// <param name="status">Status.</param>
        /// <param name="environmentVariables">EnvironmentVariables.</param>
        public EdgeModuleSpecification(
            string name,
            string image,
            string version = "1.0",
            RestartPolicy restartPolicy = RestartPolicy.Always,
            string createOptions = "",
            ModuleStatus status = ModuleStatus.Running,
            List<EnvironmentVariable> environmentVariables = null)
        {
            this.Name = name;
            this.Image = image;
            this.Version = version;
            this.RestartPolicy = restartPolicy;
            this.CreateOptions = createOptions;
            this.Status = status;
            this.EnvironmentVariables = environmentVariables == null ? new List<EnvironmentVariable>() : environmentVariables;
        }

        /// <summary>
        /// Gets name.
        /// Module name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets image.
        /// The URI to the module image.
        /// </summary>
        public string Image { get; }

        /// <summary>
        /// Gets version.
        /// A user-defined string representing the version of this module.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets restartPolicy.
        /// {"never" | "always"}.
        /// </summary>
        public RestartPolicy RestartPolicy { get; }

        /// <summary>
        /// Gets createOptions.
        /// A stringified JSON containing the options for the creation of the module container.
        /// </summary>
        public string CreateOptions { get; }

        /// <summary>
        /// Gets status.
        /// {"running" | "stopped"}.
        /// </summary>
        public ModuleStatus Status { get; }

        /// <summary>
        /// Gets environmentVariables.
        /// </summary>
        public List<EnvironmentVariable> EnvironmentVariables { get; }
    }
}
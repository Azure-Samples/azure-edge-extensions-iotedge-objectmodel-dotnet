// <copyright file="EdgeAgentDesiredProperties.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;

    /// <summary>
    /// EdgeAgentDesiredProperties.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11 for more information.
    /// </summary>
    public class EdgeAgentDesiredProperties
    {
        /// <summary>
        /// Gets schemaVersion.
        /// Either "1.0" or "1.1". Version 1.1 was introduced with IoT Edge version 1.0.10, and is recommended.
        /// </summary>
        public string SchemaVersion { get; } = "1.1";

        /// <summary>
        /// Gets or sets systemModuleVersion.
        /// EdgeAgent and EdgeHub version.
        /// </summary>
        public string SystemModuleVersion { get; set; } = "1.3";

        /// <summary>
        /// Gets or sets edgeAgentCreateOptions.
        /// A stringified JSON containing the options for the creation of the IoT Edge agent container.
        /// </summary>
        public string EdgeAgentCreateOptions { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets edgeHubCreateOptions.
        /// A stringified JSON containing the options for the creation of the IoT Edge hub container.
        /// </summary>
        public string EdgeHubCreateOptions { get; set; } = "{\"HostConfig\":{\"PortBindings\":{\"443/tcp\":[{\"HostPort\":\"443\"}],\"5671/tcp\":[{\"HostPort\":\"5671\"}],\"8883/tcp\":[{\"HostPort\":\"8883\"}]}}}";

        /// <summary>
        /// Gets or sets registryCredentials.
        /// </summary>
        public List<RegistryCredential> RegistryCredentials { get; set; } = new List<RegistryCredential>();

        /// <summary>
        /// Gets or sets edgeSystemModuleSpecifications.
        /// </summary>
        public List<EdgeModuleSpecification> EdgeSystemModuleSpecifications { get; set; } = new List<EdgeModuleSpecification>();

        /// <summary>
        /// Gets or sets edgeModuleSpecifications.
        /// </summary>
        public List<EdgeModuleSpecification> EdgeModuleSpecifications { get; set; } = new List<EdgeModuleSpecification>();
    }
}
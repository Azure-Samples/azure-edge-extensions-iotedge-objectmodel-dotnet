// <copyright file="EdgeHubDesiredProperties.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;

    /// <summary>
    /// EdgeHubDesiredProperties.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11 for more information.
    /// </summary>
    public class EdgeHubDesiredProperties
    {
        /// <summary>
        /// Gets or sets routes.
        /// </summary>
        public List<Route> Routes { get; set; } = new List<Route>();

        /// <summary>
        /// Gets schemaVersion.
        /// Either "1.0" or "1.1". Version 1.1 was introduced with IoT Edge version 1.0.10, and is recommended.
        /// </summary>
        public string SchemaVersion { get; } = "1.1";

        /// <summary>
        /// Gets or sets storeAndForwardTimeToLiveSecs.
        /// The device time in seconds that IoT Edge hub keeps messages if disconnected from routing endpoints, whether IoT Hub or a local module. This time persists over any power offs or restarts.
        /// The default value is 7200. See more https://docs.microsoft.com/en-us/azure/iot-edge/offline-capabilities?view=iotedge-2020-11#time-to-live for more information.
        /// </summary>
        public int StoreAndForwardTimeToLiveSecs { get; set; } = 7200;
    }
}
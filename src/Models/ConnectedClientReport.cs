// <copyright file="ConnectedClientReport.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System;

    /// <summary>
    /// ConnectedClientReport.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgehub-reported-properties for more information.
    /// </summary>
    public class ConnectedClientReport
    {
        /// <summary>
        /// Gets or sets clientId.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// The connectivity status of this device or module. Possible values {"connected" | "disconnected"}. Only module identities can be in disconnected state. Downstream devices connecting to IoT Edge hub appear only when connected.
        /// </summary>
        public ClientStatus Status { get; set; }

        /// <summary>
        /// Gets or sets lastConnectedTimeUtc.
        /// Last time the device or module connected.
        /// </summary>
        public DateTime LastConnectedTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets lastDisconnectedTimeUtc.
        /// Last time the device or module disconnected.
        /// </summary>
        public DateTime LastDisconnectedTimeUtc { get; set; }
    }
}
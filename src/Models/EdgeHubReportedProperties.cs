// <copyright file="EdgeHubReportedProperties.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// EdgeHubReportedProperties.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11 for more information.
    /// </summary>
    public class EdgeHubReportedProperties
    {
        /// <summary>
        /// Gets or sets connectedClientReports.
        /// </summary>
        public List<ConnectedClientReport> ConnectedClientReports { get; set; } = new List<ConnectedClientReport>();
    }
}
// <copyright file="EdgeAgentReportedProperties.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;

    /// <summary>
    /// EdgeAgentReportedProperties.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11 for more information.
    /// </summary>
    public class EdgeAgentReportedProperties
    {
        /// <summary>
        /// Gets or sets edgeAgentModuleReport.
        /// </summary>
        public EdgeModuleReport EdgeAgentModuleReport { get; set; }

        /// <summary>
        /// Gets or sets edgeHubModuleReport.
        /// </summary>
        public EdgeModuleReport EdgeHubModuleReport { get; set; }

        /// <summary>
        /// Gets or sets edgeModuleReports.
        /// </summary>
        public List<EdgeModuleReport> EdgeModuleReports { get; set; }
    }
}
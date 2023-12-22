// <copyright file="ModuleStatus.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// ModuleStatus.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgeagent-desired-properties for more information.
    /// </summary>
    public enum ModuleStatus
    {
        /// <summary>
        /// Running.
        /// </summary>
        Running,

        /// <summary>
        /// Stopped.
        /// </summary>
        Stopped,

        /// <summary>
        /// Unknown.
        /// When ModuleStatus is null.
        /// </summary>
        Unknown,
    }
}
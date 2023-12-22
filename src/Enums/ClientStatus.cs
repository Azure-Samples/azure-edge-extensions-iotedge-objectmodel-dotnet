// <copyright file="ClientStatus.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// ClientStatus.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgehub-reported-properties for more information.
    /// </summary>
    public enum ClientStatus
    {
        /// <summary>
        /// Connected.
        /// </summary>
        Connected,

        /// <summary>
        /// Disconnected.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Unknown.
        /// When ClientStatus is null.
        /// </summary>
        Unknown,
    }
}
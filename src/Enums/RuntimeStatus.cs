// <copyright file="RuntimeStatus.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// RuntimeStatus.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgeagent-reported-properties for more information.
    /// </summary>
    public enum RuntimeStatus
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
        /// Failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Backoff.
        /// </summary>
        Backoff,

        /// <summary>
        /// Unhealthy
        /// </summary>
        Unhealthy,

        /// <summary>
        /// Unknown.
        /// When RuntimeStatus is null.
        /// </summary>
        Unknown,
    }
}

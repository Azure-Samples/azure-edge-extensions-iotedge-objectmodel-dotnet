// <copyright file="ImagePullPolicy.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// ImagePullPolicy.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgeagent-desired-properties for more information.
    /// </summary>
    public enum ImagePullPolicy
    {
        /// <summary>
        /// OnCreate.
        /// </summary>
        OnCreate,

        /// <summary>
        /// Never.
        /// </summary>
        Never,

        /// <summary>
        /// Unknown.
        /// When ImagePullPolicy is null.
        /// </summary>
        Unknown,
    }
}

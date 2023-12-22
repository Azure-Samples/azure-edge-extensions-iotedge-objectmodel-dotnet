// <copyright file="Settings.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// Settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets imageHash.
        /// </summary>
        public string ImageHash { get; set; }

        /// <summary>
        /// Gets or sets createOptions.
        /// </summary>
        public string CreateOptions { get; set; }
    }
}
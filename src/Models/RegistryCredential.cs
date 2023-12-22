// <copyright file="RegistryCredential.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    /// <summary>
    /// RegistryCredential.
    /// </summary>
    public class RegistryCredential
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryCredential"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="address">Address.</param>
        /// <param name="userName">UserName.</param>
        /// <param name="password">Password.</param>
        public RegistryCredential(string name, string address, string userName, string password)
        {
            this.Name = name;
            this.Address = address;
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets userName.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Gets password.
        /// </summary>
        public string Password { get; }
    }
}
// <copyright file="DeploymentManifest.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// DeploymentManifest for an edge device based on existing edge device and its desired properties.
    /// refer to https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgeagent-desired-properties.
    /// </summary>
    public class DeploymentManifest
    {
        /// <summary>
        /// Gets or sets modulesContent.
        /// </summary>
        [JsonProperty("modulesContent")]
        public ModulesCtnt ModulesContent { get; set; }

        /// <summary>
        /// ModulesContent.
        /// </summary>
        public class ModulesCtnt
        {
            /// <summary>
            /// Gets or sets edgeAgent.
            /// </summary>
            [JsonProperty("$edgeAgent")]
            public EdgeAgent EdgeAgent { get; set; }

            /// <summary>
            /// Gets or sets edgeHub.
            /// </summary>
            [JsonProperty("$edgeHub")]
            public EdgeHub EdgeHub { get; set; }
        }

        /// <summary>
        /// EdgeAgent.
        /// </summary>
        public class EdgeAgent
        {
            /// <summary>
            /// Gets or sets properties.desired.
            /// </summary>
            [JsonProperty("properties.desired")]
            public PropertiesDesiredEdgeAgent PropertiesDesired { get; set; }
        }

        /// <summary>
        /// PropertiesDesiredEdgeAgent.
        /// </summary>
        public class PropertiesDesiredEdgeAgent
        {
            /// <summary>
            /// Gets or sets schemaVersion.
            /// </summary>
            [JsonProperty("schemaVersion")]
            public string SchemaVersion { get; set; }

            /// <summary>
            /// Gets or sets runtime.
            /// </summary>
            [JsonProperty("runtime")]
            public Runtime Runtime { get; set; }

            /// <summary>
            /// Gets or sets systemModules.
            /// </summary>
            [JsonProperty("systemModules")]
            public Dictionary<string, SystemModuleSpecification> SystemModules { get; set; }

            /// <summary>
            /// Gets or sets modules.
            /// </summary>
            [JsonProperty("modules")]
            public Dictionary<string, SystemModuleSpecification> Modules { get; set; }
        }

        /// <summary>
        /// Runtime.
        /// </summary>
        public class Runtime
        {
            /// <summary>
            /// Gets or sets type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets settings.
            /// </summary>
            [JsonProperty("settings")]
            public Settings Settings { get; set; }
        }

        /// <summary>
        /// Settings.
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// Gets or sets minDockerVersion.
            /// </summary>
            [JsonProperty("minDockerVersion")]
            public string MinDockerVersion { get; set; }

            /// <summary>
            /// Gets or sets loggingOptions.
            /// </summary>
            [JsonProperty("loggingOptions")]
            public string LoggingOptions { get; set; }

            /// <summary>
            /// Gets or sets registryCredentials.
            /// </summary>
            [JsonProperty("registryCredentials")]
            public Dictionary<string, Store> RegistryCredentials { get; set; }
        }

        /// <summary>
        /// Registry store.
        /// </summary>
        public class Store
        {
            /// <summary>
            /// Gets or sets address.
            /// </summary>
            [JsonProperty("address")]
            public string Address { get; set; }

            /// <summary>
            /// Gets or sets password.
            /// </summary>
            [JsonProperty("password")]
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets username.
            /// </summary>
            [JsonProperty("username")]
            public string Username { get; set; }
        }

        /// <summary>
        /// SystemModuleSpecification.
        /// </summary>
        public class SystemModuleSpecification
        {
            /// <summary>
            /// Gets or sets type.
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets status.
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// Gets or sets restartPolicy.
            /// </summary>
            [JsonProperty("restartPolicy")]
            public string RestartPolicy { get; set; }

            /// <summary>
            /// Gets or sets settings.
            /// </summary>
            [JsonProperty("settings")]
            public SettingsSpecification Settings { get; set; }

            /// <summary>
            /// Gets or sets env.
            /// </summary>
            [JsonProperty("env")]
            public Dictionary<string, EnvSpecification> Env { get; set; }

            /// <summary>
            /// Gets or sets startupOrder.
            /// </summary>
            [JsonProperty("startupOrder")]
            public int? StartupOrder { get; set; }
        }

        /// <summary>
        /// SettingsSpecification.
        /// </summary>
        public class SettingsSpecification
        {
            /// <summary>
            /// Gets or sets image.
            /// </summary>
            [JsonProperty("image")]
            public string Image { get; set; }

            /// <summary>
            /// Gets or sets createOptions.
            /// </summary>
            [JsonProperty("createOptions")]
            public string CreateOptions { get; set; }
        }

        /// <summary>
        /// EnvSpecification.
        /// </summary>
        public class EnvSpecification
        {
            /// <summary>
            /// Gets or sets value.
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        /// <summary>
        /// EdgeHub.
        /// </summary>
        public class EdgeHub
        {
            /// <summary>
            /// Gets or sets properties.desired.
            /// </summary>
            [JsonProperty("properties.desired")]
            public PropertiesDesiredEdgeHub PropertiesDesired { get; set; }
        }

        /// <summary>
        /// PropertiesDesiredEdgeHub.
        /// </summary>
        public class PropertiesDesiredEdgeHub
        {
            /// <summary>
            /// Gets or sets schemaVersion.
            /// </summary>
            [JsonProperty("schemaVersion")]
            public string SchemaVersion { get; set; }

            /// <summary>
            /// Gets or sets routes.
            /// </summary>
            [JsonProperty("routes")]
            public Dictionary<string, Dictionary<string, string>> Routes { get; set; }

            /// <summary>
            /// Gets or sets storeAndForwardConfiguration.
            /// </summary>
            [JsonProperty("storeAndForwardConfiguration")]
            public StoreAndForwardConfiguration StoreAndForwardConfiguration { get; set; }
        }

        /// <summary>
        /// StoreAndForwardConfiguration.
        /// </summary>
        public class StoreAndForwardConfiguration
        {
            /// <summary>
            /// Gets or sets timeToLiveSecs.
            /// </summary>
            [JsonProperty("timeToLiveSecs")]
            public int TimeToLiveSecs { get; set; }
        }
    }
}
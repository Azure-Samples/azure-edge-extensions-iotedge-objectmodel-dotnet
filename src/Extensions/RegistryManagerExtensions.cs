// <copyright file="RegistryManagerExtensions.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Shared;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using static Microsoft.Azure.Devices.DeploymentManifest;

    /// <summary>
    /// RegistryManagerExtensions.
    /// </summary>
    public static class RegistryManagerExtensions
    {
        /// <summary>
        /// GetDeploymentManifest from edgeHub and edgeAgent twins.
        /// </summary>
        /// <param name="registryManager">RegistryManager.</param>
        /// <param name="deviceId">IoT Edge deviceId.</param>
        /// <returns>DeploymentManifest JSON.</returns>
        public static async Task<string> GetDeploymentManifest(this RegistryManager registryManager, string deviceId)
        {
            Twin edgeAgentTwin = await registryManager.GetTwinAsync(deviceId, "$edgeAgent");
            Twin edgeHubTwin = await registryManager.GetTwinAsync(deviceId, "$edgeHub");

            string edgeAgentDesiredProperties = edgeAgentTwin.Properties.Desired.ToJson();
            string edgeHubDesiredProperties = edgeHubTwin.Properties.Desired.ToString();

            DeploymentManifest manifest = new DeploymentManifest()
            {
                ModulesContent = new ModulesCtnt()
                {
                    EdgeAgent = new EdgeAgent()
                    {
                        PropertiesDesired = JsonConvert.DeserializeObject<PropertiesDesiredEdgeAgent>(edgeAgentDesiredProperties),
                    },
                    EdgeHub = new EdgeHub()
                    {
                        PropertiesDesired = JsonConvert.DeserializeObject<PropertiesDesiredEdgeHub>(edgeHubDesiredProperties),
                    },
                },
            };

            return JsonConvert.SerializeObject(
                manifest,
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        /// <summary>
        /// Get ModulesContent from a deployment-at-scale.
        /// </summary>
        /// <param name="registryManager">RegistryManager.</param>
        /// <param name="currentDeploymentId">Current deploymentId.</param>
        /// <returns>Current ModulesContent.</returns>
        public static async Task<IDictionary<string, IDictionary<string, object>>> GetModulesContent(
            this RegistryManager registryManager,
            string currentDeploymentId)
        {
            Configuration configuration = await registryManager.GetConfigurationAsync(currentDeploymentId);

            return configuration?.Content?.ModulesContent;
        }

        /// <summary>
        /// Get deployment-at-scale by deploymentId and clone it.
        /// </summary>
        /// <param name="registryManager">RegistryManager.</param>
        /// <param name="currentDeploymentId">Current deploymentId.</param>
        /// <param name="newDeploymentId">New deploymentId.</param>
        /// <param name="newModulesContent">New modulesContent: if not specified, modulesContent is cloned from existing deployment.</param>
        /// <returns>Task.</returns>
        public static async Task CloneDeploymentAtScale(
            this RegistryManager registryManager,
            string currentDeploymentId,
            string newDeploymentId,
            IDictionary<string, IDictionary<string, object>> newModulesContent = null)
        {
            Configuration configuration = await registryManager.GetConfigurationAsync(currentDeploymentId);

            if (newModulesContent != null)
            {
                configuration.Content.ModulesContent = newModulesContent;
            }

            var config = new Configuration(newDeploymentId)
            {
                Content = configuration.Content,
                Labels = configuration.Labels,
                Metrics = configuration.Metrics,
                Priority = configuration.Priority,
                TargetCondition = configuration.TargetCondition,
            };

            await registryManager.AddConfigurationAsync(config);
        }
    }
}
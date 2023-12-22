// <copyright file="Samples.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Shared;

    /// <summary>
    /// Samples.
    /// </summary>
    public class Samples
    {
        /// <summary>
        /// GenerateManifestSample.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task GenerateManifestSample()
        {
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString("<ioTHubConnectionString>");
            EdgeAgentDesiredProperties edgeAgentDesiredProperties = new EdgeAgentDesiredProperties()
            {
                SystemModuleVersion = "1.3",
                RegistryCredentials = new List<RegistryCredential>()
                {
                    new RegistryCredential("<containerRegistryName>", "<address>", "<userName>", "<password>"),
                },
                EdgeModuleSpecifications = new List<EdgeModuleSpecification>()
                {
                    new EdgeModuleSpecification("simulator", "mcr.microsoft.com/azureiotedge-simulated-temperature-sensor:1.0"),
                },
                EdgeSystemModuleSpecifications = new List<EdgeModuleSpecification>()
                {
                    new EdgeModuleSpecification("edgeAgent", "mcr.microsoft.com/azureiotedge-agent:1.4"),
                    new EdgeModuleSpecification("edgeHub", "mcr.microsoft.com/azureiotedge-hub:1.4", createOptions: "{\"HostConfig\":{\"PortBindings\":{\"443/tcp\":[{\"HostPort\":\"443\"}],\"5671/tcp\":[{\"HostPort\":\"5671\"}],\"8883/tcp\":[{\"HostPort\":\"8883\"}]}}}"),
                },
            };
            EdgeHubDesiredProperties edgeHubConfig = new EdgeHubDesiredProperties()
            {
                Routes = new List<Route>()
                {
                    new Route("sensorToUpstream", "FROM /messages/modules/tempSensor/outputs/temperatureOutput INTO $upstream"),
                },
            };
            ModuleSpecificationDesiredProperties customModule = new ModuleSpecificationDesiredProperties()
            {
                Name = "simulator",
                DesiredProperties = new { customObject = "custom properties" },
            };
            ConfigurationContent configurationContent = new ConfigurationContent()
                            .SetEdgeHub(edgeHubConfig)
                            .SetEdgeAgent(edgeAgentDesiredProperties)
                            .SetModuleDesiredProperty(customModule);

            await registryManager.ApplyConfigurationContentOnDeviceAsync("IoTEdgeId", configurationContent).ConfigureAwait(false);
        }

        /// <summary>
        /// GetModuleTwinSample.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task GetModuleTwinSample()
        {
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString("ioTHubConnectionString");

            // Get edgeAgent reported properties.
            Twin edgeAgentTwin = await registryManager.GetTwinAsync("IoTEdgeId", "$edgeAgent").ConfigureAwait(false);
            EdgeAgentReportedProperties edgeAgentReportedProperties = edgeAgentTwin.GetEdgeAgentReportedProperties();

            // Get edgeHub reported properties.
            Twin edgeHubTwin = await registryManager.GetTwinAsync("IoTEdgeId", "$edgeHub").ConfigureAwait(false);
            EdgeHubReportedProperties edgeHubReportedProperties = edgeHubTwin.GetEdgeHubReportedProperties();
        }

        /// <summary>
        /// GetDeploymentManifestSample.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task GetDeploymentManifestSample()
        {
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString("<IoTHub ConnectionString>");

            // Get deployment manifest for edge deviceId
            string manifest = await registryManager.GetDeploymentManifest("<IoTEdgeId>");
        }

        /// <summary>
        /// CloneDeploymentAtScaleSample.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task CloneDeploymentAtScaleSample()
        {
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString("<IoTHub ConnectionString>");

            // optional: Add new modulesContent
            IDictionary<string, IDictionary<string, object>> newModulesContent = await registryManager.GetModulesContent("<CurrentDeploymentId>");

            // Clone deployment-at-scale
            await registryManager.CloneDeploymentAtScale("<CurrentDeploymentId>", "<NewDeploymentId>", newModulesContent);
        }
    }
}
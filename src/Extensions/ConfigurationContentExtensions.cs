// <copyright file="ConfigurationContentExtensions.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ConfigurationContentExtensions.
    /// </summary>
    public static class ConfigurationContentExtensions
    {
        /// <summary>
        /// SetEdgeAgent.
        /// </summary>
        /// <param name="configurationContent">ConfigurationContent Input.</param>
        /// <param name="edgeAgentDesiredProperties">EdgeAgentDesiredProperties.</param>
        /// <returns>ConfigurationContent Output.</returns>
        public static ConfigurationContent SetEdgeAgent(this ConfigurationContent configurationContent, EdgeAgentDesiredProperties edgeAgentDesiredProperties)
        {
            if (configurationContent.ModulesContent == null)
            {
                configurationContent.ModulesContent = new Dictionary<string, IDictionary<string, object>>();
            }

            configurationContent.ModulesContent.Add(
                "$edgeAgent",
                new Dictionary<string, object>
                {
                    ["properties.desired"] = GetEdgeAgentConfiguration(edgeAgentDesiredProperties),
                });

            return configurationContent;
        }

        /// <summary>
        /// SetEdgeHub.
        /// </summary>
        /// <param name="configurationContent">ConfigurationContent Input.</param>
        /// <param name="edgeHubDesiredProperties">EdgeHubDesiredProperties.</param>
        /// <returns>ConfigurationContent Output.</returns>
        public static ConfigurationContent SetEdgeHub(this ConfigurationContent configurationContent, EdgeHubDesiredProperties edgeHubDesiredProperties)
        {
            Dictionary<string, Dictionary<string, string>> routes = new Dictionary<string, Dictionary<string, string>>();
            edgeHubDesiredProperties.Routes.ForEach(x =>
            {
                routes.Add(x.Name, new Dictionary<string, string>
                {
                    { "route", x.Value },
                });
            });

            if (configurationContent.ModulesContent == null)
            {
                configurationContent.ModulesContent = new Dictionary<string, IDictionary<string, object>>();
            }

            configurationContent.ModulesContent.Add(
           "$edgeHub",
           new Dictionary<string, object>
           {
               ["properties.desired"] = new
               {
                   schemaVersion = edgeHubDesiredProperties.SchemaVersion,
                   routes = routes,
                   storeAndForwardConfiguration = new
                   {
                       timeToLiveSecs = edgeHubDesiredProperties.StoreAndForwardTimeToLiveSecs,
                   },
               },
           });

            return configurationContent;
        }

        /// <summary>
        /// SetModuleDesiredProperty.
        /// </summary>
        /// <param name="configurationContent">ConfigurationContent Input.</param>
        /// <param name="moduleSpecificationDesiredProperties">ModuleSpecificationDesiredProperties.</param>
        /// <returns>ConfigurationContent Output.</returns>
        public static ConfigurationContent SetModuleDesiredProperty(this ConfigurationContent configurationContent, ModuleSpecificationDesiredProperties moduleSpecificationDesiredProperties)
        {
            if (configurationContent.ModulesContent == null)
            {
                configurationContent.ModulesContent = new Dictionary<string, IDictionary<string, object>>();
            }

            configurationContent.ModulesContent.Add(
               moduleSpecificationDesiredProperties.Name, new Dictionary<string, object>
               {
                   ["properties.desired"] = moduleSpecificationDesiredProperties.DesiredProperties,
               });

            return configurationContent;
        }

        private static object GetEdgeAgentConfiguration(EdgeAgentDesiredProperties edgeAgentDesiredProperties)
        {
            Dictionary<string, Dictionary<string, string>> manifestRegistryCredentials = new Dictionary<string, Dictionary<string, string>>();
            edgeAgentDesiredProperties.RegistryCredentials.ForEach(x =>
            {
                manifestRegistryCredentials.Add(x.Name, new Dictionary<string, string>()
                {
                    { "address", x.Address },
                    { "username", x.UserName },
                    { "password", x.Password },
                });
            });

            Dictionary<string, object> modules = new Dictionary<string, object>();
            edgeAgentDesiredProperties.EdgeModuleSpecifications.ForEach(x =>
            {
                Dictionary<string, object> env = new Dictionary<string, object>();
                x.EnvironmentVariables.ForEach(e => env.Add(e.Name, new { value = e.Value }));
                modules.Add(
                    x.Name,
                    new
                    {
                        version = x.Version,
                        type = "docker",
                        status = x.Status.ToString().ToLower(),
                        restartPolicy = x.RestartPolicy.ToString().ToLower(),
                        settings = new
                        {
                            image = x.Image,
                            createOptions = x.CreateOptions,
                        },
                        env = env,
                    });
            });

            return new
            {
                schemaVersion = edgeAgentDesiredProperties.SchemaVersion,
                runtime = new
                {
                    type = "docker",
                    settings = new
                    {
                        loggingOptions = string.Empty,
                        minDockerVersion = "v1.25",
                        registryCredentials = manifestRegistryCredentials,
                    },
                },
                systemModules = GetSystemModuleSpecification(edgeAgentDesiredProperties),
                modules = modules,
            };
        }

        private static object GetSystemModuleSpecification(EdgeAgentDesiredProperties edgeAgentDesiredProperties)
        {
            Dictionary<string, object> systemModules = new Dictionary<string, object>();
            if (edgeAgentDesiredProperties.EdgeSystemModuleSpecifications.Any())
            {
                edgeAgentDesiredProperties.EdgeSystemModuleSpecifications.ForEach(x =>
                {
                    Dictionary<string, object> env = new Dictionary<string, object>();
                    x.EnvironmentVariables.ForEach(e => env.Add(e.Name, new { value = e.Value }));
                    systemModules.Add(
                        x.Name,
                        new
                        {
                            version = x.Version,
                            type = "docker",
                            status = x.Status.ToString().ToLower(),
                            restartPolicy = x.RestartPolicy.ToString().ToLower(),
                            settings = new
                            {
                                image = x.Image,
                                createOptions = x.CreateOptions,
                            },
                            env = env,
                        });
                });
                return systemModules;
            }

            return new
            {
                edgeAgent = new
                {
                    type = "docker",
                    settings = new
                    {
                        image = $"mcr.microsoft.com/azureiotedge-agent:{edgeAgentDesiredProperties.SystemModuleVersion}",
                        createOptions = edgeAgentDesiredProperties.EdgeAgentCreateOptions,
                    },
                },
                edgeHub = new
                {
                    type = "docker",
                    status = "running",
                    restartPolicy = "always",
                    settings = new
                    {
                        image = $"mcr.microsoft.com/azureiotedge-hub:{edgeAgentDesiredProperties.SystemModuleVersion}",
                        createOptions = edgeAgentDesiredProperties.EdgeHubCreateOptions,
                    },
                },
            };
        }
    }
}

// <copyright file="TwinExtensions.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Devices.Shared;

    /// <summary>
    /// TwinExtensions.
    /// </summary>
    public static class TwinExtensions
    {
        /// <summary>
        /// GetTwinConfig.
        /// </summary>
        /// <param name="twin">Twin.</param>
        /// <returns>EdgeAgentReportedProperties.</returns>
        public static EdgeAgentReportedProperties GetEdgeAgentReportedProperties(this Twin twin)
        {
            EdgeModuleReport edgeAgentModuleReport = twin.Properties.Reported.Contains("systemModules") ? ExtractEdgeModuleReport(twin.Properties.Reported["systemModules"]["edgeAgent"], "edgeAgent") : default(EdgeModuleReport);
            EdgeModuleReport edgeHubModuleReport = twin.Properties.Reported.Contains("systemModules") ? ExtractEdgeModuleReport(twin.Properties.Reported["systemModules"]["edgeHub"], "edgeHub") : default(EdgeModuleReport);
            List<EdgeModuleReport> edgeModuleReports = new List<EdgeModuleReport>();

            if (twin.Properties.Reported.Contains("modules"))
            {
                TwinCollection modules = twin.Properties.Reported["modules"];
                foreach (KeyValuePair<string, object> keyValuePair in modules)
                {
                    edgeModuleReports.Add(ExtractEdgeModuleReport(new TwinCollection(keyValuePair.Value.ToString()), keyValuePair.Key));
                }
            }

            EdgeAgentReportedProperties edgeAgentReportedProperties = new EdgeAgentReportedProperties()
            {
                EdgeAgentModuleReport = edgeAgentModuleReport,
                EdgeHubModuleReport = edgeHubModuleReport,
                EdgeModuleReports = edgeModuleReports,
            };

            return edgeAgentReportedProperties;
        }

        /// <summary>
        /// GetTwinConfig.
        /// </summary>
        /// <param name="twin">Twin.</param>
        /// <returns>EdgeHubReportedProperties.</returns>
        public static EdgeHubReportedProperties GetEdgeHubReportedProperties(this Twin twin)
        {
            EdgeHubReportedProperties edgeHubReportedProperties = new EdgeHubReportedProperties();
            if (twin.Properties.Reported.Contains("clients"))
            {
                TwinCollection clients = twin.Properties.Reported["clients"];
                foreach (KeyValuePair<string, object> keyValuePair in clients)
                {
                    TwinCollection client = new TwinCollection(keyValuePair.Value.ToString());
                    edgeHubReportedProperties.ConnectedClientReports.Add(new ConnectedClientReport()
                    {
                        ClientId = keyValuePair.Key,
                        LastConnectedTimeUtc = client.Contains("lastConnectedTimeUtc") ? DateTime.Parse(client["lastConnectedTimeUtc"].ToString()) : DateTime.MinValue,
                        LastDisconnectedTimeUtc = client.Contains("lastDisconnectedTimeUtc") ? DateTime.Parse(client["lastDisconnectedTimeUtc"].ToString()) : DateTime.MinValue,
                        Status = client.Contains("status") ? (ClientStatus)Enum.Parse(typeof(ClientStatus), client["status"].ToString(), true) : ClientStatus.Unknown,
                    });
                }
            }

            return edgeHubReportedProperties;
        }

        private static EdgeModuleReport　ExtractEdgeModuleReport(dynamic module, string moduleName)
        {
            EdgeModuleReport edgeModuleReport = new EdgeModuleReport()
            {
                Name = moduleName,
                StatusDescription = module.Contains("statusDescription") ? module["statusDescription"] : string.Empty,
                Version = module.Contains("version") ? module["version"] : string.Empty,
                Type = module.Contains("type") ? module["type"] : string.Empty,
                StartupOrder = module.Contains("startupOrder") ? module["startupOrder"] : 0,
                RestartCount = module.Contains("restartCount") ? module["restartCount"] : 0,
                ExitCode = module.Contains("exitCode") ? module["exitCode"] : 0,
                Status = module.Contains("status") ? (ModuleStatus)Enum.Parse(typeof(ModuleStatus), module["status"].ToString(), true) : ModuleStatus.Unknown,
                RestartPolicy = module.Contains("restartPolicy") ? (RestartPolicy)Enum.Parse(typeof(RestartPolicy), module["restartPolicy"].ToString(), true) : RestartPolicy.Unknown,
                ImagePullPolicy = module.Contains("imagePullPolicy") ? (ImagePullPolicy)Enum.Parse(typeof(ImagePullPolicy), module["imagePullPolicy"].ToString().Replace("-", string.Empty), true) : ImagePullPolicy.Unknown,
                RuntimeStatus = module.Contains("runtimeStatus") ? (RuntimeStatus)Enum.Parse(typeof(RuntimeStatus), module["runtimeStatus"].ToString(), true) : RuntimeStatus.Unknown,
                LastRestartTimeUtc = module.Contains("lastRestartTimeUtc") ? DateTime.Parse(module["lastRestartTimeUtc"].ToString()) : DateTime.MinValue,
                LastStartTimeUtc = module.Contains("lastStartTimeUtc") ? DateTime.Parse(module["lastStartTimeUtc"].ToString()) : DateTime.MinValue,
                LastExitTimeUtc = module.Contains("lastExitTimeUtc") ? DateTime.Parse(module["lastExitTimeUtc"].ToString()) : DateTime.MinValue,
            };

            if (module.Contains("settings"))
            {
                TwinCollection settings = new TwinCollection(module["settings"].ToString());
                edgeModuleReport.Settings = new Settings()
                {
                    Image = settings.Contains("image") ? settings["image"] : string.Empty,
                    ImageHash = settings.Contains("imageHash") ? settings["imageHash"] : string.Empty,
                    CreateOptions = settings.Contains("createOptions") ? settings["createOptions"] : string.Empty,
                };
            }

            if (module.Contains("env"))
            {
                TwinCollection env = new TwinCollection(module["env"].ToString());
                foreach (KeyValuePair<string, object> keyValuePair in env)
                {
                    TwinCollection valueTwin = new TwinCollection(keyValuePair.Value.ToString());
                    string value = valueTwin.Contains("value") ? valueTwin["value"] : string.Empty;
                    edgeModuleReport.EnvironmentVariables.Add(new EnvironmentVariable(keyValuePair.Key, value));
                }
            }

            return edgeModuleReport;
        }
    }
}

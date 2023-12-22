// <copyright file="EdgeModuleReport.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// </copyright>

namespace Microsoft.Azure.Devices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// EdgeModuleReport.
    /// see https://docs.microsoft.com/en-us/azure/iot-edge/module-edgeagent-edgehub?view=iotedge-2020-11#edgeagent-reported-properties for more information.
    /// </summary>
    public class EdgeModuleReport
    {
        /// <summary>
        /// Gets or sets name.
        /// Module name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets exitCode.
        /// The exit code reported by the IoT Edge hub container if the container exits.
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// Gets or sets statusDescription.
        /// Text description of the status of IoT Edge hub if unhealthy.
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets lastStartTimeUtc.
        /// </summary>
        public DateTime LastStartTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets lastExitTimeUtc.
        /// Time when IoT Edge hub last exited.
        /// </summary>
        public DateTime LastExitTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets restartCount.
        /// </summary>
        public int RestartCount { get; set; }

        /// <summary>
        /// Gets or sets lastRestartTimeUtc.
        /// Time when IoT Edge hub was last restarted.
        /// </summary>
        public DateTime LastRestartTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets runtimeStatus.
        /// Status of IoT Edge hub: { "running" | "stopped" | "failed" | "backoff" | "unhealthy" }.
        /// </summary>
        public RuntimeStatus RuntimeStatus { get; set; }

        /// <summary>
        /// Gets or sets version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// {"running" | "stopped"}.
        /// </summary>
        public ModuleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets restartPolicy.
        /// {"never" | "always"}.
        /// </summary>
        public RestartPolicy RestartPolicy { get; set; }

        /// <summary>
        /// Gets or sets imagePullPolicy.
        /// {"on-create" | "never"}.
        /// </summary>
        public ImagePullPolicy ImagePullPolicy { get; set; }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets startupOrder.
        /// </summary>
        public int StartupOrder { get; set; }

        /// <summary>
        /// Gets or sets settings.
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets environmentVariables.
        /// </summary>
        public List<EnvironmentVariable> EnvironmentVariables { get; set; } = new List<EnvironmentVariable>();
    }
}
using EnvironmentConfig.Model;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;

namespace EnvironmentConfig
{
    public class ConfigurationLoader
    {
        private const string DefaultSettingsFile = "./Config/appsettings.json";

        /// <summary>
        /// Loads the configuration for the given environment and tenant.
        /// If no environment or tenant is provided, then the default local config is loaded.
        /// </summary>
        /// <param name="environment">The environment the tests should point to.</param>
        /// <param name="tenant">The tenant the tests should target.</param>
        /// <returns>The configuration to use for the tests.</returns>
        public HostsConfiguration Load(string environment = "", string tenant = "")
        {
            string targetJsonFile = DefaultSettingsFile;

            if (!string.IsNullOrWhiteSpace(environment) && !string.IsNullOrWhiteSpace(tenant))
            {
                // Override default config with environment specific config
                environment = FormatEnvironment(environment);
                tenant = FormatTenant(tenant);
                targetJsonFile = $"./Config/appsettings.{environment}.{tenant}.json";
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(DefaultSettingsFile)
                .AddJsonFile(targetJsonFile)
                .Build();

            var gitHubConfiguration = new HostsConfiguration();

            configuration.GetSection("Hosts").Bind(gitHubConfiguration);

            return gitHubConfiguration;
        }

        private string FormatEnvironment(string environment)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(environment);
        }

        private string FormatTenant(string tenant)
        {
            return tenant.ToUpper();
        }
    }
}

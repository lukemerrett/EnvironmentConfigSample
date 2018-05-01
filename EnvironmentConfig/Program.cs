using EnvironmentConfig.Model;
using System;

namespace EnvironmentConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configLoader = new ConfigurationLoader();

            HostsConfiguration configuration = null;

            if (args.Length != 2)
            {
                Console.WriteLine("No environment parameters supplied");
                Console.WriteLine("Should be in the format: 'dotnet run Staging UK'");
                Console.WriteLine("Loading default config instead");

                configuration = configLoader.Load();
            }
            else
            {
                var environment = args[0];
                var tenant = args[1];

                Console.WriteLine($"Loading configuration for '{environment}' -' {tenant}'");
                configuration = configLoader.Load(environment, tenant);
            }

            Console.WriteLine("\n\n------------------\nLoaded configuration is:");
            Console.WriteLine($"Tests Enabled: {configuration.TestsEnabled}");
            Console.WriteLine($"Tenant: {configuration.Tenant}");
            Console.WriteLine($"First API: {configuration.FirstApi}");
            Console.WriteLine($"Second API: {configuration.SecondApi}");

            Console.WriteLine("\n\nPress enter to exit");
            Console.ReadLine();
        }
    }
}

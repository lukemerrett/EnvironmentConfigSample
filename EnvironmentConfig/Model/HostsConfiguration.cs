namespace EnvironmentConfig.Model
{
    public class HostsConfiguration
    {
        public bool TestsEnabled { get; set; }

        public string Tenant { get; set; }

        public string FirstApi { get; set; }

        public string SecondApi { get; set; }
    }
}

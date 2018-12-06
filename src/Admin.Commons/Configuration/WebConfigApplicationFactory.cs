namespace Admin.Common.Configuration
{
    public static class WebConfigApplicationFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeLogFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetWebConfigApplication()
        {
            return _applicationSettings ?? (_applicationSettings = new WebConfigApplicationSettings());
        }
    }
}
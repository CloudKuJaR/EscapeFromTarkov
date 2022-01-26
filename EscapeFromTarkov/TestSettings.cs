using Microsoft.Extensions.Configuration;

namespace EscapeFromTarkov
{
    public static class TestSettings
    {
        static TestSettings()
        {
            SetDefaultValues();
        }

        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

        public static string BaseUrl { get; set; }

        private static void SetDefaultValues()
        {
            BaseUrl = TestConfiguration["BaseUrl"];
        }
    }
}

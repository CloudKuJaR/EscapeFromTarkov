using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using System;

namespace EscapeFromTarkov
{
    public static class Initialize
    {
        public static void InitializeDriver()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Manage().Window.Maximize();
        }

        public static void GoToBaseUrl()
        {
            Driver.driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }

        public static string InitializePath()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }

        public static void InitializeReporter(string projectPath, string testName)
        {
            Reporter.htmlReporter = new ExtentHtmlReporter($"{projectPath}Reports\\{testName}\\.html");
            Reporter.htmlReporter.Config.DocumentTitle = "Test Report";
            Reporter.htmlReporter.Config.ReportName = " Artem ";
            Reporter.extent = new ExtentReports();
            Reporter.extent.AttachReporter(Reporter.htmlReporter);
        }
    }
}

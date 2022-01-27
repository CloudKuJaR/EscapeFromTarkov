using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EscapeFromTarkov.WebDriverExtension
{
    public static class WebDriverExtension
    {
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(500);
        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);

        public static WebDriverWait GetWait(
            this IWebDriver driver,
            TimeSpan timeout = default,
            TimeSpan pollingInterval = default,
            Type[] exceptionTypes = null)
        {
            var wait = new WebDriverWait(driver, timeout.Ticks == 0 ? Timeout : timeout)
            {
                PollingInterval = pollingInterval.Ticks == 0 ? DefaultPollingInterval : pollingInterval
            };

            wait.IgnoreExceptionTypes(exceptionTypes ?? new[] { typeof(StaleElementReferenceException) });

            return wait;
        }
    }
}

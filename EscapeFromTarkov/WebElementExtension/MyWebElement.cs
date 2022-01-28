using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace EscapeFromTarkov.WebElementExtension
{
    public class MyWebElement : IMyWebElement
    {
        private readonly By _by;
        private IWebElement _webElement;
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(500);
        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);

        private static IWebDriver WebDriver => Driver.driver;
        public Point LocationOnScreenOnceScrolledIntoView => ((ILocatable)WebElement).LocationOnScreenOnceScrolledIntoView;
        public ICoordinates Coordinates => ((ILocatable)WebElement).Coordinates;
        public IWebElement WrappedElement => WebElement;

        private IWebElement WebElement
        {
            get
            {
                if (_webElement == null)
                {
                    _webElement = WebDriver.FindElement(_by);
                }

                return _webElement;
            }
        }

        public MyWebElement(By by) => _by = by;

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return WebElement.FindElements(by);
            }
            catch (StaleElementReferenceException)
            {
                return WebElement.FindElements(by);
            }
        }

        private void WaitForElementExistence(TimeSpan? timeout = null, bool shouldExist = true)
        {
            var wait = new WebDriverWait(WebDriver, timeout ?? Timeout);
            wait.Until(drv => drv.FindElements(_by).Count != 0 == shouldExist);
        }

        private bool IsExists(TimeSpan timeout, bool shouldExist)
        {
            try
            {
                WaitForElementExistence(timeout, shouldExist: shouldExist);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsExists(int timeout, bool shouldExist) => IsExists(TimeSpan.FromMilliseconds(timeout), shouldExist);

        public bool IsPresent(int timeout = 3000) => IsExists(timeout, true);

        public bool IsRemoved(int timeout = 3000) => IsExists(timeout, false);

        public void ScrollToElement() =>
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", WebElement);

        public void Click()
        {
            var wait = new WebDriverWait(WebDriver, Timeout);
            wait.IgnoreExceptionTypes(new[] { typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException) });
            wait.Until(drv =>
            {
                WebElement.Click();

                return true;
            });
        }

        public void HoverOver()
        {
            var action = new Actions(WebDriver);
            var wait = new WebDriverWait(WebDriver, Timeout);
            wait.IgnoreExceptionTypes(new[] { typeof(ElementClickInterceptedException) });
            wait.Until(drv =>
            {
                action.MoveToElement(WebElement);
                action.Build().Perform();

                return true;
            });
        }

        public void WaitForElementIsDisplayed(int? timeout = null)
        {
            var wait = new WebDriverWait(WebDriver, timeout == null ? Timeout : TimeSpan.FromMilliseconds((int)timeout));
            wait.Until(drv => IsPresent(1) && drv.FindElement(_by).Displayed);
        }

        #region DefualtMethods
        public void Clear()
        {
            WebElement.Clear();
        }

        public void SendKeys(string text)
        {
            WebElement.SendKeys(text);
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(by);

        public void Submit()
        {
            WebElement.Submit();
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return WebElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return WebElement.GetProperty(propertyName);
        }

        public string TagName => _webElement?.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;

        public By Selector => _by;

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}


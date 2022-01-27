using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class SupportPage
    {
        private const string SEARCH_FIELD_LOCATOR = "//input[@id='main_search']";
        private const string SEARCH_RESULT_LOCATOR = "//ul[@class='results']//a[text()='{0}']";

        private MyWebElement SearchField => new MyWebElement(By.XPath(SEARCH_FIELD_LOCATOR));

        public void ClickSearchField() => SearchField.Click();

        public void FillSearchField(string searchText) => SearchField.SendKeys(searchText);

        public bool IsSearchResultPresent(string searchText) => new MyWebElement(By.XPath(string.Format(SEARCH_RESULT_LOCATOR, searchText))).IsPresent();

        public void OpenErrorPage(string searchText) => new MyWebElement(By.XPath(string.Format(SEARCH_RESULT_LOCATOR, searchText))).Click();

        public bool IsSeachFieldFocused(string expectedAttributeText)
        {
            string focusedElementText = Driver.driver.SwitchTo().ActiveElement().GetAttribute("placeholder");
            return focusedElementText == expectedAttributeText;
        }
    }
}

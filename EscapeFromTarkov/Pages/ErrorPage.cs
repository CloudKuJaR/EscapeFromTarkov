using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class ErrorPage
    {
        private const string ERROR_PAGE_NAME_TITLE_LOCATOR = "//h1[@itemprop='name headline']";

        private MyWebElement ErrorPageNameTitle => new MyWebElement(By.XPath(ERROR_PAGE_NAME_TITLE_LOCATOR));

        public bool IsNameOfErrorPageCorrect(string errorName) => ErrorPageNameTitle.Text == errorName;
    }
}

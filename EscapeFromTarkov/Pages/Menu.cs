using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class Menu
    {
        private const string MERCH_BUTTON_LOCATOR = "//a[@href='https://tarkovmerchstore.com/']";

        private MyWebElement MerchButton => new MyWebElement(By.XPath(MERCH_BUTTON_LOCATOR));

        public void OpenMerchPage() => MerchButton.Click();
    }
}

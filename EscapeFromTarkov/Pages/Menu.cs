using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class Menu
    {
        private const string MERCH_BUTTON_LOCATOR = "//a[@href='https://tarkovmerchstore.com/']";
        private const string WIKI_BUTTON_LOOCATOR = "//a[@href='https://escapefromtarkov-ru.gamepedia.com/Escape_from_Tarkov_Wiki']";
        private const string SUPPORT_BUTTON_LOCATOR = "//a[@href='/support']";
        private const string RAITING_BUTTON_LOCATOR = "//a[@href='/rating']";

        private MyWebElement MerchButton => new MyWebElement(By.XPath(MERCH_BUTTON_LOCATOR));
        private MyWebElement WikiButton => new MyWebElement(By.XPath(WIKI_BUTTON_LOOCATOR));
        private MyWebElement SupportButton => new MyWebElement(By.XPath(SUPPORT_BUTTON_LOCATOR));
        private MyWebElement RaitingButton => new MyWebElement(By.XPath(RAITING_BUTTON_LOCATOR));

        public void OpenMerchPage() => MerchButton.Click();

        public void OpenWikiPage() => WikiButton.Click();

        public void OpenSupportPage() => SupportButton.Click();

        public void OpenRaitingPage() => RaitingButton.Click();
    }
}

using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class PreOrderPage
    {
        private const string PRE_ORDER_BUTTON_LOCATOR = "//div[@data-selected='{0}']";
        private const string NEED_OF_REGISTRATION_WINDOW_LOCATOR = "//div[@class='table-cell'][not(contains(@id,'preorder-page'))]";

        private MyWebElement NeedOfRegistrationWindow => new MyWebElement(By.XPath(NEED_OF_REGISTRATION_WINDOW_LOCATOR));

        public void ChoosePreOrderEdition(string preOrderEdition) => new MyWebElement(By.XPath(string.Format(PRE_ORDER_BUTTON_LOCATOR, preOrderEdition))).Click();

        public bool IsNeedOfRegistrationWindowPresent() => NeedOfRegistrationWindow.IsPresent();
    }
}

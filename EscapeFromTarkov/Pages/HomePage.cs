using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class HomePage
    {
        private const string PRE_ORDER_IMAGE_LOCATOR = "//img[@class='preorder_button']";

        private MyWebElement PreOrderImage => new MyWebElement(By.XPath(PRE_ORDER_IMAGE_LOCATOR));

        public void OpenPreOrderPage() => PreOrderImage.Click();
    }
}

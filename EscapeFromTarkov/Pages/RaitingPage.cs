using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class RaitingPage
    {        
        private const string SORT_BY_DROP_DOWN_MENU_LOCATOR = "//div[@class='category switcher inlinetop']";
        private const string SORT_OPTIONS_COTINER_LOCATOR = "//div[@class='category switcher inlinetop']//ul[@class='selector']";
        private const string OPTION_LOCATOR = "//li[text()='{0}']";

        private MyWebElement SortByDropDownMenu => new MyWebElement(By.XPath(SORT_BY_DROP_DOWN_MENU_LOCATOR));
        private MyWebElement SortOptionsContainer => new MyWebElement(By.XPath(SORT_OPTIONS_COTINER_LOCATOR));

        public void OpenSortByDropDownMenu() => SortByDropDownMenu.Click();

        public bool IsSortOptionContainerPresent() => SortOptionsContainer.IsPresent();

        public void ChooseOptionInDropDownMenu(string optionName) => new MyWebElement(By.XPath(string.Format(OPTION_LOCATOR, optionName))).Click();

        public bool IsOptionPresent(string optionName) => new MyWebElement(By.XPath(string.Format(OPTION_LOCATOR, optionName))).IsPresent();
    }
}

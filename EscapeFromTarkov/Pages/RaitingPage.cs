using EscapeFromTarkov.WebDriverExtension;
using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class RaitingPage
    {        
        private const string SORT_BY_DROP_DOWN_MENU_LOCATOR = "//div[@class='category switcher inlinetop']";
        private const string OPTION_LOCATOR = "//li[text()='{0}']";
        private const string RAITING_TABLE_LOCATOR = "//tbody";
        private const string RAITING_NUMBER_LOCATOR = "//td[@class='col-1']";
        private const string LAST_ELEMENT_IN_TABLE_LOCATOR = "(//td[@class='col-5'])[100]";

        private MyWebElement SortByDropDownMenu => new MyWebElement(By.XPath(SORT_BY_DROP_DOWN_MENU_LOCATOR));
        private MyWebElement RatingTable => new MyWebElement(By.XPath(RAITING_TABLE_LOCATOR));
        private MyWebElement LastElementInTable => new MyWebElement(By.XPath(LAST_ELEMENT_IN_TABLE_LOCATOR));

        public void OpenSortByDropDownMenu() => SortByDropDownMenu.Click();

        public void ChooseOptionInDropDownMenu(string optionName) => new MyWebElement(By.XPath(string.Format(OPTION_LOCATOR, optionName))).Click();

        public bool IsOptionPresent(string optionName) => new MyWebElement(By.XPath(string.Format(OPTION_LOCATOR, optionName))).IsPresent();

        public bool IsRaitingContainsRecords()
        {
            bool isContains = true;
            var ListOfRecords = Driver.driver.FindElements(By.XPath(RAITING_NUMBER_LOCATOR));
            if (ListOfRecords.Count < 100 )
            {
                isContains = false;
            }

            return isContains;
        }

        public bool IsAllPlayersHasValidLevel()
        {
            bool isAllLevelsAreValid = true;
            Driver.driver.GetWait().Until(drv => !LastElementInTable.Text.Contains("%"));
            var ListOfLevels = RatingTable.FindElements(By.XPath(".//td[@class='col-5']"));
            foreach (var item in ListOfLevels)
            {
                int level = int.Parse(item.Text);
                if (level < 1 | level > 58)
                {
                    isAllLevelsAreValid = false;
                    break;
                }
            }

            return isAllLevelsAreValid;
        }
    }
}

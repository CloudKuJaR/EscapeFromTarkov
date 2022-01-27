using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class WikiPage
    {
        private const string WEAPONS_AND_MODS_DROP_DOWN_LOCATOR = "//div[@class='resizable-container']//*[contains(text(),'Оружие и моды')]";
        private const string WEAPON_AND_MODS_DROP_DOWN_CONTAINER = "//div[@class='resizable-container']//*[contains(text(),'Оружие и моды')]//parent::a//parent::div//parent::li//ul[@class='wds-list wds-is-linked']";
        private const string DROP_DOWN_MENU_OPTION = "//div[@class='resizable-container']//span[text()='{0}']";

        private MyWebElement WeaponsAndModsDropDown => new MyWebElement(By.XPath(WEAPONS_AND_MODS_DROP_DOWN_LOCATOR));
        private MyWebElement WeapoAndModsDropDownMenuContainer => new MyWebElement(By.XPath(WEAPON_AND_MODS_DROP_DOWN_CONTAINER));

        public void HoverOverWeaponsAndModsDropDown() => WeaponsAndModsDropDown.Click();

        public bool IsWeaponAndModsDropDownMenuDesplayed() => WeapoAndModsDropDownMenuContainer.Displayed;

        public void ChooseDropDownOption(string optionText) => new MyWebElement(By.XPath(string.Format(DROP_DOWN_MENU_OPTION, optionText))).Click();
    }
}

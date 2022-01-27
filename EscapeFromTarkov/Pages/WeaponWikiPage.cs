using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class WeaponWikiPage
    {
        private const string WEAPON_LOCATOR = "//a[@title='{0}'][text()='{0}']";
        private const string WEAPON_AMMO_TYPE_LOCATOR = "//a[@title='{0}'][text()='АК-74М']/parent::td//parent::tr//td[2]//a";

        public void ChooseAndFindWeapon(string weaponName) => new MyWebElement(By.XPath(string.Format(WEAPON_LOCATOR, weaponName))).HoverOver();

        public bool IsWeaponAmmoTypeCorrect(string weaponName, string expectedWeaponAmmoType) => new MyWebElement(By.XPath(string.Format(WEAPON_AMMO_TYPE_LOCATOR, weaponName))).Text == expectedWeaponAmmoType;
    }
}

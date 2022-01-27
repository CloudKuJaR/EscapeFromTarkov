using AventStack.ExtentReports;
using EscapeFromTarkov.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace EscapeFromTarkov.TestSuites
{
    public class EscapeFromTarkovTests
    {
        private static IWebDriver WebDriver => Driver.driver;
        private string preOrderStandartEdition = "standard";
        private string booksPageUrl = "https://tarkovmerchstore.com/Books";
        private string wikiPageUrl = "https://escapefromtarkov.fandom.com/ru/wiki/Escape_from_Tarkov_Wiki";
        private string weaponWikiUrl = "https://escapefromtarkov.fandom.com/ru/wiki/%D0%9E%D1%80%D1%83%D0%B6%D0%B8%D0%B5";
        private string bookName = "Хозяин Ночи";
        private string bookLanguageVersion = "Русская версия";
        private string expectedBookPrice = "260₽";
        private string weaponOption = "Оружие";
        private string weaponName = "АК-74М";
        private string expectedWeaponAmmoType = "5.45x39 мм";
        private string expectedAttributeText = "Введите вопрос...";
        private string videoFrameId = "VideoPlayer_39";
        private string optionName = "время в игре";

        [OneTimeSetUp]
        public void InitizeComponent()
        {
            Initialize.InitializeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            Initialize.GoToBaseUrl();
            string reportPath = Initialize.InitializePath();
            var testName = TestContext.CurrentContext.Test.Name;
            Initialize.InitializeReporter(reportPath, testName);
            Reporter.test = Reporter.extent.CreateTest(testName).Info("Test Started");
        }

        [Test]
        public void CheckRegistrationWindowAfterPreOrder()
        {
            Page.HomePage.OpenPreOrderPage();
            Page.PreOrderPage.ChoosePreOrderEdition(preOrderStandartEdition);
            Assert.IsTrue(Page.PreOrderPage.IsNeedOfRegistrationWindowPresent());
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void CheckBookPrice()
        {
            Page.Menu.OpenMerchPage();
            SwitchToNewTab();
            Page.MerchPage.OpenBooksPage();
            Assert.IsTrue(IsPageOpened(booksPageUrl));
            Page.MerchBooksPage.FindTheBook(bookName, bookLanguageVersion);
            Assert.IsTrue(Page.MerchBooksPage.IsBookPresent(bookName, bookLanguageVersion));
            Assert.AreEqual(expectedBookPrice, Page.MerchBooksPage.GetBookPrice(bookName, bookLanguageVersion));
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void CheckWeaponAmmoType()
        {
            Page.Menu.OpenWikiPage();
            SwitchToNewTab();
            Assert.IsTrue(IsPageOpened(wikiPageUrl));
            Page.WikiPage.HoverOverWeaponsAndModsDropDown();
            Assert.IsTrue(Page.WikiPage.IsWeaponAndModsDropDownMenuDesplayed());
            Page.WikiPage.ChooseDropDownOption(weaponOption);
            Assert.IsTrue(IsPageOpened(weaponWikiUrl));
            Page.WeaponWikiPage.ChooseAndFindWeapon(weaponName);
            Assert.IsTrue(Page.WeaponWikiPage.IsWeaponAmmoTypeCorrect(weaponName, expectedWeaponAmmoType));
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void CheckError208PageIsValid()
        {
            Page.Menu.OpenSupportPage();
            Page.SupportPage.ClickSearchField();
            Assert.IsTrue(Page.SupportPage.IsSeachFieldFocused(expectedAttributeText));
            Page.SupportPage.FillSearchField(TestSettings.SearchText);
            Assert.IsTrue(Page.SupportPage.IsSearchResultPresent(TestSettings.SearchText));
            Page.SupportPage.OpenErrorPage(TestSettings.SearchText);
            Assert.IsTrue(Page.ErrorPage.IsNameOfErrorPageCorrect(TestSettings.SearchText));
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void CheckVideoIsPlaying()
        {
            Page.HomePage.ClickOnVideo();
            Page.HomePage.SwitchToVideoFrame(videoFrameId);
            Page.HomePage.PlayVideo();
            Assert.IsTrue(Page.HomePage.IsVideoPlaying());
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void CheckSortInRecrods()
        {
            Page.Menu.OpenRaitingPage();
            Page.RaitingPage.OpenSortByDropDownMenu();
            Assert.IsTrue(Page.RaitingPage.IsOptionPresent(optionName));
            Page.RaitingPage.ChooseOptionInDropDownMenu(optionName);
            Assert.IsTrue(Page.RaitingPage.IsRaitingContainsRecords());
            Assert.IsTrue(Page.RaitingPage.IsAllPlayersHasValidLevel());
            Reporter.test.Log(Status.Pass, "Test Passed");
        }

        [TearDown]
        public void CleanUpAfterTest()
        {
            Reporter.extent.Flush();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }

        private void SwitchToNewTab()
        {
            List<string> listOfTabs = WebDriver.WindowHandles.ToList();
            WebDriver.Close();
            WebDriver.SwitchTo().Window(listOfTabs[1]);
        }

        private bool IsPageOpened(string expectedUrl) => expectedUrl == WebDriver.Url;
    }
}

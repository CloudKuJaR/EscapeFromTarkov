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
        private string bookName = "Хозяин Ночи";
        private string bookLanguageVersion = "Русская версия";
        private string expectedBookPrice = "260₽";

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
            List<string> listOfTabs = WebDriver.WindowHandles.ToList();
            WebDriver.SwitchTo().Window(listOfTabs[1]);
            Page.MerchPage.OpenBooksPage();
            Assert.AreEqual(booksPageUrl, Page.BooksPage.GetCurrentUrl());
            Page.BooksPage.FindTheBook(bookName, bookLanguageVersion);
            Assert.IsTrue(Page.BooksPage.IsBookPresent(bookName, bookLanguageVersion));
            Assert.AreEqual(expectedBookPrice, Page.BooksPage.GetBookPrice(bookName, bookLanguageVersion));
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
    }
}

using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class MerchBooksPage
    {
        private string BOOKS_LOCATOR = "//span[contains(text(),'{0}')][contains(text(),'{1}')]";
        private string BOOK_PRICE_LOCATOR = "//span[contains(text(),'{0}')][contains(text(),'{1}')]//parent::div//parent::div//*[@class='price']";

        public void FindTheBook(string bookName, string bookLanguageVersion) => new MyWebElement(By.XPath(string.Format(BOOKS_LOCATOR, bookName, bookLanguageVersion))).HoverOver();

        public bool IsBookPresent(string bookName, string bookLanguageVersion) => new MyWebElement(By.XPath(string.Format(BOOKS_LOCATOR, bookName, bookLanguageVersion))).IsPresent();

        public string GetBookPrice(string bookName, string bookLanguageVersion) => new MyWebElement(By.XPath(string.Format(BOOK_PRICE_LOCATOR, bookName, bookLanguageVersion))).Text;
    }
}

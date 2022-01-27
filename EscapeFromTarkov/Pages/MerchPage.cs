using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class MerchPage
    {
        private const string BOOKS_BUTTON_LOCATOR = "//a[contains(text(),'Книги')]";

        private MyWebElement BooksButton => new MyWebElement(By.XPath(BOOKS_BUTTON_LOCATOR));

        public void OpenBooksPage() => BooksButton.Click();
    }
}

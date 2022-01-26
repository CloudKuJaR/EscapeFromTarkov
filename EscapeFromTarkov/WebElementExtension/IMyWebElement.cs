using OpenQA.Selenium;

namespace EscapeFromTarkov.WebElementExtension
{
    interface IMyWebElement : IWebElement, ILocatable, IWrapsElement
    {
        By Selector { get; }
    }
}

using SeleniumExtras.PageObjects;

namespace EscapeFromTarkov.Pages
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Driver.driver, page);
            return page;
        }

        public static HomePage HomePage => GetPage<HomePage>();

        public static PreOrderPage PreOrderPage => GetPage<PreOrderPage>();

        public static Menu Menu => GetPage<Menu>();

        public static MerchPage MerchPage => GetPage<MerchPage>();

        public static MerchBooksPage MerchBooksPage => GetPage<MerchBooksPage>();

        public static WikiPage WikiPage => GetPage<WikiPage>();

        public static WeaponWikiPage WeaponWikiPage => GetPage<WeaponWikiPage>();

        public static SupportPage SupportPage => GetPage<SupportPage>();

        public static ErrorPage ErrorPage => GetPage<ErrorPage>();

        public static RaitingPage RaitingPage => GetPage<RaitingPage>();
    }
}

using EscapeFromTarkov.WebElementExtension;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class HomePage
    {
        private const string PRE_ORDER_IMAGE_LOCATOR = "//img[@class='preorder_button']";
        private const string VIDEO_LOCATOR = "//section[@class='video_cont banner_cont']";
        private const string PLAY_VIDEO_BUTTON_LOCATOR = "//button[@class='ytp-large-play-button ytp-button']";
        private const string VIDEO_CONTAINER_LOCATOR = "//div[contains(@class,'playing-mode')]";

        private MyWebElement PreOrderImage => new MyWebElement(By.XPath(PRE_ORDER_IMAGE_LOCATOR));
        private MyWebElement Video => new MyWebElement(By.XPath(VIDEO_LOCATOR));
        private MyWebElement PlayVideoButton => new MyWebElement(By.XPath(PLAY_VIDEO_BUTTON_LOCATOR));
        private MyWebElement VideoContainer => new MyWebElement(By.XPath(VIDEO_CONTAINER_LOCATOR));

        public void ClickOnVideo() => Video.Click();

        public void PlayVideo() => PlayVideoButton.Click();

        public void OpenPreOrderPage() => PreOrderImage.Click();

        public void SwitchToVideoFrame(string videoFrameId) => Driver.driver.SwitchTo().Frame(videoFrameId);

        public bool IsVideoPlaying() => VideoContainer.IsPresent();
    }
}

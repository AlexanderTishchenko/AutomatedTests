using AutomatedTests.Core;
using AutomatedTests.Elements.SimpleElements;
using AutomatedTests.Models.Attributes;
using AutomatedTests.Utilities;
using OpenQA.Selenium;

namespace AutomatedTests.Pages
{
    [PageUri("https://contentsquare.com/")]
    internal class MainPage : BasePage
    {
        public MainPage(BrowserDriver browser, Uri uri) : base(browser, uri)
        {
        }

        public RequestADemoPage OpenRequestADemoPage()
        {
            return PageOpening.Open<RequestADemoPage>(Browser, GetADemoButton);
        }

        private ButtonElement GetADemoButton
        {
            get
            {
                return new ButtonElement(Browser.FindElement(By.ClassName("hero-button")), this);
            }
        }
    }
}

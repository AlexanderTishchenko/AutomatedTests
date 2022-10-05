using AutomatedTests.Core;
using AutomatedTests.Elements.SimpleElements;
using AutomatedTests.Models.Attributes;
using OpenQA.Selenium;

namespace AutomatedTests.Pages
{
    [PageUri("https://contentsquare.com/request-a-demo/")]
    internal class RequestADemoPage : BasePage
    {
        public RequestADemoPage(BrowserDriver browser, Uri uri) : base(browser, uri)
        {
        }

        public string GetHeaderText()
        {
            return Header.GetText();
        }

        private ReadOnlyElement Header
        {
            get
            {
                return new ReadOnlyElement(Browser.FindElement(By.CssSelector("h1.text-block__headline strong")), this);
            }
        }
    }
}

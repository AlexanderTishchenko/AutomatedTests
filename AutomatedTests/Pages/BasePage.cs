using AutomatedTests.Core;
using OpenQA.Selenium;
using AutomatedTests.Models.Interfaces;

namespace AutomatedTests.Pages
{
    internal abstract class BasePage : IElementContainer, IPage
    {
        public BrowserDriver Browser;
        protected Uri Uri;

        public BasePage(BrowserDriver browser, Uri uri)
        {
            Browser = browser;
            Uri = uri;
        }


        public BasePage GetPage()
        {
            return this;
        }

        public ISearchContext GetSearchContext()
        {
            return Browser.GetWebDriver();
        }

        public Uri GetUri()
        {
            return Uri;
        }
    }
}

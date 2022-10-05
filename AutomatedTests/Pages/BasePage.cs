using AutomatedTests.Core;
using AutomatedTests.Utilities;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
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

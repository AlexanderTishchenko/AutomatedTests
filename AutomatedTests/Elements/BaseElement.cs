using AutomatedTests.Core;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using AutomatedTests.Pages;
using AutomatedTests.Models.Interfaces;

namespace AutomatedTests.Elements
{
    internal abstract class BaseElement
    {
        private IElementContainer _elementContainer;
        private IWebElement _wrappedElement;
        public BrowserDriver Browser;

        public BaseElement(IWebElement wrappedElement, IElementContainer elementContainer)
        {
            _wrappedElement = wrappedElement;
            _elementContainer = elementContainer;
            Browser = GetPage().Browser;
        }

        public string GetClassListAsString()
        {
            return GetWrappedElement().GetAttribute("class");
        }

        public IWebElement GetWrappedElement()
        {
            return _wrappedElement;
        }

        public BasePage GetPage()
        {
            return _elementContainer.GetPage();
        }

        public string GetText()
        {
            return GetWrappedElement().Text;
        }

        public void Click()
        {
            GetWrappedElement().Click();
        }

        public void Hover()
        {
            Actions action = new Actions(Browser.GetWebDriver());
            action.MoveToElement(GetWrappedElement()).Build().Perform();
        }
    }
}

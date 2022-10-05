using AutomatedTests.Core;
using AutomatedTests.Elements;
using AutomatedTests.Models.Interfaces;
using AutomatedTests.Pages;
using OpenQA.Selenium;
using System.Reflection;

namespace AutomatedTests.Utilities
{
    internal class PageOpening
    {
        public static T Open<T>(BrowserDriver driver) where T : IPage
        {
            return Open<T>(driver, UriBuilder.GetUri<T>());
        }

        public static T Open<T>(BrowserDriver driver, string uri) where T : IPage
        {
            Action action = () => driver.Open(uri);
            return (T)Open<T>(driver, action, false);
        }

        public static T Open<T>(BrowserDriver driver, BaseElement element, bool inOtherTab = false) where T : IPage
        {
            return (T)Open<T>(driver, () => element.Click(), inOtherTab);
        }

        public static IPage Open<T>(BrowserDriver driver, Action actionToOpen, bool inOtherTab = false) where T : IPage
        {
            actionToOpen.Invoke();
            try
            {
                return CreatePage<T>(driver, inOtherTab);
            }
            catch (NoSuchElementException e)
            {
                string textError = "Problem with creation of page ";// + pageClass.getTypeName();
                throw new NoSuchElementException(textError, e);
            }
        }

        private static IPage CreatePage<T>(BrowserDriver driver, bool inNewTab)
        {
            try
            {
            if (inNewTab)
            {
                driver.SwitchToNewWindow();
            }
            Wait.WaitForPageLoad(driver);
            Uri pageUrl = driver.GetUri();
            Type type = typeof(T);
            return (IPage)Activator.CreateInstance(typeof(T), new object[] { driver, pageUrl });
            } catch (ArgumentNullException e) {
                        throw new Exception("Problem with creation of page" + typeof(T), e);
            }
        }
    }
}

using AutomatedTests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace AutomatedTests.Core
{
    internal class BrowserDriver
    {
        private static IWebDriver _webDriver;
        private ConfigReader _config;
        public BrowserDriver()
        {
            _config = new ConfigReader();
        }

        public IWebDriver GetWebDriver()
        {
            if (IsBrowserOpened())
            {
                return _webDriver;
            }
            else
            {
                forceBrowserDriver();
                return _webDriver;
            }
        }

        public void Open(string uri)
        {
            GetWebDriver().Navigate().GoToUrl(uri);
        }

        public ConfigReader GetConfig()
        {
            return _config;
        }

        private static Boolean IsBrowserOpened()
        {
            return _webDriver != null;
        }

        private static void forceBrowserDriver()
        {
            if (IsBrowserOpened())
            {
                Quit();
            }

            ChromeOptions options = new ChromeOptions();
            //options.SetExperimentalOption("prefs", chromePrefs);
            _webDriver = new ChromeDriver(options);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public Uri GetUri()
        {
            return new Uri(GetWebDriver().Url);
        }

        public static void Quit()
        {
            if (IsBrowserOpened())
            {
                _webDriver.Quit();
            }
        }

        public object ExecuteScript(string script)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(script);
        }

        public object ExecuteScript(string script, object[] parameters)
        {
            return ((IJavaScriptExecutor)_webDriver).ExecuteScript(script, parameters);
        }

        public void DeleteAllCookies()
        {
            GetWebDriver().Manage().Cookies.DeleteAllCookies();
        }

        public IWebElement FindElement(By by)
        {
            return GetWebDriver().FindElement(by);
        }

        public void SwitchToNewWindow()
        {
            string parentWindow = GetWebDriver().CurrentWindowHandle;
            var windowHandles = GetWebDriver().WindowHandles;
            foreach (string windowHandle in windowHandles)
            {
                if (!windowHandle.Equals(parentWindow))
                {
                    GetWebDriver().SwitchTo().Window(windowHandle);
                }
            }
        }
    }
}

using AutomatedTests.Core;
using OpenQA.Selenium;

namespace AutomatedTests.Utilities
{
    internal class Wait
    {
        public static void WaitForPageLoad(BrowserDriver driver)
        {
            int timeout = 1000;
            Thread.Sleep(timeout);
        }

        private static bool IsQueriesInProgress(BrowserDriver driver)
        {
            bool isJQueryDefined;
            try
            {
                isJQueryDefined = (bool)driver.ExecuteScript("return window.$ != undefined");
            }
            catch (WebDriverException)
            {
                return false;
            }

            if (isJQueryDefined)
            {
                try
                {
                    return (bool)driver.ExecuteScript("return $.active != 0");
                }
                catch (WebDriverException) {
                    return false;
                }
                }
                return false;
            }
        }
    }

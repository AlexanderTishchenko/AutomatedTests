using AutomatedTests.Core;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutomatedTests.Pages;

namespace AutomatedTests.Utilities
{
    internal class Wait
    {
        public static void waitForPageLoad(BrowserDriver driver)
        {
            int timeout = 1000;
            Thread.Sleep(timeout);
        }



        private static bool isQueriesInProgress(BrowserDriver driver)
        {
            Boolean isJQueryDefined;
            try
            {
                isJQueryDefined = (Boolean)driver.ExecuteScript("return window.$ != undefined");
            }
            catch (WebDriverException e)
            {
                return false;
            }

            if (isJQueryDefined)
            {
                try
                {
                    return (bool)driver.ExecuteScript("return $.active != 0");
                }
                catch (WebDriverException e) {
                    return false;
                }
                }
                return false;
            }
        }
    }

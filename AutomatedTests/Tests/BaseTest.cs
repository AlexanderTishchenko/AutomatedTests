using AutomatedTests.Core;
using AutomatedTests.Logger;
using NUnit.Framework.Interfaces;

namespace AutomatedTests.Tests
{
    internal class BaseTest
    {
        private BrowserDriver _driver;

        BrowserDriver GetBrowser()
        {
            if (_driver != null)
            {
                return _driver;
            }
            else
            {
                _driver = new BrowserDriver();
                return _driver;
            }
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            CustomLog.Info("Test start time: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        [TearDown]
        public void TearDown(ITestResult result)
        {
            if (result.ResultState.Status == ResultState.Failure.Status)
            {
                LogErrorAndTakeScreenshot("Test fails with reason: " + TestContext.CurrentContext.Result, result);
            }
        }

        private void LogErrorAndTakeScreenshot(String message, ITestResult result)
        {
            CustomLog.ErrorWithScreenshot(message, _driver, result.Test.MethodName);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            CustomLog.Info("Test end time: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomLog.Debug("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            BrowserDriver.Quit();
        }
    }
}

using AutomatedTests.Core;
using AutomatedTests.Logger;
using NUnit.Framework.Interfaces;

namespace AutomatedTests.Tests
{
    internal class BaseTest
    {
        private BrowserDriver _driver;

        protected BrowserDriver GetBrowser()
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
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                LogErrorAndTakeScreenshot("Test fails with reason: " + TestContext.CurrentContext.Result, TestContext.CurrentContext);
            }
        }

        private void LogErrorAndTakeScreenshot(String message, TestContext result)
        {
            CustomLog.ErrorWithScreenshot(message, _driver, result.Test.MethodName);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            CustomLog.Info("Test end time: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomLog.Debug("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            BrowserDriver.Quit();
        }
    }
}

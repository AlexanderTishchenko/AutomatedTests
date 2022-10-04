using AutomatedTests.Core;
using log4net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OpenQA.Selenium;

namespace AutomatedTests.Logger
{
    internal class CustomLog
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void step(int step, String text)
        {
            log.Info($"Step {step}: {text}");
        }

        public static void Info(String text)
        {
            log.Info(text);
        }

        public static void error(String text)
        {
            log.Error(text);
        }

        public static void Debug(String text)
        {
            log.Debug(text);
        }

        public static void ErrorWithScreenshot(String text, BrowserDriver driver, String screenshotName)
        {
            var path = CaptureScreenshot(screenshotName, driver);
            int index = text.IndexOf("(Session info");
            if (index == -1)
            {
                index = text.IndexOf("Build info");
                if (index == -1)
                {
                    index = text.Length;
                }
            }
            error(text.Substring(0, index));
            if (path != null)
            {
                Info("Screenshot: " + path);
            }
        }

        public static void error(String text, Exception e)
        {
            log.Error(text, e);
        }

        private static string CaptureScreenshot(String name, BrowserDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver.GetWebDriver()).GetScreenshot();
            var folderPath = Path.Combine("target", "screenshots", DateTime.Now.ToString("dd.MM.yyyy"));
            var screenshotName = $"{name} {DateTime.Now.ToString("HH-mm-ss")}.png";
            var fullPath = Path.Combine(folderPath, screenshotName);

            screenshot.SaveAsFile(fullPath);
            return fullPath;

        }
    }
}

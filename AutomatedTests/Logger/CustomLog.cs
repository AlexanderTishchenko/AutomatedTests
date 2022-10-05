using AutomatedTests.Core;
using log4net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OpenQA.Selenium;
using System.IO;

namespace AutomatedTests.Logger
{
    internal class CustomLog
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        public static void Step(int step, string text)
        {
            _log.Info($"Step {step}: {text}");
        }

        public static void Info(string text)
        {
            _log.Info(text);
        }

        public static void Error(string text)
        {
            _log.Error(text);
        }

        public static void Debug(string text)
        {
            _log.Debug(text);
        }

        public static void ErrorWithScreenshot(string text, BrowserDriver driver, String screenshotName)
        {
            var path = CaptureScreenshot(screenshotName, driver);
            Error(text);
            if (path != null)
            {
                Info("Screenshot: " + path);
            }
        }

        public static void Error(string text, Exception e)
        {
            _log.Error(text, e);
        }

        private static string CaptureScreenshot(string name, BrowserDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver.GetWebDriver()).GetScreenshot();
            var folderPath = Path.Combine("target", "screenshots", DateTime.Now.ToString("dd.MM.yyyy"));
            var screenshotName = $"{name} {DateTime.Now.ToString("HH-mm-ss")}.png";
            var fullPath = Path.Combine(folderPath, screenshotName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            screenshot.SaveAsFile(fullPath);
            return fullPath;

        }
    }
}

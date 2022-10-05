using AutomatedTests.Logger;
using AutomatedTests.Pages;
using AutomatedTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Tests
{
    internal class FirstTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            string expectedHeader = "Better Experiences Start Here";

            CustomLog.Step(1, "Open main page");
            MainPage homePage = PageOpening.Open<MainPage>(GetBrowser());

            CustomLog.Step(2, "Open Request A Demo page");
            var requestADemoPage = homePage.OpenRequestADemoPage();

            CustomLog.Step(3, "Check a header text");
            Assert.That(requestADemoPage.GetHeaderText, Is.EqualTo(expectedHeader), "Header is not equal to expected");
        }
    }
}

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

            MainPage homePage = PageOpening.Open<MainPage>(GetBrowser());
            var requestADemoPage = homePage.OpenRequestADemoPage();
            Assert.That(requestADemoPage.GetHeaderText, Is.EqualTo(expectedHeader), "Header is not equal to expected");
        }
    }
}

using AutomatedTests.Core;
using AutomatedTests.Elements.SimpleElements;
using AutomatedTests.Models.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    [PageUri("https://jsonplaceholder.typicode.com/comments")]
    internal class CommentsPage : BasePage
    {
        public CommentsPage(BrowserDriver browser, Uri uri) : base(browser, uri)
        {
        }

        public string GetContentText()
        {
            return Content.GetText();
        }

        private ReadOnlyElement Content
        {
            get
            {
                return new ReadOnlyElement(Browser.FindElement(By.CssSelector("body pre")), this);
            }
        }
    }
}

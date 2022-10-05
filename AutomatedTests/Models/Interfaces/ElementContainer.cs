using AutomatedTests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Models.Interfaces
{
    internal interface IElementContainer
    {
        BasePage GetPage();

        ISearchContext GetSearchContext();
    }
}

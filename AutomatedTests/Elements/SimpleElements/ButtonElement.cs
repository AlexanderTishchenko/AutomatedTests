using AutomatedTests.Models.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Elements.SimpleElements
{
    internal class ButtonElement : BaseElement
    {
        public ButtonElement(IWebElement wrappedElement, IElementContainer elementContainer) : base(wrappedElement, elementContainer)
        {
        }
    }
}

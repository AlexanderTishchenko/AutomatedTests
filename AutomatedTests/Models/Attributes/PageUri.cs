using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Models.Attributes
{
    internal class PageUri : Attribute
    {
        public PageUri(string uri)
        {
            Uri = uri;
        }

        public string Uri { get; set; }
    }
}

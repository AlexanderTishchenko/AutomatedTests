using AutomatedTests.Core;
using AutomatedTests.Models.Attributes;
using AutomatedTests.Models.Interfaces;

namespace AutomatedTests.Utilities
{
    internal class UriBuilder
    {
        public static string GetUri<T>() where T : IPage
        {
            if (typeof(T).GetCustomAttributes(typeof(PageUri), true).FirstOrDefault() is PageUri uri)
            {
                return uri.Uri;
            }
            return null;
        }

        static bool IsUriMatches<T>(BrowserDriver driver, Uri currentUri) where T : IPage
        {
            return currentUri.ToString().Contains(GetUri<T>());
        }
    }
}

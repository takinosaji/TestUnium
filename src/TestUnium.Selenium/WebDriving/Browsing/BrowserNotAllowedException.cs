using System;

namespace TestUnium.Selenium.WebDriving.Browsing
{
    [Serializable]
    class BrowserNotAllowedException : ApplicationException
    {
        public BrowserNotAllowedException(Browser browser) : base($"Browser {browser} is not allowed for current test case!")
        {

        }

        public BrowserNotAllowedException(Browser browser, Exception innerException) : base($"Browser {browser} is not allowed for current testcase!", innerException)
        {

        }
    }
}

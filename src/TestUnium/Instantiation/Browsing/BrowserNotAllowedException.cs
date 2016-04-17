using System;

namespace TestUnium.Instantiation.Browsing
{
    [Serializable]
    class BrowserNotAllowedException : ApplicationException
    {
        public BrowserNotAllowedException(Browser browser) : base($"Browser {browser} is npt allowed for current test case!")
        {

        }

        public BrowserNotAllowedException(Browser browser, Exception innerException) : base($"Browser {browser} is npt allowed for current testcase!", innerException)
        {

        }
    }
}

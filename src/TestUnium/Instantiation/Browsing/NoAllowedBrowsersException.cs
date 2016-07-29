using System;

namespace TestUnium.Instantiation.Browsing
{
    [Serializable]
    class NoAllowedBrowsersException : ApplicationException
    {
        public NoAllowedBrowsersException() : base("All browsers are forbidden to run current test case!")
        {
        }

        public NoAllowedBrowsersException(Exception innerException) : base("All browsers are forbidden to run current test case!", innerException)
        {
        }
    }
}

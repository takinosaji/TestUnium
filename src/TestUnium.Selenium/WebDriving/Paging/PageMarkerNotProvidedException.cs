using System;

namespace TestUnium.Selenium.WebDriving.Paging
{
    public class PageMarkerNotProvidedException : ApplicationException
    {
        public PageMarkerNotProvidedException(String pageName) 
            : base($"Any marker was not provided for {pageName}.") { }
        public PageMarkerNotProvidedException(String pageName, Exception innerException) 
            : base($"Any marker was not provided for {pageName}.", innerException) { }
    }
}
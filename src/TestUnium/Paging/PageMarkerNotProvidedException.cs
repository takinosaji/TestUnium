using System;

namespace TestUnium.Paging
{
    public class PageMarkerNotProvidedException : ApplicationException
    {
        public PageMarkerNotProvidedException(String pageName) 
            : base($"Marker was not provided for {pageName}.") { }
        public PageMarkerNotProvidedException(String pageName, Exception innerException) 
            : base($"Marker was not provided for {pageName}.", innerException) { }
    }
}
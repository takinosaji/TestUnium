using System;

namespace TestUnium.Selenium.WebDriving.Paging
{
    public class PageObjectNotFoundException : ApplicationException
    {
        public PageObjectNotFoundException(String pageName) 
            : base($"{pageName} was not found.") { }
        public PageObjectNotFoundException(String pageName, Exception innerException) 
            : base($"{pageName} was not found.", innerException) { }
    }
}
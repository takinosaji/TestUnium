using System;

namespace TestUnium.Instantiation.WebDriving
{

    public class WebDriverHasNotBeenProperlyInitializedException : ApplicationException
    {
        public WebDriverHasNotBeenProperlyInitializedException() 
            : base("Driver is required, but wasn't properly initialized within WebDriverAttribute or it's descendant.") { }

        public WebDriverHasNotBeenProperlyInitializedException(Exception innerException) 
            : base("Driver is required, but wasn't properly initialized within WebDriverAttribute or it's descendant.", innerException) { }
    }
}
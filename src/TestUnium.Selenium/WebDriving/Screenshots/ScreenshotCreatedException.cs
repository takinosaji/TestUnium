using System;

namespace TestUnium.Selenium.WebDriving.Screenshots
{
    /// <summary>
    /// Exception class created for enriching error output of test runner with screenshot file path.
    /// </summary>
    public class ScreenshotCreatedException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Path to screenshot file.</param>
        /// <param name="innerException">Real exception which has occured.</param>
        public ScreenshotCreatedException(String filePath, Exception innerException) : base($"{innerException.Message}. Screenshot was created: {filePath}", innerException)
        {
        }
    }
}
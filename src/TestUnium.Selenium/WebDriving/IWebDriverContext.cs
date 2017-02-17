using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUnium.Selenium.WebDriving
{
    public interface IWebDriverContext
    {
        IWebDriver Driver { get; set; }
        IWait<IWebDriver> SmallWait { get; set; }
        IWait<IWebDriver> MediumWait { get; set; }
        IWait<IWebDriver> LongWait { get; set; }
    }
}
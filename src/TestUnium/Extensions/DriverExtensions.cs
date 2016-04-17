using System;
using System.Collections.ObjectModel;
using System.Linq;
using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestUnium.Bootstrapping;
using TestUnium.Paging;

namespace TestUnium.Extensions
{
    public static class DriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindElement(by, new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? driver.FindElement(@by) : wait.Until(drv => drv.FindElement(@by));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindElements(by, new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? driver.FindElements(@by) : wait.Until(drv => drv.FindElements(@by));
        }

        public static IWebElement FindStickyElement(this IWebDriver driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindStickyElement(by, new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static IWebElement FindStickyElement(this IWebDriver driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? new StickyElement(driver, by) : new StickyElement(driver, by, wait);
        }

        public static ReadOnlyCollection<StickyElement> FindStickyElements(this IWebDriver driver, By by, Double timeoutInSeconds)
        {
            return driver.FindStickyElements(by, new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static ReadOnlyCollection<StickyElement> FindStickyElements(this IWebDriver driver, By by, IWait<IWebDriver> wait)
        {
            var elements = wait.Timeout.TotalSeconds <= 0 ? driver.FindElements(@by) : wait.Until(drv => drv.FindElements(@by));
            var stickyCollection = new ReadOnlyCollection<StickyElement>(elements.Select(e => new StickyElement(driver, by, wait, e)).ToList());
            return stickyCollection;
        }

        public static TPageObject GetPageObject<TPageObject>(this IWebDriver driver) where TPageObject : PageObject
        {
            var page = Resolver.Instance.Kernel.Get<TPageObject>();
            PageFactory.InitElements(driver, page);
            return page;
        }
    }
}
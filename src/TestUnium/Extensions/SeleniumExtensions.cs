using System;
using System.Collections.ObjectModel;
using System.Linq;
using Ninject;
using Ninject.Parameters;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestUnium.Global;
using TestUnium.Instantiation.WebDriving;
using TestUnium.Paging;

namespace TestUnium.Extensions
{
    public static class SeleniumExtensions
    {
        public static IWebElement FindElement(this ISearchContext driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindElement(by, new WebDriverWait((IWebDriver)driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static IWebElement FindElement(this ISearchContext driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? driver.FindElement(@by) : wait.Until(drv => drv.FindElement(@by));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this ISearchContext driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindElements(by, new WebDriverWait((IWebDriver)driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this ISearchContext driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? driver.FindElements(@by) : wait.Until(drv => drv.FindElements(@by));
        }

        public static IWebElement FindStickyElement(this ISearchContext driver, By by, IWait<IWebDriver> wait)
        {
            return wait.Timeout.TotalSeconds <= 0 ? new StickyElement((IWebDriver)driver, by) : new StickyElement((IWebDriver)driver, by, wait);
        }

        public static IWebElement FindStickyElement(this ISearchContext driver, By by, Double timeoutInSeconds = 0)
        {
            return driver.FindStickyElement(by, new WebDriverWait((IWebDriver)driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static ReadOnlyCollection<StickyElement> FindStickyElements(this ISearchContext driver, By by, Double timeoutInSeconds)
        {
            return driver.FindStickyElements(by, new WebDriverWait((IWebDriver)driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        }

        public static ReadOnlyCollection<StickyElement> FindStickyElements(this ISearchContext driver, By by, IWait<IWebDriver> wait)
        {
            var elements = wait.Timeout.TotalSeconds <= 0 ? driver.FindElements(@by) : wait.Until(drv => drv.FindElements(@by));
            var stickyCollection = new ReadOnlyCollection<StickyElement>(elements.Select(e => new StickyElement((IWebDriver)driver, by, wait, e)).ToList());
            return stickyCollection;
        }



        //public static IWebElement FindElement<TElement>(this IWebDriver driver, By by, IWait<IWebDriver> wait)
        //    where TElement : IWebElement, new()
        //{
        //    return wait.Timeout.TotalSeconds <= 0 ? new TElement(driver, by) : new StickyElement(driver, by, wait);
        //}
        //public static IWebElement FindElement<TElement>(this IWebDriver driver, By by, Double timeoutInSeconds = 0)
        //    where TElement : IWebElement
        //{
        //    return driver.FindElement<TElement>(by, new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)));
        //}

        //We have to resolve an issue when test will be executed in several threads
        public static TPageObject GetPage<TPageObject>(this IWebDriver driver,
            Action<TPageObject> pageTransformAction = null, Boolean suppressLoading = false, params By[] markerSelectors) 
            where TPageObject : IPageObject
        {
            if (!Resolver.Instance.Kernel.GetBindings(typeof(TPageObject)).Any())
            {
                Resolver.Instance.Kernel.Bind<TPageObject>().ToSelf();
            }
            var page = Resolver.Instance.Kernel.Get<TPageObject>(new ConstructorArgument("markerSelectors", markerSelectors));         
            pageTransformAction?.Invoke(page);
            if(suppressLoading) return page;
            if (!page.CheckMarkerAfterInitialization()) return page;
            page.Load();
            return page;
        }

        public static TPageObject GetPage<TPageObject>(this IWebDriver driver, Boolean suppressLoading)
            where TPageObject : IPageObject =>
                GetPage<TPageObject>(driver, null, suppressLoading);
        public static TPageObject GetPage<TPageObject>(this IWebDriver driver, params By[] markerSelectors)
            where TPageObject : IPageObject =>
                GetPage<TPageObject>(driver, null, false, markerSelectors);
        public static TPageObject GetPage<TPageObject>(this IWebDriver driver, Boolean suppressLoading, params By[] markerSelectors)
            where TPageObject : IPageObject =>
                GetPage<TPageObject>(driver, null, suppressLoading, markerSelectors);
        public static TPageObject GetPage<TPageObject>(this IWebDriver driver, Action<TPageObject> pageTransformAction, params By[] markerSelectors)
            where TPageObject : IPageObject =>
                GetPage(driver, pageTransformAction, false, markerSelectors);

        public static Screenshot GetScreenshot(this IWebDriver driver)
        {
            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        public static void SetCookie(this IWebDriver driver, String name, String value)
        {
            driver.Manage().Cookies.AddCookie(new Cookie(name, value));
        }
    }
}
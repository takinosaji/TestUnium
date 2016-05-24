using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestUnium.Extensions;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Paging
{
    public class PageObject : WebDriverContainer, IPageObject
    {
        public String Name { get; set; }
        protected IWebElement Marker { get; private set; }

        public PageObject(IWebDriver driver, IWait<IWebDriver>[] waits) : base(driver, waits)
        {
            var nameAttr = (NameAttribute) GetType().GetCustomAttribute(typeof(NameAttribute));
            var lazyAttr = (LazyAttribute) GetType().GetCustomAttribute(typeof(LazyAttribute));
            Name = nameAttr?.Name ?? GetType().Name;
            if (lazyAttr != null) return;
            CheckMarker();
        }

        public void CheckMarker()
        {
            try
            {
                var markerAttr = (MarkerAttribute)GetType().GetCustomAttribute(typeof(MarkerAttribute));
                if (markerAttr == null)
                    throw new PageMarkerNotProvidedException(Name);
                Marker = Driver.FindElement(markerAttr.GetBy(), LongWait);
            }
            catch(Exception excp)
            {
                throw new PageObjectNotFoundException(Name);
            }
        }
    }
}
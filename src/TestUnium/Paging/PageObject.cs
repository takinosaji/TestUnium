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
        protected readonly By MarkerSelector;
        private IWebElement _marker;

        public String Name { get; set; }
        public PageObject() : this(null) {}

        public PageObject(By markerSelector)
        {
            MarkerSelector = markerSelector;
            var nameAttr = (NameAttribute)GetType().GetCustomAttribute(typeof(NameAttribute));
            
            Name = nameAttr?.Name ?? GetType().Name;
        }

        public bool CheckMarkerAfterInitialization() => (LazyAttribute)GetType().GetCustomAttribute(typeof(LazyAttribute)) != null;

        public void CheckMarker()
        {
            try
            {
                var markerAttr = (MarkerAttribute)GetType().GetCustomAttribute(typeof(MarkerAttribute));
                if (markerAttr == null)
                {
                    if (MarkerSelector == null) throw new PageMarkerNotProvidedException(Name);
                    _marker = Driver.FindElement(MarkerSelector, LongWait);
                    return;
                }
                _marker = Driver.FindElement(markerAttr.GetBy(), LongWait);
            }
            catch(Exception excp)
            {
                throw new PageObjectNotFoundException(Name, excp);
            }
        }
    }
}
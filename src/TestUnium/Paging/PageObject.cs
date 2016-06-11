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
        private readonly By _markerBy;
        private IWebElement _marker;

        public String Name { get; set; }
        public PageObject() : this(null) {}

        public PageObject(By markerBy)
        {
            _markerBy = markerBy;
            var nameAttr = (NameAttribute)GetType().GetCustomAttribute(typeof(NameAttribute));
            
            Name = nameAttr?.Name ?? GetType().Name;
        }

        public bool CheckMarkerAfterInitialization()
        {
            return (LazyAttribute)GetType().GetCustomAttribute(typeof(LazyAttribute)) != null;
        }

        public void CheckMarker()
        {
            try
            {
                var markerAttr = (MarkerAttribute)GetType().GetCustomAttribute(typeof(MarkerAttribute));
                if (markerAttr == null)
                {
                    if (_markerBy == null) throw new PageMarkerNotProvidedException(Name);
                    _marker = Driver.FindElement(_markerBy, LongWait);
                    return;
                }
                _marker = Driver.FindElement(markerAttr.GetBy(), LongWait);
            }
            catch(Exception excp)
            {
                throw new PageObjectNotFoundException(Name);
            }
        }
    }
}
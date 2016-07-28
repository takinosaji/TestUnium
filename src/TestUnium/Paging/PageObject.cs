using System;
using System.Collections.Generic;
using System.Linq;
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
        protected readonly By[] MarkerSelectors;
        private readonly List<IWebElement> _markers;

        public String Name { get; set; }
        public PageObject() : this(null) {}

        public PageObject(params By[] markerSelectors)
        {
            _markers = new List<IWebElement>();
            MarkerSelectors = markerSelectors;
            var nameAttr = (NameAttribute)GetType().GetCustomAttribute(typeof(NameAttribute));
            
            Name = nameAttr?.Name ?? GetType().Name;
        }

        public bool CheckMarkerAfterInitialization() => (LazyAttribute)GetType().GetCustomAttribute(typeof(LazyAttribute)) == null;

        public void CheckMarker()
        {
            try
            {           
                if (MarkerSelectors == null)
                {
                    var markerAttrs = (MarkerAttribute[])GetType().GetCustomAttributes(typeof(MarkerAttribute));
                    if (markerAttrs == null || markerAttrs.Length <= 0) throw new PageMarkerNotProvidedException(Name);
                    Array.ForEach(markerAttrs, ma =>
                    {
                        _markers.Add(Driver.FindElement(ma.GetBy(), LongWait));
                    });

                    return;
                }
                Array.ForEach(MarkerSelectors, by =>
                {
                    _markers.Add(Driver.FindElement(by, LongWait));
                });         
            }
            catch(Exception excp)
            {
                throw new PageObjectNotFoundException(Name, excp);
            }
        }
    }
}
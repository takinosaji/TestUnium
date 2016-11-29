using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestUnium.Annotating;
using TestUnium.Selenium.Extensions;
using TestUnium.Settings;

namespace TestUnium.Selenium.WebDriving.Paging
{
    public class PageObject : WebDriverContainer, IPageObject
    {
        protected readonly By[] MarkerSelectors;
        private readonly List<IWebElement> _markers;

        [Inject]
        public ISettings Settings { get; set; }

        public Boolean IsLoaded { get; private set; }
        public String Name { get; set; }

        public PageObject() : this(null) {}

        public PageObject(params By[] markerSelectors)
        {
            _markers = new List<IWebElement>();
            MarkerSelectors = markerSelectors;

            var nameAttr = (NameAttribute)GetType().GetCustomAttribute(typeof(NameAttribute));
            Name = nameAttr?.Name ?? GetType().Name;

            IsLoaded = false;
        }

        public bool CheckMarkerAfterInitialization() => (LazyAttribute)GetType().GetCustomAttribute(typeof(LazyAttribute)) == null;

        public void Load()
        {
            try
            {
                if (MarkerSelectors == null)
                {
                    var markerAttrs = (MarkerAttribute[]) GetType().GetCustomAttributes(typeof(MarkerAttribute));
                    if (markerAttrs == null || markerAttrs.Length <= 0) throw new PageMarkerNotProvidedException(Name);
                    Array.ForEach(markerAttrs, ma =>
                    {
                        _markers.Add(Driver.FindElement(ma.GetBy(), LongWait));
                    });
                }
                else
                {

                    Array.ForEach(MarkerSelectors, by =>
                    {
                        _markers.Add(Driver.FindElement(by, LongWait));
                    });
                }
                PageFactory.InitElements(Driver, this);
                IsLoaded = true;
            }
            catch(Exception excp)
            {
                throw new PageObjectNotFoundException(Name, excp);
            }
        }
    }
}
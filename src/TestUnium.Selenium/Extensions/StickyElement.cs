using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUnium.Selenium.Extensions
{
    public class StickyElement : IWebElement
    {
        private IWebElement _el;
        private readonly IWebDriver _driver;
        private readonly IWait<IWebDriver> _wait;
        private readonly By _by;

        public StickyElement(IWebDriver driver, By @by, IWait<IWebDriver> wait = null, IWebElement element = null)
        {
            if(wait == null) 
                wait = new WebDriverWait(driver, TimeSpan.Zero);
            _driver = driver;
            _by = @by;
            _wait = wait;
            _el = element ?? _driver.FindElement(_by, _wait);
        }

        private void CheckOrRecreate()
        {
            try
            {
                _el.GetAttribute("id");
            }
            catch
            {
                _el = _el = _driver.FindElement(_by, _wait);
            }
        }

        public IWebElement FindElement(By @by)
        {
            CheckOrRecreate();
            return _el.FindElement(@by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            CheckOrRecreate();
            return _el.FindElements(@by);
        }

        public void Clear()
        {
            CheckOrRecreate();
            _el.Clear();
        }

        public void SendKeys(string text)
        {
            CheckOrRecreate();
            _el.SendKeys(text);
        }

        public void Submit()
        {
            CheckOrRecreate();
            _el.Submit();
        }

        public void Click()
        {
            CheckOrRecreate();
            _el.Click();
        }

        public string GetAttribute(string attributeName)
        {
            CheckOrRecreate();
            return _el.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            CheckOrRecreate();
            return _el.GetCssValue(propertyName);
        }

        public string TagName
        {
            get
            {
                CheckOrRecreate();
                return _el.TagName;
            }
        }

        public string Text
        {
            get
            {
                CheckOrRecreate();
                return _el.TagName;
            }
        }
        public bool Enabled
        {
            get
            {
                CheckOrRecreate();
                return _el.Enabled;
            }
        }
        public bool Selected
        {
            get
            {
                CheckOrRecreate();
                return _el.Selected;
            }
        }
        public Point Location
        {
            get
            {
                CheckOrRecreate();
                return _el.Location;
            }
        }
        public Size Size
        {
            get
            {
                CheckOrRecreate();
                return _el.Size;
            }
        }
        public bool Displayed
        {
            get
            {
                CheckOrRecreate();
                return _el.Displayed;
            }
        }
    }
}

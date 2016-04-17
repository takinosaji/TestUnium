using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUnium.Instantiation.WebDriving
{
    public class WebDriverContainer
    {
        private IWait<IWebDriver>[] _waits;
        public IWebDriver Driver { get; set; }

        public WebDriverContainer(IWebDriver driver, IWait<IWebDriver>[] waits)
        {
            Driver = driver;
            _waits = waits;
        }

        public IWait<IWebDriver> SmallWait
        {
            get { return GetWait(0); } 
            set { SetWait(0, value); }
        }

        public IWait<IWebDriver> MediumWait
        {
            get { return GetWait(1); } 
            set { SetWait(1, value); }
        }

        public IWait<IWebDriver> LongWait
        {
            get { return GetWait(2); }
            set { SetWait(2, value); }
        }

        private IWait<IWebDriver> GetWait(Int16 index)
        {
            return (_waits.Length < index) ? null : _waits[index];
        }

        private void SetWait(Int16 index, IWait<IWebDriver> wait)
        {
            if (_waits == null)
            {
                _waits = new IWait<IWebDriver>[3];
            }
            if (_waits.Length - 1 < index)
            {
                for (var i = _waits.Length; i <= index; i++)
                {
                    _waits[i] = i == index ? wait : null;
                }
                return;
            }

            _waits[index] = wait;
        }
    }
}

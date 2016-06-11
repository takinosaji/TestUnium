using System;
using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUnium.Instantiation.WebDriving
{
    public class WebDriverContainer
    {
        [Inject] public IWebDriver Driver { get; set; }

        [Inject] public IWait<IWebDriver>[] Waits { get; set; }

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
            return (Waits.Length < index) ? null : Waits[index];
        }

        private void SetWait(Int16 index, IWait<IWebDriver> wait)
        {
            if (Waits == null)
            {
                Waits = new IWait<IWebDriver>[3];
            }
            if (Waits.Length - 1 < index)
            {
                for (var i = Waits.Length; i <= index; i++)
                {
                    Waits[i] = i == index ? wait : null;
                }
                return;
            }

            Waits[index] = wait;
        }
    }
}

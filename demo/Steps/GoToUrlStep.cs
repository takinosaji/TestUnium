using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestUnium.Instantiation.Stepping.Steps;

namespace Steps
{
    public class GoToUrlStep : WebDriverStep
    {
        public String Url { get; set; } = "github.com";
        public GoToUrlStep(IWebDriver driver) : base(driver)
        {
        }

        public override void Execute()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}

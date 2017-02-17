using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestUnium.Selenium.Stepping;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace Steps
{
    public class GoToUrlStep : WebDriverStep
    {
        public String Url { get; set; } = "github.com";

        public override void Execute()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}

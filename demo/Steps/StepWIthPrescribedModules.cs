using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Steps.Modules;
using TestUnium.Selenium.Stepping;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace Steps
{
    [UseWithStepModule(typeof(ThrowsExceptionModule))]
    public class StepWIthPrescribedModules : WebDriverStep
    {
        public override void Execute()
        {
        }
    }
}

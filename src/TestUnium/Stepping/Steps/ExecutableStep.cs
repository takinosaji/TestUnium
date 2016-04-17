using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUnium.Instantiation.WebDriving;

namespace TestUnium.Stepping.Steps
{
    public abstract class ExecutableStep
    {
        protected StepState State { get; set; }

        private Boolean IsFakeStep => GetType().GetCustomAttribute(typeof (FakeStepAttribute)) != null;

        protected ExecutableStep()
        {
            State = StepState.BeforeExecute;
        }
    }
}
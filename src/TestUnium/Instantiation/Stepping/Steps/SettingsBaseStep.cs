using Ninject;
using OpenQA.Selenium;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class SettingsBaseStep : ExecutableStep
    {
        [Inject]
        public ISettings Settings { get; set; }
    }
}
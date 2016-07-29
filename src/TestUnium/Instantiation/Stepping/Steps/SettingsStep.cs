using Ninject;
using OpenQA.Selenium;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public abstract class SettingsStep : ExecutableStep
    {
        [Inject]
        public ISettings Settings { get; set; }
    }
}
using Ninject;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Stepping.Steps.Settings
{
    public abstract class SettingsStep : ExecutableStep
    {
        [Inject]
        public ISettings Settings { get; set; }
    }
}
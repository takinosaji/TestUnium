using Ninject;
using TestUnium.Settings;

namespace TestUnium.Stepping.Steps.Settings
{
    public abstract class SettingsStep : ExecutableStep
    {
        [Inject]
        public ISettings Settings { get; set; }
    }
}
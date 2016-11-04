using Ninject;
using TestUnium.Settings;
using TestUnium.Stepping.Steps.Kernel;

namespace TestUnium.Stepping.Steps.Settings
{
    public abstract class SettingsDrivenStepCore : KernelDrivenStepCore
    {
        [Inject]
        public ISettings Settings { get; set; }
    }
}
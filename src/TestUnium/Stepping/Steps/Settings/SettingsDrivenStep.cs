namespace TestUnium.Stepping.Steps.Settings
{
    public abstract class SettingsDrivenStep<T> : SettingsDrivenStepCore, IExecutableStep<T>
    {
        public abstract T Execute();
    }

    public abstract class SettingsDrivenStep : SettingsDrivenStepCore, IExecutableStep
    {
        public abstract void Execute();
    }
}

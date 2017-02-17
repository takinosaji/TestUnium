using TestUnium.Stepping;

namespace TestUnium.Settings
{
    public interface ISettingsContext
    {
        ISettings Settings { get; set; }
    }
}
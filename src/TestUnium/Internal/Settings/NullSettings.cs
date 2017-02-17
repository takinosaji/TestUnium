using TestUnium.Settings;

namespace TestUnium.Internal.Settings
{
    internal class NullSettings : ISettings
    {
        public ISettingsContext Context { get; set; }
        public string LogSystemPath { get; set; }
        public string LogUrlPath { get; set; }
        public int LogFolderCapacity { get; set; }
        public void PostInitializeAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
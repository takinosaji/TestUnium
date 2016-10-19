using System;

namespace TestUnium.Settings
{
    public interface ISettings
    {
        String LogSystemPath { get; set; }
        String LogUrlPath { get; set; }
        Int32 LogFolderCapacity { get; set; }
        /// <summary>
        /// Overriding some settings values set by default and loaded from file. 
        /// Note that changes made by following code dont affect settigns file content.
        /// </summary>
        void PostInitializeAction();
    }
}
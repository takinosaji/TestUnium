using System;

namespace TestUnium.Selenium.Paging
{
    public interface IPageObject
    {
        Boolean CheckMarkerAfterInitialization();
        void Load();
        Boolean IsLoaded { get; }
    }
}
using System;

namespace TestUnium.Selenium.WebDriving.Paging
{
    public interface IPageObject
    {
        Boolean CheckMarkerAfterInitialization();
        void Load();
        Boolean IsLoaded { get; }
    }
}
using System;

namespace TestUnium.Paging
{
    public interface IPageObject
    {
        Boolean CheckMarkerAfterInitialization();
        void Load();
        Boolean IsLoaded { get; }
    }
}
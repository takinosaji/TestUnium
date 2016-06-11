using System;

namespace TestUnium.Paging
{
    public interface IPageObject
    {
        Boolean CheckMarkerAfterInitialization();
        void CheckMarker();
    }
}
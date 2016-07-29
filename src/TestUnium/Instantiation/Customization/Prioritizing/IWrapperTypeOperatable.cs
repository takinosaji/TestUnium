using System;

namespace xUnium.Instantiation.Prioritizing
{
    public interface IWrapperTypeOperatable
    {
        Type GetWrapperType();
        void SetWrapperType(Type wrapperType);
    }
}
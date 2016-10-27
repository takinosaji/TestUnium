using System;

namespace TestUnium
{
    public interface IChecker<in TType>
    {
        Boolean Check(TType @object);
    }
}
using System;
using System.Collections.Generic;

namespace TestUnium.Plugging
{
    public interface ICompositionEngine<out TCompositionType>
    {
        IEnumerable<TCompositionType> GetComposedParts();
    }
}
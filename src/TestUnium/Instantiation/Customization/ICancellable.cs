using System;
using System.Collections.Generic;

namespace TestUnium.Instantiation.Customization
{
    public interface ICancellable
    {
        Boolean HasToBeCanceled(IEnumerable<Type> invocationList);
    }
}
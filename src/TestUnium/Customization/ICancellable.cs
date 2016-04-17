using System;
using System.Collections.Generic;

namespace TestUnium.Customization
{
    public interface ICancellable
    {
        Boolean CheckCancellationClause(IEnumerable<Type> invocationList);
    }
}
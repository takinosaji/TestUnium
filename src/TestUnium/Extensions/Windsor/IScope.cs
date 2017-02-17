using System;

namespace TestUnium.Extensions.Windsor
{
    public interface IScope
    {
        IDisposable GetScopeObject();
    }
}
using System;

namespace TestUnium.Extensions.Ninject
{
    public interface IScope
    {
        IDisposable GetScopeObject();
    }
}
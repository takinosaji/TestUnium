using System;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;
using TestUnium.Internal.Bootstrapping;

namespace TestUnium.Stepping.Pipeline
{
    public class StepModuleLifeStyleScopeAccessor : IScopeAccessor
    {
        private readonly IScopeAccessor _transientScopeAccessor;

        public StepModuleLifeStyleScopeAccessor()
        {
            _transientScopeAccessor = new TransientScopeAccessor();
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            
            var scope = CallContextLifetimeScope.ObtainCurrentScope();
            return scope ?? _transientScopeAccessor.GetScope(context);
        }

        #region IDisposable
        private Boolean _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _transientScopeAccessor.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
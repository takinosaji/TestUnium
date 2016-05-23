using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession, IStepModuleRegistrator
    {
        private readonly ISessionDrivenTest _testContext;
        private readonly ISessionContext _context;
        private readonly List<ISessionPlugin> _plugins;
        private List<IStepModule> _reusableStepModules;
        private List<Type> _nonreusableStepModules;
        //public readonly DubKeyDictionary<Type, Boolean> StepModules;

        public SessionBase(ISessionDrivenTest testContext, ISessionContext context)
        {
            _plugins = new List<ISessionPlugin>();
            //StepModules = new DubKeyDictionary<Type, Boolean>();
            _reusableStepModules = new List<IStepModule>();
            _nonreusableStepModules = new List<Type>();
            _testContext = testContext;
            _context = context;
        }

        #region Plugins
        protected virtual void AddPlugins(params ISessionPlugin[] plugins) 
            => AddPlugins(plugins.ToList());
        protected virtual void AddPlugins(IEnumerable<ISessionPlugin> plugins) 
            => _plugins.AddRange(plugins);
        public ISession Using(params ISessionPlugin[] plugins)
        {
            AddPlugins(plugins); return this;
        }

        public ISession Using<TPlugin>()
            where TPlugin : ISessionPlugin, new()
        {
            AddPlugins(Activator.CreateInstance<TPlugin>());
            return this;
        }
        #endregion

        #region StepModules

       
        public ISession Include(Boolean makeReusable = false, params Type[] moduleTypes)
        {
            RegisterStepModules(makeReusable, moduleTypes); return this;
        }

        public ISession Include<TStepModule>(Boolean makeReusable = false) where TStepModule : IStepModule
        {
            RegisterStepModule<TStepModule>(makeReusable); return this;
        }

        public ISessionDrivenTest GetTestContext()
        {
            return _testContext;
        }

        public void Start(Action<ISessionContext> operations)
        {
            try
            {
                _plugins.ForEach(sp => sp.OnStart(_context));
                operations(_context);
            }
            finally
            {
                End();
            }
        }
        #endregion

        public void End()
        {
            _plugins.ForEach(sp => sp.OnEnd(_context));
            ISession session;
            _testContext.Sessions.TryRemove(Thread.CurrentThread.ManagedThreadId, out session);
        }

        public void RegisterStepModule<TStepModule>(bool makeReusable) where TStepModule : IStepModule
        {
            throw new NotImplementedException();
        }

        public void RegisterStepModule(Type moduleType, bool makeReusable)
        {
            throw new NotImplementedException();
        }

        public void RegisterStepModules(bool makeReusable, params Type[] moduleTypes)
        {
            throw new NotImplementedException();
        }

        public void UnregisterStepModule<TStepModule>() where TStepModule : IStepModule
        {
            throw new NotImplementedException();
        }

        public void UnregisterStepModules(params Type[] moduleTypes)
        {
            throw new NotImplementedException();
        }
    }
}
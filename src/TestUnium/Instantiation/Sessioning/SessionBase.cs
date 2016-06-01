using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ninject;
using TestUnium.Common;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public class SessionBase: ISession
    {
        private readonly IStepModuleRegistrationStrategy _moduleRegistrationStrategy;
        private readonly ISessionDrivenTest _testContext;
        private readonly ISessionContext _context;
        private readonly IKernel _kernel;
        private readonly List<ISessionPlugin> _plugins;

        public SessionBase(ISessionDrivenTest testContext, ISessionContext context, IKernel kernel,
            IStepModuleRegistrationStrategy moduleRegistrationStrategy)
        {
            _moduleRegistrationStrategy = moduleRegistrationStrategy;
            _plugins = new List<ISessionPlugin>();
            _testContext = testContext;
            _context = context;
            _kernel = kernel;
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

        public IKernel GetSessionKernel()
        {
            return _kernel;
        }

        #endregion

        #region StepModules
        public ISession Include(params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(_kernel, false, moduleTypes); return this;
        }
        public ISession Include(Boolean makeReusable, params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(_kernel, makeReusable, moduleTypes); return this;
        }
        public ISession Include<TStepModule>(Boolean makeReusable = false) where TStepModule : IStepModule
        {
            _moduleRegistrationStrategy.RegisterStepModule<TStepModule>(_kernel, makeReusable); return this;
        }
        #endregion

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
       
        public void End()
        {
            _plugins.ForEach(sp => sp.OnEnd(_context));
            ISession session;
            _testContext.Sessions.TryRemove(Thread.CurrentThread.ManagedThreadId, out session);
        }
    }
}
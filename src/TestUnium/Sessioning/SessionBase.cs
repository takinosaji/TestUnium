using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ninject;
using TestUnium.Stepping;
using TestUnium.Stepping.Modules;

namespace TestUnium.Sessioning
{
    public class SessionBase: ISession
    {
        private readonly IStepModuleRegistrationStrategy _moduleRegistrationStrategy;
        private readonly ISessionDrivenTest _testContext;
        private readonly ISessionContext _context;
        private readonly List<ISessionPlugin> _plugins;
        public Guid SessionId { get; set; }

        public SessionBase(ISessionDrivenTest testContext, ISessionContext context,
            IStepModuleRegistrationStrategy moduleRegistrationStrategy)
        {
            _moduleRegistrationStrategy = moduleRegistrationStrategy;
            _plugins = new List<ISessionPlugin>();
            _testContext = testContext;
            _context = context;
            SessionId = Guid.NewGuid();
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
            return _context.Kernel;
        }
        #endregion

        #region StepModules
        public ISession Include(params Type[] moduleTypes)
        {
            return Include(false, moduleTypes);
        }
        public ISession Include(Boolean makeReusable, params Type[] moduleTypes)
        {
            _moduleRegistrationStrategy.RegisterStepModules(_context.Kernel, SessionId.ToString(), makeReusable, moduleTypes); return this;
        }
        public ISession Include<TStepModule>(Boolean makeReusable) where TStepModule : IStepModule
        {
            _moduleRegistrationStrategy.RegisterStepModule<TStepModule>(_context.Kernel, SessionId.ToString(), makeReusable); return this;
        }
        public ISession Include<TStepModule>() where TStepModule : IStepModule
        {
            return Include<TStepModule>(false);
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

        public String GetSessionId() => SessionId.ToString();
    }
}
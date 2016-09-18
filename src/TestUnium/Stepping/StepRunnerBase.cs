using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public class StepRunnerBase : IStepRunner
    {
        private IEnumerable<IStepModule> _modules;

        public StepRunnerBase(IKernel kernel, String sessionId)
        {
            _modules = String.IsNullOrEmpty(sessionId) 
                ? kernel.GetAll<IStepModule>() 
                : kernel.GetAll<IStepModule>(sessionId);
        }

        public void BeforeExecution(IStep step)
        {
            foreach (var module in _modules)
            {
                module.BeforeExecution(step);
            }
        }

        public void AfterExecution(IStep step, StepState state)
        {
            foreach (var module in _modules)
            {
                module.AfterExecution(step, state);
            }
        }

        public void Run(IExecutableStep step)
        {
            BeforeExecution(step);
            try
            {
                step.Execute();
                step.State = StepState.Executed;
            }
            catch(Exception excp)
            {
                step.LastException = excp;
                step.State = StepState.Failed;
                AfterExecution(step, StepState.Failed);
                if (step.ExceptionHandlingMode == StepExceptionMode.Rethrow)
                {
                    throw;
                }
                return;
            }
            
            AfterExecution(step, StepState.Executed);
        }

        public TResult RunWithReturnValue<TResult>(IExecutableStep<TResult> step)
        {
            var value = default(TResult);
            BeforeExecution(step);
            try
            {
                value = step.Execute();
                step.State = StepState.Executed;
            }
            catch(Exception excp)
            {
                step.LastException = excp;
                step.State = StepState.Failed;
                AfterExecution(step, StepState.Failed);
                if (step.ExceptionHandlingMode == StepExceptionMode.Rethrow)
                {
                    throw;
                }
                return value;
            }
            AfterExecution(step, StepState.Executed);
            return value;
        }

        public void AddModules(params IStepModule[] modules)
        {
            if (modules == null || modules.Length <= 0) return;
            var modulesList = _modules.ToList();
            modulesList.AddRange(modules);
            _modules = modulesList.ToArray();
        }

        public void RemoveModules(params IStepModule[] modules)
        {
            if (modules == null || modules.Length <= 0) return;
            var modulesList = _modules.ToList();
            foreach (var module in modules)
            {
                modulesList.Remove(module);
            }
            _modules = modulesList.ToArray();
        }
    }
}

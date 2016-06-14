using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
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

        public void AfterExecution(IStep step, StepExecutionResult result)
        {
            foreach (var module in _modules)
            {
                module.AfterExecution(step, result);
            }
        }

        public void Run(IExecutableStep step)
        {
            BeforeExecution(step);
            try
            {
                step.Execute();
            }
            catch(Exception excp)
            {
                step.SetException(excp);
                AfterExecution(step, StepExecutionResult.Failure);
                throw;
            }
            
            AfterExecution(step, StepExecutionResult.Success);
        }

        public TResult RunWithReturnValue<TResult>(IExecutableStep<TResult> step)
        {
            TResult value = default(TResult);
            BeforeExecution(step);
            try
            {
                value = step.Execute();
            }
            catch(Exception excp)
            {
                step.SetException(excp);
                AfterExecution(step, StepExecutionResult.Failure);
                throw;
            }
            AfterExecution(step, StepExecutionResult.Success);
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

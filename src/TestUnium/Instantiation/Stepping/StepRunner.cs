using System;
using System.Linq;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace TestUnium.Instantiation.Stepping
{
    public class StepRunner : IStepRunner
    {
        private IStepModule[] _modules;

        public StepRunner(IStepModule[] modules)
        {
            _modules = modules;
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
            catch
            {
                AfterExecution(step, StepExecutionResult.Failure);
                return;
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
            catch 
            {
                AfterExecution(step, StepExecutionResult.Failure);
                return value;
            }
            AfterExecution(step, StepExecutionResult.Success);
            return value;
        }

        public void RegisterModules(params IStepModule[] modules)
        {
            if (modules == null || modules.Length <= 0) return;
            var modulesList = _modules.ToList();
            modulesList.AddRange(modules);
            _modules = modulesList.ToArray();
        }

        public void UnregisterModules(params IStepModule[] modules)
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

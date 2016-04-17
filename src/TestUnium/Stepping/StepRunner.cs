using System;
using System.Collections.Generic;
using System.Linq;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
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
                AfterExecution(step, StepExecutionResult.Success);
            }
            finally
            {
                AfterExecution(step, StepExecutionResult.Failure);
            }
        }

        public void Run(Action operations)
        {
            Run(new FakeStep(operations));
        }

        public TResult RunWithReturnValue<TResult>(IExecutableStep<TResult> step)
        {
            BeforeExecution(step);
            try
            {
                var value = step.Execute();
                AfterExecution(step, StepExecutionResult.Success);
                return value;
            }
            finally 
            {
                AfterExecution(step, StepExecutionResult.Failure);
            }
        }

        public TResult RunWithReturnValue<TResult>(Func<TResult> operationsWithReturnValue)
        {
            return RunWithReturnValue(new FakeStepWithReturnValue<TResult>(operationsWithReturnValue));          
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

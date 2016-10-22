using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Ninject;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Steps;
using TestUnium.Stepping.Steps.Validation;

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

        public virtual void Run<TStep>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep
        {
            step.Executor = executor;
            step.ExceptionHandlingMode = exceptionHandlingMode;
            stepSetUpAction?.Invoke(step);

            if (validateStep)
            {
                var validator = new RequiredMembersStepValidator().Validate(step);
                if (!validator.IsValid)
                {
                    Contract.Assert(validator.IsValid, validator.Message);
                }
            }
            step.PreExecute();

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
                if (step.ExceptionHandlingMode == StepExceptionHandlingMode.Rethrow)
                {
                    throw;
                }
                return;
            }
            
            AfterExecution(step, StepState.Executed);
        }

        public virtual TResult RunWithReturnValue<TStep, TResult>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep<TResult>
        {
            step.Executor = executor;
            step.ExceptionHandlingMode = exceptionHandlingMode;
            stepSetUpAction?.Invoke(step);

            var validator = new RequiredMembersStepValidator().Validate(step);
            if (!validator.IsValid)
            {
                Contract.Assert(validator.IsValid, validator.Message);
            }
            step.PreExecute();

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
                if (step.ExceptionHandlingMode == StepExceptionHandlingMode.Rethrow)
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

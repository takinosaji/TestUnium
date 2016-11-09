using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Ninject;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Validation.Step;
using TestUnium.Internal.Validation.StepModules;
using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public class StepRunnerBase : IStepRunner
    {
        private IEnumerable<IStepModule> _modules;

        private readonly IEnumerable<IStepModuleValidator> _moduleValidators;
        private readonly IEnumerable<IStepValidator> _stepValidators;

        public StepRunnerBase(IKernel kernel, String sessionId)
        {
            _modules = String.IsNullOrEmpty(sessionId)
                ? kernel.GetAll<IStepModule>()
                : kernel.GetAll<IStepModule>(sessionId);

            _moduleValidators = Container.Instance.Kernel.GetAll<IStepModuleValidator>();
            _stepValidators = Container.Instance.Kernel.GetAll<IStepValidator>();
        }

        public void BeforeExecution(IStep step)
        {
            //Filter global and session stepmodules
            foreach (var module in _modules)
            {
                var isValid = true;
                var moduleType = module.GetType();
                foreach (var stepModuleValidator in _moduleValidators)
                {
                    if (!stepModuleValidator.Validate(moduleType, step))
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    module.BeforeExecution(step);
                }
            }
            //Invoke personal step modules
        }

        public void AfterExecution(IStep step, StepState state)
        {
            foreach (var module in _modules)
            {
                var isValid = true;
                var moduleType = module.GetType();
                foreach (var stepModuleValidator in _moduleValidators)
                {
                    if (!stepModuleValidator.Validate(moduleType, step))
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    module.AfterExecution(step, state);
                }
            }
        }

        public void Run<TStep>(IStepExecutor executor, String callingMethodName, TStep step,
            Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep
        {
            step.Executor = executor;
            step.CallingMethodName = callingMethodName;
            step.ExceptionHandlingMode = exceptionHandlingMode;

            try
            {
                stepSetUpAction?.Invoke(step);
            }
            catch (Exception excp)
            {
                throw new StepSetUpException(
                    $"Unexpected error during setting up of step: {step.GetType().Name} has occured.", excp);
            }

            foreach (var stepValidator in _stepValidators)
            {
                var validator = stepValidator.Validate(step);
                Contract.Assert(validator.IsValid, validator.Message);
            }         

            step.PreExecute();

            BeforeExecution(step);
            try
            {
                step.Execute();
                step.State = StepState.Executed;
            }
            catch (Exception excp)
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

        public TResult RunWithReturnValue<TStep, TResult>(IStepExecutor executor, String callingMethodName, TStep step,
            Action<TStep> stepSetUpAction, StepExceptionHandlingMode exceptionHandlingMode, Boolean validateStep)
            where TStep : IExecutableStep<TResult>
        {
            step.Executor = executor;
            step.CallingMethodName = callingMethodName;
            step.ExceptionHandlingMode = exceptionHandlingMode;

            try
            {
                stepSetUpAction?.Invoke(step);
            }
            catch (Exception excp)
            {
                throw new StepSetUpException($"Unexpected error during setting up of step: {step} has occured.", excp);
            }

            foreach (var stepValidator in _stepValidators)
            {
                var validator = stepValidator.Validate(step);
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
            catch (Exception excp)
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

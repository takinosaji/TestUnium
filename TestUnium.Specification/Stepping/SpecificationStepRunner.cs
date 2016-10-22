using System;
using Ninject;
using TestUnium.Stepping;

namespace TestUnium.Specification.Stepping
{
    public class SpecificationStepRunner : StepRunnerBase
    {
        public SpecificationStepRunner(IKernel kernel, string sessionId) : base(kernel, sessionId)
        {

        }

        public override void Run<TStep>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction,
            StepExceptionHandlingMode exceptionHandlingMode, bool validateStep)
        {
            base.Run(executor, step, stepSetUpAction, exceptionHandlingMode, validateStep);
        }

        public override TResult RunWithReturnValue<TStep, TResult>(IStepExecutor executor, TStep step, Action<TStep> stepSetUpAction,
            StepExceptionHandlingMode exceptionHandlingMode, bool validateStep)
        {
            return base.RunWithReturnValue<TStep, TResult>(executor, step, stepSetUpAction, exceptionHandlingMode, validateStep);
        }
    }
}
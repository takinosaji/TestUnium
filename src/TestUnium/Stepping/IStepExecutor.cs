﻿using System;
using TestUnium.Stepping.Steps;

namespace TestUnium.Stepping
{
    public interface IStepExecutor
    {
        void Do<TStep>
            (Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow, 
            Boolean validateStep = true) 
            where TStep : IExecutableStep;
        void Do<TStep>
            (StepExceptionHandlingMode exceptionHandlingMode, 
            Boolean validateStep = true)
            where TStep : IExecutableStep;
        void Do<TStep>(Boolean validateStep) 
            where TStep : IExecutableStep;

        TResult Do<TStep, TResult>
            (Action<TStep> stepSetUpAction = null,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow,
            Boolean validateStep = true)
            where TStep : IExecutableStep<TResult>;
        TResult Do<TStep, TResult>
            (StepExceptionHandlingMode exceptionHandlingMode, 
            Boolean validateStep = true)
            where TStep : IExecutableStep<TResult>;
        TResult Do<TStep, TResult>(Boolean validateStep) 
            where TStep : IExecutableStep<TResult>;

        void Do(Action outOfStepOperations, StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow);
        TResult Do<TResult>(Func<TResult> outOfStepFuncWithReturnValue,
            StepExceptionHandlingMode exceptionHandlingMode = StepExceptionHandlingMode.Rethrow);

        TStep GetStep<TStep>(Action<TStep> stepSetupAction = null) where TStep : IStep;
    }
}
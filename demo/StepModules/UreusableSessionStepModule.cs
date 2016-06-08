﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Modules;
using TestUnium.Instantiation.Stepping.Steps;

namespace StepModules
{
    public class UreusableSessionStepModule : IStepModule
    {
        private Boolean Flag { get; set; }
        public void BeforeExecution(IStep step)
        {
            if(Flag) throw new InvalidOperationException();
            Flag = true;
        }

        public void AfterExecution(IStep step, StepExecutionResult result)
        {
        }
    }
}
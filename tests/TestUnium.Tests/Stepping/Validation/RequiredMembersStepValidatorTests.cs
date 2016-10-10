using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Moq;
using Ninject;
using TestUnium.Stepping;
using TestUnium.Stepping.Steps.Settings;
using Xunit;
using Xunit.Abstractions;

namespace TestUnium.Tests.Stepping.Validation
{
    public class RequiredMembersStepValidatorTests
    {
        private readonly ITestOutputHelper _output;
        public RequiredMembersStepValidatorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Required_Members_Step_Validator_Perfomance_Tests()
        {
            var creationAttemptsNumber = 20000;
            var stepRunner = new StepRunnerBase(new Mock<IKernel>().Object, "111");
            var step = new TestStep();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < creationAttemptsNumber; i++)
            {
                stepRunner.Run(step, null, StepExceptionHandlingMode.Rethrow, false);
            }
            stopwatch.Stop();
            var withoutElapsed = stopwatch.Elapsed;
            _output.WriteLine($"Without Required check: {withoutElapsed.TotalSeconds} seconds.");

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < creationAttemptsNumber; i++)
            {
                stepRunner.Run(step, null, StepExceptionHandlingMode.Rethrow, true);
            }
            stopwatch.Stop();
            var withElapsed = stopwatch.Elapsed;
            _output.WriteLine($"With Required check: {withElapsed.TotalSeconds} seconds.");

            _output.WriteLine($"Without Required check is faster than with it in {withElapsed.TotalSeconds / withoutElapsed.TotalSeconds} times for {creationAttemptsNumber} attempts.");
        }

        public class TestStep : SettingsDrivenStep
        {
            [Required] public String Url { get; set; } = "github.com";
            [Required] public String Url2 { get; set; } = "github.com";
            [Required] public String Url3 { get; set; } = "github.com";
            [Required] public String Url4 { get; set; } = "github.com";
            [Required] public String Url5 { get; set; } = "github.com";
            [Required] public String Url6 = "github.com";
            [Required] public String Url7 = "github.com";
            [Required] public String Url8  = "github.com";
            [Required] public String Url9 = "github.com";
            [Required] public String Url10 = "github.com";


            public override void Execute()
            {
              
            }
        }
    }
}

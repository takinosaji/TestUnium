using TestUnium.Stepping.Modules;
using TestUnium.Stepping.Modules.Conditions;
using TestUnium.Stepping.Steps;

namespace StepModules.Conditions
{
    public class TestStepChecker : IStepChecker
    {
        public bool Check(IStep @object)
        {
            return true;
        }
    }
}
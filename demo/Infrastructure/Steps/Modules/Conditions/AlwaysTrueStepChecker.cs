using TestUnium.Stepping.Pipeline.Conditions;
using TestUnium.Stepping.Steps;

namespace Steps.Modules.Conditions
{
    public class TestStepChecker : IStepChecker
    {
        public bool Check(IStep @object)
        {
            return true;
        }
    }
}
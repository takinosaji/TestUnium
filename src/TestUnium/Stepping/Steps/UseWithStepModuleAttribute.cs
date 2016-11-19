using System;
using TestUnium.Stepping.Pipeline;

namespace TestUnium.Stepping.Steps
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class UseWithStepModuleAttribute : Attribute
    {
        private readonly Type[] _stepModules;

        public UseWithStepModuleAttribute(params Type[] stepModules)
        {
            foreach (var stepModule in stepModules)
            {
                if (!typeof(IStepModule).IsAssignableFrom(stepModule))
                    throw new ArgumentException($"WithStepModuleAttribute accepts only types that implement IStepModule interface. {stepModule.Name} doesn't implement IStepModule.");
            }

            _stepModules = stepModules;
        }

        public Type[] GetStepModules() => _stepModules;
    }
}
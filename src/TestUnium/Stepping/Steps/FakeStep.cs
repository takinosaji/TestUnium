using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnium.Stepping.Steps
{
    [FakeStep]
    class FakeStep : ExecutableStep, IExecutableStep
    {
        public Action Operations;

        public FakeStep(Action operations)
        {
            Operations = operations;
        }

        public void Execute()
        {
            Operations();
        }
    }
}

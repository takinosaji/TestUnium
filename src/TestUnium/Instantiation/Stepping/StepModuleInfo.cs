using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Instantiation.Stepping.Modules;

namespace TestUnium.Instantiation.Sessioning
{
    public struct StepModuleInfo
    {
        public Type ModuleType { get; set; }
        public Int32 ThreadId { get; set; }
        public Boolean IsRegistered { get; set; }
        public Boolean IsReusable { get; set; }
        public StepModuleInfo(Type moduleType, Boolean isReusable, Int32 threadId)
        {
            ModuleType = moduleType;
            IsReusable = isReusable;
            ThreadId = threadId;
            IsRegistered = false;
        } 
    }
}

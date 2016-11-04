using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnium.Internal.Domain;

namespace TestUnium.Extensions
{
    public static class EnumExtensions
    {
        public static Int32 GetValue(this Move move)
        {
            return (Int32) move;
        }
    }
}

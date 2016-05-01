using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnium.Customization
{
    class VisibilityAttribute : Attribute
    {
        public Boolean Visible { get; set; }

        public VisibilityAttribute(Boolean visible = true)
        {
            Visible = visible;
        }

        public VisibilityAttribute()
        {
        }
    }
}

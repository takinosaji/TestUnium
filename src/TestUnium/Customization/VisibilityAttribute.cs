using System;

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

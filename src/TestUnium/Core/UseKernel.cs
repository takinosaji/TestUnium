using TestUnium.Customization;

namespace TestUnium.Core
{
    public class UseKernel : CustomizationAttribute, ICustomizer<KernelDrivenTest>
    {
        public void Customize(KernelDrivenTest context)
        {
            throw new System.NotImplementedException();
        }
    }
}
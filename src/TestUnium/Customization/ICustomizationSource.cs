namespace TestUnium.Customization
{
    public interface ICustomizationSource
    {
        void Customize(ICustomizationTarget context);
    }
}
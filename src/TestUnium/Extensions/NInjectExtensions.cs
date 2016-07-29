using System.Collections.Generic;
using System.Linq;
using Ninject.Planning.Bindings;
using Ninject.Syntax;

namespace TestUnium.Extensions
{
    public static class NinjectExtensions
    {
        public static void AddBindings(this IBindingRoot root, params IBinding[] bindings)
        {
            foreach (var binding in bindings)
            {
                root.AddBinding(binding);
            }
        }

        public static void AddBindings(this IBindingRoot root, IEnumerable<IBinding> bindings)
        {
            root.AddBindings(bindings.ToArray());
        }
    }
}
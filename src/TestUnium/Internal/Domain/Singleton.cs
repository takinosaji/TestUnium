using System;
using System.Reflection;

namespace TestUnium.Internal.Domain
{
    public class Singleton<T> where T : class
    {
        protected Singleton() { }

        private sealed class SingletonCreator<S> where S : class
        {
            public static S CreatorInstance { get; } = (S)typeof(S).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]).Invoke(null);
        }

        public static T Instance => SingletonCreator<T>.CreatorInstance;
    }
}
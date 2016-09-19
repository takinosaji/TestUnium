using System;

namespace TestUnium.Internal.Services
{
    public interface IShellService
    {
        String TryGetArg(String key, String defaultValue);

        String TryGetArg(String key);
    }
}
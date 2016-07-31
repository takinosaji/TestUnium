using System;

namespace TestUnium.Services
{
    public interface IShellService
    {
        String TryGetArg(String key, String defaultValue);

        String TryGetArg(String key);
    }
}
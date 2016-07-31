using System;

namespace TestUnium.Services.Implementations
{
    public class ShellService : IShellService
    {
        public String TryGetArg(String key, String defaultValue)
        {
            var args = Environment.GetCommandLineArgs();
            var pos = Array.IndexOf(args, key);
            return (pos != -1 && pos < args.Length - 1) ? args[pos + 1] : defaultValue;
        }

        public String TryGetArg(String key)
        {
            return TryGetArg(key, null);
        }
    }
}

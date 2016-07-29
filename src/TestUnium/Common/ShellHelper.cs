using System;

namespace TestUnium.Common
{
    public static class ShellHelper
    {
        public static String TryGetArg(String key, String defaultValue)
        {
            var args = Environment.GetCommandLineArgs();
            var pos = Array.IndexOf(args, key);
            return (pos != -1 && pos < args.Length - 1) ? args[pos + 1] : defaultValue;
        }

        public static String TryGetArg(String key)
        {
            return TryGetArg(key, null);
        }
    }
}

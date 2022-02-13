using Faksistent.Debugging;

namespace Faksistent
{
    public class FaksistentConsts
    {
        public const string LocalizationSourceName = "Faksistent";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "3a793db9c3d24ca18da816f2f090a065";
    }
}

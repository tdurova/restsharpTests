using System.Configuration;

namespace RestsharpTests
{
    public class Config
    {
        public static string ApplicationMainUrl => ConfigurationManager.AppSettings["applicationMainUrl"];

        public static string AppLogin => ConfigurationManager.AppSettings["login"];

        public static string AppPassword => ConfigurationManager.AppSettings["password"];

        public static object ConsumerId { get; internal set; }

        public static object RedirectUrl { get; internal set; }
    }
}

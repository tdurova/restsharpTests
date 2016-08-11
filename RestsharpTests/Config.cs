using System.Configuration;

namespace RestsharpTests
{
    public class Config
    {
        public static string loginPageUrl;
        public static string ApplicationMainUrl => ConfigurationManager.AppSettings["applicationMainUrl"];

        public static string AppLogin => ConfigurationManager.AppSettings["login"];

        public static string AppPassword => ConfigurationManager.AppSettings["password"];

        public static string ConsumerId { get; internal set; }

        public static string RedirectUrl { get; internal set; }

        public static string LoginPageUrl { get; internal set; }

        
    }
}

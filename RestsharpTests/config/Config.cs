using System.Configuration;

namespace RestsharpTests
{
    public class Config
    {
        public static string ApplicationMainUrl => ConfigurationManager.AppSettings["applicationMainUrl"];
        public static string AppLogin => ConfigurationManager.AppSettings["login"];
        public static string AppPassword => ConfigurationManager.AppSettings["password"];
        public static string ClientId => ConfigurationManager.AppSettings["clientId"];
        public static string RedirectUrl => ConfigurationManager.AppSettings["redirectURL"];
        public static string LoginPageUrl => ConfigurationManager.AppSettings["loginPageUrl"];
        public static string ResponseType => ConfigurationManager.AppSettings["responseType"];
        public static string ClientSecret => ConfigurationManager.AppSettings["clientSecret"];
    }
}

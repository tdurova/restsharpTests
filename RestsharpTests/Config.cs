using System.Configuration;

namespace RestsharpTests
{
    class Config
    {
        public static string ApplicationMainUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["applicationMainUrl"];
            }
        }

        public static string AppLogin
        {
            get
            {
                return ConfigurationManager.AppSettings["login"];
            }
        }

        public static string AppPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["password"];
            }
        }

        
    }
}

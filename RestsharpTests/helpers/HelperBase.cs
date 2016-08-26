using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using NLog.Targets;
using RestsharpExtension;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpTests.helpers
{
    public class HelperBase
    {
        public string AccessToken { get; set; }
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public RestApi RestApi = new RestApi(RestsharpClient.Client, logger);

        public ResponseToken GetAuthToken(string username, string password)
        {
            var cookieJar = new CookieContainer();
            RestsharpClient.Client.CookieContainer = cookieJar;

            var request = new RestRequest("api/oauth/v2/token", Method.GET);

            request.AddParameter("client_id", Config.ClientId);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("client_secret", Config.ClientSecret);

            var response = RestsharpClient.Client.Execute(request);
            //RestApi.Execute(request);

            var token = JsonConvert.DeserializeObject<ResponseToken>(response.Content);

            return token;
        }

        protected FileTarget GetNLogfilePath()
        {
            LogManager.ThrowExceptions = true;
            //  Find the correct target
            var fileTarget = (FileTarget) LogManager.Configuration.FindTargetByName("fullLog");
            //  Using the target, get the full path to the log file
            var logEventInfo = new LogEventInfo {TimeStamp = DateTime.Now};
            string fileName = fileTarget.FileName.Render(logEventInfo);
            if (!File.Exists(fileName))
                throw new Exception("Log file does not exist.");
            Console.WriteLine(fileName);
            return fileTarget;
        }

        public class ResponseToken
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
            public string refresh_token { get; set; }
        }

        public void Authenticate(IRestRequest request, string accessToken)
        {
            if (accessToken != null && !request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddHeader("Authorization", "Bearer " + accessToken);
            }
        }

        public void Authenticate(IRestClient client, string accessToken)
        {
            if (accessToken != null && !client.DefaultParameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                Parameter clientParameter = new Parameter
                {
                    /*Name = "access_token",
                    Value = accessToken,
                    Type = ParameterType.GetOrPost*/
                    Name = "Authorization",
                    Value = "Bearer " + accessToken,
                    Type = ParameterType.HttpHeader
                };
                client.DefaultParameters.Add(clientParameter);
            }
        }

        public void Deauthenticate(IRestRequest request)
        {
            Parameter parameter = request.Parameters.SingleOrDefault(
                p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

            if (request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.Parameters.Remove(parameter);
            }
        }

        public void Deauthenticate(IRestClient client, List<IRestRequest> requests)
        {
            Parameter parameter1 = client.DefaultParameters.SingleOrDefault(
                p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

            if (client.DefaultParameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                client.DefaultParameters.Remove(parameter1);
                client.DefaultParameters.Clear();
            }

            foreach (var request in requests)
            {
                Parameter parameter2 = request.Parameters.SingleOrDefault(
                p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

                if (request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                {
                    request.Parameters.Remove(parameter2);
                }
            }
        }
    }
}

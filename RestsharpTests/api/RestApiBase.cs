using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NLog;
using Newtonsoft.Json;
using RestSharp;
using ServiceStack;
using ServiceStack.Text;

namespace RestsharpExtension
{
/**
 * От этого класса наследуются классы работы с разными API. Например, с тестируемым.
 * Класс реализован с помощью HTTP REST клиента Restsharp.
 * @link http://restsharp.org/
 **/

    public abstract class RestApiBase
    {
        protected IRestClient _restClient;
        protected ILogger _logger;
       
        protected RestApiBase(IRestClient restClient, ILogger logger)
        {
            _restClient = restClient;
            _logger = logger;
        }

        protected virtual IRestResponse Execute(IRestRequest request)
        {
            IRestResponse response = null;
            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();
                response = _restClient.Execute(request);
                stopWatch.Stop();

                // CUSTOM CODE: Do more stuff here if you need to...

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! " + e);
                // Handle exceptions in your CUSTOM CODE (restSharp will never throw itself)
            }
            finally
            {
                LogRequest(request, response, stopWatch.ElapsedMilliseconds);
            }

            return null;
        }

        protected virtual T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse response = null;
            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();
                response = _restClient.Execute(request);
                stopWatch.Stop();

                // CUSTOM CODE: Do more stuff here if you need to...

                // We can't use RestSharp deserialization because it could throw, and we need a clean response
                // We need to implement our own deserialization.
                var returnType = JsonConvert.DeserializeObject<T>(response.Content);
                return returnType;
            }
            catch (Exception)
            {
                // Handle exceptions in your CUSTOM CODE (restSharp will never throw itself)
                // Handle exceptions in deserialization
            }
            finally
            {
                LogRequest(request, response, stopWatch.ElapsedMilliseconds);
            }

            return default(T);
        }

        private void LogRequest(IRestRequest request, IRestResponse response, long durationMs)
        {
            var sbRequestParameters = new StringBuilder();
            foreach (var param in request.Parameters)
            {
                sbRequestParameters.AppendFormat("{0}: {1}\r\n", param.Name, param.Value);
            }

            _logger.Trace(() =>
            {
                var requestToLog = string.Format(
                    "resource = {0}\n" +
                    "uri = {3}\n" +
                    "method = {2}\n" +
                    "{1}"
                    ,request.Resource, sbRequestParameters, request.Method.ToString(), _restClient.BuildUri(request));

                /*var requestToLog = new
                {
                    resource = request.Resource,
                    // Parameters are custom anonymous objects in order to have the parameter type as a nice string
                    // otherwise it will just show the enum value
                    parameters = sb.ToString(),
                    // ToString() here to have the method as a nice string otherwise it will just show the enum value
                    method = request.Method.ToString(),
                    // This will generate the actual Uri used in the request
                    uri = _restClient.BuildUri(request),
                };*/


                var sbResponseHeaders = new StringBuilder();
                foreach (var param in response.Headers)
                {
                    sbResponseHeaders.AppendFormat("{0}: {1}\r\n", param.Name, param.Value);
                }

                var responseToLog = string.Format(
                    "statusCode = {0}\n" +
                    "{1}" +
                    "responseUri = {2}\n" +
                    "errorMessage = {3}\n" +
                    "content = {4}\n"
                    , response.StatusCode, sbResponseHeaders, response.ResponseUri, response.ErrorMessage, response.Content);

                /*var responseToLog = new
                {
                    statusCode = response.StatusCode,
                    headers = sb2,
                    // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                    responseUri = response.ResponseUri,
                    errorMessage = response.ErrorMessage,
                    content = response.Content
                };*/

                //JsonConvert.SerializeObject
                return string.Format("\r\nRequest completed in {0} ms\r\n" +
                                     "\r\nRequest\r\n{1}" +
                                     "\r\nResponse\r\n{2}",
                    durationMs, requestToLog, responseToLog);
            });
        }
    }
}
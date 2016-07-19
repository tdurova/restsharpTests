using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace RestsharpTests
{
    class RestSchemaValidator
    {
        static readonly string ResourceLocation = typeof(RestSchemaValidator).Namespace;

        public static void ValidateResponse(string resourceFileName, string restResponseContent)
        {
            var resourceFullName = "{0}.{1}".FormatUsing(ResourceLocation, resourceFileName);
            JsonSchema schema;

            // the json file name that is given to this method is stored as a 
            // resource file inside the test project (BuildAction = Embedded Resource)
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFullName))
            using (var reader = new StreamReader(stream))
            using (Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFileName))
            {
                var schematext = reader.ReadToEnd();
                schema = JsonSchema.Parse(schematext);
            }

            var parsedResponse = JObject.Parse(restResponseContent);
            Assert.DoesNotThrow(() => parsedResponse.Validate(schema));
        }
    }
}

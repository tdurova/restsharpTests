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
using StringExtensions;


namespace RestsharpTests
{
    class RestSchemaValidator
    {
        static readonly string ResourceLocation = typeof(RestSchemaValidator).Namespace;

        public static void ValidateResponse(string resourceFileName, string restResponseContent)
        {
            //JSchema schema;

        }
    }
}

using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;
using PayPalHttp;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PaypalProject.Models
{
    public class PayPalClient
    {
        public static PayPalEnvironment environment()
        {
            IOptions<PaypalApiSetting> ps = ServiceLocator.Current.GetInstance<IOptions<PaypalApiSetting>>();            
            return new SandboxEnvironment(ps.Value.ClientID, ps.Value.Secret);
        }

        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(serializableObject.GetType(),
                new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            serializer.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}

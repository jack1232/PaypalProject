using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace PaypalProject.Models
{
    public class RestCleintV1
    {  
        public static IRestClient client(string url)
        {
            string baseUrl = "https://api.sandbox.paypal.com";

            // This is for sandbox test.

            // For live account, change the credentials to live in appsettings.json, and use the following baseUrl:
            // string baseUrl = "https://api.paypal.com
            

            IOptions<PaypalApiSetting> ps = ServiceLocator.Current.GetInstance<IOptions<PaypalApiSetting>>();
            var client = new RestClient(baseUrl + url).UseSerializer(() => new JsonNetSerializer());
            client.Authenticator = new HttpBasicAuthenticator(ps.Value.ClientID, ps.Value.Secret);
            return client;
        }
    }
}

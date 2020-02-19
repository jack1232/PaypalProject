using RestSharp;
using RestSharp.Authenticators;

namespace PayPalSubscriptionNetSdk
{
    public class RestClientV1
    {
        public static string ClientId { get; set; }
        public static string Secret { get; set; }
        public static string BaseUrl { get; set; } = "https://api.sandbox.paypal.com";

        public static IRestClient client(string url)
        {         
            var client = new RestClient(BaseUrl + url).UseSerializer(() => new JsonNetSerializer());
            client.Authenticator = new HttpBasicAuthenticator(ClientId, Secret);
            return client;
        }
    }
}

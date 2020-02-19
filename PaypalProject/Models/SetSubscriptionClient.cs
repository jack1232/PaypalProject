using Microsoft.Extensions.Options;
using PayPalSubscriptionNetSdk;

namespace PaypalProject.Models
{
    public class SetSubscriptionClient
    {
        private readonly static IOptions<PaypalApiSetting> ps = ServiceLocator.Current.GetInstance<IOptions<PaypalApiSetting>>();
        public static void client()
        {
            RestClientV1.ClientId = ps.Value.ClientID;
            RestClientV1.Secret = ps.Value.Secret;
            RestClientV1.BaseUrl = "https://api.sandbox.paypal.com";
        }
    }
}

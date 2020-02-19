using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class LastPaymentDetails
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("amount")]
        public Currency Amount { get; set; }
    }
}

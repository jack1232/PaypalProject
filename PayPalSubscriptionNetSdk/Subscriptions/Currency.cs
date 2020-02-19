using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Currency
    {
        public Currency() { }

        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }
}

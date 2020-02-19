using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Taxes
    {
        public Taxes() { }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
        [JsonProperty("inclusive")]
        public bool Inclusive { get; set; }
    }
}

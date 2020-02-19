using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Frequency
    {
        public Frequency() { }

        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }
        [JsonProperty("interval_count")]
        public int IntervalCount { get; set; }
    }
}

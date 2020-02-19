using Newtonsoft.Json;
using System;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class PricingScheme
    {
        public PricingScheme() { }

        [JsonProperty("fixed_price")]
        public Currency FixedPrice { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; } = "ACTIVE";
        [JsonProperty("version")]
        public int Version { get; set; } = 1;
        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }
        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}

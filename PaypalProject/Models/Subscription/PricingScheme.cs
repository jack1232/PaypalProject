using Newtonsoft.Json;
using System;

namespace PaypalProject.Models.Subscription
{
    public class PricingScheme
    {
        public PricingScheme() { }

        [JsonProperty("fixed_price")]
        public Currency FixedPrice { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }
        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}

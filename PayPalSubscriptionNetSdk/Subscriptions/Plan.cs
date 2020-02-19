using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Plan
    {
        public Plan() { }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlanStatusEnum Status { get; set; }

        [JsonProperty("billing_cycles")]
        public List<BillingCycle> BillingCycles { get; set; }
        [JsonProperty("payment_preferences")]
        public PaymentPreferences PaymentPreferences { get; set; }
        [JsonProperty("taxes")]
        public Taxes Taxes { get; set; }
        [JsonProperty("links")]
        public List<LinkDescriptionObject> Links { get; set; }
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }
        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }
        [JsonProperty("quantity_supported")]
        public bool QuantitySupported { get; set; } = false;
    }
}

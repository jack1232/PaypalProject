using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Subscription
    {
        public Subscription() { }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }
        [JsonProperty("quantity")]
        public string Quantity { get; set; }
        [JsonProperty("shipping_amount")]
        public Currency ShippingAmount { get; set; }
        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionStatusEnum Status { get; set; }

        [JsonProperty("status_change_note")]
        public string StatusChangeNote { get; set; }
        [JsonProperty("status_update_time")]
        public string StatusUpdateTime { get; set; }
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }
        [JsonProperty("links")]
        public List<LinkDescriptionObject> Links { get; set; }
        [JsonProperty("application_context")]
        public ApplicationContext ApplicationContext { get; set; }

[JsonProperty("billing_info")]
public BillingInfo BillingInfo { get; set; }
    }
}

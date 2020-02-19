using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PaypalProject.Models.Subscription
{
    public class Subscription
    {
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
        public string Status { get; set; }
        [JsonProperty("status_update_time")]
        public string StatusUpdateTime { get; set; }        
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }
        [JsonProperty("links")]
        public List<LinkDescriptionObject> Links { get; set; }
        [JsonProperty("application_context")]
        public ApplicationContext ApplicationContext { get; set;}
    }
}

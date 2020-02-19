using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypalProject.Models.Subscription
{
    public class Subscriber
    {
        [JsonProperty("name")]
        public Name Name { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }
}

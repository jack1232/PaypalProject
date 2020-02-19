using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class ShippingAddress
    {
        [JsonProperty("name")]
        public FullName Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}

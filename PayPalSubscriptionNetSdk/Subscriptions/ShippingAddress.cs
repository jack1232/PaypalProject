using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class ShippingAddress
    {
        public ShippingAddress() { }

        [JsonProperty("name")]
        public FullName Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}

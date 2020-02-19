using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class LinkDescriptionObject
    {
        public LinkDescriptionObject() { }

        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("rel")]
        public string Rel { get; set; }
    }
}

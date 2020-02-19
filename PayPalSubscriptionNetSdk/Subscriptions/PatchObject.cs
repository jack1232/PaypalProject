using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class PatchObject
    {
        public PatchObject() { }

        [JsonProperty("op")]
        public string Op { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}

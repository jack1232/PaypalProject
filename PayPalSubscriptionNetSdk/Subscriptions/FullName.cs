using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class FullName
    {
        public FullName() { }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }
    }
}

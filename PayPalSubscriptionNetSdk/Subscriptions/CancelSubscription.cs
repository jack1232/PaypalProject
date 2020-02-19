using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class CancelSubscription
    {
        public CancelSubscription() { }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

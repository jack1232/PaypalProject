using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class CaptureBody
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("capture_type")]
        public string CaptureType { get; set; }

        [JsonProperty("amount")]
        public Currency Amount { get; set; }
    }    
}

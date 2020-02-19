using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class CancelSubscription
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

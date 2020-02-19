using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class PaymentMethod
    {
        public PaymentMethod() { }

        [JsonProperty("payer_selected")]
        public string PayerSelected { get; set; }
        [JsonProperty("payee_preferred")]
        public string PayeePreferred { get; set; }
    }
}

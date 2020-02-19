using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class PaymentMethod
    {
        [JsonProperty("payer_selected")]
        public string PayerSelected { get; set; }
        [JsonProperty("payee_preferred")]
        public string PayeePreferred { get; set; }
    }
}

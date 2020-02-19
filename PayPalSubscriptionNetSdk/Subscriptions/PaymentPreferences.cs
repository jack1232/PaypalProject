using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class PaymentPreferences
    {
        public PaymentPreferences() { }
        [JsonProperty("auto_bill_outstanding")]
        public bool AutoBillOutstanding { get; set; }
        [JsonProperty("setup_fee")]
        public Currency SetupFee { get; set; }

        [JsonProperty("setup_fee_failure_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentPreferencesSetupFeeFailureActionEnum SetupFeeFailureAction { get; set; }

        [JsonProperty("payment_failure_threshold")]
        public int PaymentFailureThreshold { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class FailedPaymentDetails
    {
        [JsonProperty("amount")]
        public Currency Amount { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("reason_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReasonCodeEnum ReasonCode { get; set; }

        [JsonProperty("next_payment_retry_time")]
        public string NextPaymentRetryTime { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class BillingCycle
    {
        public BillingCycle() { }

        [JsonProperty("frequency")]
        public Frequency Frequency { get; set; }

        [JsonProperty("tenure_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BillingCycleTenureTypeEnum TenureType { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }
        [JsonProperty("total_cycles")]
        public int TotalCycles { get; set; }
        [JsonProperty("pricing_scheme")]
        public PricingScheme PricingScheme { get; set; }
    }
}

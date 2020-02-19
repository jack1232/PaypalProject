using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class CycleExecution
    {
        [JsonProperty("tenure_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BillingCycleTenureTypeEnum TenureType { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("cycles_completed")]
        public int CyclesCompleted { get; set; }

        [JsonProperty("cycles_remaining")]
        public int CyclesRemaining { get; set; }

        [JsonProperty("current_pricing_scheme_version")]
        public int CurrentPricingSchemeVersion { get; set; }

        [JsonProperty("total_cycles")]
        public int TotalCycles { get; set; }
    }
}

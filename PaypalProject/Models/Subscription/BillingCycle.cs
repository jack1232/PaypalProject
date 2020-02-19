using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class BillingCycle
    {
        public BillingCycle() { }

        [JsonProperty("frequency")]
        public Frequency Frequency { get; set; }
        [JsonProperty("tenure_type")]
        public string TenureType { get; set; }
        [JsonProperty("sequence")]
        public int Sequence { get; set; }
        [JsonProperty("total_cycles")]
        public int TotalCycles { get; set; }
        [JsonProperty("pricing_scheme")]
        public PricingScheme PricingScheme { get; set; }
    }
}

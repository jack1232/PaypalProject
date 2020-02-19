using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class BillingInfo
    {
        public BillingInfo() { }

        [JsonProperty("outstanding_balance")]
        public Currency OutstandingBalance { get; set; }

        [JsonProperty("cycle_executions")]
        public List<CycleExecution> CycleExecutions { get; set; }

        [JsonProperty("last_payment")]
        public LastPaymentDetails LastPayment { get; set; }

        [JsonProperty("next_billing_time")]
        public string NextBillingTime { get; set; }

        [JsonProperty("final_payment_time")]
        public string FinalPaymentTime { get; set; }

        [JsonProperty("failed_payments_count")]
        public int FailedPaymentsCount { get; set; }

        [JsonProperty("last_failed_payment")]
        public FailedPaymentDetails LastFailedPayment { get; set; }
    }
}

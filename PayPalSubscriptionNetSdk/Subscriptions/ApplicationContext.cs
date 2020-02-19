using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class ApplicationContext
    {
        public ApplicationContext() { }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("shipping_preference")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationContextShippingPreferenceEnum ShippingPreference { get; set; }

        [JsonProperty("user_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationContextUserActionEnum UserAction { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }
}

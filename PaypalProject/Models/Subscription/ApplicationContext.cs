using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class ApplicationContext
    {
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("shipping_preference")]
        public string ShippingPreference { get; set; }
        [JsonProperty("user_action")]
        public string UserAction { get; set; }
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }
}

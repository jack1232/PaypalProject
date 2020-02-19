using Newtonsoft.Json;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class Name
    {
        public Name() { }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}

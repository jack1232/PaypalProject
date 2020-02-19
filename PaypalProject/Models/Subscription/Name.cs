using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class Name
    {
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}

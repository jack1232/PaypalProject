using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class FullName
    {
        [JsonProperty("full_name")]
        public string Fullname { get; set; }
    }
}

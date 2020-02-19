using Newtonsoft.Json;

namespace PaypalProject.Models.Subscription
{
    public class LinkDescriptionObject
    {
        public LinkDescriptionObject() { }

        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("rel")]
        public string Rel { get; set; }
    }
}

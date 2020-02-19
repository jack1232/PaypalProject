using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PaypalProject.Models.Subscription
{
    public class Taxes
    {
        public Taxes() { }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
        [JsonProperty("inclusive")]
        public bool Inclusive { get; set; }
    }
}

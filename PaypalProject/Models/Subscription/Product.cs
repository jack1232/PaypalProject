using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaypalProject.Models.Subscription
{
    public class Product
    {
        public Product() { }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("home_url")]
        public string HomeUrl { get; set; }
        [JsonProperty("links")]
        public List<LinkDescriptionObject> Links { get; set; }
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }
        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }
    }
}

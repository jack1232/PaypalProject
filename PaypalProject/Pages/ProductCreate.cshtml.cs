using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class ProductCreateModel : PageModel
    {
        public string CreateResult { get; set; }
        public string CreateStatus { get; set; }
        public string ProductId { get; set; }       
        public string ListResult { get; set; }
        public string ListStatus { get; set; }

        public void OnPost()
        {
            var res = CreateProduct();
            ProductId = JsonConvert.DeserializeObject<Product>(res.Content).Id;
            CreateStatus = res.StatusCode.ToString();
            CreateResult = res.Content;
        }

        public void OnPostListProduct()
        {
            var res = ProductResponse.ProductsList(20, 1, true);
            ListStatus = res.StatusCode.ToString();
            ListResult = res.Content;
        }

        private IRestResponse CreateProduct()
        {
            var product = new Product
            {
                Name = "Video Streaming Service",
                Description = "Video streaming service",
                Type = ProductTypeEnum.SERVICE,
                Category = ProductCategoryEnum.SOFTWARE,
                ImageUrl = "https://example.com/streaming.jpg",
                HomeUrl = "https://example.com/home"
            };
            return ProductResponse.ProductCreate(product);
        }
    }
}
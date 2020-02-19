using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;
using System.Collections.Generic;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class ProductUpdateModel : PageModel
    {
        public string UpdateResult { get; set; }
        public string UpdateStatus { get; set; }
        public string ProductId { get; set; }
        public string GetResult { get; set; }
        public string GetStatus { get; set; }

        private readonly string id = "PROD-42V77176VN1981152";
        //private readonly string id = "PROD-5G710912G17664450";

        public void OnGet()
        {
            ProductId = id;
        }

        public void OnPost()
        {
            ProductId = id;
            var res = ProductResponse.ProductGet(ProductId);
            GetStatus = res.StatusCode.ToString();
            GetResult = res.Content;
        }

        public void OnPostUpdateProduct()
        {
            ProductId = id;
            var res = PatchProduct(ProductId);
            UpdateStatus = res.StatusCode.ToString();
            if (res.StatusCode.ToString() == "NoContent")
            {
                var res1 = ProductResponse.ProductGet(ProductId);                
                UpdateResult = res1.Content;
            }            
        }

        private IRestResponse PatchProduct(string  productId)
        {
            var patches = new List<PatchObject>()
            {
                new PatchObject()
                {
                    Op = "replace",
                    Path = "/description",
                    Value = "Premium video streaming service"
                }
            };
            return ProductResponse.ProductPatch(ProductId, patches);
        }
    }
}
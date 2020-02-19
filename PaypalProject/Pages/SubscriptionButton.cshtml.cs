using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PaypalProject.Models;
using PayPalSubscriptionNetSdk.Subscriptions;

namespace PaypalProject
{
    public class SubscriptionButtonModel : PageModel
    {
        [BindProperty]
        public SubscriptionViewModel InputModel { get; set; }

        public void OnGet()
        {
            InputModel = new SubscriptionViewModel();
        }

        public void OnPostProduct()
        {
            var res = ProductResponse.ProductCreate(InputModel.CreateProduct(), "representation", "PRODUCT-my-testing15");            
            if(res.IsSuccessful)
            {
                InputModel.ProductId = JsonConvert.DeserializeObject<Product>(res.Content).Id;
                InputModel.ProductStatus = res.StatusCode.ToString();
                InputModel.ProductResult = res.Content;
            }
        }

        public void OnPostPlan()
        {
            var res = PlanResponse.PlanCreate(InputModel.CreatePlan(InputModel.ProductId), "representation", "PLAN-my-testing16");            
            if (res.IsSuccessful)
            {
                InputModel.PlanId = JsonConvert.DeserializeObject<Plan>(res.Content).Id;
                InputModel.PlanStatus = res.StatusCode.ToString();
                InputModel.PlanResult = res.Content;
            }
        }
    }
}
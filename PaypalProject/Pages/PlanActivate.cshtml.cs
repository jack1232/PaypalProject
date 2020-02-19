using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;

namespace PaypalProject
{
    [BindProperties]
    public class PlanActivateModel : PageModel
    {
        public string OriginalStatus { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }                 
               
        private readonly string planId = "P-1C4020999Y123420ULZCGSOI";

        public void OnGet()
        {
            var res = PlanResponse.PlanGet(planId);
            Status = JsonConvert.DeserializeObject<Plan>(res.Content).Status.ToString();
        }


        public void OnPost()
        {
            var res = PlanResponse.PlanGet(planId);
            IRestResponse res1, res2;
            string status1;
            OriginalStatus = JsonConvert.DeserializeObject<Plan>(res.Content).Status.ToString();
            if(OriginalStatus == "ACTIVE")
            {
                res1 = PlanResponse.PlanDeactivate(planId);
                status1 = res1.StatusCode.ToString();
                if (status1 == "NoContent")
                {
                    res2 = PlanResponse.PlanGet(planId);
                    Status = JsonConvert.DeserializeObject<Plan>(res2.Content).Status.ToString();
                    Result = res2.Content;
                }
            }
            else
            {
                res1 = PlanResponse.PlanActivate(planId);
                status1 = res1.StatusCode.ToString();
                if (status1 == "NoContent")
                {
                    res2 = PlanResponse.PlanGet(planId);
                    Status = JsonConvert.DeserializeObject<Plan>(res2.Content).Status.ToString();
                    Result = res2.Content;
                }
            }
        }
    }
}
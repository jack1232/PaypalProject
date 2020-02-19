using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;
using System.Collections.Generic;

namespace PaypalProject
{
    [BindProperties]
    public class PlanUpdateModel : PageModel
    {
        public string UpdateResult { get; set; }
        public string UpdateStatus { get; set; }
        public string PlanId { get; set; }
        public string GetResult { get; set; }
        public string GetStatus { get; set; }

        private readonly string id = "P-1C4020999Y123420ULZCGSOI";

        public void OnGet()
        {
            PlanId = id;
        }

        public void OnPost()
        {
            PlanId = id;
            var res = PlanResponse.PlanGet(PlanId);
            GetStatus = res.StatusCode.ToString();
            GetResult = res.Content;
        }

        public void OnPostUpdatePlan()
        {
            PlanId = id;
            var res = PatchPlan(PlanId);
            UpdateStatus = res.StatusCode.ToString();
            if (res.StatusCode.ToString() == "NoContent")
            {
                var res1 = PlanResponse.PlanGet(PlanId);
                UpdateResult = res1.Content;
            }
        }

        private IRestResponse PatchPlan(string planId)
        {
            var patches = new List<PatchObject>()
            {
                new PatchObject()
                {
                    Op = "replace",
                    Path = "/payment_preferences/payment_failure_threshold",
                    Value = 7 // original Value = 3
                }
            };
            return PlanResponse.PlanPatch(planId, patches);
        }
    }
}
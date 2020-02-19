using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;
using System.Collections.Generic;

namespace PaypalProject
{
    [BindProperties]
    public class SubscriptionUpdateModel : PageModel
    {      
        public string UpdateResult { get; set; }
        public string UpdateStatus { get; set; }
        public string SubscriptionId { get; set; }
        public string GetResult { get; set; }
        public string GetStatus { get; set; }

        private readonly string id = "I-FXM4J9UWR6XL";

        public void OnGet()
        {
            SubscriptionId = id;
        }

        public void OnPost()
        {
            SubscriptionId = id;
            var res = SubscriptionResponse.SubscriptionGet(SubscriptionId);
            GetStatus = res.StatusCode.ToString();
            GetResult = res.Content;
        }

        public void OnPostUpdatePlan()
        {
            SubscriptionId = id;
            var res = PatchSubscription(SubscriptionId);
            UpdateStatus = res.StatusCode.ToString();
            if (res.StatusCode.ToString() == "NoContent")
            {
                var res1 = SubscriptionResponse.SubscriptionGet(SubscriptionId);
                UpdateResult = res1.Content;
            }
        }

        private IRestResponse PatchSubscription(string subId)
        {
            var patches = new List<PatchObject>()
            {
                new PatchObject()
                {
                    Op = "replace",
                    Path = "/status_change_note",
                    Value = "Item out of stock"
                }
            };
            return SubscriptionResponse.SubscriptionPatch(subId, patches);
        }
    }
}
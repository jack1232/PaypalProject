using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayPalSubscriptionNetSdk.Subscriptions;

namespace PaypalProject
{
    [BindProperties]
    public class SubscriptionActivateModel : PageModel
    {
        public string ActivateResult { get; set; }
        public string ActivateStatus { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string SubscriptionId { get; set; }
        public string Error { get; set; }

        public void OnGet()
        {
            //SubscriptionId = "I-N564KWVKM523";
            SubscriptionId = "I-FXM4J9UWR6XL";
            var res = SubscriptionResponse.SubscriptionGet(SubscriptionId);
            Status = res.StatusCode.ToString();
            Result = res.Content;
        }

        public void OnPost()
        {
            var res = SubscriptionResponse.SubscriptionActivate(SubscriptionId);
            ActivateStatus = res.StatusCode.ToString();
            Error = res.ErrorMessage + ", " + res.ErrorException;
            if(ActivateStatus == "NoContent")
            {
                var res1 = SubscriptionResponse.SubscriptionGet(SubscriptionId);
                ActivateResult = res1.Content;
            }
        }
    }
}
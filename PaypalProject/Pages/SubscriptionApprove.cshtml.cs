using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;

namespace PaypalProject
{
    [BindProperties]
    public class SubscriptionApproveModel : PageModel
    {
        public string SubscriptionId { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string ApproveLink { get; set; }

        public void OnGet()
        {
            //SubscriptionId = "I-FXM4J9UWR6XL";
            SubscriptionId = "I-NEX4493J8BLA";
            var res = SubscriptionResponse.SubscriptionGet(SubscriptionId);
            Status = res.StatusCode.ToString();
            Result = res.Content;
        }

        public void OnPost()
        {
            var links = JsonConvert.DeserializeObject<Subscription>(Result).Links;
            foreach(var link in links)
            {
                if(link.Rel == "approve")
                {
                    ApproveLink = link.Href;
                }
            }
        }
    }
}
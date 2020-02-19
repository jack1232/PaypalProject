using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;
using System.Collections.Generic;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class PlanCreateModel : PageModel
    {
        public string CreateResult { get; set; }
        public string CreateStatus { get; set; }
        public string PlanId { get; set; }
        public string ListResult { get; set; }
        public string ListStatus { get; set; }

        private readonly string prodId = "PROD-42V77176VN1981152";
        public void OnPost()
        {
            var res = CreatePlan(prodId);
            PlanId = JsonConvert.DeserializeObject<Plan>(res.Content).Id;
            CreateStatus = res.StatusCode.ToString();
            CreateResult = res.Content;
            /*var res = CreatePlan(prodId);
            CreateResult = JsonConvert.SerializeObject(res);*/
        }

        public void OnPostListProduct()
        {
            var res = PlanResponse.PlansList(prodId, 20, 1, true);
            ListStatus = res.StatusCode.ToString();
            ListResult = res.Content;
        }

        private IRestResponse CreatePlan(string productId)
        //private Plan CreatePlan(string productId)
        {
            var plan = new Plan()
            {
                ProductId = productId,
                Name = "Video Streaming Service Plan",
                Description = "Video Streaming Service basic plan",
                Status = PlanStatusEnum.ACTIVE,
                BillingCycles = new List<BillingCycle>()
                {
                    new BillingCycle()
                    {
                        Frequency = new Frequency()
                        {
                            IntervalUnit = "MONTH",
                            IntervalCount = 1
                        },
                        TenureType = BillingCycleTenureTypeEnum.TRIAL,
                        Sequence = 1,
                        TotalCycles = 1,
                        PricingScheme = new PricingScheme()
                        {
                            FixedPrice = new Currency()
                            {
                                Value = "10",
                                CurrencyCode = "USD"
                            }
                        }
                    },
                    new BillingCycle()
                    {
                        Frequency = new Frequency()
                        {
                            IntervalUnit = "MONTH",
                            IntervalCount = 1
                        },
                        TenureType = BillingCycleTenureTypeEnum.REGULAR,
                        Sequence = 2,
                        TotalCycles = 12,
                        PricingScheme = new PricingScheme()
                        {
                            FixedPrice = new Currency()
                            {
                                Value = "100",
                                CurrencyCode = "USD"
                            }
                        }
                    }
                },
                PaymentPreferences = new PaymentPreferences()
                {
                    AutoBillOutstanding = true,
                    SetupFee = new Currency()
                    {
                        Value = "10",
                        CurrencyCode = "USD"
                    },
                    SetupFeeFailureAction = PaymentPreferencesSetupFeeFailureActionEnum.CONTINUE,
                    PaymentFailureThreshold = 3
                },
                Taxes = new Taxes()
                {
                    Percentage = "10",
                    Inclusive = false
                }
            };
            return PlanResponse.PlanCreate(plan,"representation", "PLAN-1my-testing10");
            //return plan;
        }
    }
}
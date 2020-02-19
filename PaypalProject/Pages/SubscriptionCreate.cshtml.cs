using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class SubscriptionCreateModel : PageModel
    {
        public string CreateResult { get; set; }
        public string CreateStatus { get; set; }
        public string PlanId { get; set; }
        public string SubscriptionId { get; set; }

        public void OnGet()
        {
            PlanId = "P-1C4020999Y123420ULZCGSOI";
        }

        public void OnPost()
        {
            var res = CreateSubscription(PlanId);
            SubscriptionId = JsonConvert.DeserializeObject<Subscription>(res.Content).Id;
            CreateStatus = res.StatusCode.ToString();
            CreateResult = res.Content;
        }

        private IRestResponse CreateSubscription(string planid)
        {
            var subscription = new Subscription()
            {
                PlanId = planid,
                StartTime = "2020-03-01T06:00:00Z",
                ShippingAmount = new Currency
                {
                    Value = "10.00",
                    CurrencyCode = "USD"
                },
                Subscriber = new Subscriber()
                {
                    Name = new Name
                    {
                        GivenName = "John",
                        Surname = "Doe"
                    },
                    EmailAddress = "customer@example.com",
                    ShippingAddress = new ShippingAddress
                    {
                        Name = new FullName
                        {
                            Fullname = "John Doe"
                        },
                        Address = new Address
                        {
                            AddressLine1 = "2211 N First Street",
                            AddressLine2 = "Building 17",
                            AdminArea2 = "San Jose",
                            AdminArea1 = "CA",
                            PostalCode = "95131",
                            CountryCode = "US"
                        }
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    BrandName = "Walmart",
                    Locale = "en-US",
                    ShippingPreference = ApplicationContextShippingPreferenceEnum.SET_PROVIDED_ADDRESS,
                    UserAction = ApplicationContextUserActionEnum.SUBSCRIBE_NOW,
                    PaymentMethod = new PaymentMethod()
                    {
                        PayerSelected = "PAYPAL",
                        PayeePreferred = "IMMEDIATE_PAYMENT_REQUIRED"
                    },
                    ReturnUrl = "https://example.com/returnUrl",
                    CancelUrl = "https://example.com/cancelUrl"
                }
            };

            return SubscriptionResponse.SubscriptionCreate(subscription, "representation", "SUBSCRIPTION-my-testing03");
        }
    }
}
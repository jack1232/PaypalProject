using PaypalProject.Models.Subscription;
using RestSharp;
using System.Collections.Generic;

namespace PaypalProject.Models
{
    public class PlanSample
    {
        public static IRestResponse SuspendSubscription(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/suspend");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new CancelSubscription
            {
                Reason = "Iten out of stock"
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse CancelSubscription(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/cancel");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new CancelSubscription
            {
                Reason = "Not satisfied with the service"
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ActivateSubscription(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse GetSubscription(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/catalogs/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse UpdateSubscription(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/catalogs/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new List<PatchObject>()
            {
                new PatchObject()
                {
                    Op = "replace",
                    Path = "/billing_info/outstanding_balance",
                    Value = new Currency
                    {
                        Value = "50.00",
                        CurrencyCode = "USD"
                    }
                }
            });
            IRestResponse response = client.Execute(request);
            return response;
        }


        public static IRestResponse CreateSubscription(string planId)
        {
            var client = RestCleintV1.client("/v1/billing/subscriptions");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=representation");
            request.AddHeader("PayPal-Request-Id", "SUBSCRIPTION-my-testing01");
            request.AddJsonBody(BuildSubscriptionBody(planId));
            IRestResponse response = client.Execute(request);
            return response;
        }
        private static Subscription.Subscription BuildSubscriptionBody(string planId)
        {
            return new Subscription.Subscription()
            {
                PlanId = planId,
                StartTime = "2020-06-01T06:00:00Z",
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
                    ShippingPreference = "SET_PROVIDED_ADDRESS",
                    UserAction = "SUBSCRIBE_NOW",
                    PaymentMethod = new PaymentMethod()
                    {
                        PayerSelected = "PAYPAL",
                        PayeePreferred = "IMMEDIATE_PAYMENT_REQUIRED"
                    },
                    ReturnUrl = "https://example.com/returnUrl",
                    CancelUrl = "https://example.com/cancelUrl"
                }
            };
        }

        public static IRestResponse GetProduct(string productId)
        {
            var client = RestCleintV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse UpdateProduct(string productId)
        {
            var client = RestCleintV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new List<PatchObject>()
            {
                new PatchObject()
                {
                    Op = "replace",
                    Path = "/description",
                    Value = "Premium video streaming service"
                }
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ListProducts(int pageSize, int page, bool totalRequired)
        {
            var client = RestCleintV1.client($"/v1/catalogs/products?page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse CreateProduct()
        {
            var client = RestCleintV1.client("/v1/catalogs/products");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=representation");
            request.AddHeader("PayPal-Request-Id", "PRODUCT-my-testing01");
            request.AddJsonBody(new Product
            {                
                Name = "Video Streaming Service",
                Description = "Video streaming service",
                Type = "SERVICE",
                Category = "SOFTWARE",
                ImageUrl = "https://example.com/streaming.jpg",
                HomeUrl = "https://example.com/home"
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse UpdatePlanPricing(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId + "/update-pricing-schemes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new List<PricingScheme>() { 
                new PricingScheme()
                {
                    FixedPrice = new Currency()
                    {
                        Value = "50",
                        CurrencyCode = "USD"
                    }                
                }
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse DeactivatePlan(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId + "/deactivate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ActivatePlan(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId +"/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse GetPlan(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PatchPlan(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new List<PatchObject>()
            {
                new PatchObject() {
                    Op = "replace",
                    Path = "/payment_preferences/payment_failure_threshold",
                    Value = 7
                }
            });
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ListPans(string productId, int pageSize, int page, bool totalRequired)
        {
            var client = RestCleintV1.client($"/v1/billing/plans?product_id={productId}&page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");           
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse CreatePlan(string productId)
        {
            var client = RestCleintV1.client("/v1/billing/plans");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=representation");
            request.AddHeader("PayPal-Request-Id", "PLAN-my-testing01");
            request.AddJsonBody(BuildPlanBody(productId));
            IRestResponse response = client.Execute(request);
            return response;
        }

        private static Plan BuildPlanBody(string productId)
        {
            return new Plan()
            {
                ProductId = productId,
                Name = "Video Streaming Service Plan",
                Description = "Video Streaming Service basic plan",
                Status = "Active",
                BillingCycles = new List<BillingCycle>()
                {
                    new BillingCycle()
                    {
                        Frequency = new Frequency()
                        {
                            IntervalUnit = "MONTH",
                            IntervalCount = 1
                        },
                        TenureType = "TRIAL",
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
                        TenureType = "REGULAR",
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
                    SetupFeeFailureAction = "CONTINUE",
                    PaymentFailureThreshold = 3
                },
                Taxes = new Taxes()
                {
                    Percentage = "10",
                    Inclusive = false
                }
            };
        }

    }
}

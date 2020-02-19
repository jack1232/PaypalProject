using PayPalSubscriptionNetSdk.Subscriptions;
using System.Collections.Generic;

namespace PaypalProject.Models
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel() { }

        public string ProductId { get; set; }
        public string ProductStatus { get; set; }
        public string ProductResult { get; set; }
        public string PlanId { get; set; }
        public string PlanStatus { get; set; }
        public string PlanResult { get; set; }

        public Product CreateProduct()
        {
            return new Product()
            {
                Name = "Music Streaming Service",
                Description = "Music streaming service",
                Type = ProductTypeEnum.SERVICE,
                Category = ProductCategoryEnum.SOFTWARE,
                ImageUrl = "https://example.com/streaming.jpg",
                HomeUrl = "https://example.com/home"
            };
        }

        public Plan CreatePlan(string productId)
        {
            return new Plan()
            {
                ProductId = productId,
                Name = "Basic Plan",
                Description = "This is a basic plan",
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
                        TotalCycles = 1                      
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
                                Value = "10",
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
                },
                QuantitySupported = true
            };
        }
    }
}

using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;

namespace PaypalProject.Models
{
    public class OrderDetailViewModel
    {
        public double TotalShippingAndHandling { get; set; }
        public List<Item> TotalItems { get; set; }
        public AmountBreakdown Breakdown { get; set; }
        public double TotalTax { get; set; }
        public List<int> Quantities { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalItemCost { get; set; }
        public double TotalCost { get; set; }
        public OrderRequest Order { get; set; }
        public string Intent { get; set; } = "CAPTURE";

        public OrderDetailViewModel() 
        {
            TotalItems = new List<Item>();
            Breakdown = new AmountBreakdown();
            Quantities = new List<int>() { 1, 1 };
        }

        public void Calculate()
        {           
            TotalShippingAndHandling = 0;
            TotalTax = 0;
            //TotalQuantity = 0;
            TotalItemCost = 0;
            TotalItemCost = 0;

            TotalItems = GetItems();
            Breakdown = GetBreakdown();
            foreach(var item in TotalItems)
            {
                TotalItemCost += double.Parse(item.UnitAmount.Value) * int.Parse(item.Quantity);
                //TotalQuantity += int.Parse(item.Quantity);
                TotalTax += double.Parse(item.Tax.Value) * int.Parse(item.Quantity);
            }
            TotalShippingAndHandling = double.Parse(Breakdown.Shipping.Value) + double.Parse(Breakdown.Handling.Value) 
                                     - double.Parse(Breakdown.ShippingDiscount.Value);
            TotalCost = TotalItemCost + TotalTax + TotalShippingAndHandling;
            Order = GetOrder();
        }

        private List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item
                {
                    Name = "T-shirt",
                    Description = "Green XL",
                    Sku = "sku01",
                    UnitAmount = new Money
                    {
                        CurrencyCode = "USD",
                        Value = "90.00"
                    },
                    Tax = new Money
                    {
                        CurrencyCode = "USD",
                        Value = "10.00"
                    },
                    Quantity = Quantities[0].ToString(),
                    Category = "PHYSICAL_GOODS"
                },
                new Item
                {
                    Name = "Shoes",
                    Description = "Running, Size 10.5",
                    Sku = "sku02",
                    UnitAmount = new Money
                    {
                        CurrencyCode = "USD",
                        Value = "45.00"
                    },
                    Tax = new Money
                    {
                        CurrencyCode = "USD",
                        Value = "5.00"
                    },
                    Quantity = Quantities[1].ToString(),
                    Category = "PHYSICAL_GOODS"
                }
            };
        }
        
        private AmountBreakdown GetBreakdown()
        {
            return new AmountBreakdown
            {
                ItemTotal = new Money
                {
                    CurrencyCode = "USD",                    
                    Value = TotalItemCost.ToString()
                },
                Shipping = new Money
                {
                    CurrencyCode = "USD",
                    Value = "20.00"
                },
                Handling = new Money
                {
                    CurrencyCode = "USD",
                    Value = "10.00"
                },
                TaxTotal = new Money
                {
                    CurrencyCode = "USD",                    
                    Value = TotalTax.ToString()
                },
                ShippingDiscount = new Money
                {
                    CurrencyCode = "USD",
                    Value = "10.00"
                }
            };          
        }

        private OrderRequest GetOrder()
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = Intent.ToUpper(),
                ApplicationContext = new ApplicationContext
                {
                    BrandName = "EXAMPLE INC",
                    LandingPage = "BILLING",
                    CancelUrl = "https://www.example.com",
                    ReturnUrl = "https://www.example.com",
                    UserAction = "CONTINUE",
                    ShippingPreference = "SET_PROVIDED_ADDRESS"
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest{
                        ReferenceId =  "PUHF",
                        Description = "Sporting Goods",
                        CustomId = "CUST-HighFashions",
                        SoftDescriptor = "HighFashions",
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "USD",
                            Value = TotalCost.ToString(),                            
                            AmountBreakdown = Breakdown
                        },
                        Items = TotalItems,
                        ShippingDetail = new ShippingDetail
                        {
                            Name = new Name
                            {
                                FullName = "John Doe"
                            },
                            AddressPortable = new AddressPortable
                            {
                                AddressLine1 = "123 Townsend St",
                                AddressLine2 = "Floor 6",
                                AdminArea2 = "San Francisco",
                                AdminArea1 = "CA",
                                PostalCode = "94107",
                                CountryCode = "US"
                            }
                        }
                    }
                }
            };
            return orderRequest;
        }
    }
}

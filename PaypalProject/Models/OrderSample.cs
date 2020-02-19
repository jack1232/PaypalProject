using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaypalProject.Models
{
    public class OrderSample
    {
        #region authorize order
        public async static Task<HttpResponse> AuthorizeOrder(string OrderId)
        {
            var request = new OrdersAuthorizeRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new AuthorizeRequest());
            var response = await PayPalClient.client().Execute(request);

            // Add code here to process the response results on server.
            // for example, you can extract the authorization ID and store it to database.

            return response;
        }

        public async static Task<HttpResponse> CaptureAuthorizedOrder(string AuthorizationId)
        {
            var request = new PayPalCheckoutSdk.Payments.AuthorizationsCaptureRequest(AuthorizationId);
            request.Prefer("return=representation");
            request.RequestBody(new PayPalCheckoutSdk.Payments.CaptureRequest());
            var response = await PayPalClient.client().Execute(request);
            return response;
        }

        #endregion authorize order

        #region capture refund
        public async static Task<HttpResponse> CapturesRefundWithOrderId(string orderId, string refundAmount)
        {
            var captureId = GetOrder(orderId).Result.Result<Order>().PurchaseUnits[0].Payments.Captures[0].Id;
            return await CapturesRefund(captureId, refundAmount);
        }

        public async static Task<HttpResponse> CapturesRefund(string captureId, string refundAmount)
        {
            var request = new PayPalCheckoutSdk.Payments.CapturesRefundRequest(captureId);
            request.Prefer("return=representation");
            var refundRequest = new PayPalCheckoutSdk.Payments.RefundRequest()
            {
                Amount = new PayPalCheckoutSdk.Payments.Money
                {
                    Value = refundAmount,
                    CurrencyCode = "USD"
                }
            };
            request.RequestBody(refundRequest);
            var response = await PayPalClient.client().Execute(request);

            return response;
        }
        #endregion capture refund


        #region patch order
        public async static Task<HttpResponse> PatchOrder(string orderId)
        {
            var request = new OrdersPatchRequest<Object>(orderId);
            request.RequestBody(BuildPatchRequest());
            var response = await PayPalClient.client().Execute(request);
            return response;
        }

        private static List<Patch<Object>> BuildPatchRequest()
        {
            var patches = new List<Patch<Object>>
             {
                 new Patch<Object>
                 {
                     Op= "replace",
                     Path= "/intent",
                     Value= "CAPTURE"

                 },
                 new Patch<Object>
                 {
                     Op= "replace",
                     Path= "/purchase_units/@reference_id=='PUHF'/description",
                     Value= "Physical Goods"

                 }
             };
            return patches;
        }
        #endregion patch order

        #region capture order
        public async static Task<HttpResponse> CaptureOrder(string OrderId)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            var response = await PayPalClient.client().Execute(request);

            // Add code here to process the response results on server.
            // for example, you can extract the order ID and buyer's information and store them to database.

            return response;
        }
        #endregion capture order

        #region get order

        public async static Task<HttpResponse> GetNewOrder(bool isMiniOrder)
        {
            HttpResponse response;
            if (isMiniOrder) response = await CreateOrderWithMinimumFields("capture");
            else response = await CreateOrder("capture", 1, 2);
            return await GetOrder(response.Result<Order>().Id);
        }

        public async static Task<HttpResponse> GetOrder(string orderId)
        {
            var request = new OrdersGetRequest(orderId);
            var response = await PayPalClient.client().Execute(request);
            return response;
        }
        #endregion get order

        #region capture intent order

        public async static Task<HttpResponse> CreateOrderWithMinimumFields(string intent, string amount = "0.01")
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBodyWithMinimumFields(intent, amount));
            var response = await PayPalClient.client().Execute(request);

            return response;
        }

        private static OrderRequest BuildRequestBodyWithMinimumFields(string intent, string amount)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = intent.ToUpper(),
                ApplicationContext = new ApplicationContext
                {
                    CancelUrl = "https://www.example.com",
                    ReturnUrl = "https://www.example.com"
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest{
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "USD",
                            Value = amount
                        }
                    }
                }
            };

            return orderRequest;
        }

        public async static Task<HttpResponse> CreateOrder(string intent, int quantity0, int quantity1)
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBody(intent, quantity0, quantity1));
            var response = await PayPalClient.client().Execute(request);
            return response;
        }

        public static OrderRequest BuildRequestBody(string intent, int quantity0, int quantity1)
        {
            var items = GetItems(quantity0, quantity1);
            double totalTax = 0;
            double totalItemCost = 0;
            foreach (var item in items)
            {
                totalItemCost += double.Parse(item.UnitAmount.Value) * int.Parse(item.Quantity);
                totalTax += double.Parse(item.Tax.Value) * int.Parse(item.Quantity);
            }
            var breakdown = GetBreakdown(totalItemCost, totalTax);
            var totalShippingAndHandling = double.Parse(breakdown.Shipping.Value) + double.Parse(breakdown.Handling.Value)
                                        - double.Parse(breakdown.ShippingDiscount.Value);
            var totalCost = totalItemCost + totalTax + totalShippingAndHandling;

            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = intent.ToUpper(),
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
                    Value = totalCost.ToString(),
                    AmountBreakdown = breakdown
                },
                Items = items,
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

        private static List<Item> GetItems(int q0, int q1)
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
            Quantity = q0.ToString(),
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
            Quantity = q1.ToString(),
            Category = "PHYSICAL_GOODS"
        }
    };
        }

        private static AmountBreakdown GetBreakdown(double totalItemCost, double totalTax)
        {
            return new AmountBreakdown
            {
                ItemTotal = new Money
                {
                    CurrencyCode = "USD",
                    Value = totalItemCost.ToString()
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
                    Value = totalTax.ToString()
                },
                ShippingDiscount = new Money
                {
                    CurrencyCode = "USD",
                    Value = "10.00"
                }
            };
        }
        #endregion capture intent order
    }
}

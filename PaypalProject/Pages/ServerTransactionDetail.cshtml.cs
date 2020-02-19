using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayPalCheckoutSdk.Orders;
using PaypalProject.Models;
using System.Collections.Generic;

namespace PaypalProject.Pages
{
    public class ServerTransactionDetailModel : PageModel
    {
        [BindProperty]
        public InputViewModel Input { get; set; }

        public void OnGet()
        {
            Input = new InputViewModel();
            Input.Update();
        }

        public void OnPost()
        {
            Input.Update();
        }

        public class InputViewModel
        {
            public List<int> Quantities { get; set; }

            public OrderRequest Order { get; set; }
            public double TotalShippingAndHandling { get; set; }           
            public double TotalTax { get; set; }            
            public double TotalItemCost { get; set; }
            public double TotalCost { get; set; }

            public InputViewModel()
            {
                Quantities = new List<int>() { 1, 1 };
            }

            public void Update()
            {
                Order = OrderSample.BuildRequestBody("CAPTURE", Quantities[0], Quantities[1]);
                TotalCost = double.Parse(Order.PurchaseUnits[0].AmountWithBreakdown.Value);
                var breakdown = Order.PurchaseUnits[0].AmountWithBreakdown.AmountBreakdown;
                TotalShippingAndHandling = double.Parse(breakdown.Shipping.Value) +
                    double.Parse(breakdown.Handling.Value) -
                    double.Parse(breakdown.ShippingDiscount.Value);
                TotalTax = double.Parse(breakdown.TaxTotal.Value);
                TotalItemCost = double.Parse(breakdown.ItemTotal.Value);
            }
        }
    }    
}
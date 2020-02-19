using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace PaypalProject.Pages
{
    public class JsTransactionDetailModel : PageModel
    {
        [BindProperty]
        public InputViewModel Input { get; set; }

        public void OnGet()
        {
            List<Product> Products = new List<Product>();
            Products.Add(new Product
            {
                Name = "T-Shirt",
                Description = "Blue, XL",
                SKU = "SKU01",
                UnitPrice = 55.99M,
                Quantity = 1
            });
            Products.Add(new Product
            {
                Name = "Shoes",
                Description = "Running Shoes, Size 9.5",
                SKU = "SKU01",
                UnitPrice = 101.99M,
                Quantity = 1
            });

            Input = new InputViewModel
            {
                Products = Products,
                ShippingCost = 12.5M,
                HandlingCost = 7.8M,
                TaxRate = 0.085M
            };
        }

        public void OnPost()
        {
            Input.Calculate();
            //ViewData["products"] = Input.Products;
        }

        public class InputViewModel
        {
            public List<Product> Products { get; set; }
            public decimal ShippingCost { get; set; }
            public decimal HandlingCost { get; set; }
            public decimal ShippingAndHandlingCost { get; set; }
            public decimal TaxRate { get; set; }
            public bool isTaxableOnShippingHandling { get; set; } = false;
            public decimal TotalTax { get; set; }
            public int TotalQuantity { get; set; } = 0;
            public decimal TotalProductCost { get; set; }
            public decimal TotalCost { get; set; }

            public InputViewModel()
            {
                Products = new List<Product>();
            }
            public void Calculate()
            {
                foreach (var p in Products)
                {
                    TotalProductCost += p.UnitPrice * p.Quantity;
                    TotalQuantity += p.Quantity;
                }
                var cost = TotalProductCost + ShippingCost + HandlingCost;
                TotalTax = isTaxableOnShippingHandling ? TaxRate * cost : TaxRate * TotalProductCost;
                ShippingAndHandlingCost = ShippingCost + HandlingCost;
                TotalCost = cost + TotalTax;
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string SKU { get; set; }
            public decimal UnitPrice { get; set; } = 0;
            public int Quantity { get; set; } = 1;
        }
    }
}
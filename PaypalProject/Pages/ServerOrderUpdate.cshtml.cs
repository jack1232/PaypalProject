using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using PaypalProject.Models;
using System.Threading.Tasks;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class ServerOrderUpdateModel : PageModel
    {        

        public string OrderId { get; set; }
        public string OriginalResult { get; set; }
        public string Status { get; set; }
        public string UpdatedResult { get; set; }
        
        public async Task OnGetAsync()
        {
            /*var response = await OrderSample.CreateOrder("authorize", "1,2,20,180,220");
            OriginalResult = JsonConvert.SerializeObject(response.Result<Order>());
            OrderId = response.Result<Order>().Id;*/
        }

        public async Task OnPostAsync()
        {            
            var res = await OrderSample.PatchOrder(OrderId);
            Status = JsonConvert.SerializeObject(res.StatusCode) == "204" ? "Update successfully." : "Update failed.";
            var response = await OrderSample.GetOrder(OrderId);
            UpdatedResult = JsonConvert.SerializeObject(response.Result<Order>());            
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Payments;
using PaypalProject.Models;
using System.Threading.Tasks;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class ServerCaptureAuthorizeModel : PageModel
    {
        public string AuthorizationId { get; set; }
        public string ResponseResult { get; set; }

        public void OnGet()
        {
            AuthorizationId = null;
            ResponseResult = null;
        }
        public async Task OnPostAsync()
        {
            var response = await OrderSample.CaptureAuthorizedOrder(AuthorizationId);
            ResponseResult = JsonConvert.SerializeObject(response.Result<Capture>());
        }
    }
}
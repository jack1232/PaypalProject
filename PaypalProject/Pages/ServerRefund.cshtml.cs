using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Payments;
using PaypalProject.Models;
using System.Threading.Tasks;

namespace PaypalProject.Pages
{
    [BindProperties]
    public class ServerRefundModel : PageModel
    {
        public string CaptureId { get; set; }
        public string OrderId { get; set; }
        public string AmountCapture { get; set; }
        public string AmountOrder { get; set; }
        public string Result { get; set; }

        public void OnGet()
        {
            CaptureId = "0N7362667M311843J";
            OrderId = "7UH61628XA245370J";
            AmountCapture = "10.00";
            AmountOrder = "10.00";
        }

        public async Task OnPostAsync()
        {
            var res = await OrderSample.CapturesRefund(CaptureId, AmountCapture);
            Result = JsonConvert.SerializeObject(res.Result<Refund>());
            OrderId = "7UH61628XA245370J";
            AmountOrder = "10.00";
        }

        public async Task OnPostOrderIdAsync()
        {
            var res = await OrderSample.CapturesRefundWithOrderId(OrderId, AmountOrder);
            Result = JsonConvert.SerializeObject(res.Result<Refund>());
            CaptureId = "0N7362667M311843J";
            AmountCapture = "10.00";
        }
    }
}
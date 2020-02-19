using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using PaypalProject.Models;
using System.Threading.Tasks;

namespace PaypalProject.Controllers
{
    public class PayPalWebApi : Controller
    {
        [Route("~/api/AuthorizeOrder/{orderId}")]
        [HttpPost]        
        public async Task<string> AuthorizeOrder(string orderId)
        {
            var response = await OrderSample.AuthorizeOrder(orderId);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/CaptureRefund/{captureId}/{refundAmount}")]
        [HttpPost]
        public async Task<string> CaptureRefund(string captureId, string refundAmount)
        {
            var response = await OrderSample.CapturesRefund(captureId, refundAmount);
            var res = response.Result<Refund>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/PatchOrder/{orderId}")]
        [HttpPatch]
        public async Task<string> PatchOrder(string orderId)
        {
            var response = await OrderSample.PatchOrder(orderId);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/GetNewOrder/{isMiniOrder}")]
        [HttpGet]
        public async Task<string> GetNewOrder(bool isMiniOrder)
        {
            var response = await OrderSample.GetNewOrder(isMiniOrder);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/GetOrder/{orderId}")]
        [HttpGet]
        public async Task<string> GetOrder(string orderId)
        {
            var response = await OrderSample.GetOrder(orderId);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        /*[Route("~/api/CreateOrder/{intent}/{args}")]
        [HttpPost]
        public async Task<string> CreateOrder(string intent, string args)
        {
            var response = await OrderSample.CreateOrder(intent, args);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }*/

        [Route("~/api/CreateOrder/{intent}/{quantity0}/{quantity1}")]
        [HttpPost]
        public async Task<string> CreateOrder(string intent, int quantity0, int quantity1)
        {
            var response = await OrderSample.CreateOrder(intent, quantity0, quantity1);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/CaptureOrder/{orderId}")]
        [HttpPost]
        public async Task<string> CaptureOrder(string orderId)
        {
            var response = await OrderSample.CaptureOrder(orderId);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

        [Route("~/api/CreateMinimumOrder/{intent}/{amount}")]
        [HttpPost]
        public async Task<string> CreateMinimumOrder(string intent, string amount)
        {
            var response = await OrderSample.CreateOrderWithMinimumFields(intent, amount);
            var res = response.Result<Order>();
            var json = JsonConvert.SerializeObject(res);
            return json;
        }

    }
}

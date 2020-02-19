using RestSharp;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class SubscriptionResponse
    {
        public static IRestResponse SubscriptionCreate(Subscription subscription, string prefer = "representation", string paypalRequestId = "SUBSCRIPTION-my-testing01")
        {
            var client = RestClientV1.client("/v1/billing/subscriptions");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=" + prefer);
            request.AddHeader("PayPal-Request-Id", paypalRequestId);
            request.AddJsonBody(subscription);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionPatch(string subscriptionId, List<PatchObject> patchObjects)
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionGet(string subscriptionId)
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionActivate(string subscriptionId)
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId + "/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionCancel(string subscriptionId, CancelSubscription cancel)
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId + "/cancel");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(cancel);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionSuspend(string subscriptionId, CancelSubscription suspend)
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId + "/suspend");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(suspend);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionTransactionsList(string subscriptionId, string startTime, string endTime) 
        {
            var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId + 
                "/transactions?start_time=" + startTime + "&end_time=" + endTime);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

public static IRestResponse SubscriptionCapture(string subscriptionId, CaptureBody capture)
{
    var client = RestClientV1.client("/v1/billing/subscriptions/" + subscriptionId + "/capture");
    var request = new RestRequest(Method.POST);
    request.AddHeader("Content-Type", "application/json");
    request.AddJsonBody(capture);
    IRestResponse response = client.Execute(request);
    return response;
}
    }
}

using RestSharp;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class PlanResponse
    {
        public static IRestResponse PlanCreate(Plan plan, string prefer = "representation", string paypalRequestId = "PLAN-my-testing01")
        {
            var client = RestClientV1.client("/v1/billing/plans");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=" + prefer);
            request.AddHeader("PayPal-Request-Id", paypalRequestId);
            request.AddJsonBody(plan);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlansList(string productId, int pageSize, int page, bool totalRequired)
        {
            var client = RestClientV1.client($"/v1/billing/plans?product_id={productId}&page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanPatch(string planId, List<PatchObject> patchObjects)
        {
            var client = RestClientV1.client("/v1/billing/plans/" + planId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanGet(string planId)
        {
            var client = RestClientV1.client("/v1/billing/plans/" + planId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanActivate(string planId)
        {
            var client = RestClientV1.client("/v1/billing/plans/" + planId + "/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanDeactivate(string planId)
        {
            var client = RestClientV1.client("/v1/billing/plans/" + planId + "/deactivate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanPricingUpdate(string planId, List<PricingScheme> pricingSchemes)
        {
            var client = RestClientV1.client("/v1/billing/plans/" + planId + "/update-pricing-schemes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(pricingSchemes);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}

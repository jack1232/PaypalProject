using RestSharp;
using System.Collections.Generic;

namespace PaypalProject.Models.Subscription
{
    public class GetRestResponse
    {
        public static IRestResponse ProductCreate(Product product, string prefer = "representation", string requestId = "PRODUCT-my-testing01")
        {
            var client = RestCleintV1.client("/v1/catalogs/products");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=" + prefer);
            request.AddHeader("PayPal-Request-Id", requestId);
            request.AddJsonBody(product);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductsList(int pageSize, int page, bool totalRequired)
        {
            var client = RestCleintV1.client($"/v1/catalogs/products?page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductPatch(string productId, List<PatchObject> patchObjects)
        {
            var client = RestCleintV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductGet(string productId)
        {
            var client = RestCleintV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanCreate(Plan plan, string prefer = "representation", string requestId = "PLAN-my-testing01")
        {
            var client = RestCleintV1.client("/v1/billing/plans");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=" + prefer);
            request.AddHeader("PayPal-Request-Id", requestId);
            request.AddJsonBody(plan);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PansList(string productId, int pageSize, int page, bool totalRequired)
        {
            var client = RestCleintV1.client($"/v1/billing/plans?product_id={productId}&page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanPatch(string planId, List<PatchObject> patchObjects)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanGet(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanActivate(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId + "/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanDeactivate(string planId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId + "/deactivate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse PlanPricingUpdate(string planId, List<PricingScheme> pricingSchemes)
        {
            var client = RestCleintV1.client("/v1/payments/billing/plans/" + planId + "/update-pricing-schemes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(pricingSchemes);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionCreate(Subscription subscription)
        {
            var client = RestCleintV1.client("/v1/billing/subscriptions");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=representation");
            request.AddHeader("PayPal-Request-Id", "SUBSCRIPTION-my-testing01");
            request.AddJsonBody(subscription);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionPatch(string subscriptionId, List<PatchObject> patchObjects)
        {
            var client = RestCleintV1.client("/v1/catalogs/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionGet(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/catalogs/subscriptions/" + subscriptionId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionActivate(string subscriptionId)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/activate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionCancel(string subscriptionId, CancelSubscription cancel)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/cancel");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(cancel);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse SubscriptionSuspend(string subscriptionId, CancelSubscription suspend)
        {
            var client = RestCleintV1.client("/v1/payments/billing/subscriptions/" + subscriptionId + "/suspend");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(suspend);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}

using RestSharp;
using System.Collections.Generic;

namespace PayPalSubscriptionNetSdk.Subscriptions
{
    public class ProductResponse
    {
        public static IRestResponse ProductCreate(Product product, string prefer = "representation", string paypalRequestId = "PRODUCT-my-testing01")
        {
            var client = RestClientV1.client("/v1/catalogs/products");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Prefer", "return=" + prefer);
            request.AddHeader("PayPal-Request-Id", paypalRequestId);
            request.AddJsonBody(product);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductsList(int pageSize, int page, bool totalRequired)
        {
            var client = RestClientV1.client($"/v1/catalogs/products?page_size={pageSize}&page={page}&total_required={totalRequired}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductPatch(string productId, List<PatchObject> patchObjects)
        {
            var client = RestClientV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(patchObjects);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static IRestResponse ProductGet(string productId)
        {
            var client = RestClientV1.client("/v1/catalogs/products/" + productId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypalProject.Models.Subscription.Requests
{
    public class ProductCreateRequest : RestRequest
    {
        public ProductCreateRequest() : base("/v1/catalogs/products")
        {

        }
    }
}

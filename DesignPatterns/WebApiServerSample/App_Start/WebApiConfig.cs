using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using WebApiServerSample.Models;

namespace WebApiServerSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



            
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<StockDeal>("StockDeals");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

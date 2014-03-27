using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Store.API.Model;

namespace Store.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Enable Cross Origin Resource Sharing
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            #region Custom Routing Constraint Route

            config.Routes.MapHttpRoute(
                name: "CustomRoutingStyleApi",
                routeTemplate: "cr/{controller}/{country}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new
                {
                    country = new CountryValuesListConstraint("in", "fr", "au"),
                    //model = new CountryValuesListConstraintDI((IModelValues)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ICountryValues))),
                    action = "PhoneList",
                    controller = "PhonesRpc"
                });

            #endregion

            config.Routes.MapHttpRoute(
                name: "RpcStyleApi",
                routeTemplate: "rpc/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                //routeTemplate: "api/{orgid}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                //, constraints: new { orgid = @"\d+" }
            );
        }
    }
}

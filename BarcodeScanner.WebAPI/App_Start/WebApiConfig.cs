using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;

namespace BarcodeScanner.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiCustom",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { action = new RegexRouteConstraint(@"[a-zA-Z]+[a-zA-Z0-9]*") }
                );

            config.Routes.MapHttpRoute(
                name: "ApiGet",
                routeTemplate: "{controller}/{id}",
                defaults: new {action = "Get", id = RouteParameter.Optional},
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );

            config.Routes.MapHttpRoute(
                name: "ApiCreate",
                routeTemplate: "{controller}",
                defaults: new {action = "Create" },
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Post)}
                );

            config.Routes.MapHttpRoute(
                name: "ApiUpdate",
                routeTemplate: "{controller}/{id}",
                defaults: new {action = "Update", id = RouteParameter.Optional},
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Put)}
                );

            config.Routes.MapHttpRoute(
                name: "ApiDelete",
                routeTemplate: "{controller}/{id}",
                defaults: new {action = "Delete"},
                constraints: new {httpMethod = new HttpMethodConstraint(HttpMethod.Delete), id = @"\d+" }
                );
        }
    }
}

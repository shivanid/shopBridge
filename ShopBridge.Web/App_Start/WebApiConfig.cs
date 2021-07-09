using System.Web.Http;
using ShopBridge.Application.ProductAction;
using ShopBridge.Web.Controllers;
using Unity;

namespace ShopBridge.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IProductAction, ProductAction>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}

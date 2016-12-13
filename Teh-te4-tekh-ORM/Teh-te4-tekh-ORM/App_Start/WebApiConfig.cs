namespace Teh_te4_tekh_ORM
{
    using MessageHandlers;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using Microsoft.Practices.Unity;
    using Orm.Data.Implementations;
    using Orm.Data.Interfaces;
    using Services;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            UnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);

            config.MessageHandlers.Add(new MethodOverrideHandler());
        }
    }
}
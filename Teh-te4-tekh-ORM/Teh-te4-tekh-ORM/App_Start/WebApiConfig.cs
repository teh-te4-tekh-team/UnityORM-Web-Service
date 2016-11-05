using Teh_te4_tekh_ORM.MessageHandlers;

namespace Teh_te4_tekh_ORM
{
    using System.Net.Http.Headers;
    using System.Web.Http;

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

            config.MessageHandlers.Add(new MethodOverrideHandler());
/*
            config.Routes.MapHttpRoute(
                name: "GetGameUser",
                routeTemplate: "api/GameUser/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CreateGameUser",
                routeTemplate: "api/GameUser"
            );*/
        }
    }
}

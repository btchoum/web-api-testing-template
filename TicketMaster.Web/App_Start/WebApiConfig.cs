using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace TicketMaster.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Remove XML Formatter
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            // CamelCase JSON results
            var json = config.Formatters.JsonFormatter;
#if DEBUG
            json.Indent = true;
#endif
            json.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

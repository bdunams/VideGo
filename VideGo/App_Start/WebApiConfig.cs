using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace VideGo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new QueryStringMapping("json", "true", "application/json"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DataMartApp.App_Start
{
    public class WebApiConfig
    {


        public static void RegisterRoutes(HttpConfiguration config)
        {

            
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());


            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

     

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "textSearch",
                routeTemplate: "test/{controller}/{action}/{text}",
                defaults: new { text = RouteParameter.Optional }
                );
        }
    }
}
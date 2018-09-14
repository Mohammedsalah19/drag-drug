using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiContrib.Formatting.Jsonp;
namespace WepApi
{

    public class CustomJsonFormatter : JsonMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("Text/html"));
        }


        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }


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


            // this for remove json and preview xml only 
            config.Formatters.Remove(config.Formatters.XmlFormatter);



            # region this for share api to differant projects which have different port


            //  this for jsonp
            //     var jsonpformatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //  config.Formatters.Insert(0, jsonpformatter);


            // this for cors to deffirant origin
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            #endregion

            // this for move from http tp https
            //    config.Filters.Add(new REquiredHttpsAttribute());

            // enable out attribut on controller
            config.MapHttpAttributeRoutes();
            
        }
    }
}

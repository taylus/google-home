using System.Web.Http;
using System.Net.Http.Headers;

namespace GoogleAssistantWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //route using RouteAttributes set on controllers/actions
            config.MapHttpAttributeRoutes();

            //make JSON the default response for requests w/ Accept: text/html headers (e.g. web browsers)
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
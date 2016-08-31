using System.Web.Http;
using log4net.Config;

namespace ImplementingDIandLogger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
            XmlConfigurator.Configure();


            //WebHook initialization
            config.InitializeReceiveBitbucketWebHooks();
        }
    }
}
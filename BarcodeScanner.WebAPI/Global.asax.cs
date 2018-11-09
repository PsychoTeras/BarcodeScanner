using System.Web;
using System.Web.Http;

namespace BarcodeScanner.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureApi(GlobalConfiguration.Configuration);
        }

        void ConfigureApi(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}

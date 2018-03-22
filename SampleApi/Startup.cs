using Owin;
using System.Web.Http;

namespace SampleApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration _config;

            _config = new HttpConfiguration();
            _config.MapHttpAttributeRoutes();
            _config.Formatters.Remove(_config.Formatters.XmlFormatter);

            app.UseWebApi(_config);
        }
    }
}
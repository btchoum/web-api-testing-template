using Owin;
using System.Net;
using System.Web.Http;
using TicketMaster.Web;

namespace TicketMaster.Tests.Integration
{
    /// <summary>
    /// This class sets up the Web Api configuration.
    /// it uses the WebApiConfig class from the production project
    /// </summary>
    public class TestAppStartup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);
            EnableWindowsAuthentication(appBuilder);
        }   

        private void EnableWindowsAuthentication(IAppBuilder appBuilder)
        {
            if (appBuilder.Properties.ContainsKey("System.Net.HttpListener"))
            {
                var listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
                listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
            }
        }
    }
}

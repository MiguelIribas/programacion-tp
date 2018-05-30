using Microsoft.Owin;
using Owin;

[assembly:OwinStartup(typeof(TrabajoPractico.Web.Clases.Startup))]
namespace TrabajoPractico.Web.Clases
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }

    }
}
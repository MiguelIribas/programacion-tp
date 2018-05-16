using Owin;

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
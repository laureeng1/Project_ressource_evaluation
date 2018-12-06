using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EVALUATION.WEB.Startup))]

namespace EVALUATION.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            app.UseReportProviders()
            .AddSsrsReportHost("local",  "http://localhost/ReportServer");
        }
    }
}

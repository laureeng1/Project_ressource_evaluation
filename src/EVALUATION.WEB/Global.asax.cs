using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EVALUATION.WEB.Models.Notification;

namespace EVALUATION.WEB
{
    public class MvcApplication : HttpApplication
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Start SqlDependency with application initialization
            //SqlDependency.Start(_connString);

           // NotificationComponent.GetNotificationRecords();
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{
        //     //NC = new NotificationComponent();
        //    var currentTime = DateTime.Now;
        //    HttpContext.Current.Session["LastUpdated"] = currentTime;
        //    NotificationComponent.GetNotificationRecords();
        //}

        protected void Application_End()
        {
            //Stop the sqlDependency
            SqlDependency.Stop(_connString);
        }
    }    
}

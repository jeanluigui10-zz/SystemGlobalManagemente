using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace System_Maintenance
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                var app = (HttpApplication)sender;
                Exception lastError = app.Server.GetLastError();
                var httpEx = lastError as HttpException;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
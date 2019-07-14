using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace xSystem_Maintenance.src.app_code
{
    public class Config
    {
        public static String LogoutRedirect = "~/private/security/login.aspx";
        public static String DistributorPhysicalPath { get { return WebConfigurationManager.AppSettings["dpPath"]; } }
        public static String UrlPageDefault { get { return WebConfigurationManager.AppSettings["UrlPageDefault"]; } }
        
    }
}
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
        public static String UrlPageDefault { get { return WebConfigurationManager.AppSettings["UrlPageDefault"]; } }

        public static string DistributorPhysicalPath { get { return WebConfigurationManager.AppSettings["dpPath"]; } }
        public static string EnterprisePhysicalPath { get { return WebConfigurationManager.AppSettings["epPath"]; } }
        public static string DistributorVirtualPath { get { return WebConfigurationManager.AppSettings["dvPath"]; } }
        public static string EnterpriseVirtualPath { get { return WebConfigurationManager.AppSettings["evPath"]; } }
        public static String RedirectChatModule { get { return HttpUtility.UrlDecode(WebConfigurationManager.AppSettings["Domain_ChatModule"]); } }
        public static String ChatModuleId { get { return HttpUtility.UrlDecode(WebConfigurationManager.AppSettings["ChatModuleId"]); } }
        public static string Impremtawendomain { get { return WebConfigurationManager.AppSettings["impremtawendomain"]; } }
        public static string impremtawendomainReview { get { return WebConfigurationManager.AppSettings["impremtawendomainReview"]; } }
        
    }
}
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using xAPI.Entity;
using xAPI.Library.General;
using xAPI.Entity.Security;

namespace xSystem_Maintenance.src.app_code
{
    public class BaseSession
    {
        /*
         
        public static [TIPO_SESION] [NOMBRE_SESION_USO]
        {
            get { return clsExtension.GetSession<[TIPO_SESION]>("[NOMBRE_SESION]"); }
            set { HttpContext.Current.Session["[NOMBRE_SESION]"] = value; }
        }
         
        */
        public static String SsTheme
        {
            get { return clsExtension.GetSession<String>("User_Theme"); }
            set { HttpContext.Current.Session["User_Theme"] = value; }
        }
        public static DataTable SsCommission
        {
            get { return clsExtension.GetSession<DataTable>("dtCommission"); }
            set { HttpContext.Current.Session["dtCommission"] = value; }
        }

        public static Usuario SsUser
        {
            get { return clsExtension.GetSession<Usuario>("User_xCorporate") ?? RedirectUser<Usuario>(); }
            set { HttpContext.Current.Session["User_xCorporate"] = value; }
        }

        public static String SsCaptchaText
        {
            get { return clsExtension.GetSession<String>("CaptchaImageText_xCorporate"); }
            set { HttpContext.Current.Session["CaptchaImageText_xCorporate"] = value; }
        }
        private static T RedirectUser<T>()
        {
            Logout();
            HttpContext.Current.Response.Redirect(Config.LogoutRedirect + "?back_url=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri));
            return default(T);
        }

        //public static clsOrdersHeader SsOrderPlacexCorporate
        //{
        //    get { return clsExtension.GetSession<clsOrdersHeader>("Order_xCorporate") ?? RedirectOrderPlace<clsOrdersHeader>(); }
        //    set { HttpContext.Current.Session["Order_xCorporate"] = value; }
        //}
        //private static T RedirectOrderPlace<T>()
        //{
        //    HttpContext.Current.Response.Redirect("~/Private/orders/PlaceOrder.aspx?ex=3N4WdpI4hmMuOQlCTXvZNg==");
        //    return default(T);
        //}
        //public static clsOrdersHeader SsOrderHeader
        //{

        //    get { return clsExtension.GetSession<clsOrdersHeader>("Order_header") ?? new clsOrdersHeader(); }
        //    set { HttpContext.Current.Session["Order_header"] = value; }
        //}
        //public static clsOrdersHeader SsOrderxCorporate
        //{

        //    get { return clsExtension.GetSession<clsOrdersHeader>("Order_xCorporate") ?? new clsOrdersHeader(); }
        //    set { HttpContext.Current.Session["Order_xCorporate"] = value; }
        //}
        //public static clsAutoshipordersHeader SsAutoShipOrderxCorporate
        //{
        //    get { return clsExtension.GetSession<clsAutoshipordersHeader>("AutoShip_xCorporate") ?? RedirectAutoshipOrder<clsAutoshipordersHeader>(); }
        //    set { HttpContext.Current.Session["AutoShip_xCorporate"] = value; }
        //}
        //private static T RedirectAutoshipOrder<T>()
        //{
        //    HttpContext.Current.Response.Redirect("~/Private/distributor/AutoshipOrderPlace.aspx?ex=3N4WdpI4hmMuOQlCTXvZNg==");
        //    return default(T);
        //}

        //public static clsAutoshipordersHeader SsAutoShipxCorporate
        //{

        //    get { return clsExtension.GetSession<clsAutoshipordersHeader>("AutoShip_xCorporate") ?? new clsAutoshipordersHeader(); }
        //    set { HttpContext.Current.Session["AutoShip_xCorporate"] = value; }
        //}
        //public static clsOrdersHeader SsEnrollmentxBackOffice
        //{
        //    get { return clsExtension.GetSession<clsOrdersHeader>("Market") ?? new clsOrdersHeader(); }
        //    set { HttpContext.Current.Session["Market"] = value; }
        //}
        public static void Logout()
        {
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Session.Clear();
        }
        public static String SsCulture
        {
            get { return  GetCulture() ; }
            //get { return clsExtension.GetSession<String>("Culture_xCorp") ?? GetCulture() ; }
            set { HttpContext.Current.Session["Culture_xCorp"] = value; }
        }
        private static String GetCulture()
        {
            String cult = "en-US";
            try
            {
              cult= CultureInfo.CreateSpecificCulture(HttpContext.Current.Request.UserLanguages[0].ToString()).ToString();
            }
            catch (Exception)
            {
                cult = "en-US";
                
            }
            return cult;
        }
        //public static List<srEmailTemplate> SsListTemplate
        //{
        //    get { return clsExtension.GetSession<List<srEmailTemplate>>("TemplateList") ?? new List<srEmailTemplate>(); }
        //    set { HttpContext.Current.Session["TemplateList"] = value; }
        //}

        //public static List<String> SsLanguage
        //{
        //    get { return clsExtension.GetSession<List<String>>("language_xCorporate"); }
        //    set { HttpContext.Current.Session["language_xCorporate"] = value; }
        //}

        //public static TranslationTerms SsTranslationTerms
        //{
        //    get 
        //    { 
        //        if (clsExtension.GetSession<TranslationTerms>("TranslationTerms_xCorporate") == null)
        //            HttpContext.Current.Session["TranslationTerms_xCorporate"] = new TranslationTerms(); 

        //        return clsExtension.GetSession<TranslationTerms>("TranslationTerms_xCorporate");
        //    }
        //    set { HttpContext.Current.Session["TranslationTerms_xCorporate"] = value; }
        //}


        public static Hashtable SsCsutomTranslation
        {
            get
            {
                if (clsExtension.GetSession<Hashtable>("CustomTranslationTerms_xCorporate") == null)
                    HttpContext.Current.Session["CustomTranslationTerms_xCorporate"] = new Hashtable();

                return clsExtension.GetSession<Hashtable>("CustomTranslationTerms_xCorporate");
            }
            set { HttpContext.Current.Session["CustomTranslationTerms_xCorporate"] = value; }
        }

        public static Hashtable SsCsutomTranslationMessages
        {
            get
            {
                if (clsExtension.GetSession<Hashtable>("CustomTranslationTerms_xCorporateMessages") == null)
                    HttpContext.Current.Session["CustomTranslationTerms_xCorporateMessages"] = new Hashtable();

                return clsExtension.GetSession<Hashtable>("CustomTranslationTerms_xCorporateMessages");
            }
            set { HttpContext.Current.Session["CustomTranslationTerms_xCorporateMessages"] = value; }
        }

        public static String SsCultureId
        {
            get { return clsExtension.GetSession<String>("CultureId"); }
            set { HttpContext.Current.Session["CultureId"] = value; }
        }
    }
}
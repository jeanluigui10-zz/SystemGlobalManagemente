using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using xAPI.Library.General;

namespace System_Maintenance.src.app_code
{
    public class BasePageModule : Page
    {
        public Boolean RequiresAuth = true;
        public Boolean RequiresAccess = true;
        //public object CurrentUserSession { get; set; }

        #region
        private String _termName = "";
        private String _termResxUrl = "";

        public String termName
        {
            set { this._termName = value; }
            get { return _termName; }
        }

        public String termResxUrl
        {
            set { this._termResxUrl = value; }
            get { return _termResxUrl; }
        }
        #endregion

        public void Message(EnumAlertType type)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "');</script>", false);
        }

        public void Message(EnumAlertType type, String message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }
        public void Message(EnumAlertType type, String message, String typeOrder)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "','" + typeOrder.Trim() + "');</script>", false);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.PreInit"/> event at the beginning of page initialization.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event to initialize the page.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            ///Estaba validando por la url que ingresaba debe validar siempre.
            //if (HttpContext.Current.Request.Url.ToString().Contains("localhost")
            //    || HttpContext.Current.Request.Url.ToString().Contains("xirectstage"))
            //    RequiresAccess = true;
            if (RequiresAuth)
            {
                //ValidateLogin();
                //ValidateAccess();
                ///Esto era parte de la validación por la url.
                //if (RequiresAccess)
                    //ValidateAccess();
            }
            base.OnInit(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.InitComplete"/> event after page initialization.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.PreLoad"/> event after postback data is loaded into the page server controls but before the <see cref="M:System.Web.UI.Control.OnLoad(System.EventArgs)"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.LoadComplete"/> event at the end of the page load stage.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            HtmlTextWriter hWriter = new HtmlTextWriter(sw);

            base.Render(hWriter/*writer*/);

            //writer.Write(BaseSession.SsTranslationTerms.FindGlobalTextToTraslate(sb.ToString()));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.PreRenderComplete"/> event after the <see cref="M:System.Web.UI.Page.OnPreRenderComplete(System.EventArgs)"/> event and before the page is rendered.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }

        protected void ValidateLogin()
        {
            //if (BaseSession.SsUser == null) ;
            //    if (!IsUserAuthorized())
            //    {
            //        Response.Redirect("~/common/login.aspx?back_url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //    }
            //}
        }

        protected void ValidateAccess()
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.IndexOf("ListReports.aspx") > -1) return;

            //AccessManager managerAccess = new AccessManager(HttpContext.Current.Request.Url.AbsolutePath, BaseSession.SsUser.ListSettings);

            bool hasAccess = false;
            if (HttpContext.Current.Request.Url.AbsolutePath.Contains("/Private/reports"))
            {
                //hasAccess = managerAccess.HasAccess((Int16)EnumSettingAccess.Report);
            }
            else
            {
                //hasAccess = managerAccess.HasAccess((Int16)EnumSettingAccess.Pages);
            }            

            if (!hasAccess)
            {
                Control myControl1 = null;
                Control myControl2 = null;
                try
                {
                    myControl1 = this.Master.Master.FindControl("ContentPlaceHolder").FindControl("PanelView");
                    myControl2 = this.Master.Master.FindControl("ContentPlaceHolder").FindControl("PanelNotAcces");
                }
                catch (Exception)
                {
                    myControl1 = null;
                    myControl2 = null;
                }
                if (myControl1 != null && myControl2 != null)
                {
                    myControl1.Visible = false;
                    myControl2.Visible = true;
                }
            }
        }

        bool bolNoContinue = false;
        public bool IsValidEmail(string Email)
        {

            if (String.IsNullOrEmpty(Email))
                return false;
            try
            {
                Email = Regex.Replace(Email, @"(@)(.+)$", this.DomainMapper, RegexOptions.None);
            }
            catch (Exception ex)
            {
                return false;
            }
            if (bolNoContinue)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(Email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string DomainMapper(Match Match)
        {
            IdnMapping idn = new IdnMapping();
            string domainName = Match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                bolNoContinue = true;
            }
            return Match.Groups[1].Value + domainName;
        }
        public void JQueryDateTimePicker(String StartDate, String EndDate)
        {
            String jscript = " var dates = $('input[id$=" + StartDate + "],input[id$=" + EndDate + "]').datepicker({" +
             "defaultDate: \"+1w\"," +
             "changeMonth: true," +
             "changeYear: true," +
             "onSelect: function (selectedDate) {" +

                 "var option = $(\"input[id$=" + StartDate + "]\").attr('id') == this.id ? \"minDate\" : \"maxDate\"," +
                    "instance = $(this).data(\"datepicker\")," +
                    "date = $.datepicker.parseDate(" +
                        "instance.settings.dateFormat ||" +
                        "$.datepicker._defaults.dateFormat," +
                        "selectedDate, instance.settings);" +
                 "dates.not(this).datepicker(\"option\", option, date);}});";

            ClientScript.RegisterStartupScript(typeof(Page), "date", @"<script type='text/javascript'>" + jscript + "</script>", false);
        }

        public void SendDownload(String filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.AddHeader("Content-Type", "application/Excel");
                    //Response.ContentType = "application/vnd.xls";
                    //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    file.Delete();
                    Response.End();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// INITIALIZATION CULTURE
        /// </summary>
        //protected override void InitializeCulture()
        //{            
        //    CultureInfo ci = ManageGlobalization.GetUrlCulture(BaseSession.SsLanguage);
        //    Thread.CurrentThread.CurrentCulture = ci;
        //    Thread.CurrentThread.CurrentUICulture = ci;            
        //    String culturecurrent = ci.ToString();

        //    if (!culturecurrent.Equals(BaseSession.SsCultureId))
        //    {
        //        FillHashTableStrings(culturecurrent);
        //        FillHashTableMessages(culturecurrent);
        //        BaseSession.SsCultureId = culturecurrent;
        //    }

        //    base.InitializeCulture();
        //}

        private void FillHashTableStrings(String ci)
        {
            //BaseSession.SsCsutomTranslation = new Hashtable();
            //string path = ConfigurationManager.AppSettings["EnumResxFilesUrl"].ToString();
            //if (!File.Exists(path + "Strings." + ci + ".resx"))
            //    ci = ConfigurationManager.AppSettings["DefaultCulture"].ToString();

            //ResXResourceReader reader = new ResXResourceReader(path + "Strings." + ci + ".resx");
            //if (reader != null)
            //{

            //    IDictionaryEnumerator id = reader.GetEnumerator();
            //    foreach (DictionaryEntry d in reader)
            //    {
            //        if (d.Value == null)
            //            BaseSession.SsCsutomTranslation.Add(d.Key.ToString(), "");
            //        else
            //            BaseSession.SsCsutomTranslation.Add(d.Key.ToString(), d.Value.ToString());
            //    }
            //    reader.Close();
            //}
        }


        private void FillHashTableMessages(String ci)
        {
            //BaseSession.SsCsutomTranslationMessages = new Hashtable();
            //string path = ConfigurationManager.AppSettings["EnumResxFilesUrl"].ToString();
            //if (!File.Exists(path + "Messages." + ci + ".resx"))
            //    ci = ConfigurationManager.AppSettings["DefaultCulture"].ToString();

            //ResXResourceReader reader = new ResXResourceReader(path + "Messages." + ci + ".resx");

            //if (reader != null)
            //{

            //    IDictionaryEnumerator id = reader.GetEnumerator();
            //    foreach (DictionaryEntry d in reader)
            //    {
            //        if (d.Value == null)
            //            BaseSession.SsCsutomTranslationMessages.Add(d.Key.ToString(), "");
            //        else
            //            BaseSession.SsCsutomTranslationMessages.Add(d.Key.ToString(), d.Value.ToString());
            //    }
            //    reader.Close();
            //}
        }



        /// <summary>
        /// BaseSession.SsLanguage[0] -> Language Id (Example: English (United State) = 1)
        /// BaseSession.SsLanguage[1] -> Language Culture (Example: en-US, es-ES)
        /// BaseSession.SsLanguage[2] -> Language Icon (Example: /src/images/flags/us.gif)
        /// BaseSession.SsLanguage[3] -> Language Custom Name (Example: Japanese (日本語 Nihõŋŋo))
        /// </summary>
        /// <returns></returns>
        //public static List<string> GetCultureLanguage()
        //{
        //    //if (BaseSession.SsLanguage == null)
        //    //{
        //    //    BaseEntity Base = new BaseEntity();
        //    //    CultureInfo ci = ManageGlobalization.GetUrlCulture(BaseSession.SsLanguage);
        //    //    DataTable dt = xLogic.Instance.Language_GetByCulture(ref Base, ci.Name);

        //    //    BaseSession.SsLanguage = null;
        //    //    BaseSession.SsLanguage = new List<string>();
        //    //    BaseSession.SsLanguage.Add(dt.Rows[0]["ID"].ToString());
        //    //    BaseSession.SsLanguage.Add(dt.Rows[0]["CULTUREINFO"].ToString());
        //    //    BaseSession.SsLanguage.Add(dt.Rows[0]["ICON"].ToString());
        //    //    BaseSession.SsLanguage.Add(dt.Rows[0]["LANGUAGENAME"].ToString());
        //    //}

        //    //return BaseSession.SsLanguage;
        //}


        //public Hashtable SetCofiguration()
        //{
        //    String ci = System.Globalization.CultureInfo.CurrentUICulture.Name;
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(ci);
        //    //return FillHashTable(ci);
        //}

        //private Hashtable FillHashTable(String ci)
        //{
            //string path = ConfigurationManager.AppSettings["EnumResxFilesUrl"].ToString();//Thread.GetDomain().BaseDirectory + @"App_GlobalResources\Strings.";
            //Hashtable resourceEntries = new Hashtable();
            //ResXResourceReader reader = new ResXResourceReader(path + ci + ".resx");
            //if (reader != null)
            //{
            //    IDictionaryEnumerator id = reader.GetEnumerator();
            //    foreach (DictionaryEntry d in reader)
            //    {
            //        if (d.Value == null)
            //            resourceEntries.Add(d.Key.ToString(), "");
            //        else
            //            resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
            //    }
            //    reader.Close();
            //}

            //return resourceEntries;
        //}





    }
}
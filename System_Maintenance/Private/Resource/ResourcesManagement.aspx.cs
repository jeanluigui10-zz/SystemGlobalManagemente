using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Resource
{
    public partial class ResourcesManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!Page.IsPostBack)
                {
                    if (String.IsNullOrEmpty(Request.QueryString["q"]))
                    {
                        //hfLng.Value = Server.UrlEncode(Encryption.Encrypt(Convert.ToString((int)EnumLanguage.United_States) + "|" + Config.EnterpriseVirtualPath + Config.IconLanguageDefault));
                        //imgRegion.ImageUrl = Config.EnterpriseVirtualPath + Config.IconLanguageDefault;
                        LoadData();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Request.QueryString["q"]))
                        {
                            if (!String.IsNullOrEmpty(Encryption.Decrypt(Request.QueryString["q"])))
                            {
                                //hfLng.Value = Server.UrlEncode(Request.QueryString["q"]);
                                //String query = Encryption.Decrypt(Request.QueryString["q"]);
                                //String[] Values = query.Split('|');
                                //imgRegion.ImageUrl = Values[1];

                                LoadData();
                            }
                            else
                            {
                                //hfLng.Value = Server.UrlEncode(Encryption.Encrypt(Convert.ToString((int)EnumLanguage.United_States) + "|" + Config.EnterpriseVirtualPath + Config.IconLanguageDefault));
                                //imgRegion.ImageUrl = Config.EnterpriseVirtualPath + Config.IconLanguageDefault;
                                LoadData();
                            }
                        }
                    }
                }
            //SetAllowedLanguages();
        }
        [WebMethod]
        public static Object SendDelete(String jsondata)
        {
            Boolean success = false;
            try
            {
                JavaScriptSerializer sr = new JavaScriptSerializer();
                List<String> listDes = sr.Deserialize<List<String>>(jsondata);
                tBaseIdList baseIdList = new tBaseIdList();

                foreach (String item in listDes)
                    baseIdList.Add(new tBaseId { Id = Convert.ToInt32(Encryption.Decrypt(HttpContext.Current.Server.UrlDecode(item))), Action = 0 });

                BaseEntity objEntity = new BaseEntity();

                success = ResourceBL.Instance.AppResource_Delete(ref objEntity, baseIdList);

                if (objEntity.Errors.Count == 0)
                    if (success)
                    {
                        return new { Lista = sr.Serialize(List()), sJSON = "Deleted successfully" };
                    }
                    else
                    {
                        return new { Lista = new List<AppResource>(), sJSON = "Unable to delete the record(s)" };
                    }

                else
                {
                    return new { Lista = new List<AppResource>(), sJSON = "An error occurred while deleting" };
                }
            }
            catch (Exception exception)
            {
                return new { Lista = new List<AppResource>(), sJSON = "An error occurred while deleting" };
            }
        }
        
        private static List<srAppResource> List()
        {
            BaseEntity objEntity = new BaseEntity();
            List<srAppResource> lst = new List<srAppResource>();

            DataTable dt = ResourceBL.Instance.AppResource_GetByAplicationID(ref objEntity);
            if (objEntity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        String sId = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString()));
                        lst.Add(new srAppResource()
                        {
                            isCheckbox = "1",
                            Id = sId,
                            FileName = item["FILENAME"].ToString(),
                            DocType = item["DOCTYPE"].ToString(),
                            FileDescription = item["DESCRIPTION"].ToString(),
                            NameResource = item["NAMERESOURCE"].ToString(),
                            CreatedDate = Convert.ToDateTime(item["CREATEDDATE"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["STATUS"]) == (short)EnumStatus.Enabled ? "Enabled" : "Disabled",
                            Index = count.ToString()
                        });
                    }
                }
            }
            return lst;
        }

        private void LoadData(Boolean ShowMessage = false)
        {
            BaseEntity entity = new BaseEntity();
            List<srAppResource> lst = new List<srAppResource>();

            DataTable dt = ResourceBL.Instance.AppResource_GetByAplicationID(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        String sId = Server.UrlEncode(Encryption.Encrypt(item["ID"].ToString()));
                        lst.Add(new srAppResource()
                        {
                            isCheckbox = "1",
                            Id = sId,
                            FileName = item["FILENAME"].ToString(),
                            DocType = item["DOCTYPE"].ToString(),
                            Category =  item["RESOURCE_CATEGORY_NAME"].ToString(),
                            FileDescription = item["DESCRIPTION"].ToString(),
                            NameResource = item["NAMERESOURCE"].ToString(),
                            CreatedDate = Convert.ToDateTime(item["CREATEDDATE"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["STATUS"]) == (short)EnumStatus.Enabled ? "Enabled" : "Disabled",
                            Index = item["ID"].ToString()
                        });
                    }
                }
                else
                {
                    this.Message(EnumAlertType.Error, "An error occurred while loading data");
                }
            }
            else
            {
                this.Message(EnumAlertType.Success, entity.Errors[0].MessageClient);
            }

            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfData.Value = sJSON.ToString();
                }
            }
        }

        //private void SetAllowedLanguages()
        //{
        //    List<clsLanguage> List = xLogic.Instance.Language_GetAllList();
        //    if (List != null)
        //        BuildLangs(List);
        //    else
        //    {
        //        this.Message(EnumAlertType.Error, "An error ocurrred while loading Languages");
        //    }
        //}

        //private void BuildLangs(List<clsLanguage> List)
        //{
        //    HtmlGenericControl li = null;

        //    foreach (clsLanguage item in List)
        //    {
        //        if (item.Status == 1)
        //        {
        //            li = new HtmlGenericControl("li");

        //            Image img = new Image
        //            {
        //                ToolTip = item.Name,
        //                ImageUrl = Config.EnterpriseVirtualPath + item.Icon.ToString().Replace("~/", "")
        //            };

        //            li.Controls.Add(img);

        //            LinkButton lnkBtn = new LinkButton
        //            {
        //                Text = item.Name
        //            };

        //            lnkBtn.Attributes.Add("nfo", Convert.ToString(item.ID) + "|" + item.Icon);

        //            lnkBtn.Click += new EventHandler(btnMethod_Click);

        //            li.Controls.Add(lnkBtn);
        //            li.Attributes.Add("class", "language-items");

        //            languages.Controls.Add(li);
        //        }
        //    }
        //}

        #region Languages_Methods

        //protected void btnMethod_Click(Object sender, EventArgs e)
        //{
        //    String lng = "";
        //    LinkButton lnkBtn = (LinkButton)sender;
        //    String[] Values = lnkBtn.Attributes["nfo"].Split('|');
        //    hfLng.Value = Server.UrlEncode(Encryption.Encrypt(Values[0] + "|" + Values[1]));
        //    lng = Values[1].ToString().Replace("~//", "");
        //    lng = Values[1].ToString().Replace("~/", "");
        //    imgRegion.ImageUrl = Config.EnterpriseVirtualPath + lng;
        //    LoadData(true);
        //}

        #endregion

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Resource
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!Page.IsPostBack)
                {
                    if (String.IsNullOrEmpty(Request.QueryString["q"]))
                    {
                        LoadData();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Request.QueryString["q"]))
                        {
                            if (!String.IsNullOrEmpty(Encryption.Decrypt(Request.QueryString["q"])))
                            {
                                LoadData();
                            }
                            else
                            {
                                LoadData();
                            }
                        }
                    }
                }
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
            catch (Exception ex)
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
                            Name =  item["Name"].ToString(),
                            FileDescription = item["DESCRIPTION"].ToString(),
                            NameResource = item["NAMERESOURCE"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]).ToString(),
                            CreatedDate = Convert.ToDateTime(item["CREATEDDATE"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["STATUS"]) == (short)EnumStatus.Enabled ? "Habilitado" : "Deshabilitado",
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
        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }
    }
}
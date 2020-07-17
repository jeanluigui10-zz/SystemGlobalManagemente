using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Category;
using xAPI.Entity;
using xAPI.Entity.Category;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.CategoryManagement
{
    public partial class CategoryEntry : System.Web.UI.Page
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
            BaseEntity objEntity = new BaseEntity();
            tBaseIdList baseIdList = new tBaseIdList();
            JavaScriptSerializer sr = new JavaScriptSerializer();
            try
            {
                List<String> listDes = sr.Deserialize<List<String>>(jsondata);
                foreach (String item in listDes)
                    baseIdList.Add(new tBaseId { Id = Convert.ToInt32(Encryption.Decrypt(HttpContext.Current.Server.UrlDecode(item))), Action = 0 });

                success = CategoryBL.Instance.Category_Delete(ref objEntity, baseIdList);
                if (objEntity.Errors.Count == 0)
                    if (success)
                    {
                        return new { Lista = sr.Serialize(List()), sJSON = "Se eliminó correctamente!" };
                    }
                    else
                    {
                        return new { Lista = new List<Categorys>(), sJSON = "No se puede eliminar los registro(s)" };
                    }
                else
                {
                    return new { Lista = new List<Categorys>(), sJSON = "No se puede eliminar los registro(s)" };
                }
            }
            catch (Exception ex)
            {
                return new { Lista = new List<Categorys>(), sJSON = "Ocurrió un error al eliminar" };
            }
        }

        private static List<srCategory> List()
        {
            BaseEntity objEntity = new BaseEntity();
            List<srCategory> lst = new List<srCategory>();

            DataTable dt = CategoryBL.Instance.Category_GetList(ref objEntity);
            if (objEntity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srCategory()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            NameResource = item["NameResource"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            CreatedDate = Convert.ToDateTime(item["CreatedDate"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["Status"]) == (short)EnumStatus.Enabled ? "Activo" : "Inactivo",
                            Index = count.ToString()
                        });
                    }
                }
            }
            return lst;
        }
        private void LoadData()
        {
            BaseEntity entity = new BaseEntity();
            List<srCategory> lst = new List<srCategory>();

            DataTable dt = CategoryBL.Instance.Category_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srCategory()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            NameResource = item["NameResource"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            CreatedDate = Convert.ToDateTime(item["CreatedDate"]).ToString("MM/dd/yyyy"),
                            Status = Convert.ToInt16(item["Status"]) == (short)EnumStatus.Enabled ? "Activo" : "Inactivo",
                            Index = count.ToString()
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
                    hfDataCategory.Value = sJSON.ToString();
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
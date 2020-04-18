using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Product;
using xAPI.Entity;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.ProductManagement
{
    public partial class ProductEntry : System.Web.UI.Page
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

                success = ProductBL.Instance.Product_Delete(ref objEntity, baseIdList);

                if (objEntity.Errors.Count == 0)
                    if (success)
                    {
                        return new { Lista = sr.Serialize(List()), sJSON = "Ok" };
                    }
                    else
                    {
                        return new { Lista = new List<Products>(), sJSON = "NoOK" };
                    }
                else
                {
                    return new { Lista = new List<Products>(), sJSON = "No se pueden eliminar los registro(s)" };
                }
            }
            catch (Exception ex)
            {
                return new { Lista = new List<Products>(), sJSON = "Ocurri un error al eliminar" };
            }
        }

        private static List<srProducts> List()
        {
            BaseEntity objEntity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();

            DataTable dt = ProductBL.Instance.Product_GetList(ref objEntity);
            if (objEntity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srProducts()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            Category = item["Resource_Category_Name"].ToString(),
                            NameResource = item["NameResource"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]).ToString(),
                            Stock = Convert.ToInt32(item["Stock"]).ToString(),
                            PriceOffer = Convert.ToDecimal(item["PriceOffer"]).ToString(),
                            UniMed = item["UniMed"].ToString(),
                            Status = Convert.ToInt16(item["Status"]) == (short)EnumStatus.Enabled ? "Activo" : "Inactivo",
                            Index = count.ToString()
                        });
                    }
                }
                else {
                    lst = null;
                }
            }
            else
            {
                lst = null;
            }
            return lst;
        }
        private void LoadData(Boolean ShowMessage = false)
        {
            BaseEntity entity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();

            DataTable dt = ProductBL.Instance.Product_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srProducts()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            Category = item["Resource_Category_Name"].ToString(),
                            NameResource = item["NameResource"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]).ToString(),
                            Stock = Convert.ToInt32(item["Stock"]).ToString(),
                            PriceOffer = Convert.ToDecimal(item["PriceOffer"]).ToString(),
                            UniMed = item["UniMed"].ToString(),
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
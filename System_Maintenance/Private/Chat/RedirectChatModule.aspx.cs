using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Customers;
using xAPI.BL.Resource;
using xAPI.BL.Security;
using xAPI.Entity.Customers;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;
using System.Data;
using System;
namespace xSystem_Maintenance.Private.Chat
{
    public partial class RedirectChatModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarClientes();
                CargarProductos();
            }

            ucRedirectChatModule.SetUserId(BaseSession.SsUser.Id_Usuario);
        }
        private void CargarClientes()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Customer> list = CustomersBL.Instance.ListarCliente(ref objBase, "", "");
                if (objBase.Errors.Count == 0)
                {
                    if (list != null)
                    {
                        ddlCliente.DataSource = list;
                        ddlCliente.DataTextField = "FirstName";
                        ddlCliente.DataValueField = "CustomerId";
                        ddlCliente.DataBind();
                    }
                    else
                    {
                        Message(EnumAlertType.Info, "Error al cargar los clientes.");
                    }
                }
                else
                {
                    Message(EnumAlertType.Info, "Error al cargar los clientes.");
                }                
            }
            catch (Exception exception)
            {
                Message(EnumAlertType.Error, exception.Message);
            }
        }
        private void CargarProductos()
        {
            try
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
                                Category = item["RESOURCE_CATEGORY_NAME"].ToString(),
                                Name = item["Name"].ToString(),
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
            }
            catch (Exception exception)
            {
                Message(EnumAlertType.Error, exception.Message);
            }
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }
        [WebMethod]
        public static object RegistroOrden(String clientes, String productos, String descripcion, String cantidad, String precio, String estado)
        {
            Object objReturn = new Object();
            try
            {
           
                BaseEntity objBase = new BaseEntity();
                Byte Status = Convert.ToByte(estado);
                #region GetMarkets
                JavaScriptSerializer sr = new JavaScriptSerializer();
                List<String> lstClientesString = sr.Deserialize<List<String>>(clientes);
                List<Int32> lstClientesInt = new List<Int32>();
                if (lstClientesString.Count > 0)
                {
                    if (lstClientesString[0].Equals("multiselect-all")) { lstClientesString.RemoveAt(0); }
                    lstClientesInt = lstClientesString.Select(Int32.Parse).ToList();
                }
                else { lstClientesInt.Insert(0, 0); }

                //xss.AutoshipBackend.Entity.tBaseTaxUserMarketsList ListTaxMarkets = new xss.AutoshipBackend.Entity.tBaseTaxUserMarketsList();
                //foreach (int item in lstClientesInt)
                //{
                //    ListTaxMarkets.Add(new xss.AutoshipBackend.Entity.tBaseTaxUserMarkets
                //    {
                //        MarketId = item,
                //        Status = 1
                //    });
                //}
                #endregion

                
            }
            catch (Exception exception)
            {
                Message(EnumAlertType.Error, exception.Message);
            }
            return objReturn;
        }
    }
}
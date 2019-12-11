using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Customers;
using xAPI.BL.Order;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Entity.Customers;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

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
                BaseEntity objBase = new BaseEntity();

                DataTable dt = ResourceBL.Instance.AppResource_GetByAplicationID(ref objBase);
                if (objBase.Errors.Count == 0)
                {
                    if (dt != null)
                    {
                        ddlProductos.DataSource = dt;
                        ddlProductos.DataTextField = "NAME";
                        ddlProductos.DataValueField = "ID";
                        ddlProductos.DataBind();
                        ddlProductos.Items.Add(new ListItem("Paquete de productos", "00001"));
                    }
                    else
                    {
                        this.Message(EnumAlertType.Error, "Error al cargar los productos.");
                    }
                }
                else
                {
                    this.Message(EnumAlertType.Success, objBase.Errors[0].MessageClient);
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
            BaseEntity objBase = new BaseEntity();
            tBaseDetailOrderList objListDetail = new tBaseDetailOrderList();
            try
            {
           
                
                #region Obtener Cliente
                JavaScriptSerializer sr = new JavaScriptSerializer();
                List<String> lstClientesString = sr.Deserialize<List<String>>(clientes);
                List<Int32> lstClientesInt = new List<Int32>();
                if (lstClientesString.Count > 0)
                {
                    if (lstClientesString[0].Equals("multiselect-all")) { lstClientesString.RemoveAt(0); }
                    lstClientesInt = lstClientesString.Select(Int32.Parse).ToList();
                }
                else { lstClientesInt.Insert(0, 0); }
                #endregion

                #region Obtener Producto
                JavaScriptSerializer srp = new JavaScriptSerializer();
                List<String> lstProductString = sr.Deserialize<List<String>>(clientes);
                List<Int32> lstProductsInt = new List<Int32>();
                if (lstProductString.Count > 0)
                {
                    if (lstProductString[0].Equals("multiselect-all")) { lstProductString.RemoveAt(0); }
                    lstClientesInt = lstProductString.Select(Int32.Parse).ToList();
                }
                else { lstClientesInt.Insert(0, 0); }
                #endregion

                Int32 CustomerId = (lstClientesInt.Count > 0) ? lstClientesInt[0] : 0;
                Int32 ProductId = (lstProductsInt.Count > 0) ? lstProductsInt[0] : 0;
                Decimal UnitPrice = Convert.ToDecimal(precio);
                Int32 Quantity = Convert.ToInt32(cantidad);
                Byte Status = Convert.ToByte(estado);

                OrderHeader objOrder = new OrderHeader();

                objListDetail.Add(new tBaseDetailOrder()
                {
                    ProductId = ProductId,
                    Price = UnitPrice,
                    Quantity = Quantity,
                    CreatedBy = CustomerId,
                    UpdatedBy = CustomerId,
                    Status = (Status == 1) ? Convert.ToByte(EnumStatus.Enabled) : Convert.ToByte(0)
                });
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = ProductId;
                orderDetail.Product.UnitPrice = UnitPrice;
                orderDetail.Quantity = Quantity;
                orderDetail.CreatedBy = CustomerId;
                orderDetail.UpdatedBy = CustomerId;
                orderDetail.Status = (Status == 1) ? Convert.ToByte(EnumStatus.Enabled) : Convert.ToByte(0);

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                lstOrderDetail.Add(orderDetail);

                //objOrder.ListOrderDetail(lstOrderDetail); AQUI ME QUEDE

                Boolean success = OrderBL.Instance.Insertar_Pedido(ref objBase, ref objOrder, objListDetail);
                if (success)
                {
                    //Ok
                    //Response.Redirect("Confirmation.aspx", true);
                }
                else
                {
                    //this.Message(EnumAlertType.Info, "No se pudo guardar la Orden");
                }

              


            }
            catch (Exception exception)
            {
             
            }
            return objReturn;
        }

        private void SaveOrder(OrderHeader objOrder)
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                tBaseDetailOrderList objListDetail = new tBaseDetailOrderList();

                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    objListDetail.Add(new tBaseDetailOrder()
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.Id,
                        Price = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        CreatedBy = objOrder.Customer.CustomerId,
                        UpdatedBy = objOrder.Customer.CustomerId,
                        Status = Convert.ToByte(EnumStatus.Enabled)
                    });
                }
                Boolean success = OrderBL.Instance.Insertar_Pedido(ref objBase, ref objOrder, objListDetail);
                if (success)
                {
                    //Ok
                    Response.Redirect("Confirmation.aspx", true);
                }
                else
                {
                    this.Message(EnumAlertType.Info, "No se pudo guardar la Orden");
                }
            }
            catch (Exception ex)
            {
                this.Message(EnumAlertType.Error, "Ocurrio un error al guardar la Orden");
            }
        }

    }
}
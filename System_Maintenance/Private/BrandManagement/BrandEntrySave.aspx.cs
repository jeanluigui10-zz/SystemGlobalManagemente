using System;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Brand;
using xAPI.Entity.Brand;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.BrandManagement
{
    public partial class BrandEntrySave : System.Web.UI.Page
    {
        public int vsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default(int); }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetQuery();
                SetData();
                LoadFieldTranslations();
            }
        }
        private void LoadFieldTranslations()
        {
            lblRequiredFields.Text = "(*)Campos requeridos.";
            lblName.Text = "* Nombre:";
            lblEnabled.Text = "Activar";
            btnCancel.Text = "Regresar";
        }
        #region SetQuery
        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                this.ltTitle.Text = "Editar Marca";
                String id = Encryption.Decrypt(Request.QueryString["q"]);
                if (!String.IsNullOrEmpty(id))
                {
                    vsId = Convert.ToInt32(id);
                    hfBrandId.Value = id;
                }
                else
                {
                    GoBack();
                }
            }
            else
            {
                this.ltTitle.Text = "Agregar Categoría";
            }
        }
        #endregion
        #region SetData
        private void SetData()
        {
            try
            {
                if (vsId > 0)
                {
                    Brands obj = null;
                    BaseEntity entity = new BaseEntity();
                    obj = BrandBL.Instance.Brand_Get_ById(ref entity, vsId);
                    if (entity.Errors.Count == 0)
                        if (obj != null)
                        {
                            SetControls(obj);
                        }
                        else
                        {
                            SetControls();
                        }
                    else
                    {
                        Message(EnumAlertType.Error, "An error occurred while loading data");
                    }
                }
            }
            catch (Exception)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }

        }
        private void SetControls()
        {
            hfBrandId.Value = String.Empty;
            txtName.Text = String.Empty;
            chkStatus.Checked = true;
        }
        private void SetControls(Brands objBrand)
        {
            try
            {
                hfBrandId.Value = objBrand.ID.ToString();
                txtName.Text = objBrand.Name;
                chkStatus.Checked = objBrand.Status == (int)EnumStatus.Enabled ? true : false;
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        [WebMethod]
        public static Object Brand_Save(srBrand u)
        {
            BaseEntity entity = new BaseEntity();
            Boolean success = false;
            try
            {
                Brands objBrand = new Brands
                {
                    ID = String.IsNullOrEmpty(u.Id) ? 0 : Convert.ToInt32(u.Id),
                    Name = u.Name.ToString(),
                    Status = Convert.ToInt32(u.Status)
                };

                success = BrandBL.Instance.Brand_Save(ref entity, objBrand);
                if (entity.Errors.Count <= 0 && success)
                {
                    return new { Msg = "Se guardo correctamente!", Result = "Ok" };

                }
                else
                {
                    return new { Msg = "No se pudo guardar", Result = "NoOK" };
                }
            }
            catch (Exception ex)
            {
                return new { Msg = "No se pudo guardar", Result = "NoOK" };
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        private void GoBack()
        {
            Response.Redirect("BrandEntry.aspx", false);
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }

    }
}
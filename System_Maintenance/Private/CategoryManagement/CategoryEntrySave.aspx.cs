using System;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Category;
using xAPI.Entity.Category;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.CategoryManagement
{
    public partial class CategoryEntrySave : System.Web.UI.Page
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
            lblDescription.Text = " Descripción:";
            lblEnabled.Text = "Activar";
            btnCancel.Text = "Regresar";
        }
        #region SetQuery
        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                this.ltTitle.Text = "Editar Categoría";
                String id = Encryption.Decrypt(Request.QueryString["q"]);
                if (!String.IsNullOrEmpty(id))
                {
                    vsId = Convert.ToInt32(id);
                    hfCategoryId.Value = id;
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
                    Categorys obj = null;
                    BaseEntity entity = new BaseEntity();
                    obj = CategoryBL.Instance.Category_Get_ById(ref entity, vsId);
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
            hfCategoryId.Value = String.Empty;
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            chkStatus.Checked = true;
        }
        private void SetControls(Categorys objCategory)
        {
            try
            {
                hfCategoryId.Value = objCategory.ID.ToString();
                txtName.Text = objCategory.Name;
                txtDescription.Text = objCategory.Description;
                chkStatus.Checked = objCategory.Status == (int)EnumStatus.Enabled ? true : false;
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        [WebMethod]
        public static Object Category_Save(srCategory u)
        {
            BaseEntity entity = new BaseEntity();
            Boolean success = false;
            try
            {
                Categorys objCategory = new Categorys
                {
                    ID = String.IsNullOrEmpty(u.Id) ? 0 : Convert.ToInt32(u.Id),
                    Name = u.Name.ToString(),
                    Description = u.Description.ToString(),
                    Status = Convert.ToInt32(u.Status)
                };

                success = CategoryBL.Instance.Category_Save(ref entity, objCategory);
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
            Response.Redirect("CategoryEntry.aspx", false);
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }

    }
}
using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Category;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.SubCategoryManagement
{
    public partial class SubCategoryEntrySave : System.Web.UI.Page
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
                LoadData();
                SetData();
                LoadFieldTranslations();
            }
        }
        #region LoadDLL
        private void LoadData()
        {
            try
            {
                LoadDDLCategory();
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }

        private void LoadDDLCategory()
        {
            BaseEntity entity = new BaseEntity();
            DataTable dt = CategoryBL.Instance.Product_Category_GetList(ref entity);
            try
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataBind();
                ddlCategory.Items.Add(new ListItem("-- Seleccionar Opción --", "0"));
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
      
        #endregion

        private void LoadFieldTranslations()
        {
            lblRequiredFields.Text = "(*) Campos requeridos.";
            lblSubCategoryName.Text = "* Sub-Categoría: ";
            lblCategory.Text = "* Categoría: ";
            lblEnabled.Text = "Activar";
            btnCancel.Text = "Regresar";
        }

        #region SetQuery
        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                this.ltTitle.Text = "Editar Sub-Categoría";
                String id = Encryption.Decrypt(Request.QueryString["q"]);
                if (!String.IsNullOrEmpty(id))
                {
                    vsId = Convert.ToInt32(id);
                    hfSubCategoryId.Value = id;
                }
                else
                {
                    GoBack();
                }
            }
            else
            {
                this.ltTitle.Text = "Agregar Sub-Categoría";
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
                    Products obj = null;
                    BaseEntity entity = new BaseEntity();
                    obj = CategoryBL.Instance.SubCategory_Get_ById(ref entity, vsId);
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
            hfSubCategoryId.Value = String.Empty;
            txtSubCategoryName.Text = String.Empty;
            ddlCategory.SelectedIndex = 0;
            chkStatus.Checked = true;
        }
        private void SetControls(Products objSubCategory)
        {
            try
            {
                hfSubCategoryId.Value = objSubCategory.subcategory.ID.ToString();
                txtSubCategoryName.Text = objSubCategory.subcategory.Name.ToString();
                ddlCategory.SelectedValue = objSubCategory.category.ID.ToString();
                chkStatus.Checked = objSubCategory.subcategory.Status == (int)EnumStatus.Enabled ? true : false;
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        [WebMethod]
        public static Object SubCategory_Save(srSubCategory u)
        {
            BaseEntity entity = new BaseEntity();
            Boolean success = false;
            try
            {
                Products objSubCategory = new Products();

                objSubCategory.subcategory.ID = String.IsNullOrEmpty(u.Id) ? 0 : Convert.ToInt32(u.Id);
                objSubCategory.subcategory.Name = u.SubCategoryName.ToString();
                objSubCategory.subcategory.Status = Convert.ToInt32(u.Status);
                objSubCategory.category.ID = String.IsNullOrEmpty(u.CategoryId) ? 0 : Convert.ToInt32(u.CategoryId);

                success = CategoryBL.Instance.SubCategory_Save(ref entity, objSubCategory);
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
            Response.Redirect("SubCategoryEntry.aspx", false);
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }

    }
}
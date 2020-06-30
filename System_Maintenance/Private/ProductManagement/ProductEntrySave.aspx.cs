using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Brand;
using xAPI.BL.Category;
using xAPI.BL.Product;
using xAPI.BL.Resource;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.ProductManagement
{
    public partial class ProductEntrySave : System.Web.UI.Page
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
        private void LoadFieldTranslations()
        {
            lblRequiredFields.Text = "(*)Campos requeridos.";
            lblResourceCategory.Text = "Categoría del Producto:";
            lblResourceType.Text = "Tipo:";
            lblSystemContact.Text = "System Contact:";
            lblName.Text = "* Nombre:";
            lblBrand.Text = "* Marca";
            lblDescription.Text = " Descripción:";
            lblUploadFile.Text = "Subir Archivo:";
            lblUrl.Text = "Url:";
            rbFile.Text = "Subir Imagen";
            rbLink.Text = "Enlace";
            lblFileNameL.Text = "* Nombre de archivo y ubicación:  <br><small class='col-md-10'> Tamaño maximo: 5MB</small>";
            lblEnabled.Text = "Activar";
            btnUpload.Text = "Guardar";
            btnCancel.Text = "Regresar";
            lblUniMed.Text = "Unidad de Medida";
            lblPriceOffer.Text = "Precio de Oferta";
            lblUnitPrice.Text = "* Precio";
            lblStock.Text = "* Stock";
            lblSKU.Text = "SKU";
        }
     
        #region LoadDLL
        private void LoadData()
        {
            try
            {
                DDLType();
                LoadDDLCategory();
                LoadDDLBrand();
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        private void DDLType()
        {
            BaseEntity objEntity = new BaseEntity();
            DataTable dt = ResourceBL.Instance.ResourceType_GetAll(ref objEntity);
            try
            {
                if (objEntity.Errors.Count <= 0)
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            ddlResourceType.Items.Add(new ListItem(item["Name"].ToString(), item["Name"].ToString()));
                        }
                    }
                }
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
        private void LoadDDLBrand()
        {
            BaseEntity entity = new BaseEntity();
            DataTable dt = BrandBL.Instance.Product_Brand_GetList(ref entity);
            try
            {
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "ID";
                ddlBrand.DataBind();
                ddlBrand.Items.Add(new ListItem("-- Seleccionar Opción --", "0"));
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        #region SetQuery
        private void SetQuery()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["q"]))
            {
                ltTitle.Text = "Editar Producto";
                String id = Encryption.Decrypt(Request.QueryString["q"]);
                if (!String.IsNullOrEmpty(id))
                    vsId = Convert.ToInt32(id);
                else
                    GoBack();
            }
            else
            {
                ltTitle.Text = "Agregar Producto";
            }

        }
        #endregion

        #region SetData
        private void SetData()
        {
            if (vsId > 0)
            {
                Products obj = null;
                BaseEntity entity = new BaseEntity();
                obj = ProductBL.Instance.Products_GetList_ById(ref entity, vsId);
                if (entity.Errors.Count == 0)
                    if (obj != null)
                        SetControls(obj);
                    else
                        GoBack();
                else
                    Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        private void SetControls()
        {
            ddlResourceType.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlBrand.SelectedIndex = 0;
            hfProductId.Value = String.Empty;
            txtSku.Text = String.Empty;
            txtStock.Text = String.Empty;
            txtUnitPrice.Text = String.Empty;
            txtPriceOffer.Text = String.Empty;
            txtUniMed.Text = String.Empty;
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtUrl.Text = String.Empty;
            txtLink.Text = String.Empty;
            chkEnable.Checked = true;
            rbFile.Checked = true;
            rbLink.Checked = false;
        }
        private void SetControls(Products objProduct)
        {
            try
            {
                hfProductId.Value = objProduct.ID.ToString();
                ddlResourceType.SelectedValue = objProduct.DocType;
                txtDescription.Text = objProduct.Description;

                txtName.Text = objProduct.Name;
                ddlBrand.SelectedValue = objProduct.brand.ID.ToString();
                txtStock.Text = objProduct.Stock.ToString();
                txtUniMed.Text = objProduct.UniMed;
                txtUnitPrice.Text = objProduct.UnitPrice.ToString();
                txtPriceOffer.Text = objProduct.PriceOffer.ToString();

                ddlCategory.SelectedValue = objProduct.category.ID.ToString();
                chkEnable.Checked = objProduct.Status == (int)EnumStatus.Enabled ? true : false;
                rbFile.Checked = objProduct.IsUpload == 1 ? true : false;

                rbLink.Checked = objProduct.IsUpload == 0 ? true : false;
                txtUnitPrice.Text = objProduct.UnitPrice.ToString();
                if (rbFile.Checked == true)
                {
                    hfPathImage.Value = objProduct.NameResource;
                    hfFileExtension.Value = objProduct.FileExtension;
                    hfFileName.Value = objProduct.FileName;
                    hfPublicName.Value = objProduct.FilePublicName;
                }
                else
                {
                    //txtLink.Text = objProduct.NameResource;
                    txtLink.Text = Config.EnterpriseVirtualPath + EnumFolderSettings.FolderImages.GetStringValue() + objProduct.FilePublicName;

                }

                Page.ClientScript.RegisterStartupScript(GetType(), "DivfileDivLink", "fn_hide_show();", true);
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        #region Save
        public bool ParseEnum2<TEnum>(string sEnumValue) where TEnum : struct
        {
            bool success = false;

            foreach (int value in Enum.GetValues(typeof(TEnum)))
            {
                if (Enum.GetName(typeof(TEnum), value) == sEnumValue)
                    success = true;
            }
            return success;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpFileCollection hfc = null;
            HttpPostedFile hpf = null;
            Products objProduct = new Products();
            try
            {
                hfc = Request.Files;
                objProduct.ID = vsId;
                objProduct.DocType = ddlResourceType.SelectedItem.Text.Trim();
                objProduct.category.ID = Convert.ToInt32(ddlCategory.SelectedValue);
                objProduct.brand.ID = Convert.ToInt32(ddlBrand.SelectedValue);
                objProduct.Name = HtmlSanitizer.SanitizeHtml(txtName.Text.Trim());
                objProduct.Stock = Convert.ToInt32(txtStock.Text.Trim());
                objProduct.UniMed = HtmlSanitizer.SanitizeHtml(txtUniMed.Text.Trim());
                objProduct.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                if (txtPriceOffer.Text.Trim() == "")
                {
                    objProduct.PriceOffer = 0;
                }
                else {
                    objProduct.PriceOffer = Convert.ToDecimal(txtPriceOffer.Text.Trim());
                }
                objProduct.Description = HtmlSanitizer.SanitizeHtml(txtDescription.Text);
                objProduct.Status = chkEnable.Checked ? (Int16)EnumStatus.Enabled : (Int16)EnumStatus.Disabled;
                if (String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    Message(EnumAlertType.Error, "Debe ingresar un nombre ");
                    return;
                }
                if (String.IsNullOrEmpty(txtStock.Text.Trim()))
                {
                    Message(EnumAlertType.Error, "Debe ingresar Stock ");
                    return;
                }
                
                if (String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
                {
                    Message(EnumAlertType.Error, "Debe ingresar precio del producto ");
                    return;
                }
               
                if (rbFile.Checked == true || rbFile.Checked == false)
                {
                    objProduct.IsUpload = 1;
                    if (vsId == 0 && hfc.Count > 0)
                    {
                        hpf = hfc[0];
                        UploadanImage(objProduct);
                    }
                    else
                    {
                        hpf = hfc[0];
                        if (hpf.ContentLength > 0)
                        {
                            UploadanImage(objProduct);
                        }
                        else
                        {
                            objProduct.NameResource = hfPathImage.Value.Split('\\')[0] + "\\";
                            objProduct.FileName = hfFileName.Value;
                            objProduct.FilePublicName = hfPublicName.Value.Split('.')[0];
                            objProduct.FileExtension = hfFileExtension.Value;
                            hpf = null;
                        }
                    }
                }
                else
                {
                    objProduct.IsUpload = 0;
                    objProduct.NameResource = txtLink.Text;
                    objProduct.FileName = "External Url";
                    objProduct.FilePublicName = clsUtilities.GeneratePublicName(BaseSession.SsUser.Id_Usuario);
                    objProduct.FileExtension = "ext";
                }

                BaseEntity entity = new BaseEntity();

                Int32 quantityLegalDocument = ProductBL.Instance.Get_QuantityLegalDocuments(ref entity, objProduct);
                if (quantityLegalDocument == 0)
                {
                    SaveProduct(objProduct, hpf);
                }
                else
                {
                    Message(EnumAlertType.Error, "Category or language already exists in another resource");
                }
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        private void SaveProduct(Products objProduct, HttpPostedFile hpf)
        {
            BaseEntity entity = new BaseEntity();
            bool success = ProductBL.Instance.Product_Save(ref entity, objProduct);
            if (entity.Errors.Count <= 0)
            {
                if (success)
                {
                    string savedFileName = string.Empty;
                    if (hpf != null)
                    {

                        if (objProduct.FileExtension.ToLower() == ".bmp" || objProduct.FileExtension.ToLower() == ".jpeg" || objProduct.FileExtension.ToLower() == ".jpg" || objProduct.FileExtension.ToLower() == ".png" || objProduct.FileExtension.ToLower() == ".gif")
                            savedFileName = Config.EnterprisePhysicalPath + EnumFolderSettings.FolderImages.GetStringValue() + objProduct.FilePublicName;
                        else
                            savedFileName = Config.EnterprisePhysicalPath + EnumFolderSettings.FolderDocs.GetStringValue() + objProduct.FilePublicName;
                        if (!Directory.Exists(Config.EnterprisePhysicalPath + EnumFolderSettings.FolderDocs.GetStringValue()))
                        {
                            Directory.CreateDirectory(Config.EnterprisePhysicalPath + EnumFolderSettings.FolderDocs.GetStringValue());
                        }
                        if (!Directory.Exists(Config.EnterprisePhysicalPath + EnumFolderSettings.FolderImages.GetStringValue()))
                        {
                            Directory.CreateDirectory(Config.EnterprisePhysicalPath + EnumFolderSettings.FolderImages.GetStringValue());
                        }
                        hpf.SaveAs(savedFileName);
                    }

                    if (vsId == 0)
                        SetControls();

                    Message(EnumAlertType.Success, "Se guardo correctamente!");
                }
                else
                {
                    Message(EnumAlertType.Error, "Invalid Language");
                }
            }
        }
        private Products UploadanImage(Products resources)
        {
            string FileName = "";
            Products objProduct = resources ?? new Products();
            try
            {
                HttpFileCollection hfc = Request.Files;
                HttpPostedFile hpf = hfc[0];
                if (hpf.ContentLength > 0)
                {
                    if (hpf.ContentLength < 5242880)
                    {
                        #region MyRegion

                        FileName = hpf.FileName;
                        string Extension = Path.GetExtension(FileName).ToLower().Replace(".", "");
                        string DocType = objProduct.DocType;
                        bool returnsw = false;
                        switch (objProduct.DocType)
                        {
                            case "Document":
                                if (!ParseEnum2<EnumDocumentFileFormat>(Extension))
                                {
                                    Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                }
                                break;
                            case "Image":
                                if (!ParseEnum2<EnumImageFileFormat>(Extension))
                                {
                                    Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                }
                                break;
                            case "Audio":
                                if (!ParseEnum2<EnumAudioFileFormat>(Extension))
                                {
                                    Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                }
                                break;
                            case "Video":
                                if (!ParseEnum2<EnumVideoFileFormat>(Extension))
                                {
                                    Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                }
                                break;
                            case "Presentation":
                                if (!ParseEnum2<EnumPresentationFileFormat>(Extension))
                                {
                                    Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                }
                                break;
                            default:
                                break;
                        }
                        if (returnsw)
                            return objProduct;
                        Random r = new Random(DateTime.Now.Millisecond);
                        FileName = r.Next(1000, 9999) + "_" + Regex.Replace(FileName, @"[^0-9a-zA-Z\._]", string.Empty);
                        objProduct.FileName = FileName;
                        objProduct.FilePublicName = clsUtilities.GeneratePublicName(BaseSession.SsUser.Id_Usuario);
                        objProduct.FileExtension = Path.GetExtension(FileName).ToLower();

                        if (objProduct.FileExtension.ToLower() == ".bmp" || objProduct.FileExtension.ToLower() == ".jpeg" || objProduct.FileExtension.ToLower() == ".jpg" || objProduct.FileExtension.ToLower() == ".png" || objProduct.FileExtension.ToLower() == ".gif")
                            objProduct.NameResource = Config.EnterpriseVirtualPath + EnumFolderSettings.FolderImages.GetStringValue();
                        else
                            objProduct.NameResource = Config.EnterpriseVirtualPath + EnumFolderSettings.FolderDocs.GetStringValue();
                        #endregion
                    }
                    else
                    {
                        hpf = null;
                        Message(EnumAlertType.Info, "File size is over 5MB");
                    }
                }
                else
                {
                    hpf = null;
                    Message(EnumAlertType.Info, "Seleccione una imagen File size is 0MB");
                }
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
            return objProduct;
        }

        #endregion


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        private void GoBack()
        {
            Response.Redirect("ProductEntry.aspx", false);
        }

       public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }
    }
}
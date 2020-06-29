using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Category;
using xAPI.BL.Resource;
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
                LoadData();
                SetData();
                LoadFieldTranslations();
            }
        }
        private void LoadData()
        {
            try
            {
                DDLType();
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        private void LoadFieldTranslations()
        {
            lblRequiredFields.Text = "(*)Campos requeridos.";
            lblName.Text = "* Nombre:";
            lblDescription.Text = " Descripción:";
            lblEnabled.Text = "Activar";
            btnCancel.Text = "Regresar";
            btnUpload.Text = "Guardar";
            lblResourceType.Text = "Tipo:";
            lblUploadFile.Text = "Subir Archivo:";
            lblUrl.Text = "Url:";
            rbFile.Text = "Subir Imagen";
            rbLink.Text = "Enlace";
            lblFileNameL.Text = "* Nombre de archivo y ubicación:  <br><small class='col-md-10'> Tamaño maximo: 5MB</small>";
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

        private void SetControls()
        {
            hfCategoryId.Value = String.Empty;
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            chkEnable.Checked = true;
        }
        private void SetControls(Categorys objCategory)
        {
            try
            {
                hfCategoryId.Value = objCategory.ID.ToString();
                txtName.Text = objCategory.Name;
                txtDescription.Text = objCategory.Description;
                chkEnable.Checked = objCategory.Status == (int)EnumStatus.Enabled ? true : false;
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion

        //[WebMethod]
        //public static Object Category_Save(srCategory u)
        //{
        //    BaseEntity entity = new BaseEntity();
        //    Boolean success = false;
        //    try
        //    {
        //        Categorys objCategory = new Categorys
        //        {
        //            ID = String.IsNullOrEmpty(u.Id) ? 0 : Convert.ToInt32(u.Id),
        //            Name = u.Name.ToString(),
        //            Description = u.Description.ToString(),
        //            Status = Convert.ToInt32(u.Status)
        //        };

        //        success = CategoryBL.Instance.Category_Save(ref entity, objCategory);
        //        if (entity.Errors.Count <= 0 && success)
        //        {
        //            return new { Msg = "Se guardo correctamente!", Result = "Ok" };

        //        }
        //        else
        //        {
        //            return new { Msg = "No se pudo guardar", Result = "NoOK" };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new { Msg = "No se pudo guardar", Result = "NoOK" };
        //    }
        //}

        #region Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpFileCollection hfc = null;
            HttpPostedFile hpf = null;
            Categorys objCategory = new Categorys();
            try
            {
                hfc = Request.Files;
                objCategory.ID = vsId;
                objCategory.DocType = ddlResourceType.SelectedItem.Text.Trim();
                objCategory.Name = HtmlSanitizer.SanitizeHtml(txtName.Text.Trim());
                objCategory.Description = HtmlSanitizer.SanitizeHtml(txtDescription.Text);
                objCategory.Status = chkEnable.Checked ? (Int16)EnumStatus.Enabled : (Int16)EnumStatus.Disabled;
                
                if (String.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    Message(EnumAlertType.Error, "Debe ingresar un nombre ");
                    return;
                }
               
                if (rbFile.Checked == true || rbFile.Checked == false)
                {
                    objCategory.IsUpload = 1;
                    if (vsId == 0 && hfc.Count > 0)
                    {
                        hpf = hfc[0];
                        UploadanImage(objCategory);
                    }
                    else
                    {
                        hpf = hfc[0];
                        if (hpf.ContentLength > 0)
                        {
                            UploadanImage(objCategory);
                        }
                        else
                        {
                            objCategory.NameResource = hfPathImage.Value.Split('\\')[0] + "\\";
                            objCategory.FileName = hfFileName.Value;
                            objCategory.FilePublicName = hfPublicName.Value.Split('.')[0];
                            objCategory.FileExtension = hfFileExtension.Value;
                            hpf = null;
                        }
                    }
                }
                else
                {
                    objCategory.IsUpload = 0;
                    objCategory.NameResource = txtLink.Text;
                    objCategory.FileName = "External Url";
                    objCategory.FilePublicName = clsUtilities.GeneratePublicName(BaseSession.SsUser.Id_Usuario);
                    objCategory.FileExtension = "ext";
                }

                BaseEntity entity = new BaseEntity();

                Int32 quantityLegalDocument = CategoryBL.Instance.Get_QuantityLegalDocuments(ref entity, objCategory);
                if (quantityLegalDocument == 0)
                {
                    CategorySave(objCategory, hpf);
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
        private void CategorySave(Categorys objCategory, HttpPostedFile hpf)
        {
            BaseEntity entity = new BaseEntity();
            bool success = CategoryBL.Instance.Category_Save(ref entity, objCategory);
            if (entity.Errors.Count <= 0)
            {
                if (success)
                {
                    string savedFileName = string.Empty;
                    if (hpf != null)
                    {

                        if (objCategory.FileExtension.ToLower() == ".bmp" || objCategory.FileExtension.ToLower() == ".jpeg" || objCategory.FileExtension.ToLower() == ".jpg" || objCategory.FileExtension.ToLower() == ".png" || objCategory.FileExtension.ToLower() == ".gif")
                            savedFileName = Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderImages.GetStringValue() + objCategory.FilePublicName;
                        else
                            savedFileName = Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderDocs.GetStringValue() + objCategory.FilePublicName;
                        if (!Directory.Exists(Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderDocs.GetStringValue()))
                        {
                            Directory.CreateDirectory(Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderDocs.GetStringValue());
                        }
                        if (!Directory.Exists(Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderImages.GetStringValue()))
                        {
                            Directory.CreateDirectory(Config.EnterprisePhysicalPathCategory + EnumFolderSettings.FolderImages.GetStringValue());
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
        private Categorys UploadanImage(Categorys resources)
        {
            string FileName = "";
            Categorys objCategory = resources ?? new Categorys();
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
                        string DocType = objCategory.DocType;
                        bool returnsw = false;
                        switch (objCategory.DocType)
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
                            return objCategory;
                        Random r = new Random(DateTime.Now.Millisecond);
                        FileName = r.Next(1000, 9999) + "_" + Regex.Replace(FileName, @"[^0-9a-zA-Z\._]", string.Empty);
                        objCategory.FileName = FileName;
                        objCategory.FilePublicName = clsUtilities.GeneratePublicName(BaseSession.SsUser.Id_Usuario);
                        objCategory.FileExtension = Path.GetExtension(FileName).ToLower();

                        if (objCategory.FileExtension.ToLower() == ".bmp" || objCategory.FileExtension.ToLower() == ".jpeg" || objCategory.FileExtension.ToLower() == ".jpg" || objCategory.FileExtension.ToLower() == ".png" || objCategory.FileExtension.ToLower() == ".gif")
                            objCategory.NameResource = Config.EnterpriseVirtualPathCategory + EnumFolderSettings.FolderImages.GetStringValue();
                        else
                            objCategory.NameResource = Config.EnterpriseVirtualPathCategory + EnumFolderSettings.FolderDocs.GetStringValue();
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
            return objCategory;
        }
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

        #endregion
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
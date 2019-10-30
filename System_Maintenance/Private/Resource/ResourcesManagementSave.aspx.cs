using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System_Maintenance.src.app_code;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Resource
{
    public partial class ResourcesManagementSave : Page
    {

        public int vsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default(int); }
            set { ViewState["ID"] = value; }
        }

        public string vsName
        {
            get { return ViewState["NAME"] != null ? (string)ViewState["NAME"] : default(string); }
            set { ViewState["NAME"] = value; }
        }

        public int vsLId
        {
            get { return ViewState["LID"] != null ? (int)ViewState["LID"] : default(int); }
            set { ViewState["LID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                SetQuery();
                SetData();
                LoadFieldTranslations();
            }
        }

        private void LoadFieldTranslations()
        {
            lblRequiredFields.Text = "(*)Campos requeridos.";

            lblResourceCategory.Text = "Categoria de recurso:";
            lblResourceType.Text = "Tipo:";

            lblSystemContact.Text = "System Contact:";

            lblName.Text = "* Nombre:";
            lblDescription.Text = "* Descripcion:";


            lblUploadFile.Text = "Subir Archivo:";

            lblUrl.Text = "Url:";

            rbFile.Text = "Archivo";
            rbLink.Text = "Enlace";
            lblFileNameL.Text = "* Nombre de archivo y ubicacion:  <br><small class='col-md-10'> Tamaño maximo: 5MB</small>";
            lblEnabled.Text = "Habilitado:";

            btnUpload.Text = "Guardar";
            btnCancel.Text = "Regresar";

        }

        public class clsResourceType
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        #region LoadData

        private void LoadData()
        {
            try
            {
                LoadDDL();
                BaseEntity entity = new BaseEntity();

                DataTable dtResCat = ResourceBL.Instance.ResourceCategories_GetAll(ref entity, 1);     

                LoadDDLResourceCategory(ddlResourceCategory, dtResCat);
              
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }



        private void LoadDdlListLanguage(ListBox ddl, DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    ddl.DataSource = dt;
                    ddl.DataTextField = "LANGUAGENAME";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                }
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }


        private void LoadDDL()
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

        private void LoadDDLResourceCategory(DropDownList ddl, DataTable dt)
        {
            try
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "NAME";
                ddl.DataValueField = "ID";
                ddl.DataBind();
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
                this.ltTitle.Text = "Editar recurso";
                string id = Encryption.Decrypt(Request.QueryString["q"]); 
                if (!string.IsNullOrEmpty(id))
                    vsId = Convert.ToInt32(id);
                else
                    GoBack();
            }
            else
            {
                this.ltTitle.Text = "Agregar recurso";
            }
         
        }
        #endregion

        #region SetData

        private void SetData()
        {
            if (vsId > 0)
            {
                AppResource obj = null;
                BaseEntity entity = new BaseEntity();

                obj = ResourceBL.Instance.AppResource_GetByID(ref entity, vsId);

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
            ddlResourceCategory.SelectedIndex = 0;
            hfDistributorId.Value = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtLink.Text = string.Empty;
            chkEnable.Checked = true;
            rbFile.Checked = true;
            rbLink.Checked = false;
       
        }

        private void SetControls(AppResource objAppResource)
        {
            try
            {
                this.hfDistributorId.Value = objAppResource.UserId.ToString();
                this.ddlResourceType.SelectedValue = objAppResource.DOCTYPE;
                this.txtDescription.Text = objAppResource.FileDescription;
                this.ddlResourceType.Enabled = false;

                this.txtName.Text = objAppResource.Name;

                this.ddlResourceCategory.SelectedValue = objAppResource.CategotyId.ToString();
                chkEnable.Checked = objAppResource.Status == (int)EnumStatus.Enabled ? true : false;                
                rbFile.Checked = objAppResource.isUpload == 1 ? true : false;

                rbLink.Checked = objAppResource.isUpload == 0 ? true : false;
                txtUnitPrice.Text = objAppResource.UnitPrice.ToString();
                if (rbFile.Checked == true)
                {
                    this.hfPathImage.Value = objAppResource.NameResource;
                    this.hfFileExtension.Value = objAppResource.FileExtension;
                    this.hfFileName.Value = objAppResource.FileName;
                    this.hfPublicName.Value = objAppResource.FilePublicName;
                }
                else
                {
                    this.txtLink.Text = objAppResource.NameResource;
                }
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "DivfileDivLink", "fn_hide_show();", true);                
            }
            catch (Exception ex)
            {
               Message(EnumAlertType.Error,"An error occurred while loading data");
            }


        }

        #endregion

        #region CRUD

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
            AppResource objAppResource = new AppResource();
            try
            {
                BaseEntity objEntity = new BaseEntity();
                JavaScriptSerializer sr = new JavaScriptSerializer();
                
                hfc = Request.Files;
                objAppResource.ID = vsId;
                objAppResource.DOCTYPE = ddlResourceType.SelectedItem.Text.Trim();
                objAppResource.CategotyId = Convert.ToInt32(ddlResourceCategory.SelectedValue);
                objAppResource.Name = HtmlSanitizer.SanitizeHtml(txtName.Text.Trim());
                objAppResource.FileDescription = HtmlSanitizer.SanitizeHtml(txtDescription.Text);
                objAppResource.Createdby = BaseSession.SsUser.Id_Usuario;
                objAppResource.Updatedby = BaseSession.SsUser.Id_Usuario;
                objAppResource.UserId = BaseSession.SsUser.Id_Usuario;
                objAppResource.Status = chkEnable.Checked ? (short)EnumStatus.Enabled : (short)EnumStatus.Disabled;
                objAppResource.Url = txtUrl.Text;
                objAppResource.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                   Message(EnumAlertType.Error, "Debe ingresar un nombre ");
                    return;
                }
                
                if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                   Message(EnumAlertType.Error, "Debe ingresar una descripcion ");
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    Message(EnumAlertType.Error, "Debe ingresar un precio. ");
                    return;
                }
                if (rbFile.Checked == true)
                {
                    objAppResource.isUpload = 1;
                    if (vsId == 0 && hfc.Count > 0)
                    {
                        hpf = hfc[0];
                        UploadanImage(objAppResource);
                    }
                    else
                    {
                        hpf = hfc[0];
                        if (hpf.ContentLength > 0)
                        {
                            UploadanImage(objAppResource);
                        }
                        else
                        {
                            objAppResource.NameResource = hfPathImage.Value.Split('\\')[0] + "\\";
                            objAppResource.FileName = hfFileName.Value;
                            objAppResource.FilePublicName = hfPublicName.Value.Split('.')[0];
                            objAppResource.FileExtension = hfFileExtension.Value;
                            hpf = null;
                        }
                    }
                }
                else
                {
                    objAppResource.isUpload = 0;
                    objAppResource.NameResource = txtLink.Text;
                    objAppResource.FileName = "External Url";
                    objAppResource.FilePublicName = txtLink.Text;
                    objAppResource.FileExtension = "ext";
                }

                BaseEntity entity = new BaseEntity();
          
                int quantityLegalDocument = ResourceBL.Instance.Get_QuantityLegalDocuments(ref entity, objAppResource/*, ListLanguage*/);
                if (quantityLegalDocument == 0)
                {
                    SaveResource(objAppResource, hpf);
                }
                else
                {
                   Message(EnumAlertType.Error, "Category or language already exists in another resource");
                }
            }            
            catch (Exception ex)
            {
               Message(EnumAlertType.Error,"An error occurred while loading data");
            }
        }

        #endregion

        private AppResource UploadanImage(AppResource resources)
        {
            string FileName = "";
            AppResource objAppResource = resources ?? new AppResource();
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
                        string DocType = objAppResource.DOCTYPE;
                        bool returnsw = false;
                        switch (objAppResource.DOCTYPE)
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
                                    //return;
                                }
                                break;
                            case "Audio":
                                if (!ParseEnum2<EnumAudioFileFormat>(Extension))
                                {
                                   Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                    //return;
                                }
                                break;
                            case "Video":
                                if (!ParseEnum2<EnumVideoFileFormat>(Extension))
                                {
                                   Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                    //return;
                                }
                                break;
                            case "Presentation":
                                if (!ParseEnum2<EnumPresentationFileFormat>(Extension))
                                {
                                   Message(EnumAlertType.Info, "Invalid file type");
                                    returnsw = true;
                                    //return;
                                }
                                break;
                            default:
                                break;
                        }
                        if (returnsw)
                            return objAppResource;
                        Random r = new Random(DateTime.Now.Millisecond);
                        FileName = r.Next(1000, 9999) + "_" + Regex.Replace(FileName, @"[^0-9a-zA-Z\._]", string.Empty);
                        objAppResource.FileName = FileName;
                        objAppResource.FilePublicName = clsUtilities.GeneratePublicName(BaseSession.SsUser.Id_Usuario);
                        objAppResource.FileExtension = Path.GetExtension(FileName).ToLower();

                        if (objAppResource.FileExtension.ToLower() == ".bmp" || objAppResource.FileExtension.ToLower() == ".jpeg" || objAppResource.FileExtension.ToLower() == ".jpg" || objAppResource.FileExtension.ToLower() == ".png" || objAppResource.FileExtension.ToLower() == ".gif")
                            objAppResource.NameResource = Config.EnterpriseVirtualPath + EnumFolderSettings.FolderImages.GetStringValue();
                        else
                            objAppResource.NameResource = Config.EnterpriseVirtualPath + EnumFolderSettings.FolderDocs.GetStringValue();
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
                    Message(EnumAlertType.Info, "File size is 0MB");
                }
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
            return objAppResource;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        private void GoBack()
        {
            Response.Redirect("ResourcesManagement.aspx", false);
        }

        private void LoadDdlApplications(DropDownList ddl, DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    ddl.DataSource = dt;
                    ddl.DataTextField = "NAME";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                }
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }

        private void SaveResource(AppResource objAppResource, HttpPostedFile hpf)
        {
            BaseEntity entity = new BaseEntity();
            bool success = ResourceBL.Instance.AppResource_Save(ref entity, /*ListLanguage,*/ objAppResource);
            if (entity.Errors.Count <= 0)
            {
                if (success)
                {
                    string savedFileName = string.Empty;
                    if (hpf != null)
                    {

                        if (objAppResource.FileExtension.ToLower() == ".bmp" || objAppResource.FileExtension.ToLower() == ".jpeg" || objAppResource.FileExtension.ToLower() == ".jpg" || objAppResource.FileExtension.ToLower() == ".png" || objAppResource.FileExtension.ToLower() == ".gif")
                            savedFileName = Config.EnterprisePhysicalPath + EnumFolderSettings.FolderImages.GetStringValue() + objAppResource.FilePublicName;
                        else
                            savedFileName = Config.EnterprisePhysicalPath + EnumFolderSettings.FolderDocs.GetStringValue() + objAppResource.FilePublicName;
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

                   Message(EnumAlertType.Success, "Saved successfully");
                }
                else
                {
                   Message(EnumAlertType.Error, "Invalid Language");
                }
            }
        }

        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }


    }
}
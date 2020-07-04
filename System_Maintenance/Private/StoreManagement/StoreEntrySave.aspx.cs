using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Setting;
using xAPI.Entity.Store;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.StoreManagement
{
    public partial class StoreEntrySave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                LoadFieldName();
            }
        }
        private void LoadData()
        {
            BaseEntity objEntity = new BaseEntity();
            Store objStore = SettingBL.Instance.Store_GetInformation(ref objEntity);

            if (objEntity.Errors.Count == 0)
            {
                if (objStore != null)
                {
                    SetControls(objStore);
                }
            }
            else
            {
                Message(EnumAlertType.Error, "Ocurrio un error al cargar la data");
            }
        }

        private void SetControls(Store objStore)
        {
            try
            {
                txtName.Text = !String.IsNullOrEmpty(objStore.Name.ToString()) ? objStore.Name.ToString(): "";
                txtAddress.Text = !String.IsNullOrEmpty(objStore.Address) ? objStore.Address.ToString() : "";
                txtEmail.Text = !String.IsNullOrEmpty(objStore.Email) ? objStore.Email.ToString() : ""; 
                txtPhone1.Text = !String.IsNullOrEmpty(objStore.Phone1) ? objStore.Phone1.ToString() : "";  
                txtPhone2.Text = !String.IsNullOrEmpty(objStore.Phone2) ? objStore.Phone2.ToString() : ""; 
                txtAttentionHours.Text = !String.IsNullOrEmpty(objStore.AttentionHours) ? objStore.AttentionHours.ToString() : "";  
                txtNoteDelivery.Text = !String.IsNullOrEmpty(objStore.NoteDelivery) ? objStore.NoteDelivery.ToString() : ""; 
                txtNoteSupport.Text = !String.IsNullOrEmpty(objStore.NoteSupport) ? objStore.NoteSupport.ToString() : ""; 
                txtNotePromotions.Text = !String.IsNullOrEmpty(objStore.NotePromotions) ? objStore.NotePromotions.ToString() : "";  
                txtNotePayment.Text = !String.IsNullOrEmpty(objStore.NotePayment) ? objStore.NotePayment.ToString() : "";
                txtYear.Text = !String.IsNullOrEmpty(objStore.Year.ToString()) ? objStore.Year.ToString() : "";  
                txtFacebook.Text = !String.IsNullOrEmpty(objStore.Facebook) ? objStore.Facebook.ToString() : "";  
                txtInstagram.Text = !String.IsNullOrEmpty(objStore.Instagram) ? objStore.Instagram.ToString() : ""; 
                txtYoutube.Text = !String.IsNullOrEmpty(objStore.Youtube) ? objStore.Youtube.ToString() : "";  
                txtTwitter.Text = !String.IsNullOrEmpty(objStore.Twitter) ? objStore.Twitter.ToString() : "";  

                hfStoreId.Value = HttpUtility.UrlEncode(Encryption.Encrypt(objStore.ID.ToString()));
            }
            catch (Exception)
            {
                Message(EnumAlertType.Error, "Ocurrio un error al cargar la data");
            }
        }
        public void LoadFieldName() {

            lblRequiredFields3.Text = "(*) Campos Requeridos.";
            lblName.Text = "* Nombre de mi Tienda: ";
            lblAddress.Text = "* Dirección: ";
            lblEmail.Text = "* Correo: ";
            lblPhone1.Text = "* Teléfono 1: ";
            lblPhone2.Text = "* Teléfono 2: ";
            lblAttentionHours.Text = "* Horario de atención: ";
            lblNoteDelivery.Text = "* Nota de Delivery: ";
            lblNoteSupport.Text =  "* Nota de Soporte: ";
            lblNotePromotions.Text =  "* Nota de Promoción: ";
            lblNotePayment.Text =  "* Nota de Pago: ";
            lblYear.Text =  "* Escriba Año actual: ";
            //lblBanner.Text =  "* Banner: ";
            //lblLogo.Text =  "* Logo: ";
            lblFacebook.Text =  "* Enlace de Facebook: ";
            lblInstagram.Text =  "* Enlace de Instagram: ";
            lblYoutube.Text = "* Enlace de Youtube: ";
            lblTwitter.Text = "* Enlace de Twitter: ";

            lblName2.Text = "* Nombre de mi Tienda: ";
            lblAddress2.Text = "* Dirección: ";
            lblEmail2.Text = "* Correo: ";
            lblPhone12.Text = "* Teléfono 1: ";
            lblPhone22.Text = "* Teléfono 2: ";
            lblAttentionHours2.Text = "* Horario de atención: ";
            lblNoteDelivery2.Text = "* Nota de Delivery: ";
            lblNoteSupport2.Text =  "* Nota de Soporte: ";
            lblNotePromotions2.Text =  "* Nota de Promoción: ";
            lblNotePayment2.Text =  "* Nota de Pago: ";
            lblYear2.Text =  "* Escriba Año actual: ";
            //lblBanner2.Text =  "* Banner: ";
            //lblLogo2.Text =  "* Logo: ";
            lblFacebook2.Text =  "* Enlace de Facebook: ";
            lblInstagram2.Text =  "* Enlace de Instagram: ";
            lblYoutube2.Text = "* Enlace de Youtube: ";
            lblTwitter2.Text = "* Enlace de Twitter: ";
        }

        [WebMethod]
        public static Object Store_UpdateInfo(srStore obj)
        {
            BaseEntity objEntity = new BaseEntity();
            
            try
            {
                Boolean success = false;
                Store objStore = new Store
                {
                    ID = String.IsNullOrEmpty(obj.Id) ? 0 : Convert.ToInt32(Encryption.Decrypt(HttpContext.Current.Server.UrlDecode(obj.Id))),
                    Name = obj.Name.ToString(),
                    Address = obj.Address.ToString(),
                    Email = obj.Email.ToString(),
                    Phone1 = obj.Phone1.ToString(),
                    Phone2 = obj.Phone2.ToString(),
                    AttentionHours = obj.AttentionHours.ToString(),
                    NoteDelivery = obj.NoteDelivery.ToString(),
                    NoteSupport = obj.NoteSupport.ToString(),
                    NotePromotions = obj.NotePromotions.ToString(),
                    NotePayment = obj.NotePayment.ToString(),
                    Year = String.IsNullOrEmpty(obj.Year) ? 0 : Convert.ToInt32(obj.Year),
                    Facebook = obj.Facebook.ToString(),
                    Instagram = obj.Instagram.ToString(),
                    Youtube = obj.Youtube.ToString(),
                    Twitter = obj.Twitter.ToString()
               };

                success = SettingBL.Instance.Store_UpdateInfo(ref objEntity, objStore);

                if (objEntity.Errors.Count <= 0 && success)
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
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }

    }
}
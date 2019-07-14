using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System_Maintenance.src.app_code;
using xAPI.Entity;
using xAPI.BL;
using xAPI.Entity.Security;
using xAPI.BL.Security;
using xAPI.Library.Base;
using System.Web.Services;
using xAPI.Entity.Environment;
using xAPI.BL.Environment;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Security
{
    public partial class Login : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDrowndonlist();
            }
        }

        private void LoadDrowndonlist()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Ambiente> objTipoUsuario = AmbienteBL.Instance.LlenarAmbiente(ref objBase);
                List<TipoUsuario> objTipoUsuarios = TipoUsuarioBL.Instance.LlenarTipoUsuarios(ref objBase);

                ddlAmbiente.DataSource = objTipoUsuario;
                ddlAmbiente.DataTextField = "Nombre_Ambiente";
                ddlAmbiente.DataValueField = "Id_Ambiente";
                ddlAmbiente.DataBind();

                ddlRol.DataSource = objTipoUsuarios;
                ddlRol.DataTextField = "Nombre_TipUsuario";
                ddlRol.DataValueField = "Id_TipoUsuario";
                ddlRol.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static Object LoginSecurity(dynamic objUser)
        {
            Object objReturn = new { Result = "NoOk" };
            BaseEntity objBase = new BaseEntity();
            try
            {
                String dni = objUser["Dni"];
                String password = objUser["Password"];
                Usuario objUsuario = UsuarioBL.Instance.ValidateLogin(ref objBase, dni, password);
                if (objUsuario != null)
                {
                    objReturn = new
                    {
                        Result = "Ok"
                    };

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturn;
        }

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BaseEntity objBase = new BaseEntity();
            try
            {
                String dni = txtdni.Text;
                String password = txtpassword.Text;
                Usuario objUsuario = UsuarioBL.Instance.ValidateLogin(ref objBase, dni, password);
                if (objUsuario != null)
                {
                    BaseSession.SsUser = objUsuario;
                    Response.Redirect("~/Private/Incidents/Home.aspx", false);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
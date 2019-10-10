using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using System_Maintenance.src.app_code;
using xAPI.BL.Security;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xAPI.Library.General;
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
                List<TipoUsuario> objTipoUsuarios = TipoUsuarioBL.Instance.LlenarTipoUsuarios(ref objBase);
                
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
                Int32 tipousuario = Convert.ToInt32(objUser["Id_TipoUsuario"]);
                Usuarios obj = new Usuarios()
                {
                    Dni_Usuario = dni,
                    Contrasena = password,
                    Id_TipoUsuario = tipousuario
                };
                Usuarios objUsuario = UsuarioBL.Instance.ValidateLogin(ref objBase, obj);
                if (objBase.Errors.Count == 0)
                {
                    if (objUsuario != null)
                    {
                        if (objUsuario.Estado == (Int32)EnumEsatado.Inactivo)
                        {
                            objReturn = new
                            {
                                Result = "NoOk",
                                Msg = "Usuario Inactivo"
                            };
                        }
                        else
                        {
                            if (objUsuario.Estado == (Int32)EnumEsatado.Activo)
                            {
                                BaseSession.SsUser = objUsuario;
                                objReturn = new
                                {
                                    Result = "Ok",
                                    Msg = "../Incidents/Home.aspx"
                                };
                            }                          
                        }
                    }
                    else
                    {
                        objReturn = new
                        {
                            Result = "NoOk",
                            Msg = "Credenciales Incorrectas."
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrio un error al intentar Iniciar Sesion."
                };
            }
            return objReturn;
        }

        
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    BaseEntity objBase = new BaseEntity();
        //    try
        //    {
        //        String dni = txtdni.Text;
        //        String password = txtpassword.Text;
        //        Usuarios objUsuario = UsuarioBL.Instance.ValidateLogin(ref objBase, );
        //        if (objUsuario != null)
        //        {
        //            BaseSession.SsUser = objUsuario;
        //            Response.Redirect("~/Private/Incidents/Home.aspx", false);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
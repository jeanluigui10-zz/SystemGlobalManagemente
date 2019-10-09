using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System_Maintenance.src.app_code;
using xAPI.BL.Environment;
using xAPI.BL.Security;
using xAPI.Entity.Environment;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Registro
{
    public partial class AsignacionUsuarioAmbiente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarUsuarios();
                CargarAmbientes();

            }
        }

        private void CargarUsuarios()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Usuarios> lst = UsuarioBL.Instance.ListarUsuarios(ref objBase);

                ddlUsuario.DataSource = lst;
                ddlUsuario.DataTextField = "Nombre_Usuario";
                ddlUsuario.DataValueField = "Id_Usuario";
                ddlUsuario.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarAmbientes()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Ambientes> lst = AmbienteBL.Instance.LlenarAmbiente(ref objBase);

                ddlAmbiente.DataSource = lst;
                ddlAmbiente.DataTextField = "Piso_Ambiente";
                ddlAmbiente.DataValueField = "Id_Ambiente";
                ddlAmbiente.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static object Registro(Detalle_AmbienteUsuario obj)
        {

            try
            {
                BaseEntity objBase = new BaseEntity();
                obj.Id_Usuario = obj.Id_Usuario;
                obj.Id_Ambiente= obj.Id_Ambiente;
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                Boolean success = Detalle_AmbienteUsuarioBL.Instance.RegistrarAsignacion_AmbienteUsuario(ref objBase, obj);
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Guardado correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando la asignacion" };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error guardando la asignacion" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error guardando la asignacion" };
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Security;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Registro
{
    public partial class RegistroUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDrowndonlist();
                ListarAsistentes();
            }
        }

        private void LoadDrowndonlist()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<TipoUsuario> objTipoUsuarios = TipoUsuarioBL.Instance.LlenarTipoUsuarios(ref objBase);
                
                ddlTipoUsuario.DataSource = objTipoUsuarios;
                ddlTipoUsuario.DataTextField = "Nombre_TipUsuario";
                ddlTipoUsuario.DataValueField = "Id_TipoUsuario";
                ddlTipoUsuario.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListarAsistentes()
        {
            BaseEntity objBase = new BaseEntity();

            List<Usuarios> list = UsuarioBL.Instance.ListarAsistenteUsuarios(ref objBase);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    string json = JsonConvert.SerializeObject(list);
                    hfData.Value = json.ToString();

                }
                else
                {
                    hfData.Value = String.Empty;
                }
            }
            else
            {
                hfData.Value = String.Empty;
            }
        }

        [WebMethod]
        public static object Recargar_ListaAsistentes()
        {
            BaseEntity objBase = new BaseEntity();

            List<Usuarios> list = UsuarioBL.Instance.ListarAsistenteUsuarios(ref objBase);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {                    
                    string json = JsonConvert.SerializeObject(list);
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lstUsers = json };
                }
                else
                {
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lstUsers = "" };
                }
            }
            else
            {
                return new { Result = "NoOk", Msg = "Ocurrio un problema al cargar los datos.", lstUsers = "" };
            }
        }

        [WebMethod]
        public static object Registro(Usuarios obj)
        {
            Boolean success;
            String msg = String.Empty;
            String msgError = String.Empty;
            try
            {
                BaseEntity objBase = new BaseEntity();
                obj.APaterno_Usuario = obj.APaterno_Usuario;
                obj.AMaterno_Usuario = obj.AMaterno_Usuario;
                obj.Dni_Usuario = obj.Dni_Usuario;
                obj.Contrasena = obj.Contrasena;
                obj.Estado = obj.Estado;
                obj.Id_TipoUsuario = obj.Id_TipoUsuario;
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                if (obj.Id_Usuario > 0)
                {
                     success = UsuarioBL.Instance.ActualizarUsuario(ref objBase, obj);
                     msg = "Actualizado correctamente.";
                    msgError = "A ocurrido un error actualizando el usuario";
                }
                else
                {
                     success = UsuarioBL.Instance.RegistrarUsuario(ref objBase, obj);
                    msg = "Guardado correctamente.";
                    msgError = "A ocurrido un error guardando el usuario";
                }
                
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = msg };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = msgError };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
            }
        }

        [WebMethod]
        public static object Eliminacion(Usuarios obj)
        {
            Boolean success;
            String msg = String.Empty;
            String msgError = String.Empty;
            try
            {
                BaseEntity objBase = new BaseEntity();
               
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                if (obj.Id_Usuario > 0)
                {
                    success = UsuarioBL.Instance.EliminarUsuario(ref objBase, obj);
                    msg = "Eliminado correctamente.";
                    msgError = "A ocurrido un error eliminando el usuario";
                }
                else
                {
                    success = UsuarioBL.Instance.RegistrarUsuario(ref objBase, obj);
                    msg = "Debe seleccionar un usuario para eliminar.";
                    msgError = "Debe seleccionar un usuario para eliminar.";
                }

                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = msg };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = msgError };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System_Maintenance.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Environment;
using xAPI.BL.Floor;
using xAPI.BL.Incidence;
using xAPI.BL.Report;
using xAPI.BL.Security;
using xAPI.BL.Status;
using xAPI.BL.Tool;
using xAPI.Entity.Category;
using xAPI.Entity.Environment;
using xAPI.Entity.Floor;
using xAPI.Entity.Incidence;
using xAPI.Entity.Report;
using xAPI.Entity.Security;
using xAPI.Entity.Status;
using xAPI.Entity.Tool;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Incidents
{
    public partial class Incident : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BaseEntity objBase = new BaseEntity();
                CargaIncidencias_ByUsuario();
                LlenarInformacion();
                LlenarCategorias(CategoriaBL.Instance.LlenarCategorias(ref objBase), ddlCategoria);
                LlenarEstadoEquipos(StatusBL.Instance.LlenarStatus(ref objBase), ddlEstadoEquipo);
                LlenarPiso(PisoBL.Instance.LlenarPiso(ref objBase), ddlPiso);
                LlenarUsuario(UsuarioBL.Instance.ListarUsuarios(ref objBase), ddlUsuario);


            }
        }

        private void LlenarUsuario(List<Usuarios> list, DropDownList ddl)
        {
            ddl.DataSource = list;
            ddl.DataTextField = "Nombre_Usuario";
            ddl.DataValueField = "Id_Usuario";
            ddl.DataBind();
        }

        private void LlenarPiso(List<Piso> list, DropDownList ddl)
        {
            ddl.DataSource = list;
            ddl.DataTextField = "Nombre_Piso";
            ddl.DataValueField = "Id_Piso";
            ddl.DataBind();
        }

        private void LlenarAmbientes(List<Ambientes> lst, DropDownList ddl)
        {
            ddl.DataSource = lst;
            ddl.DataTextField = "Nombre_Ambiente";
            ddl.DataValueField = "Id_Ambiente";
            ddl.DataBind();
        }

        private void LlenarCategorias(List<Categoria> lst, DropDownList ddl)
        {
            ddl.DataSource = lst;
            ddl.DataTextField = "Nombre_Categoria";
            ddl.DataValueField = "Id_Categoria";
            ddl.DataBind();
        }

        private void LlenarEstadoEquipos(List<State> lst, DropDownList ddl)
        {
            ddl.DataSource = lst;
            ddl.DataTextField = "Nombre_Condicion";
            ddl.DataValueField = "Id_Condicion";
            ddl.DataBind();
        }

        private void CargaIncidencias_ByUsuario()
        {
            BaseEntity objBase = new BaseEntity();
           
            List<Reporte> list = IncidenciaBL.Instance.IncidenciasAsignadas_ByUsusario(ref objBase, BaseSession.SsUser.Id_Usuario);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(list);
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

        private void LlenarInformacion()
        {
            fechaActualId.Text = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            nameCompleteUser.Enabled = false;
            nameCompleteUser.Text = BaseSession.SsUser.Nombre_Usuario + " " + BaseSession.SsUser.APaterno_Usuario + " " + BaseSession.SsUser.AMaterno_Usuario;
        }

        [WebMethod]
        public static object LlenarEquipos(String categoryId)
        {
            BaseEntity objBase = new BaseEntity();
            int.TryParse(categoryId, out int idcat);
            List<Equipo> lstEquipo = EquipoBL.Instance.LlenarCategorias(ref objBase, idcat);
                       
            return new
            {
                Result = "Ok",
                lstEquipo = lstEquipo
            };
        }

        [WebMethod]
        public static object LlenarAmbientes(String ambienteId)
        {
            BaseEntity objBase = new BaseEntity();
            int.TryParse(ambienteId, out int idamb);
            List<Ambientes> lstAmbiente = AmbienteBL.Instance.LlenarAmbientexPiso(ref objBase, idamb);

            return new
            {
                Result = "Ok",
                lstAmbiente = lstAmbiente
            };
        }

        [WebMethod]
        public static object RegistrarIncidencia(Incidencia objIncidencia)
        {
            
            try
            {
                BaseEntity objBase = new BaseEntity();
                objIncidencia.Id_Usuario = BaseSession.SsUser.Id_Usuario;
                objIncidencia.CreadoPor = BaseSession.SsUser.Id_Usuario;
                objIncidencia.FechaCreacion = DateTime.Now;
                objIncidencia.Estado = Convert.ToInt32(EnumEsatado.Activo);
                Boolean success = IncidenciaBL.Instance.RegistrarIncidencia(ref objBase, objIncidencia);
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Guardado correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando la incidencia" };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error guardando la incidencia" };
                }

            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error guardando la incidencia" };
            }
        }

        [WebMethod]
        public static object ReloadCargaIncidencias_ByUsuario()
        {
            BaseEntity objBase = new BaseEntity();

            List<Reporte> list = IncidenciaBL.Instance.IncidenciasAsignadas_ByUsusario(ref objBase, BaseSession.SsUser.Id_Usuario);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(list);
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lstIncidents = json };
                }
                else
                {
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lstIncidents = "" };
                }
            }
            else
            {
                return new { Result = "NoOk", Msg = "Ocurrio un problema al cargar los datos.", lstIncidents = "" };
            }
        }
    }
}
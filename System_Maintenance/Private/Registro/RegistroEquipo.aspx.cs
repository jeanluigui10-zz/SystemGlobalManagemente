using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Category;
using xAPI.BL.Environment;
using xAPI.BL.Floor;
using xAPI.BL.Tool;
using xAPI.Entity.Category;
using xAPI.Entity.Environment;
using xAPI.Entity.Floor;
using xAPI.Entity.Tool;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Registro
{
    public partial class RegistroEquipo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Llenar_Categoria();
                CargarLista();
            }
        }

        private void CargarLista()
        {
            BaseEntity objBase = new BaseEntity();

            List<Equipo> list = EquipoBL.Instance.CargarEquipos(ref objBase);
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
        public static object Recargar_Lista()
        {
            BaseEntity objBase = new BaseEntity();

            List<Equipo> list = EquipoBL.Instance.CargarEquipos(ref objBase);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    string json = JsonConvert.SerializeObject(list);
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lst = json };
                }
                else
                {
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lst = "" };
                }
            }
            else
            {
                return new { Result = "NoOk", Msg = "Ocurrio un problema al cargar los datos.", lst = "" };
            }
        }

        private void Llenar_Categoria()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Categoria> lst = CategoriaBL.Instance.LlenarCategorias(ref objBase);

                ddlCategoria.DataSource = lst;
                ddlCategoria.DataTextField = "Nombre_Categoria";
                ddlCategoria.DataValueField = "Id_Categoria";
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public static object Registro(Equipo obj)
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                obj.Id_Categoria = obj.Id_Categoria;
                obj.Nombre_Equipo = obj.Nombre_Equipo;
                obj.Descripcion_Equipo= obj.Descripcion_Equipo;
                obj.Estado = obj.Estado;
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                Boolean success = EquipoBL.Instance.RegistrarEquipo(ref objBase, obj);
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Guardado correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Equipo" };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Equipo" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Equipo" };
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Category;
using xAPI.Entity.Category;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Registro
{
    public partial class RegistroCategoria : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarLista();
            }
        }

        private void CargarLista()
        {
            BaseEntity objBase = new BaseEntity();

            List<Categoria> list = CategoriaBL.Instance.CargarCategorias(ref objBase);
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

            System.Collections.Generic.List<Categoria> list = CategoriaBL.Instance.CargarCategorias(ref objBase);
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

        [WebMethod]
        public static object Registro(Categoria obj)
        {

            try
            {
                BaseEntity objBase = new BaseEntity();
                obj.Nombre_Categoria = obj.Nombre_Categoria;
                obj.Descripcion_Categoria= obj.Descripcion_Categoria;
                obj.Estado = obj.Estado;
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                Boolean success = CategoriaBL.Instance.RegistrarCategoria(ref objBase, obj);
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Guardado correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Piso" };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Piso" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Piso" };
            }
        }
    }
}
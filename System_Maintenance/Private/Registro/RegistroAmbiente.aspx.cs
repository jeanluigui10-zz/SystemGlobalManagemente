using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Environment;
using xAPI.BL.Floor;
using xAPI.Entity.Environment;
using xAPI.Entity.Floor;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Registro
{
    public partial class RegistroAmbiente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Llenar_Piso();
                CargarLista();
            }
        }

        private void CargarLista()
        {
            BaseEntity objBase = new BaseEntity();

            List<Ambientes> list = AmbienteBL.Instance.LlenarAmbientes(ref objBase);
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

            List<Ambientes> list = AmbienteBL.Instance.LlenarAmbientes(ref objBase);
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


        private void Llenar_Piso()
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                List<Piso> lst = PisoBL.Instance.LlenarPiso(ref objBase);

                ddlPiso.DataSource = lst;
                ddlPiso.DataTextField = "Nombre_Piso";
                ddlPiso.DataValueField = "Id_Piso";
                ddlPiso.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public static object Registro(Ambientes obj)
        {

            try
            {
                BaseEntity objBase = new BaseEntity();
                obj.Id_Piso = obj.Id_Piso;
                obj.Nombre_Ambiente = obj.Nombre_Ambiente;
                obj.Descripcion_Ambiente= obj.Descripcion_Ambiente;
                obj.Estado = obj.Estado;
                obj.FechaCreacion = DateTime.Now;
                obj.CreadoPor = BaseSession.SsUser.Id_Usuario;
                Boolean success = AmbienteBL.Instance.RegistrarAmbiente(ref objBase, obj);
                if (objBase.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Guardado correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Ambiente" };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Ambiente" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error guardando el Ambiente" };
            }
        }
    }
}
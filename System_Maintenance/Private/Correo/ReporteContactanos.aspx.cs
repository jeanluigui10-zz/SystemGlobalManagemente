using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Report;
using xAPI.Entity.Report;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace System_Maintenance.Private.Correo
{
    public partial class ReporteContactanos :Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaReporte();
            }
        }

        private void CargaReporte()
        {
            BaseEntity objBase = new BaseEntity();
            String fechaInicio = (String.IsNullOrEmpty(hfFechaInicio.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaInicio.Value, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
            String fechaFin = (String.IsNullOrEmpty(hfFechaFin.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaFin.Value, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
            List<Contact> list = ReporteBL.Instance.ListarContactanos(ref objBase, fechaInicio, fechaFin);
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

        [WebMethod]
        public static object Cargar_Contactanos(string fechaInicio, string fechaFin)
        {
            BaseEntity objBase = new BaseEntity();
            String Inicio = (String.IsNullOrEmpty(fechaInicio)) ? "" : Convert.ToString(Convert.ToDateTime(fechaInicio, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
            String Fin = (String.IsNullOrEmpty(fechaFin)) ? "" : Convert.ToString(Convert.ToDateTime(fechaFin, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));

            List<Contact> list = ReporteBL.Instance.ListarContactanos(ref objBase, Inicio, Fin);
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(list);
                    return new { Result = "Ok", Msg = "Cargados correctamente.", lstContactanos = json };
                }
                else
                {
                    return new { Result = "NoOk", Msg = "Error al cargas los datos.", lstContactanos = "" };
                }
            }
            else
            {
                return new { Result = "NoOk", Msg = "Error al cargas los datos.", lstContactanos = "" };
            }
        }

        public void Export(DataTable dt)
        {
            String titulo = "Reporte_Contactanos";
            String archivo = titulo + " " + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx";
            clsExcel objExcel = new clsExcel();

            objExcel.ToExcelXL(dt, archivo, Page.Response);
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            BaseEntity objBase = new BaseEntity();

            String fechaInicio = (String.IsNullOrEmpty(hfFechaInicio.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaInicio.Value, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
            String fechaFin = (String.IsNullOrEmpty(hfFechaFin.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaFin.Value, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy"));
            List<ContactExport> list = ReporteBL.Instance.ListarContactanosExport(ref objBase, fechaInicio, fechaFin);
            DataTable dt = clsUtilities.ConvertToDataTable(list);
            Export(dt);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.BL.Report;
using xAPI.BL.Security;
using xAPI.Entity.Order;
using xAPI.Entity.Report;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace System_Maintenance.Private.Report
{
    public partial class ReportIncident : Page
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
            String fechaInicio = (String.IsNullOrEmpty(hfFechaInicio.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaInicio.Value, CultureInfo.InvariantCulture));
            String fechaFin = (String.IsNullOrEmpty(hfFechaFin.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaFin.Value,  CultureInfo.InvariantCulture));
            List<OrderHeader> list = ReporteBL.Instance.ListarVentas(ref objBase, fechaInicio, fechaFin);
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
        public static object Cargar_Ventas(string fechaInicio, string fechaFin)
        {
            BaseEntity objBase = new BaseEntity();
            String Inicio = (String.IsNullOrEmpty(fechaInicio)) ? "" : Convert.ToString(Convert.ToDateTime(fechaInicio, CultureInfo.InvariantCulture));
            String Fin = (String.IsNullOrEmpty(fechaFin)) ? "" : Convert.ToString(Convert.ToDateTime(fechaFin, CultureInfo.InvariantCulture));

            List<OrderHeader> list = ReporteBL.Instance.ListarVentas(ref objBase, Convert.ToDateTime(Inicio).ToString("MM/dd/yyyy"), Convert.ToDateTime(Fin).ToString("MM/dd/yyyy"));
            if (objBase.Errors.Count == 0)
            {
                if (list != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(list);
                    return new { Result = "Ok", Msg = "Cargados correctamente." , lstIncidents = json };
                }
                else
                {
                    return new { Result = "NoOk", Msg = "Error al cargas los datos." , lstIncidents = "" };
                }
            }
            else
            {
                return new { Result = "NoOk", Msg = "Error al cargas los datos." , lstIncidents = "" };
            }
        }

        public void Export(DataTable dt)
        {
            String titulo = "Reporte_Incidencia";
            String archivo = titulo + " " + DateTime.Now.ToString("MM-dd-yyyy") + ".xlsx";
            clsExcel objExcel = new clsExcel();

            objExcel.ToExcelXL(dt, archivo, Page.Response);
        }

        private void ExportCSV(DataTable dt, String Title)
        {
            BaseEntity entity = new BaseEntity();
            DataTable srList = dt;
            Int32 Rcount = dt.Rows.Count;
            String title = Title.Replace(" ", "_").Trim() + "_" + DateTime.Now.ToString("MM-dd-yyyy") + ".csv";
            clsCsv objCsv = new clsCsv();
            Boolean Success = false;

            Success = objCsv.CreateCSVFromDataTable(srList, "");

            if (Success)
            {
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}", title));
                Response.End();
            }
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            BaseEntity objBase = new BaseEntity();

            String fechaInicio = (String.IsNullOrEmpty(hfFechaInicio.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaInicio.Value, CultureInfo.InvariantCulture));
            String fechaFin = (String.IsNullOrEmpty(hfFechaFin.Value)) ? "" : Convert.ToString(Convert.ToDateTime(hfFechaFin.Value, CultureInfo.InvariantCulture));
            List<ReporteVentasExport> list = ReporteBL.Instance.ListarVentasExport(ref objBase, fechaInicio,fechaFin);
            DataTable dt = clsUtilities.ConvertToDataTable(list);
            Export(dt);
        }
    }
}
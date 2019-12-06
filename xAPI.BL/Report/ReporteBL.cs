using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Report;
using xAPI.Entity.Order;
using xAPI.Entity.Report;
using xAPI.Library.Base;

namespace xAPI.BL.Report
{
    public class ReporteBL
    {
        #region Singleton
        private static ReporteBL instance = null;
        public static ReporteBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReporteBL();
                return instance;
            }
        }
        #endregion


        public List<Reporte> ListarIncidencias(ref BaseEntity objBase, String fechaInicio, String fechaFin, Int32 idusuario)
        {
            objBase = new BaseEntity();
            List<Reporte> lstReport = null;
            try
            {
                lstReport = ReportDAO.Instance.ListarIncidencias(ref objBase, fechaInicio, fechaFin, idusuario);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstReport;
        }
        public List<ReporteExport> ListarIncidenciasExport(ref BaseEntity objBase, String fechaInicio, String fechaFin, Int32 idusuario)
        {
            objBase = new BaseEntity();
            List<ReporteExport> lstReport = null;
            try
            {
                lstReport = ReportDAO.Instance.ListarIncidenciasExport(ref objBase, fechaInicio, fechaFin, idusuario);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstReport;
        }

        public List<OrderHeader> ListarVentas(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            objBase = new BaseEntity();
            List<OrderHeader> lstVentas = null;
            try
            {
                lstVentas = ReportDAO.Instance.ListarVentas(ref objBase, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstVentas;
        }
        public List<ReporteVentasExport> ListarVentasExport(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            objBase = new BaseEntity();
            List<ReporteVentasExport> lstReport = null;
            try
            {
                lstReport = ReportDAO.Instance.ListarVentasExport(ref objBase, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstReport;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Report;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Report
{
    public class ReportDAO
    {
        #region Singleton
        private static ReportDAO instance = null;
        public static ReportDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReportDAO();
                return instance;
            }
        }
        #endregion
        public List<Reporte> ListarIncidencias(ref BaseEntity objBase, String fechaInicio, String fechaFin, Int32 idusuario)
        {
            SqlCommand ObjCmd = null;
            List<Reporte> listReport = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Incidencias", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                ObjCmd.Parameters.AddWithValue("@asistenteId", idusuario);
                listReport = new List<Reporte>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    Reporte objReport = new Reporte();
                    objReport.Id_Incidencia = dr.GetColumnValue<Int32>("Id_Incidencia");
                    objReport.Nombre_Usuario = dr.GetColumnValue<String>("Nombre_Usuario");
                    objReport.APaterno_Usuario = dr.GetColumnValue<String>("APaterno_Usuario");
                    objReport.AMaterno_Usuario = dr.GetColumnValue<String>("AMaterno_Usuario");
                    objReport.Nombre_TipUsuario = dr.GetColumnValue<String>("Nombre_TipUsuario");
                    objReport.Descripcion = dr.GetColumnValue<String>("Descripcion");
                    objReport.Piso_Ambiente = dr.GetColumnValue<String>("Nombre_Piso");
                    objReport.Nombre_Ambiente = dr.GetColumnValue<String>("Nombre_Ambiente");
                    objReport.Nombre_Categoria = dr.GetColumnValue<String>("Nombre_Categoria");
                    objReport.Nombre_Equipo = dr.GetColumnValue<String>("Nombre_Equipo");
                    objReport.FechaCreacion = dr.GetColumnValue<DateTime>("FechaCreacion").ToString();
                    objReport.IsCompleto = dr.GetColumnValue<String>("Completo");
                    objReport.IsCheckbox = "1";
                    objReport.Index = count.ToString();
                    listReport.Add(objReport);
                }
            }
            catch (Exception ex)
            {
                listReport = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Report not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listReport;
        }
        public List<ReporteExport> ListarIncidenciasExport(ref BaseEntity objBase, String fechaInicio, String fechaFin, Int32 idusuario)
        {
            SqlCommand ObjCmd = null;
            List<ReporteExport> listReport = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Incidencias", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                ObjCmd.Parameters.AddWithValue("@asistenteId", idusuario);
                listReport = new List<ReporteExport>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    ReporteExport objReport = new ReporteExport();
                    objReport.Id_Incidencia = dr.GetColumnValue<Int32>("Id_Incidencia");
                    objReport.Nombre_Usuario = dr.GetColumnValue<String>("Nombre_Usuario");
                    objReport.APaterno_Usuario = dr.GetColumnValue<String>("APaterno_Usuario");
                    objReport.AMaterno_Usuario = dr.GetColumnValue<String>("AMaterno_Usuario");
                    objReport.Nombre_TipUsuario = dr.GetColumnValue<String>("Nombre_TipUsuario");
                    objReport.Descripcion = dr.GetColumnValue<String>("Descripcion");
                    objReport.Piso_Ambiente = dr.GetColumnValue<String>("Nombre_Piso");
                    objReport.Nombre_Ambiente = dr.GetColumnValue<String>("Nombre_Ambiente");
                    objReport.Nombre_Categoria = dr.GetColumnValue<String>("Nombre_Categoria");
                    objReport.Nombre_Equipo = dr.GetColumnValue<String>("Nombre_Equipo");
                    objReport.FechaCreacion = dr.GetColumnValue<DateTime>("FechaCreacion").ToString();
                    objReport.IsCompleto = dr.GetColumnValue<String>("Completo");

                    listReport.Add(objReport);
                }
            }
            catch (Exception ex)
            {
                listReport = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Report not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listReport;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Order;
using xAPI.Entity.Report;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;
using xAPI.Entity.Customers;
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

        public List<OrderHeader> ListarVentas(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            SqlCommand ObjCmd = null;
            List<OrderHeader> lstOrders = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Order_GetAll_Sp", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                lstOrders = new List<OrderHeader>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    OrderHeader objOrderHeader = new OrderHeader();
                    objOrderHeader.OrderId = dr.GetColumnValue<Int32>("OrderId");
                    objOrderHeader.OrderDateStr = dr.GetColumnValue<DateTime>("OrderDate").ToString();
                    objOrderHeader.IGV = dr.GetColumnValue<Decimal>("IgvTotal");
                    objOrderHeader.SubTotal = dr.GetColumnValue<Decimal>("SubTotal");
                    objOrderHeader.Ordertotal = dr.GetColumnValue<Decimal>("Total");
                    objOrderHeader.LegacyNumber = dr.GetColumnValue<Int64>("LegacyNumber");
                    if (objOrderHeader.Customer == null)
                    {
                        objOrderHeader.Customer = new Customer() {
                            FirstName = dr.GetColumnValue<String>("FirstName")
                    };
                       

                    }
                     objOrderHeader.IsCheckbox = "1";
                     objOrderHeader.Index = count.ToString();
                     objOrderHeader.Status = dr.GetColumnValue<Int32>("Status");

                    lstOrders.Add(objOrderHeader);
                }
            }
            catch (Exception ex)
            {
                lstOrders = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Lista de Ventas no encontradas."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return lstOrders;
        }
        public List<ReporteVentasExport> ListarVentasExport(ref BaseEntity objBase, String fechaInicio, String fechaFin)
        {
            SqlCommand ObjCmd = null;
            List<ReporteVentasExport> lstOrders = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Order_GetAll_Sp", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                ObjCmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                lstOrders = new List<ReporteVentasExport>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    ReporteVentasExport objOrderHeader = new ReporteVentasExport();
                    objOrderHeader.OrderId = dr.GetColumnValue<String>("OrderId");
                    objOrderHeader.OrderDateStr = dr.GetColumnValue<DateTime>("OrderDate").ToString();
                    objOrderHeader.IGV = dr.GetColumnValue<String>("IgvTotal");
                    objOrderHeader.SubTotal = dr.GetColumnValue<String>("SubTotal");
                    objOrderHeader.Ordertotal = dr.GetColumnValue<String>("Total");
                    objOrderHeader.LegacyNumber = dr.GetColumnValue<String>("LegacyNumber");
                    objOrderHeader.FirstName = dr.GetColumnValue<String>("FirstName");                    
                    objOrderHeader.Status = dr.GetColumnValue<String>("Status");

                    lstOrders.Add(objOrderHeader);
                }
            }
            catch (Exception ex)
            {
                lstOrders = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Lista de Ventas no encontradas."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return lstOrders;
        }

    }
}

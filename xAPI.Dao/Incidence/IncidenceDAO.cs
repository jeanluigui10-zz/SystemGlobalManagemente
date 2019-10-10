using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Incidence;
using xAPI.Entity.Report;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Incidence
{
    public class IncidenceDAO
    {
        #region Singleton
        private static IncidenceDAO instance = null;
        public static IncidenceDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new IncidenceDAO();
                return instance;
            }
        }
        #endregion

        public Boolean RegistrarIncidencia(ref BaseEntity objBase, Incidencia obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_GuardarIncidencia", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Incidencia", obj.Id_Incidencia);
                cmd.Parameters.AddWithValue("@Id_Usuario", obj.Id_Usuario);
                cmd.Parameters.AddWithValue("@Id_Ambiente", obj.Id_Ambiente);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Id_Equipo", obj.Id_Equipo);
                cmd.Parameters.AddWithValue("@Completo", obj.Completo);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Id_Usuarioasignado", obj.Id_UsuarioAsignado);
                cmd.ExecuteNonQuery();
                success = true;              

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar incidencia not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public List<Reporte> IncidenciasAsignadas_ByUsusario(ref BaseEntity objBase, Int32 idusuario)
        {
            SqlCommand ObjCmd = null;
            List<Reporte> listReport = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_IncidenciaAsignada_ByUser", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@usuarioId", idusuario);
                listReport = new List<Reporte>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                    Reporte objReport = new Reporte();
                    objReport.Id_Incidencia = dr.GetColumnValue<Int32>("Id_Incidencia");
                    objReport.Id_Piso = dr.GetColumnValue<Int32>("Id_Piso");
                    objReport.Id_Ambiente = dr.GetColumnValue<Int32>("Id_Ambiente");
                    objReport.Id_Categoria = dr.GetColumnValue<Int32>("Id_Categoria");
                    objReport.Id_Equipo = dr.GetColumnValue<Int32>("Id_Equipo");
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

    }
}

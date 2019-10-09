using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Environment;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Environment
{
    public class Detalle_AmbienteUsuarioDAO
    {
        #region Singleton
        private static Detalle_AmbienteUsuarioDAO instance = null;
        public static Detalle_AmbienteUsuarioDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Detalle_AmbienteUsuarioDAO();
                return instance;
            }
        }
        #endregion


        public List<Ambientes> ListarAmbientexUsuario(ref BaseEntity objBase, int usuarioId)
        {
            SqlCommand ObjCmd = null;
            List<Ambientes> listAmbiente = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_ListarUsuarioAmbiente", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                listAmbiente = new List<Ambientes>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Ambientes objAmbiente = new Ambientes();
                    objAmbiente.Id_Ambiente = dr.GetColumnValue<Int32>("Id_Ambiente");
                    objAmbiente.Piso_Ambiente = dr.GetColumnValue<String>("Piso_Ambiente");
                    listAmbiente.Add(objAmbiente);
                }
            }
            catch (Exception ex)
            {
                listAmbiente = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listAmbiente;
        }

        public Boolean RegistrarAsignacion_AmbienteUsuario(ref BaseEntity objBase, Detalle_AmbienteUsuario obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Asignacion_UsuarioAmbiente", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", obj.Id_Usuario);
                cmd.Parameters.AddWithValue("@Id_Ambiente", obj.Id_Ambiente);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al Asignar usuario ambiente not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
    }
}

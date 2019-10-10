using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Floor;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Floor
{
    public class PisoDAO
    {
        #region Singleton
        private static PisoDAO instance = null;
        public static PisoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PisoDAO();
                return instance;
            }
        }
        #endregion

        public List<Piso> LlenarPiso(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Piso> listPiso = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Piso", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listPiso = new List<Piso>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Piso objPiso = new Piso();
                    objPiso.Id_Piso = dr.GetColumnValue<Int32>("Id_Piso");
                    objPiso.Nombre_Piso = dr.GetColumnValue<String>("Nombre_Piso");
                    listPiso.Add(objPiso);
                }
            }
            catch (Exception ex)
            {
                listPiso = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Piso not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listPiso;
        }

        public List<Piso> CargarPisos(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Piso> listPiso = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Sp_Lista_Piso]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listPiso = new List<Piso>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    Piso objPiso = new Piso();
                    count++;
                    objPiso.Id_Piso = dr.GetColumnValue<Int32>("Id_Piso");
                    objPiso.Nombre_Piso = dr.GetColumnValue<String>("Nombre_Piso");
                    objPiso.Estado = dr.GetColumnValue<Byte>("Estado");
                    objPiso.Index = count.ToString();
                    listPiso.Add(objPiso);
                }
            }
            catch (Exception ex)
            {
                listPiso = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Piso not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listPiso;
        }


        public Boolean RegistrarPiso(ref BaseEntity objBase, Piso obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Registro_Piso", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Piso", obj.Nombre_Piso);
                cmd.Parameters.AddWithValue("@Descripcion_Piso", obj.Descripcion_Piso);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
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
    }
}

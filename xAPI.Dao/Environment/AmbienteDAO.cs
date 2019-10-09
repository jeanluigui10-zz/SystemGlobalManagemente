using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Environment;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;
namespace xAPI.Dao.Environment
{
    public class AmbienteDAO
    {
        #region Singleton
        private static AmbienteDAO instance = null;
        public static AmbienteDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AmbienteDAO();
                return instance;
            }
        }
        #endregion


        public List<Ambientes> LlenarAmbiente(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Ambientes> listAmbiente = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Ambiente", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listAmbiente = new List<Ambientes>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Ambientes objAmbiente = new Ambientes();
                    objAmbiente.Id_Ambiente = dr.GetColumnValue<Int32>("Id_Ambiente");
                    objAmbiente.Nombre_Ambiente = dr.GetColumnValue<String>("Nombre_Ambiente");
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


        public List<Ambientes> LlenarAmbientes(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Ambientes> listAmbiente = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Sp_Listar_Ambientes]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listAmbiente = new List<Ambientes>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    Ambientes objAmbiente = new Ambientes();
                    count++;
                    objAmbiente.Id_Ambiente = dr.GetColumnValue<Int32>("Id_Ambiente");
                    objAmbiente.Nombre_Ambiente = dr.GetColumnValue<String>("Nombre_Ambiente");
                    objAmbiente.Piso_Ambiente = dr.GetColumnValue<String>("Nombre_Piso");
                    objAmbiente.Estado = dr.GetColumnValue<Byte>("Estado");
                    objAmbiente.Index = count.ToString();
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

        public Boolean RegistrarAmbiente(ref BaseEntity objBase, Ambientes obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Registro_Ambiente", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Piso", obj.Id_Piso); 
                cmd.Parameters.AddWithValue("@Nombre_Ambiente", obj.Nombre_Ambiente); 
                cmd.Parameters.AddWithValue("@Descripcion_Ambiente", obj.Descripcion_Ambiente);
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

        public List<Ambientes> LlenarAmbientexPiso(ref BaseEntity objBase, int idpiso)
        {
            SqlCommand ObjCmd = null;
            List<Ambientes> listAmbiente = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_AmbientexPiso", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@id_piso", idpiso);
                listAmbiente = new List<Ambientes>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Ambientes ObjAmbiente = new Ambientes();
                    ObjAmbiente.Id_Ambiente = dr.GetColumnValue<Int32>("Id_Ambiente");
                    ObjAmbiente.Nombre_Ambiente = dr.GetColumnValue<String>("Nombre_Ambiente");
                    listAmbiente.Add(ObjAmbiente);
                }
            }
            catch (Exception ex)
            {
                listAmbiente = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al cargar los ambientes."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listAmbiente;
        }

    }
}

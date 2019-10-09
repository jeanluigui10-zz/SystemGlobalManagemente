using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Tool;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Tool
{
    public class EquipoDAO
    {
        #region Singleton
        private static EquipoDAO instance = null;
        public static EquipoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EquipoDAO();
                return instance;
            }
        }
        #endregion

        public List<Equipo> LlenarEquipos(ref BaseEntity objBase, int categoryid)
        {
            SqlCommand ObjCmd = null;
            List<Equipo> listEquipo = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_EquipoxCategoria", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@categoryId", categoryid);
                listEquipo = new List<Equipo>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Equipo ObjEquipo = new Equipo();
                    ObjEquipo.Id_Equipo = dr.GetColumnValue<Int32>("Id_Equipo");
                    ObjEquipo.Nombre_Equipo = dr.GetColumnValue<String>("Nombre_Equipo");
                    listEquipo.Add(ObjEquipo);
                }
            }
            catch (Exception ex)
            {
                listEquipo = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Equipo not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listEquipo;
        }

        public List<Equipo> CargarEquipos(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Equipo> listEquipo = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Sp_Listar_Equipos]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listEquipo = new List<Equipo>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    Equipo ObjEquipo = new Equipo();
                    count++;
                    ObjEquipo.Id_Equipo = dr.GetColumnValue<Int32>("Id_Equipo");
                    ObjEquipo.Nombre_Equipo = dr.GetColumnValue<String>("Nombre_Equipo");
                    ObjEquipo.Nombre_Categoria = dr.GetColumnValue<String>("Nombre_Categoria");
                    ObjEquipo.Estado = dr.GetColumnValue<Byte>("Estado");
                    ObjEquipo.Index = count.ToString();
                    listEquipo.Add(ObjEquipo);
                }
            }
            catch (Exception ex)
            {
                listEquipo = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Equipo not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listEquipo;
        }


        public Boolean RegistrarEquipo(ref BaseEntity objBase, Equipo obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Registro_Equipo", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);
                cmd.Parameters.AddWithValue("@Nombre_Equipo", obj.Nombre_Equipo);
                cmd.Parameters.AddWithValue("@Descripcion_Equipo", obj.Descripcion_Equipo);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Equipo."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

    }
}

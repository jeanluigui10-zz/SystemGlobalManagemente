using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Status;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;
namespace xAPI.Dao.Status
{
    public class StatusDAO
    {
        #region Singleton
        private static StatusDAO instance = null;
        public static StatusDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusDAO();
                return instance;
            }
        }
        #endregion

        public List<State> LlenarEquipos(ref BaseEntity objBase, int categoryid)
        {
            SqlCommand ObjCmd = null;
            List<State> listEquipo = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_EquipoxCategoria", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@categoryId", categoryid);
                listEquipo = new List<State>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    State ObjEquipo = new State();
                    ObjEquipo.Id_Condicion = dr.GetColumnValue<Int32>("Id_Equipo");
                    ObjEquipo.Nombre_Condicion = dr.GetColumnValue<String>("Nombre_Equipo");
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
    }
}


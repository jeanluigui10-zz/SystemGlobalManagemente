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
    }
}

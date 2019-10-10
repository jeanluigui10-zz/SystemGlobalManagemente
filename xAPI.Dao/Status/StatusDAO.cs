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

        public List<State> LlenarStatus(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<State> lstStates = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_EstadoEquipo", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                lstStates = new List<State>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    State ObjEquipo = new State();
                    ObjEquipo.Id_Condicion = dr.GetColumnValue<Int32>("Id_Condicion");
                    ObjEquipo.Nombre_Condicion = dr.GetColumnValue<String>("Nombre_Condicion");
                    lstStates.Add(ObjEquipo);
                }
            }
            catch (Exception ex)
            {
                lstStates = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Estado equipo not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return lstStates;
        }
    }
}


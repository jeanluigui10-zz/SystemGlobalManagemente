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


        public List<Ambiente> LlenarAmbiente(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Ambiente> listAmbiente = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Ambiente", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listAmbiente = new List<Ambiente>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Ambiente objAmbiente = new Ambiente();
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
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Security
{
    public class TipoUsuarioDAO
    {
        #region Singleton
        private static TipoUsuarioDAO instance = null;
        public static TipoUsuarioDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TipoUsuarioDAO();
                return instance;
            }
        }
        #endregion

        public List<TipoUsuario> LlenarTipoUsuarios(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<TipoUsuario> listTipoUsuario = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("List_Usertype_Sp", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listTipoUsuario = new List<TipoUsuario>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoUsuario objTipoUsuario = new TipoUsuario();
                    objTipoUsuario.Id_TipoUsuario = dr.GetColumnValue<Int32>("Id_TipoUsuario");
                    objTipoUsuario.Nombre_TipUsuario = dr.GetColumnValue<String>("Nombre_TipUsuario");
                    listTipoUsuario.Add(objTipoUsuario);
                }
            }
            catch (Exception ex)
            {
                listTipoUsuario = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listTipoUsuario;
        }
    }
}

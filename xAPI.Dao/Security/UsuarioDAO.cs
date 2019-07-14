using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xAPI.Library.Base;
using xAPI.Library;
using System.Data.SqlClient;
using xAPI.Entity;
using System.Data;
using xAPI.Library.Connection;
using xAPI.Entity.Security;
using xAPI.Library.General;

namespace xAPI.Dao.Security
{
    public class UsuarioDAO
    {
        #region Singleton
        private static UsuarioDAO instance = null;
        public static UsuarioDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioDAO();
                return instance;
            }
        }
        #endregion

        public Usuario ValidatebyUsernameAndPassword(ref BaseEntity objBase, string username, string password)
        {
            SqlCommand ObjCmd = null;
            Usuario objUsers = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_ValidarLogueo", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@Username", username);
                ObjCmd.Parameters.AddWithValue("@Password", password);
                dr = ObjCmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsers = new Usuario();
                    objUsers.Id_Usuario = dr.GetColumnValue<Int32>("Id_Usuario");
                    objUsers.AMaterno_Usuario = dr.GetColumnValue<String>("AMaterno_Usuario");
                    objUsers.APaterno_Usuario = dr.GetColumnValue<String>("APaterno_Usuario");
                    objUsers.Nombre_Usuario = dr.GetColumnValue<String>("Nombre_Usuario");
                    objUsers.Dni_Usuario = dr.GetColumnValue<String>("Dni_Usuario");
                    objUsers.Contrasena = dr.GetColumnValue<String>("Contrasena");
                    objUsers.Estado = dr.GetColumnValue<Byte>("Estado");
                    objUsers.Id_TipoUsuario = dr.GetColumnValue<Int32>("Id_TipoUsuario");
                    //User.FechaCreacion = dr.GetColumnValue<DateTime>("FechaCreacion");
                    //User.FechaActualizacion = dr.GetColumnValue<DateTime>("FechaActualizacion");
                    //User.CreadoPor = dr.GetColumnValue<Int32>("CreadoPor");
                    //User.ActualizadoPor = dr.GetColumnValue<Int32>("ActualizadoPor");

                }
            }
            catch (Exception ex)
            {
                objUsers = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return objUsers;
        }

       
    }
}

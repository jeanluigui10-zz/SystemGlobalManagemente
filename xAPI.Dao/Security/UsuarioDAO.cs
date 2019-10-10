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

        public Usuarios ValidatebyUsernameAndPassword(ref BaseEntity objBase, Usuarios obj)
        {
            SqlCommand ObjCmd = null;
            Usuarios objUsers = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_ValidateLogin", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@Dni", obj.Dni_Usuario);
                ObjCmd.Parameters.AddWithValue("@Password", obj.Contrasena);
                ObjCmd.Parameters.AddWithValue("@Id_TipoUsuario", obj.Id_TipoUsuario);
                dr = ObjCmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsers = new Usuarios();
                    objUsers.Id_Usuario = dr.GetColumnValue<Int32>("UserId");
                    objUsers.AMaterno_Usuario = dr.GetColumnValue<String>("LastNameMaternal");
                    objUsers.APaterno_Usuario = dr.GetColumnValue<String>("LastNamePaternal");
                    objUsers.Nombre_Usuario = dr.GetColumnValue<String>("FirstName");
                    objUsers.Dni_Usuario = dr.GetColumnValue<String>("Dni");
                    objUsers.Contrasena = dr.GetColumnValue<String>("Password");
                    objUsers.Estado = dr.GetColumnValue<byte>("Status");
                    objUsers.Id_TipoUsuario = dr.GetColumnValue<Int32>("UserTypeId");
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

        public Boolean RegistrarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Registro_Usuario", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Usuario", obj.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@APaterno_Usuario", obj.APaterno_Usuario);
                cmd.Parameters.AddWithValue("@AMaterno_Usuario", obj.AMaterno_Usuario);
                cmd.Parameters.AddWithValue("@Dni_Usuario", obj.Dni_Usuario);
                cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Id_TipoUsuario", obj.Id_TipoUsuario);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
                cmd.ExecuteNonQuery();
                success = true;
                
            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public Boolean ActualizarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Actualizar_Usuario", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", obj.Id_Usuario);
                cmd.Parameters.AddWithValue("@Nombre_Usuario", obj.Nombre_Usuario);
                cmd.Parameters.AddWithValue("@APaterno_Usuario", obj.APaterno_Usuario);
                cmd.Parameters.AddWithValue("@AMaterno_Usuario", obj.AMaterno_Usuario);
                cmd.Parameters.AddWithValue("@Dni_Usuario", obj.Dni_Usuario);
                cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Id_TipoUsuario", obj.Id_TipoUsuario);
                cmd.Parameters.AddWithValue("@ActualizadoPor", obj.CreadoPor);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al actualizar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public Boolean EliminarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Eliminar_Usuario", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", obj.Id_Usuario);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al eliminar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public List<Usuarios> ListarUsuarios(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Usuarios> list= null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_Listar_Usuario", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                list = new List<Usuarios>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuarios obj = new Usuarios();
                    obj.Id_Usuario = dr.GetColumnValue<Int32>("Id_Usuario");
                    obj.Nombre_Usuario = dr.GetColumnValue<String>("Nombre_Usuario");
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                list = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return list;
        }
        
        public List<Usuarios> ListarAsistenteUsuarios(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Usuarios> list = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_ListarAsistente_Usuario", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                list = new List<Usuarios>();                                                                
                dr = ObjCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    Usuarios obj = new Usuarios();
                    count++;
                    obj.Id_Usuario = dr.GetColumnValue<Int32>("Id_Usuario");
                    obj.Nombre_Usuario = dr.GetColumnValue<String>("Nombre_Usuario");
                    obj.APaterno_Usuario = dr.GetColumnValue<String>("APaterno_Usuario");
                    obj.AMaterno_Usuario = dr.GetColumnValue<String>("AMaterno_Usuario");
                    obj.Dni_Usuario = dr.GetColumnValue<String>("Dni_Usuario");
                    obj.Contrasena = dr.GetColumnValue<String>("Contrasena");
                    obj.Nombre_TipUsuario = dr.GetColumnValue<String>("Nombre_TipUsuario");
                    obj.Id_TipoUsuario = dr.GetColumnValue<Int32>("Id_TipoUsuario");
                    obj.Estado = dr.GetColumnValue<Byte>("Estado");
                    obj.Index = count.ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                list = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return list;
        }
    }
}

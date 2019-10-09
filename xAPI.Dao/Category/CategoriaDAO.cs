using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Category;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Tool
{
    public class CategoriaDAO
    {
        #region Singleton
        private static CategoriaDAO instance = null;
        public static CategoriaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoriaDAO();
                return instance;
            }
        }
        #endregion

        public List<Categoria> LlenarCategorias(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Categoria> listCategoria = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Sp_ListarCategorias", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listCategoria = new List<Categoria>();
                dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria ObjCategory = new Categoria();
                    ObjCategory.Id_Categoria = dr.GetColumnValue<Int32>("Id_Categoria");
                    ObjCategory.Nombre_Categoria = dr.GetColumnValue<String>("Nombre_Categoria");
                    listCategoria.Add(ObjCategory);
                }
            }
            catch (Exception ex)
            {
                listCategoria = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Category not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listCategoria;
        }


        public List<Categoria> CargarCategorias(ref BaseEntity objBase)
        {
            SqlCommand ObjCmd = null;
            List<Categoria> listCategoria = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("[Sp_Listar_Categorias]", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                listCategoria = new List<Categoria>();
                dr = ObjCmd.ExecuteReader();
                int count = 0;  
                while (dr.Read())
                {
                    Categoria ObjCategory = new Categoria();
                    count++;
                    ObjCategory.Id_Categoria = dr.GetColumnValue<Int32>("Id_Categoria");
                    ObjCategory.Nombre_Categoria = dr.GetColumnValue<String>("Nombre_Categoria");
                    ObjCategory.Estado = dr.GetColumnValue<Byte>("Estado");
                    ObjCategory.Index = count.ToString();
                    listCategoria.Add(ObjCategory);
                }
            }
            catch (Exception ex)
            {
                listCategoria = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Category not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return listCategoria;
        }

        public Boolean RegistrarCategoria(ref BaseEntity objBase, Categoria obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Sp_Registro_Categoria", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre_Categoria", obj.Nombre_Categoria);
                cmd.Parameters.AddWithValue("@Descripcion_Categoria", obj.Descripcion_Categoria);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@FechaCreacion", obj.FechaCreacion);
                cmd.Parameters.AddWithValue("@CreadoPor", obj.CreadoPor);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar categoria."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
    }
}

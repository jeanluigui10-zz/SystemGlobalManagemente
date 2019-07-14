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
    }
}

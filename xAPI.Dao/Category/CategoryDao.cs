using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity;
using xAPI.Entity.Category;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Category
{
    public class CategoryDao
    {
        #region Singleton
        private static CategoryDao instance = null;
        public static CategoryDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDao();
                return instance;
            }
        }
        #endregion

        public DataTable Category_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_GetList_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }
        public DataTable Product_Category_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Product_Category_GetList_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }
        public Boolean Category_Delete(ref BaseEntity Entity, tBaseIdList BaseList)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_Delete_Sp", clsConnection.GetConnection());
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Type_BaseId", Value = BaseList, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_BASEID" });
                cmd.CommandType = CommandType.StoredProcedure;
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                success = false;
                Entity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  deleting a resource."));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
        public Categorys Category_Get_ById(ref BaseEntity Base, Int32 Id)
        {
            Categorys objAppResource = new Categorys();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_Get_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objAppResource = GetEntity_C(dr);
                }
            }
            catch (Exception ex)
            {
                objAppResource = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objAppResource;
        }
        private Categorys GetEntity_C(SqlDataReader ObjDr)
        {
            Categorys obj = new Categorys
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                Name = ObjDr.GetColumnValue<String>("Name"),
                Description = ObjDr.GetColumnValue<String>("Description"),
                Status = ObjDr.GetColumnValue<Byte>("Status")
            };
            return obj;
        }
        public Boolean Category_Save(ref BaseEntity Entity, Categorys objCategory)
        
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_Save_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", objCategory.ID);
                cmd.Parameters.AddWithValue("@name", objCategory.Name);
                cmd.Parameters.AddWithValue("@description", objCategory.Description);
                cmd.Parameters.AddWithValue("@status", objCategory.Status);

                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                success = false;
                Entity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  saving an Event."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
    }
}

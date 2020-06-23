using System;
using System.Data;
using System.Data.SqlClient;
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
            Categorys objBrand = new Categorys();
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
                    objBrand = GetEntity_C(dr);
                }
            }
            catch (Exception ex)
            {
                objBrand = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objBrand;
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
        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Entity, Categorys resource)
        {
            Int32 quantity = -1;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_QuantityLegalDocuments_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@categoryId", resource.ID);
                //cmd.Parameters.AddWithValue("@productId", resource.ID);
                SqlParameter outputParam = cmd.Parameters.Add("@quantity", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(cmd.Parameters["@quantity"].Value.ToString()))
                {
                    quantity = Convert.ToInt32(cmd.Parameters["@quantity"].Value);
                }
            }
            catch (Exception ex)
            {
                quantity = -1;
                Entity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  deleting a resource."));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return quantity;
        }
        public Boolean Category_Save(ref BaseEntity Entity, Categorys Categorys, Boolean RegisterTBL = false, String UserName = "")
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Category_Save_Sp ", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter outputParam = cmd.Parameters.Add("@publicName", SqlDbType.VarChar, 100);
                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@categoryId", Categorys.ID);
                cmd.Parameters.AddWithValue("@name", Categorys.Name);
                cmd.Parameters.AddWithValue("@fileName", Categorys.FileName);
                cmd.Parameters.AddWithValue("@description", Categorys.Description);
                cmd.Parameters.AddWithValue("@fileExtension", Categorys.FileExtension);
                cmd.Parameters.AddWithValue("@filePublicName", Categorys.FilePublicName);
                cmd.Parameters.AddWithValue("@nameResource", Categorys.NameResource);
                cmd.Parameters.AddWithValue("@status", Categorys.Status);
                cmd.Parameters.AddWithValue("@docType", Categorys.DocType);
                cmd.Parameters.AddWithValue("@isUpload", Categorys.IsUpload);
                success = cmd.ExecuteNonQuery() > 0;
                if (!String.IsNullOrEmpty(cmd.Parameters["@publicName"].Value.ToString()))
                    Categorys.FilePublicName = Convert.ToString(cmd.Parameters["@publicName"].Value);
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

        //public Boolean Category_Save(ref BaseEntity Entity, Categorys objCategory)

        //{
        //    Boolean success = false;
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        cmd = new SqlCommand("Category_Save_Sp", clsConnection.GetConnection())
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@id", objCategory.ID);
        //        cmd.Parameters.AddWithValue("@name", objCategory.Name);
        //        cmd.Parameters.AddWithValue("@description", objCategory.Description);
        //        cmd.Parameters.AddWithValue("@status", objCategory.Status);

        //        success = cmd.ExecuteNonQuery() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        Entity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  saving an Event."));
        //    }
        //    finally
        //    {
        //        clsConnection.DisposeCommand(cmd);
        //    }
        //    return success;
        //}
    }
}

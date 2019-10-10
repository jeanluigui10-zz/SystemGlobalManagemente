using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;
namespace xAPI.Dao
{
    public class ResourceCategoriesDAO
    {
        #region Constructor
        private ResourceCategoriesDAO()
        {
        }

        #endregion
        #region Singleton
        private static ResourceCategoriesDAO instance = null;
        public static ResourceCategoriesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResourceCategoriesDAO();
                return instance;
            }
        }
        #endregion

        public Boolean Save(ref BaseEntity Entity, ResourceCategories ResourceCategory)
        {
            Boolean Success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_RESOURCECATEGORIES_SAVE", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter paramID = cmd.Parameters.Add("@NEWID", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ID", ResourceCategory.ID);
                cmd.Parameters.AddWithValue("@NAME", ResourceCategory.Name);
                cmd.Parameters.AddWithValue("@translationKey", ResourceCategory.TranslationKey);
                cmd.Parameters.AddWithValue("@DESCRIPTION", ResourceCategory.Description);
                cmd.Parameters.AddWithValue("@STATUS", ResourceCategory.Status);
                cmd.Parameters.AddWithValue("@CREATEDBY", ResourceCategory.Createdby);
                cmd.Parameters.AddWithValue("@UPDATEDBY", ResourceCategory.Updatedby);
                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["@NEWID"].Value.ToString()))
                    ResourceCategory.ID = Convert.ToInt32(cmd.Parameters["@NEWID"].Value);

                Success = true;

            }
            catch (Exception ex)
            {
                Success = false;
                Entity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  saving a vendor. Error on Level 3"));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }

            return Success;
        }

        public DataTable GetaAll(ref BaseEntity Entity, Int16 Status)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ResourceCategories_GetAll_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@STATUS", Status);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Entity.Errors.Add(new BaseEntity.ListError(ex, ex.Message));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }

        public bool Delete(ref BaseEntity Entity, tBaseIdList BaseList)
        {
            bool success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_RESOURCECATEGORIES_DELETE", clsConnection.GetConnection());
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_BASEID", Value = BaseList, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_BASEID" });
                cmd.CommandType = CommandType.StoredProcedure;

                success = cmd.ExecuteNonQuery() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                success = false;
                Entity.Errors.Add(new BaseEntity.ListError(ex, ex.Message));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public ResourceCategories GetById(ref BaseEntity Entity, Int32 Id)
        {
            SqlDataReader dr = null;
            ResourceCategories objResourceCategory = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_RESOURCECATEGORIES_GETBYID", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("ID", Id);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objResourceCategory = new ResourceCategories
                    {
                        ID = dr.GetColumnValue<Int32>("ID"),
                        Name = dr.GetColumnValue<String>("NAME"),
                        Description = dr.GetColumnValue<String>("DESCRIPTION"),
                        Status = dr.GetColumnValue<Int16>("STATUS"),
                        TranslationKey = dr.GetColumnValue<String>("TranslationKey")
                    };
                }
            }
            catch (Exception ex)
            {
                cmd = null;
                Entity.Errors.Add(new BaseEntity.ListError(ex, ex.Message));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objResourceCategory;
        }
    }
}

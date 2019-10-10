using System;
using System.Collections.Generic;
using xAPI.Entity;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao
{
    public class ResourcesDAO
    {
        #region Singleton
        private static ResourcesDAO instance = null;
        public static ResourcesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResourcesDAO();
                return instance;
            }
        }
        #endregion


     

        public bool Save(ref BaseEntity Base, Resource objResource)
        {
            bool isSuccess = false;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand("SPR_RESOURCE_SAVE",clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter paramValue = cmd.Parameters.Add("@NEWID", SqlDbType.Int);
                paramValue.Direction = ParameterDirection.Output;
                paramValue = cmd.Parameters.Add("@NAMERESOURCE", SqlDbType.NVarChar, 150);
                paramValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ID", objResource.ID);
                cmd.Parameters.AddWithValue("@DISTRIBUTORID", 55/*objResource.Distributor.ID*/);
                cmd.Parameters.AddWithValue("@FILENAME", objResource.Filename);
                cmd.Parameters.AddWithValue("@RESOURCETYPE", objResource.Type.ID);
                cmd.Parameters.AddWithValue("@DESCRIPTION", objResource.Description);
                cmd.Parameters.AddWithValue("@FILEEXTENSION", objResource.FileExtension);
                cmd.Parameters.AddWithValue("@STATUS", objResource.Status);

                cmd.ExecuteNonQuery();


                if (!String.IsNullOrEmpty(cmd.Parameters["@NEWID"].Value.ToString()))
                    objResource.ID = Convert.ToInt32(cmd.Parameters["@NEWID"].Value);

                if (!String.IsNullOrEmpty(cmd.Parameters["@NAMERESOURCE"].Value.ToString()))
                    objResource.Filename = Convert.ToString(cmd.Parameters["@NAMERESOURCE"].Value);

                cmd.Connection.Close();

                isSuccess = true;
            }
            catch (Exception ex)
            {
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred saving resource"));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }

            return isSuccess;
        }

        public DataTable ResourceType_GetAll(BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("sp_Resourcetype_GetAll", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, ex.Message));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }
    }
}

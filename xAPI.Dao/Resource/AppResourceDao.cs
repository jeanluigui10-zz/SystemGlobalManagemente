using System;
using System.Collections.Generic;
using xAPI.Entity;
using System.Data.SqlClient;
using System.Data;
using xAPI.Library.General;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.Dao
{
    public class AppResourceDAO
    {
        #region Singleton

        private static AppResourceDAO instance = null;
        public static AppResourceDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppResourceDAO();
                return instance;
            }
        }

        #endregion

        private AppResource GetEntity_v3(SqlDataReader ObjDr)
        {
            AppResource obj = new AppResource
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                FileName = ObjDr.GetColumnValue<String>("FileName"),
                FileDescription = ObjDr.GetColumnValue<String>("DESCRIPTION"),
                FileExtension = ObjDr.GetColumnValue<String>("FileExtension"),
                FilePublicName = ObjDr.GetColumnValue<String>("FilePublicname"),
                DOCTYPE = ObjDr.GetColumnValue<String>("DOCTYPE"),
                NameResource = ObjDr.GetColumnValue<String>("NameResource"),
                AplicationId = ObjDr.GetColumnValue<Int32>("AplicationId"),
                UserId = ObjDr.GetColumnValue<Int32>("DistributorId"),
                Photoid = ObjDr.GetColumnValue<Int32>("LEGACYNUMBER"),
                Status = ObjDr.GetColumnValue<Int16>("STATUS"),
                isUpload = ObjDr.GetColumnValue<Int16>("ISUPLOAD"),
                Url = ObjDr.GetColumnValue<String>("URL"),

                CategotyId = ObjDr.GetColumnValue<Int32>("RESOURCECATEGORYID"),
                SystemContactId = ObjDr.GetColumnValue<Int32>("SYSTEMCONTACID"),
                Name = ObjDr.GetColumnValue<String>("NAME"),
                TranslationKey = ObjDr.GetColumnValue<String>("KeyName") ?? String.Empty
            };
            return obj;
        }

        public AppResource GetAllByID(ref BaseEntity Base, Int32 ID)
        {
            AppResource objAppResource = new AppResource();
            //List<clsLanguage> lstLanguages = new List<clsLanguage>(); comente
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_APPRESOURCES_GETBYID_LANGUAGEIDS", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", ID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objAppResource = GetEntity_v3(dr);
                }

                dr.NextResult();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //clsLanguage lang = new clsLanguage
                        //{
                        //    ID = dr.GetColumnValue<Int32>("LANGUAGEID")
                        //};
                        //lstLanguages.Add(lang);           comente
                    }
                    //objAppResource.ListLanguage = lstLanguages; comente
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

        public DataTable GetAllByAplicationID(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Resources_GetResource_Sp", clsConnection.GetConnection())
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

        public DataTable GetAllByAplicationID_Status(ref BaseEntity Base, Int32 AplicationID, Int16 Status, Int32 languageID)
        {
            DataTable dt = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_APPRESOURCES_GETBYAPLICATIONID_AND_STATUS", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@APLICATIONID", AplicationID);
                cmd.Parameters.AddWithValue("@LANGUAGEID", languageID);
                cmd.Parameters.AddWithValue("@STATUS", Status);
                dt = new DataTable();
                cmd.CommandTimeout = 120;
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

        public Boolean Save(ref BaseEntity Entity, /*tBaseLanguagueIdList listLanguages,*/ AppResource Resource, Boolean RegisterTBL = false, String UserName = "")
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Appresources_GetbyAplicationId_LanguageIds_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter outputParam = cmd.Parameters.Add("@PUBLICNAME", SqlDbType.VarChar, 100);
                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@FILEID", Resource.ID);
                cmd.Parameters.AddWithValue("@FILENAME", Resource.FileName);
                cmd.Parameters.AddWithValue("@DOCTYPE", Resource.DOCTYPE);
                cmd.Parameters.AddWithValue("@FILEPUBLICNAME", Resource.FilePublicName);
                cmd.Parameters.AddWithValue("@DESCRIPTION", Resource.FileDescription);
                cmd.Parameters.AddWithValue("@FILEEXTENSION", Resource.FileExtension);
                cmd.Parameters.AddWithValue("@NAMERESOURCE", Resource.NameResource);
                cmd.Parameters.AddWithValue("@DISTRIBUTORID", Resource.UserId);
                cmd.Parameters.AddWithValue("@CREATEDBY", Resource.Createdby);
                cmd.Parameters.AddWithValue("@STATUS", Resource.Status);
                cmd.Parameters.AddWithValue("@USERNAME", UserName);
                cmd.Parameters.AddWithValue("@URL", Resource.Url);
                cmd.Parameters.AddWithValue("@ISUPLOAD", Resource.isUpload);
                cmd.Parameters.AddWithValue("@RESOURCECATEGORYID", Resource.CategotyId);
                cmd.Parameters.AddWithValue("@NAME", Resource.Name);

              
                success = cmd.ExecuteNonQuery() > 0;
                if (!String.IsNullOrEmpty(cmd.Parameters["@PUBLICNAME"].Value.ToString()))
                    Resource.FilePublicName = Convert.ToString(cmd.Parameters["@PUBLICNAME"].Value);

               
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
        
        public Boolean SaveMyPhoto(ref BaseEntity Entity, AppResource Resource)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("[SP_APPRESOURCES_MYPICTURE_SAVE]", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter outputParam = cmd.Parameters.Add("@PUBLICNAME", SqlDbType.VarChar, 100);
                outputParam.Direction = ParameterDirection.Output;
                outputParam = cmd.Parameters.Add("@NEWID", SqlDbType.VarChar, 100);
                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@FILEID", Resource.ID);
                cmd.Parameters.AddWithValue("@FILENAME", Resource.FileName);
                cmd.Parameters.AddWithValue("@DOCTYPE", Resource.DOCTYPE);
                cmd.Parameters.AddWithValue("@FILEPUBLICNAME", Resource.FilePublicName);
                cmd.Parameters.AddWithValue("@DESCRIPTION", Resource.FileDescription);
                cmd.Parameters.AddWithValue("@FILEEXTENSION", Resource.FileExtension);
                cmd.Parameters.AddWithValue("@NAMERESOURCE", Resource.FilePublicName + Resource.FileExtension);
                cmd.Parameters.AddWithValue("@APLICATIONID", Resource.AplicationId);
                cmd.Parameters.AddWithValue("@DISTRIBUTORID", Resource.UserId);
                cmd.Parameters.AddWithValue("@CREATEDBY", Resource.Createdby);
                cmd.Parameters.AddWithValue("@STATUS", Resource.Status);

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["@PUBLICNAME"].Value.ToString()))
                    Resource.FilePublicName = Convert.ToString(cmd.Parameters["@PUBLICNAME"].Value);
                if (!String.IsNullOrEmpty(cmd.Parameters["@NEWID"].Value.ToString()))
                {
                    Resource.ID = Convert.ToInt32(cmd.Parameters["@NEWID"].Value);
                    Entity.ID = Resource.ID;
                }
                success = true;
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

        public Boolean Delete(ref BaseEntity Entity, tBaseIdList BaseList)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("SP_APPRESOURCES_DELETE_LANGUAGESID", clsConnection.GetConnection());
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_BASEID", Value = BaseList, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_BASEID" });
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

        public Boolean DeleteMyPhotoByID(ref BaseEntity Entity, Int32 ID)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("[SP_APPRESOURCES_MYPICTURE_DELETE]", clsConnection.GetConnection());
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                success = true;
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
        
        public DataTable Get_ResourcesApplication_Actives(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ResourceApplication_Active_Sp", clsConnection.GetConnection())
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

        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Entity, AppResource resource/*, tBaseLanguagueIdList ListLanguage*/)
        {
            Int32 quantity = -1;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("[AppResource_QuantityLegalDocuments_Sp]", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@RESOURCECATEGORYID", resource.CategotyId);
                cmd.Parameters.AddWithValue("@RESOURCEID", resource.ID);

                //if (ListLanguage.Count > 0)
                //{
                //    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_LANGUAGEID", Value = ListLanguage, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_GET_LANGUAGESID" });
                //}

                SqlParameter outputParam = cmd.Parameters.Add("@QUANTITY", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(cmd.Parameters["@QUANTITY"].Value.ToString()))
                {
                    quantity = Convert.ToInt32(cmd.Parameters["@QUANTITY"].Value);
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
    }
}

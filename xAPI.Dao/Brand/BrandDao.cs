using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity;
using xAPI.Entity.Brand;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Brand
{
    public class BrandDao
    {
        #region Singleton
        private static BrandDao instance = null;
        public static BrandDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new BrandDao();
                return instance;
            }
        }
        #endregion
        public DataTable Brand_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Brand_GetList_Sp", clsConnection.GetConnection())
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
        public Boolean Brand_Delete(ref BaseEntity Entity, tBaseIdList BaseList)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Brand_Delete_Sp", clsConnection.GetConnection());
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
        public Brands Brand_Get_ById(ref BaseEntity Base, Int32 Id)
        {
            Brands objBrand = new Brands();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Brand_Get_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objBrand = GetEntity_Brand(dr);
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
        private Brands GetEntity_Brand(SqlDataReader ObjDr)
        {
            Brands obj = new Brands
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                Name = ObjDr.GetColumnValue<String>("Name"),
                Status = ObjDr.GetColumnValue<Byte>("Status")
            };
            return obj;
        }
        public Boolean Brand_Save(ref BaseEntity Entity, Brands objBrand)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Brand_Save_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", objBrand.ID);
                cmd.Parameters.AddWithValue("@name", objBrand.Name);
                cmd.Parameters.AddWithValue("@status", objBrand.Status);

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

        
        public DataTable Product_Brand_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Product_Brand_GetList_Sp", clsConnection.GetConnection())
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
    }
}

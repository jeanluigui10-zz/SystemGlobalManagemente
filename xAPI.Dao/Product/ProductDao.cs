using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Product
{
    public class ProductDao
    {
        #region Singleton
        private static ProductDao instance = null;
        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDao();
                return instance;
            }
        }
        #endregion

        public DataTable Product_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_Sp", clsConnection.GetConnection())
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
        public Boolean Product_Delete(ref BaseEntity Entity, tBaseIdList BaseList)
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Product_Delete_Sp", clsConnection.GetConnection());
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
        public Products Products_GetList_ById(ref BaseEntity Base, Int32 Id)
        {
            Products objProduct = new Products();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@productId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProduct = GetEntity_Product(dr);
                }
            }
            catch (Exception ex)
            {
                objProduct = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objProduct;
        }
        private Products GetEntity_Product(SqlDataReader ObjDr)
        {
            Products obj = new Products
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                Name = ObjDr.GetColumnValue<String>("Name"),
                FileName = ObjDr.GetColumnValue<String>("FileName"),
                Description = ObjDr.GetColumnValue<String>("Description"),
                DocType = ObjDr.GetColumnValue<String>("DocType"),
                NameResource = ObjDr.GetColumnValue<String>("NameResource"),
                FilePublicName = ObjDr.GetColumnValue<String>("FilePublicName"),
                Status = ObjDr.GetColumnValue<Byte>("Status"),
                UnitPrice = ObjDr.GetColumnValue<Decimal>("UnitPrice"),
                PriceOffer = ObjDr.GetColumnValue<Decimal>("PriceOffer"),
                UniMed = ObjDr.GetColumnValue<String>("UniMed"),
                Stock = ObjDr.GetColumnValue<Int32>("Stock")
            };
            obj.category.ID = ObjDr.GetColumnValue<Int32>("CategoryId");
            obj.brand.ID = ObjDr.GetColumnValue<Int32>("BrandId");

            return obj;
        }
        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Entity, Products resource)
        {
            Int32 quantity = -1;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_QuantityLegalDocuments_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@categoryId", resource.category.ID);
                cmd.Parameters.AddWithValue("@productId", resource.ID);
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
        public Boolean Product_Save(ref BaseEntity Entity, Products Product, Boolean RegisterTBL = false, String UserName = "")
        {
            Boolean success = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_Save_Sp ", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter outputParam = cmd.Parameters.Add("@publicName", SqlDbType.VarChar, 100);
                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@productId", Product.ID);
                cmd.Parameters.AddWithValue("@sku", Product.SKU);
                cmd.Parameters.AddWithValue("@name", Product.Name);
                cmd.Parameters.AddWithValue("@fileName", Product.FileName);
                cmd.Parameters.AddWithValue("@description", Product.Description);
                cmd.Parameters.AddWithValue("@categoryId", Product.category.ID);
                cmd.Parameters.AddWithValue("@brandId", Product.brand.ID);
                cmd.Parameters.AddWithValue("@fileExtension", Product.FileExtension);
                cmd.Parameters.AddWithValue("@filePublicName", Product.FilePublicName);
                cmd.Parameters.AddWithValue("@unitPrice", Product.UnitPrice);
                cmd.Parameters.AddWithValue("@stock", Product.Stock);
                cmd.Parameters.AddWithValue("@PriceOffer", Product.PriceOffer);
                cmd.Parameters.AddWithValue("@uniMed", Product.UniMed);
                cmd.Parameters.AddWithValue("@nameResource", Product.NameResource);
                cmd.Parameters.AddWithValue("@status", Product.Status);
                cmd.Parameters.AddWithValue("@docType", Product.DocType);
                cmd.Parameters.AddWithValue("@isUpload", Product.IsUpload);
                success = cmd.ExecuteNonQuery() > 0;
                if (!String.IsNullOrEmpty(cmd.Parameters["@publicName"].Value.ToString()))
                    Product.FilePublicName = Convert.ToString(cmd.Parameters["@publicName"].Value);
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

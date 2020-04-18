using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Product;
using xAPI.Entity;
using xAPI.Entity.Product;
using xAPI.Library.Base;

namespace xAPI.BL.Product
{
    public class ProductBL
    {
        #region Singleton
        private static ProductBL instance = null;
        public static ProductBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductBL();
                return instance;
            }
        }
        #endregion

        public DataTable Product_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = ProductDao.Instance.Product_GetList(ref entity);

            return dt;
        }
        public Boolean Product_Delete(ref BaseEntity entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = ProductDao.Instance.Product_Delete(ref entity, idList);
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));

            return success;
        }
        public Products Products_GetList_ById(ref BaseEntity entity, Int32 Id)
        {
            entity = new BaseEntity();
            Products dt = null;
            if (Id > 0)
            {
                dt = ProductDao.Instance.Products_GetList_ById(ref entity, Id);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return dt;
        }
        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Base, Products resource)
        {
            return ProductDao.Instance.Get_QuantityLegalDocuments(ref Base, resource);
        }
        public Boolean Product_Save(ref BaseEntity Entity, Products Product, Boolean RegisterTBL = false, String Username = "")
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = ProductDao.Instance.Product_Save(ref Entity, Product, RegisterTBL, Username);

            return success;
        }
    }
}

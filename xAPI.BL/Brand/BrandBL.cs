using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Brand;
using xAPI.Entity;
using xAPI.Entity.Brand;
using xAPI.Library.Base;
using xAPI.Library.Connection;

namespace xAPI.BL.Brand
{
    public class BrandBL
    {
        #region Singleton
        private static BrandBL instance = null;
        public static BrandBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BrandBL();
                return instance;
            }
        }
        #endregion
        public DataTable Brand_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = BrandDao.Instance.Brand_GetList(ref entity);

            return dt;
        }
        public Boolean Brand_Delete(ref BaseEntity entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = BrandDao.Instance.Brand_Delete(ref entity, idList);
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));

            return success;
        }
        public Brands Brand_Get_ById(ref BaseEntity entity, Int32 Id)
        {
            entity = new BaseEntity();
            Brands dt = null;
            if (Id > 0)
            {
                dt = BrandDao.Instance.Brand_Get_ById(ref entity, Id);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return dt;
        }
        public Boolean Brand_Save(ref BaseEntity Entity, Brands objBrand)
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = BrandDao.Instance.Brand_Save(ref Entity, objBrand);

            return success;
        }
        public DataTable Product_Brand_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = BrandDao.Instance.Product_Brand_GetList(ref entity);

            return dt;
        }
    }
}

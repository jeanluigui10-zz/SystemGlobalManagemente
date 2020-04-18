using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Category;
using xAPI.Entity;
using xAPI.Entity.Category;
using xAPI.Library.Base;

namespace xAPI.BL.Category
{
    public class CategoryBL
    {
        #region Singleton
        private static CategoryBL instance = null;
        public static CategoryBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryBL();
                return instance;
            }
        }
        #endregion

        public DataTable Category_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.Category_GetList(ref entity);

            return dt;
        }
        public DataTable Product_Category_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.Product_Category_GetList(ref entity);

            return dt;
        }

        public Boolean Category_Delete(ref BaseEntity entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = CategoryDao.Instance.Category_Delete(ref entity, idList);
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));

            return success;
        }
        public Categorys Category_Get_ById(ref BaseEntity entity, Int32 Id)
        {
            entity = new BaseEntity();
            Categorys dt = null;
            if (Id > 0)
            {
                dt = CategoryDao.Instance.Category_Get_ById(ref entity, Id);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return dt;
        }
        public Boolean Category_Save(ref BaseEntity Entity, Categorys objCategory)
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = CategoryDao.Instance.Category_Save(ref Entity, objCategory);

            return success;
        }
    }
}

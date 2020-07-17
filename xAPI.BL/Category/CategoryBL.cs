using System;
using System.Data;
using xAPI.Dao.Category;
using xAPI.Entity;
using xAPI.Entity.Category;
using xAPI.Entity.Product;
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

        public DataTable SubCategory_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.SubCategory_GetList(ref entity);

            return dt;
        }
        public DataTable Product_Category_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.Product_Category_GetList(ref entity);

            return dt;
        }
        public DataTable Product_SubCategory_GetList(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.Product_SubCategory_GetList(ref entity);

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

        public Boolean SubCategory_Delete(ref BaseEntity entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = CategoryDao.Instance.SubCategory_Delete(ref entity, idList);
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));

            return success;
        }
        public Boolean SubCategory_Save(ref BaseEntity Entity, Products objSubCategory)
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = CategoryDao.Instance.SubCategory_Save(ref Entity, objSubCategory);

            return success;
        }
        public Products SubCategory_Get_ById(ref BaseEntity entity, Int32 Id)
        {
            entity = new BaseEntity();
            Products dt = null;
            if (Id > 0)
            {
                dt = CategoryDao.Instance.SubCategory_Get_ById(ref entity, Id);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return dt;
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
        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Base, Categorys resource)
        {
            return CategoryDao.Instance.Get_QuantityLegalDocuments(ref Base, resource);
        }
        public Boolean Category_Save(ref BaseEntity Entity, Categorys Category, Boolean RegisterTBL = false, String Username = "")
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = CategoryDao.Instance.Category_Save(ref Entity, Category, RegisterTBL, Username);

            return success;
        }

        public DataTable SubCategory_LoadBy_CategoryId(ref BaseEntity entity, Int32 IdCategory)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CategoryDao.Instance.SubCategory_LoadBy_CategoryId(ref entity, IdCategory);

            return dt;
        }

    }
}

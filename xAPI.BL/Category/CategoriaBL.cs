using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Tool;
using xAPI.Entity.Category;
using xAPI.Library.Base;

namespace xAPI.BL.Category
{
    public class CategoriaBL
    {
        #region Singleton
        private static CategoriaBL instance = null;
        public static CategoriaBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoriaBL();
                return instance;
            }
        }
        #endregion

        public List<Categoria> LlenarCategorias(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Categoria> lstCategoria = null;
            try
            {
                lstCategoria = CategoriaDAO.Instance.LlenarCategorias(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstCategoria;
        }
    }
}

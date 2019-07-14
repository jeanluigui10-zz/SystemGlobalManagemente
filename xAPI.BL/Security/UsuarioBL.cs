using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Security;
using xAPI.Entity.Security;
using xAPI.Library.Base;

namespace xAPI.BL.Security
{
    public class UsuarioBL
    {
        #region Singleton
        private static UsuarioBL instance = null;
        public static UsuarioBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioBL();
                return instance;
            }
        }
        #endregion

        public Usuario ValidateLogin(ref BaseEntity objBase, String dni, String password)
        {
            objBase = new BaseEntity();
            Usuario objDistributor = null;
            try
            {
                if (!String.IsNullOrEmpty(dni) && !String.IsNullOrEmpty(password))
                {
                    objDistributor = UsuarioDAO.Instance.ValidatebyUsernameAndPassword(ref objBase, dni, password);
                    
                }
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return objDistributor;
        }

    }
}

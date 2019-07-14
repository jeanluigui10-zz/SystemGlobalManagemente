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
    public class TipoUsuarioBL
    {
        #region Singleton
        private static TipoUsuarioBL instance = null;
        public static TipoUsuarioBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TipoUsuarioBL();
                return instance;
            }
        }
        #endregion

     
        public List<TipoUsuario> LlenarTipoUsuarios(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<TipoUsuario> lstTipoUsuario = null;
            try
            {
                lstTipoUsuario = TipoUsuarioDAO.Instance.LlenarTipoUsuarios(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstTipoUsuario;
        }
    }
}

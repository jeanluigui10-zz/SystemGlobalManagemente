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

        public Usuarios ValidateLogin(ref BaseEntity objBase, Usuarios obj)
        {
            objBase = new BaseEntity();
            Usuarios objDistributor = null;
            try
            {
                if (obj != null)
                {
                    objDistributor = UsuarioDAO.Instance.ValidatebyUsernameAndPassword(ref objBase, obj);
                    
                }
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return objDistributor;
        }

        public Boolean RegistrarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            Boolean success = false;
            try
            {
                success = UsuarioDAO.Instance.RegistrarUsuario(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

        public Boolean ActualizarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            Boolean success = false;
            try
            {
                success = UsuarioDAO.Instance.ActualizarUsuario(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }
        public Boolean EliminarUsuario(ref BaseEntity objBase, Usuarios obj)
        {
            Boolean success = false;
            try
            {
                success = UsuarioDAO.Instance.EliminarUsuario(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

        public List<Usuarios> ListarUsuarios(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Usuarios> lst= null;
            try
            {
                lst = UsuarioDAO.Instance.ListarUsuarios(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lst;
        }
        public List<Usuarios> ListarAsistenteUsuarios(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Usuarios> lst = null;
            try
            {
                lst = UsuarioDAO.Instance.ListarAsistenteUsuarios(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lst;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Environment;
using xAPI.Entity.Environment;
using xAPI.Library.Base;

namespace xAPI.BL.Environment
{
    public class AmbienteBL
    {
        #region Singleton
        private static AmbienteBL instance = null;
        public static AmbienteBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AmbienteBL();
                return instance;
            }
        }
        #endregion

        public List<Ambientes> LlenarAmbiente(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Ambientes> lstAmbiente = null;
            try
            {
                lstAmbiente = AmbienteDAO.Instance.LlenarAmbiente(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstAmbiente;
        }
        public List<Ambientes> LlenarAmbientes(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Ambientes> lstAmbiente = null;
            try
            {
                lstAmbiente = AmbienteDAO.Instance.LlenarAmbientes(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstAmbiente;
        }
        
        public Boolean RegistrarAmbiente(ref BaseEntity objBase, Ambientes obj)
        {
            Boolean success = false;
            try
            {
                success = AmbienteDAO.Instance.RegistrarAmbiente(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

        public List<Ambientes> LlenarAmbientexPiso(ref BaseEntity objBase, int idpiso)
        {
            objBase = new BaseEntity();
            List<Ambientes> lstAmbientes = null;
            try
            {
                lstAmbientes = AmbienteDAO.Instance.LlenarAmbientexPiso(ref objBase, idpiso);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstAmbientes;
        }
    }
}


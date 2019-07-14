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

        public List<Ambiente> LlenarAmbiente(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Ambiente> lstAmbiente = null;
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
    }
}


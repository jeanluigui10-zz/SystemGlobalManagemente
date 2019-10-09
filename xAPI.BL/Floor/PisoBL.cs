using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Floor;
using xAPI.Entity.Floor;
using xAPI.Library.Base;

namespace xAPI.BL.Floor
{
    public class PisoBL
    {
        #region Singleton
        private static PisoBL instance = null;
        public static PisoBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PisoBL();
                return instance;
            }
        }
        #endregion

        public List<Piso> LlenarPiso(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Piso> lstPiso = null;
            try
            {
                lstPiso = PisoDAO.Instance.LlenarPiso(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstPiso;
        }

        public List<Piso> CargarPisos(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Piso> lstPiso = null;
            try
            {
                lstPiso = PisoDAO.Instance.CargarPisos(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstPiso;
        }

        public Boolean RegistrarPiso(ref BaseEntity objBase, Piso obj)
        {
            Boolean success = false;
            try
            {
                success = PisoDAO.Instance.RegistrarPiso(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

    }
}

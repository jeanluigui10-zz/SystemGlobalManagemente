using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Status;
using xAPI.Entity.Status;
using xAPI.Library.Base;

namespace xAPI.BL.Status
{
    public class StatusBL
    {
        #region Singleton
        private static StatusBL instance = null;
        public static StatusBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusBL();
                return instance;
            }
        }
        #endregion

        public List<State> LlenarStatus(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<State> lstStates = null;
            try
            {
                lstStates = StatusDAO.Instance.LlenarStatus(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstStates;
        }

    }
}

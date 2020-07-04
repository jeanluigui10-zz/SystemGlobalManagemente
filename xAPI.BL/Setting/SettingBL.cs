using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Setting;
using xAPI.Entity.Store;
using xAPI.Library.Base;

namespace xAPI.BL.Setting
{
    public class SettingBL
    {
        #region Singleton
        private static SettingBL instance = null;
        public static SettingBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SettingBL();
                return instance;
            }
        }
        #endregion

        #region Métodos
        public Boolean Store_UpdateInfo(ref BaseEntity objEntity, Store objStore)
        {
            Boolean success = false;
            objEntity = new BaseEntity();

            success = SettingDao.Instance.Store_UpdateInfo(ref objEntity, objStore);

            return success;
        }
        public Store Store_GetInformation(ref BaseEntity objEntity)
        {
            objEntity = new BaseEntity();
            Store objStore = null;
            objStore = SettingDao.Instance.Store_GetInformation(ref objEntity);
            return objStore;
        }
        #endregion

    }
}

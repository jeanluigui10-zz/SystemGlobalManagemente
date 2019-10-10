
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Incidence;
using xAPI.Dao.Report;
using xAPI.Entity.Incidence;
using xAPI.Entity.Report;
using xAPI.Library.Base;

namespace xAPI.BL.Incidence
{
    public class IncidenciaBL
    {
        #region Singleton
        private static IncidenciaBL instance = null;
        public static IncidenciaBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new IncidenciaBL();
                return instance;
            }
        }
        #endregion

        public Boolean RegistrarIncidencia(ref BaseEntity objBase, Incidencia obj)
        {
            Boolean success = false;
            try
            {
                success = IncidenceDAO.Instance.RegistrarIncidencia(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

        public List<Reporte> IncidenciasAsignadas_ByUsusario(ref BaseEntity objBase, Int32 idusuario)
        {
            objBase = new BaseEntity();
            List<Reporte> lstReport = null;
            try
            {
                lstReport = IncidenceDAO.Instance.IncidenciasAsignadas_ByUsusario(ref objBase, idusuario);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstReport;
        }
    }
}

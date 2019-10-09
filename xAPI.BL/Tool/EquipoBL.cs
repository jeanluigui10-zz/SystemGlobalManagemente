using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Tool;
using xAPI.Entity.Tool;
using xAPI.Library.Base;

namespace xAPI.BL.Tool
{
    public class EquipoBL
    {
        #region Singleton
        private static EquipoBL instance = null;
        public static EquipoBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new EquipoBL();
                return instance;
            }
        }
        #endregion

        public List<Equipo> LlenarCategorias(ref BaseEntity objBase, int categoryId)
        {
            objBase = new BaseEntity();
            List<Equipo> lstEquipo = null;
            try
            {
                lstEquipo = EquipoDAO.Instance.LlenarEquipos(ref objBase, categoryId);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstEquipo;
        }

        public List<Equipo> CargarEquipos(ref BaseEntity objBase)
        {
            objBase = new BaseEntity();
            List<Equipo> lstEquipo = null;
            try
            {
                lstEquipo = EquipoDAO.Instance.CargarEquipos(ref objBase);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstEquipo;
        }

        public Boolean RegistrarEquipo(ref BaseEntity objBase, Equipo obj)
        {
            Boolean success = false;
            try
            {
                success = EquipoDAO.Instance.RegistrarEquipo(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred on application level 2"));
            }
            return success;
        }
    }
}

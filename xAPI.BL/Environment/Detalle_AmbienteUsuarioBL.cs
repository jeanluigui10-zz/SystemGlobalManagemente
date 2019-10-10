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
    public class Detalle_AmbienteUsuarioBL
    {
        #region Singleton
        private static Detalle_AmbienteUsuarioBL instance = null;
        public static Detalle_AmbienteUsuarioBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new Detalle_AmbienteUsuarioBL();
                return instance;
            }
        }
        #endregion

        public List<Ambientes> ListarAmbientexUsuario(ref BaseEntity objBase, int usuarioId)
        {
            objBase = new BaseEntity();
            List<Ambientes> lstAmbiente = null;
            try
            {
                lstAmbiente = Detalle_AmbienteUsuarioDAO.Instance.ListarAmbientexUsuario(ref objBase, usuarioId);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return lstAmbiente;
        }

        public Boolean RegistrarAsignacion_AmbienteUsuario(ref BaseEntity objBase, Detalle_AmbienteUsuario obj)
        {
            Boolean success = false;
            try
            {
                success = Detalle_AmbienteUsuarioDAO.Instance.RegistrarAsignacion_AmbienteUsuario(ref objBase, obj);
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Category;
using xAPI.BL.Tool;
using xAPI.Entity.Category;
using xAPI.Entity.Tool;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Incidents
{
    public partial class Incident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BaseEntity objBase = new BaseEntity();
                LlenarInformacion();
                LlenarCategorias(CategoriaBL.Instance.LlenarCategorias(ref objBase), ddlCategoria);
                

            }
        }

        private void LlenarCategorias(List<Categoria> lst, DropDownList ddl)
        {
            ddl.DataSource = lst;
            ddl.DataTextField = "Nombre_Categoria";
            ddl.DataValueField = "Id_Categoria";
            ddl.DataBind();
        }


        private void LlenarInformacion()
        {
            nameCompleteUser.Enabled = false;
            nameCompleteUser.Text = BaseSession.SsUser.Nombre_Usuario + " " + BaseSession.SsUser.APaterno_Usuario + " " + BaseSession.SsUser.AMaterno_Usuario;
        }
        [WebMethod]
        public static object LlenarEquipos(String categoryId)
        {
            BaseEntity objBase = new BaseEntity();
            int.TryParse(categoryId, out int idcat);
            List<Equipo> lstEquipo = EquipoBL.Instance.LlenarCategorias(ref objBase, idcat);
                       
            return new
            {
                Result = "Ok",
                lstEquipo = lstEquipo
            };
        }
    }
}
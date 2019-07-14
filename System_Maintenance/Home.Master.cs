using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarInformacion();
            }
        }

        private void LlenarInformacion()
        {
            nameUserId.InnerText = BaseSession.SsUser.Nombre_Usuario;
            userName.InnerText = BaseSession.SsUser.Nombre_Usuario + " " + BaseSession.SsUser.APaterno_Usuario;
        }
    }
}
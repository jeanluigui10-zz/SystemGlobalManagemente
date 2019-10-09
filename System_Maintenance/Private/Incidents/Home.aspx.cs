using System;
using System.Web.UI;
using System_Maintenance.src.app_code;
using xSystem_Maintenance.src.app_code;

namespace System_Maintenance.Private.Incidents
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idBienvenido.InnerText = "Hola estimado " + BaseSession.SsUser.Nombre_Usuario + " " + BaseSession.SsUser.APaterno_Usuario +  ", bienvenido al sistema de monitoreo san isidro, esperamos que tenga un gran desempeño.";
            }
        }
    }
}
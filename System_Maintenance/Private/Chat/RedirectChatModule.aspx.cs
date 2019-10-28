using System;
using xSystem_Maintenance.src.app_code;

namespace xSystem_Maintenance.Private.Chat
{
    public partial class RedirectChatModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucRedirectChatModule.SetUserId(BaseSession.SsUser.Id_Usuario);
        }
    }
}
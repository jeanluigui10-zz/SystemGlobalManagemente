using System;
using System.Web;
using xSystem_Maintenance.src.app_code;

namespace xSystem_Maintenance.src.control.Chat
{
    public partial class ucRedirectChatModule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String paramId = HttpUtility.UrlEncode(hfUserId.Value.ToString());
            String paramAppId = HttpUtility.UrlEncode(Config.ChatModuleId);
            String paramRolId = HttpUtility.UrlEncode("1");

            panelChat.Attributes.Add("src", String.Format(Config.RedirectChatModule, paramId, paramAppId, paramRolId));
        }
        public void SetUserId(Int32 userId)
        {
            this.hfUserId.Value = userId.ToString();
        }

    }
}
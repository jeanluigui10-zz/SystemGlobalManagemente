<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRedirectChatModule.ascx.cs" Inherits="xSystem_Maintenance.src.control.Chat.ucRedirectChatModule" %>

<%--<script type="text/javascript">
        var mymap;
        $(function () {            
            $('ul[class=site-nav] a[id=menu_chatmodule]').addClass('menu-selected');
            $('#menu_chatmodule').addClass("nav-active");
            $(".labelDash2").html("<%=xss.Utils.Validator.ValidationHandler.ValidateAndReplace((String)GetGlobalResourceObject("Strings", "HOMEMASTER_CHATMODULE"), "HOMEMASTER_CHATMODULE")%>");
        });
</script>--%>

 <iframe id="panelChat" runat="server" sandbox="allow-same-origin allow-forms allow-scripts" style="display: block;border: none;width: 94vw; height: 100vh;"></iframe>
<input type="hidden" id="hfUserId" value="0" runat="server" />
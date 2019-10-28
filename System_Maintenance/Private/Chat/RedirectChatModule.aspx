<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RedirectChatModule.aspx.cs" Inherits="xSystem_Maintenance.Private.Chat.RedirectChatModule" %>

<%@ Register Src="~/src/control/Chat/ucRedirectChatModule.ascx" TagPrefix="ucCustom" TagName="ucRedirectChatModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ucCustom:ucRedirectChatModule runat="server" ID="ucRedirectChatModule" />
    <script>
        $('#menu_chatmodule').attr("class", "nav-active");
        $('#menu_chat').addClass("nav-active nav-expanded");
        $(".labelDash2").html("Panel Chat");
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="System_Maintenance.Private.Security.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <script type="text/javascript">
      
        $(function () {
            //fn_init();
        });

        function fn_init() {
        }
        
            function Fn_Login() {

                try {
                   
                    //var senddata = '{user:"' + $("input[id$=txtdni]").val() + '",password:"' + $("input[id$=txtpassword]").val() + '}';
                     var objUsuario = {
                        Dni: $("input[id$=txtdni]").val(),
                        Password: $("input[id$=txtpassword]").val()
                    };
                    var success = function (asw) {

                        if (asw.d.Result == "Ok")
                        {                                   
                            window.location.href = "~/Incident.aspx";
                           //fn_message('S', 'Guardado correctamente');
                        }
                        else {
                           fn_message('e', 'An error occurred while sending data');
                        }
                    }

                    var error = function (xhr, ajaxOptions, thrownError) {
                       fn_message('e', 'An error occurred while sending data');
                   }

                   var complete = function () {
                       //$('html, body').animate({ scrollTop: $('#Div15').position().top }, 'slow');
                   }
                    fn_callmethod("Login.aspx/LoginSecurity", JSON.stringify({objUser:objUsuario}), success, error);

                   } catch (e) {
                       fn_message('e', 'An error occurred while sending data');
            }

        }

    </script>
     <div class="form-group has-feedback">
         Rol Usuario:
           <asp:DropDownList ID="ddlRol" CssClass="form-control" runat="server"></asp:DropDownList>
        <%--<input type="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
    </div>
    <div class="form-group has-feedback">
        <asp:TextBox id="txtdni" type="text" runat="server" class="form-control" placeholder="Dni"></asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
    </div>
     
    <div class="form-group has-feedback">
        <asp:TextBox id="txtpassword" type="password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
    </div>
    <div class="form-group has-feedback">
         Ambiente:
           <asp:DropDownList ID="ddlAmbiente" CssClass="form-control" runat="server"></asp:DropDownList>
        <%--<input type="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
    </div>
    <div class="row" style="text-align:center">
        <!-- /.col -->
             <asp:LinkButton ID="btnLogin" runat="server" CssClass="mb-xs mt-xs mr-xs btn btn-primary" OnClick="btnLogin_Click"><span>Ingresar</span></asp:LinkButton> 
        <!-- /.col -->
    </div>

</asp:Content>

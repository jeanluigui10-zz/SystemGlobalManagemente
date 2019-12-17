<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="System_Maintenance.Private.Security.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        $(function () {
            //fn_init();
        });

        function fn_init() {
        }

        function Fn_Login()
        {
            try {
                //var senddata = '{user:"' + $("input[id$=txtdni]").val() + '",password:"' + $("input[id$=txtpassword]").val() + '}';
                var objUsuario = {
                    Dni: $("input[id$=txtdni]").val(),
                    Password: $("input[id$=txtpassword]").val(),
                    Id_TipoUsuario: $("select[id$=ddlRol] option:selected").val()
                };
                var success = function (asw) {

                    if (asw.d != null)
                    {
                        if (asw.d.Result == "Ok")
                        {
                            window.location.href = asw.d.Msg;
                        }
                        else
                        {
                            if (asw.d.Result == "NoOk")
                            {
                                fn_message('i', asw.d.Msg);
                            }
                        }
                    }
                    else {
                        fn_message('e', 'Ocurrio un error al intentar Iniciar Sesion.', 'message_row');
                    }
                }
                var error = function (xhr, ajaxOptions, thrownError) {
                    fn_message('e', 'Ocurrio un error al enviar la data.', 'message_row');
                }
                var complete = function () {
                    //$('html, body').animate({ scrollTop: $('#Div15').position().top }, 'slow');
                }
                fn_callmethod("Login.aspx/LoginSecurity", JSON.stringify({ objUser: objUsuario }), success, error);

            } catch (e)
            {
                fn_message('e', 'Ocurrio un error al enviar la data.', 'message_row');
            }
        }

    </script>
    <div id="message_row"></div>
    <div class="form-group has-feedback">
        Rol Usuario:
           <asp:DropDownList ID="ddlRol" CssClass="form-control" runat="server"></asp:DropDownList>
        <%--<input type="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
    </div>
    <div class="form-group has-feedback">
        <asp:TextBox ID="txtdni" type="text" runat="server" class="form-control" placeholder="Dni"></asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
    </div>

    <div class="form-group has-feedback">
        <asp:TextBox ID="txtpassword" type="password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
    </div>
    <div class="form-group has-feedback" style="display: none">
        Ambiente:
           <asp:DropDownList ID="ddlAmbiente" CssClass="form-control" runat="server"></asp:DropDownList>
        <%--<input type="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
    </div>
    <div class="row" style="text-align: center">
        <!-- /.col -->
        <%--<asp:LinkButton ID="btnLogin" runat="server" CssClass="mb-xs mt-xs mr-xs btn btn-primary"><span>Ingresar</span></asp:LinkButton>--%>
                <button type="button" runat="server" class="btn btn-primary" onclick="Fn_Login()"><i class="fa fa-save" style="margin-right: 5px"></i>Ingresar</button>
        <!-- /.col -->
    </div>

</asp:Content>

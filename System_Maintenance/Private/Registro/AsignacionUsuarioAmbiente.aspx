<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AsignacionUsuarioAmbiente.aspx.cs" Inherits="System_Maintenance.Private.Registro.AsignacionUsuarioAmbiente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        $(function () {
            fn_init();
        });
        function fn_init() {
            fn_bind();
        }

        function fn_bind() {
          
        }
         
        function Fn_Registro()
        {
            
            if ($("select[id$=ddlUsuario] option:selected").val() == undefined || $("select[id$=ddlTipoUsuario] option:selected").val() == 0) {
                fn_message('i', 'Debe ingresar usuario', 'message_row');
                return;
            }
            if ($("select[id$=ddlAmbiente] option:selected").val() == undefined || $("select[id$=ddlTipoUsuario] option:selected").val() == 0) {
                fn_message('i', 'Debe ingresar Ambiente', 'message_row');
                return;
            }
            

            obj = {

                Id_Usuario :$("select[id$=ddlUsuario] option:selected").val() ,
                Id_Ambiente :$("select[id$=ddlAmbiente] option:selected").val() 
                   
            }
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error guardando la Asignacion');
            };

            var data = { obj: obj };

            fn_callmethod("AsignacionUsuarioAmbiente.aspx/Registro", JSON.stringify(data), success, error);
        }
         
    </script>

    <div class="box box-warning">
        <div id="message_row"></div>
        <div class="box-header with-border">
          
            <h3 <%--class="box-title"--%> style="text-align: center">Asignacion Usuario - Ambiente</h3>
        </div>
    
        <div class="box-body">
                     
            <div class="form-group">
                <label>Usuario</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Ambiente</label>
                <asp:DropDownList ID="ddlAmbiente" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-sm-12 text-center">
                <button type="button" runat="server" class="btn btn-primary" onclick="Fn_Registro()"><i class="fa fa-save"></i> Registrar</button>
            </div>
        </div>
    </div>
</asp:Content>

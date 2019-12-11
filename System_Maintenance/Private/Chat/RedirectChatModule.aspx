<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RedirectChatModule.aspx.cs" Inherits="xSystem_Maintenance.Private.Chat.RedirectChatModule" %>

<%@ Register Src="~/src/control/Chat/ucRedirectChatModule.ascx" TagPrefix="ucCustom" TagName="ucRedirectChatModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">  
        var lstCliente = [];
        var lstProductos = [];
        $(function () {
            Fn_Init();
        });

        function Fn_Init() {
            Fn_Bind();
        }

        function Fn_Bind() {
            $("select[id$=ddlCliente]").multiselect({
                includeSelectAllOption: true,
                onChange: function (option, checked) {
                    lstCliente = [];
                    $($("select[id$=ddlCliente]").val()).each(function () {
                        if (lstCliente.length > 0) {
                            var added = false;
                            for (var i = 0; i < lstCliente.length; i++) {
                                if (lstCliente[i] === this["trim"]()) {
                                    added = true;
                                }
                            }
                            if (!added) {
                                lstCliente.push(this["trim"]());
                            }
                        } else {
                            lstCliente.push(this["trim"]());
                        }
                    });
                }
            });

            $("select[id$=ddlCliente]").multiselect({
                includeSelectAllOption: true,
                nonSelectedText: "Ninguno seleccionado",
                selectAllText: "Seleccionar todos"
            });

            $("select[id$=ddlProductos]").multiselect({
                includeSelectAllOption: true,
                onChange: function (option, checked) {
                    lstProductos = [];
                    $($("select[id$=ddlProductos]").val()).each(function () {
                        if (lstProductos.length > 0) {
                            var added = false;
                            for (var i = 0; i < lstProductos.length; i++) {
                                if (lstProductos[i] === this["trim"]()) {
                                    added = true;
                                }
                            }
                            if (!added) {
                                lstProductos.push(this["trim"]());
                            }
                        } else {
                            lstProductos.push(this["trim"]());
                        }
                    });
                }
            });

            $("select[id$=ddlProductos]").multiselect({
                includeSelectAllOption: true,
                nonSelectedText: "Ninguno seleccionado",
                selectAllText: "Seleccionar todos"
            });

        }

        function Fn_ShowModalOrder() {
            $('#MyModalRegisterOrder').modal('show');
        }


        function Fn_GuardarOrden() {

            if (success) {

                var isChecked = 0;
                if ($('#chkEstado').is(':checked')) {
                    isChecked = 1
                } else {
                    isChecked = 0;
                }

                var sendData = JSON.stringify({                   
                    clientes: JSON.stringify(lstCliente),
                    productos: JSON.stringify(lstProductos),
                    descripcion: $("input[id$=txtDescripcion]").val(),
                    cantidad: $("input[id$=txtCatidad]").val(),
                    precio: $("input[id$=txtPrecio]").val(),
                    estado: isChecked
                });

             success = function (aws) {
                    var obj = aws.d;
                    if (obj !== null) {
                       
                    } else {
                        fn_custommessage("e", "Error al guardar la orden", "message_row_order");
                    }
                };

                var error = function (xhr, ajaxOptions, thrownError) {
                    fn_custommessage("e", "Error al guardar la orden", "message_row_order");
                };

                var complete = function () {
                };
                fn_callmethod("RegistroUsuario.aspx/RegistroOrden", sendData, success, error, complete);

            }
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="col-lg-12">
        <div class="col-lg-6" style="width:10%; padding-left:0px">  
            <button type="button" runat="server" class="btn btn-primary" onclick="Fn_ShowModalOrder()"><i class="fa fa-save"></i>Generar Orden</button>
        </div>
        <div class="col-lg-6">
              <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="chkViewChatBot">
                                    Mostrar Chatbot
                                </label>
                            </div>
        </div>   
     </div>
    <ucCustom:ucRedirectChatModule runat="server" ID="ucRedirectChatModule" />
    <script>
        $('#menu_chatmodule').attr("class", "nav-active");
        $('#menu_chat').addClass("nav-active nav-expanded");
        $(".labelDash2").html("Panel Chat");
    </script>


    <div id="MyModalRegisterOrder" class="modal fade" role="dialog" aria-labelledby="myModalLabel">
     <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 id="titleModal">Generar Orden</h3>
                </div>
                <div class="modal-body" style="padding:30px">
                    <div id="message_row_order"></div>
                    <div class="form-horizontal form-bordered">

                        <div class="form-group">
                            <label>Cliente:</label>
                             <asp:DropDownList runat="server" ID="ddlCliente" multiple="multiple" class="multiselect-container" data-plugin-multiselect CssClass="form-control validate[required]">
                                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Productos:</label>
                            <asp:DropDownList runat="server" ID="ddlProductos" multiple="multiple" class="multiselect-container" data-plugin-multiselect CssClass="form-control validate[required]">
                                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Descripcion:</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" type="textarea" CssClass="form-control" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Cantidad:</label>
                            <asp:TextBox ID="txtCatidad" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Precio:</label>
                            <asp:TextBox ID="txtPrecio" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="chkEstado">
                                    Estado
                                </label>
                            </div>
                        </div>

                    </div>
                </div>
                <footer class="panel-footer">
                    <button type="button" class="btn btn-primary"<%-- onclick="Fn_Save()"--%> data-dismiss="modal">Guardar</button>
                    <button type="button" runat="server" class="btn btn-sec"><i class="fa fa-refresh"></i>Actualizar</button>
                    <button type="button" runat="server" class="btn btn-sec"><i class="fa fa-circle"></i>Limpiar</button>
                </footer>
            </div>
        </div>
    </div>


</asp:Content>

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

            $('#chkViewChatBot').change(function () {
                if (this.checked) {
                    Fn_ActivarChat(1);
                } else {
                    Fn_ActivarChat(0);
                }
                
            });

            if ($("#<%=hfIsVisiableChat.ClientID%>").val() != "") {
                if ($("#<%=hfIsVisiableChat.ClientID%>").val() == "1") {     //Chat en linea
                    $('#chkViewChatBot').prop('checked', true);
                 } else {                                           //chat bot
                    $('#chkViewChatBot').prop('checked', false);
                 }
             }

        }

        function Fn_ShowModalOrder() {
            $('#MyModalRegisterOrder').modal('show');
        }

        function Fn_Clean() {
            $("textarea[id$=txtDescripcion]").val("");
            $("input[id$=txtCatidad]").val("");
            $("input[id$=txtPrecio]").val("");
        }

        function Fn_ActivarChat(isChecked)
        {
            var sendData = JSON.stringify({
                estado: isChecked
            });

            success = function (aws) {
                var obj = aws.d;
                if (obj !== null) {
                    if (obj.Result = "Ok") {
                        if (obj.Status == "1") {
                            fn_custommessage("s", "Se Activo chat en Linea", "message_row");
                        } else {
                            fn_custommessage("s", "Se Activo ChatBot", "message_row");
                        }         
                    }
                    else {
                        fn_custommessage("i", "Hubo un problema al Cambiar Estado", "message_row");
                    }
                } else {
                    fn_custommessage("e", "Error al Cambiar Estado", "message_row");
                }
            };

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_custommessage("e", "Error Cambiar Estado", "message_row");
            };

            var complete = function () {
            };
            fn_callmethod("RedirectChatModule.aspx/ActiveChatOnLine", sendData, success, error, complete);
        }

        function Fn_GuardarOrden() {

           var isChecked = 0;
           if ($('#chkEstado').is(':checked')) {
               isChecked = 1
           } else {
               isChecked = 0;
           }
         
           var sendData = JSON.stringify({                   
               clientes: JSON.stringify(lstCliente),
               productos: JSON.stringify(lstProductos),
               descripcion: $("textarea[id$=txtDescripcion]").val(),
               cantidad: $("input[id$=txtCatidad]").val(),
               precio: $("input[id$=txtPrecio]").val(),
               estado: isChecked
           });

             success = function (aws) {
                    var obj = aws.d;
                 if (obj !== null)
                 {
                     if (obj.Result = "Ok")
                     {
                         Fn_Clean();
                         $("input[id$=txtUrlgenerate]").val(obj.UrlPaymentOrder);
                         fn_custommessage("s", obj.Msg, "message_row_order");
                     }
                     else
                     {
                         fn_custommessage("i", "Hubo un problema al guardar la Orden", "message_row_order");
                     }
                 } else {
                        fn_custommessage("e", "Error al guardar la orden", "message_row_order");
                  }
                };

                var error = function (xhr, ajaxOptions, thrownError) {
                    fn_custommessage("e", "Error al guardar la orden", "message_row_order");
                };

                var complete = function () {
                };
                fn_callmethod("RedirectChatModule.aspx/RegistroOrden", sendData, success, error, complete);
          }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField runat="server" ID="hfIsVisiableChat" />
    <div id="message_row"></div>
    <div class="col-lg-12">
        <div class="col-lg-6" style="padding-left:0px">  
            <button type="button" runat="server" class="btn btn-primary" onclick="Fn_ShowModalOrder()"><i class="fa fa-save" style="margin-right: 5px"></i>Generar Orden</button>
        </div>
        <div class="col-lg-6">
              <div class="checkbox">
                                <label>
                                    <input type="checkbox" id="chkViewChatBot">
                                    Mostrar chat en Linea
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
                        <div class="form-group">
                            <label>URL GENERADA:</label>
                            <asp:TextBox Enabled="false" ID="txtUrlgenerate" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <footer class="panel-footer">
                    <button type="button" class="btn btn-primary"onclick="Fn_GuardarOrden()">Guardar</button>
                    <button type="button" runat="server" class="btn btn-sec"><i class="fa fa-refresh"></i>Actualizar</button>
                    <button type="button" runat="server" class="btn btn-sec"><i class="fa fa-circle"></i>Limpiar</button>
                </footer>
            </div>
        </div>
    </div>


</asp:Content>

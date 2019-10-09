<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistroPiso.aspx.cs" Inherits="System_Maintenance.Private.Registro.RegistroPiso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var idSelected = "";
        var obj;
        var table;
        var rowsSelected = [];
        $(function () {
            fn_init();
        });
        function fn_init() {
            fn_bind();
        }

        function fn_bind() {
            Fn_InizializeDatatable();
            Fn_content();
        }


        function Fn_InizializeDatatable() {
            $('#datatable-default tbody').on('click', 'input[type="checkbox"]', function (e) {
                var $row = $(this).closest('tr');
                var data = table.row($row).data();
                var rowId = data[0];
                var index = $.inArray(rowId, rowsSelected);
                if (this.checked && index === -1) {
                    rowsSelected.push(rowId);
                } else if (!this.checked && index !== -1) {
                    rowsSelected.splice(index, 1);
                }
                if (this.checked) {
                    $row.addClass('selected');
                } else {
                    $row.removeClass('selected');
                }
                updateDataTableSelectAllCtrl(table);
                e.stopPropagation();
            });
            $('#datatable-default').on('click', 'tbody td, thead th:first-child', function (e) {
                $(this).parent().find('input[type="checkbox"]').trigger('click');
            });
            $('#datatable-default thead input[name="all"]').on('click', function (e) {
                if (this.checked) {
                    $('#datatable-default tbody input[type="checkbox"]:not(:checked)').trigger('click');
                } else {
                    $('#datatable-default tbody input[type="checkbox"]:checked').trigger('click');
                }
                e.stopPropagation();
            });
        }

        function Fn_content() {
            Fn_LlenarTable($("#<%=hfData.ClientID%>").val());
        }

        function Fn_LlenarTable(data) {
            var glancedata = data;
            try {
                obj = $.parseJSON(glancedata);
                var object = {};
                object.request = obj;
                var item = fn_LoadTemplates("datatable-resources", object);
                $("#datatable-default tbody").html(item);
                table = $("#datatable-default").DataTable({
                    responsive: true,
                    scrollX: true
                    //'order': [[2, 'asc']],
                    //'rowCallback': function (row, data, dataIndex) {
                    //    var rowId = data[0];
                    //    if ($.inArray(rowId, rowsSelected) !== -1) {
                    //        $(row).find('input[type="checkbox"]').prop('checked', true);
                    //        $(row).addClass('selected');
                    //    }
                    //}
                });
                //table.on('draw', function () {
                //    updateDataTableSelectAllCtrl(table);
                //});
            }
            catch (e) {
                fn_message('e', 'An error occurred while loading data');
            }
        }
        function Fn_RecargarLista() {
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        $("#datatable-default").dataTable().fnDestroy();
                        Fn_LlenarTable(asw.d.lst);
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
            };

            fn_callmethod("RegistroPiso.aspx/Recargar_Lista", "", success, error);
        }
        function Fn_Registro() {

            if ($("input[id$=txtNombrePiso]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                fn_message('i', 'Debe ingresar Nombre de Piso.', 'message_row');
                return;
            }

            var isChecked = 0;
            if ($('#chkEstado').is(':checked')) {
                isChecked = 1
            } else {
                isChecked = 0;
            }
            obj = {
                Nombre_Piso: $("input[id$=txtNombrePiso]").val().trim(),
                Descripcion_Piso: $("input[id$=txtDescripcion]").val().trim(),
                Estado: isChecked
            }
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                        Fn_RecargarLista();
                        Fn_Limpiar();
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error guardando el Piso');
            };

            var data = { obj: obj };

            fn_callmethod("RegistroPiso.aspx/Registro", JSON.stringify(data), success, error);
        }

        function Fn_Limpiar() {
            $("input[id$=txtNombrePiso]").val("");
            $("input[id$=txtDescripcion]").val("");
        }

    </script>
    <div class="box box-warning">
        <div id="message_row"></div>
        <div class="box-header with-border">
            <h3 <%--class="box-title"--%> style="text-align: center">Registro de Piso</h3>
        </div>
        <div class="box-body">
            <%--  <div class="form-group">
                <label>Nombre Ambiente</label>
                <asp:TextBox ID="txtNombrePiso" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>--%>
            <div class="form-group">
                <label>Nombre Piso</label>
                <asp:TextBox ID="txtNombrePiso" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Descripcion</label>
                <asp:TextBox ID="txtDescripcion" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <div class="checkbox">
                    <label>
                        <input type="checkbox" id="chkEstado">
                        Estado
                    </label>
                </div>
            </div>

            <div class="col-sm-12 text-center">
                <button type="button" runat="server" class="btn btn-primary" onclick="Fn_Registro()"><i class="fa fa-save"></i>Registrar</button>
            </div>
        </div>

        <!-- /.box-body -->
        <div class="modal-body">
            <div>
                <div class="box-body">
                    <table class="table table-bordered table-striped" style="width: 100%" id="datatable-default">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Id</th>
                                <th>Nombre</th>
                                <th>Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </div>
    <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
             <tr>
                 <td style='text-align: center;'>{{Index}}</td>
                 <td>{{Id_Piso}}</td>
                 <td>{{Nombre_Piso}}</td>
                 <td>{{EstadoDes}}</td>
             </tr>
        {{/each}}
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ReportIncident.aspx.cs" Inherits="System_Maintenance.Private.Report.ReportIncident" %>

<%@ Import Namespace="xSystem_Maintenance.src.app_code" %>
<%@ Import Namespace="xAPI.Library.General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- DataTables -->
    <script type="text/javascript">
        var idSelected = "";
        var obj;
        var table;
        var rowsSelected = [];

        $(function () {
            Fn_init();
            //Fecha Inicio
            $('#txtFechaInicio').datepicker({
                format: "mm/dd/yyyy",
                autoclose: true
            });
            $('#txtFechaFin').datepicker({
                format: "mm/dd/yyyy",
                autoclose: true
            });
        });

        function Fn_init() {
            Fn_bind();
            Fn_content();
        }

        function Fn_content() {
            var inicio = $("input[id$=txtFechaInicio]").val().trim();
            var fin = $("input[id$=txtFechaFin]").val().trim();
            var idasistente = $("select[id$=ddlAsistente] option:selected").val();
            $("input[id$=hfFechaInicio]").val(inicio);
            $("input[id$=hfFechaFin]").val(fin);
            $("input[id$=hfIdAsistente]").val(idasistente);
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
                    scrollX: true,
                    'order': [[2, 'asc']],
                    'rowCallback': function (row, data, dataIndex) {
                        var rowId = data[0];
                        if ($.inArray(rowId, rowsSelected) !== -1) {
                            $(row).find('input[type="checkbox"]').prop('checked', true);
                            $(row).addClass('selected');
                        }
                    }
                });
                table.on('draw', function () {
                    updateDataTableSelectAllCtrl(table);
                });
            }
            catch (e) {
                fn_message('e', 'An error occurred while loading data');
            }
        }

        function Fn_bind() {
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
        function fn_RowEdit(index) {
            //console.log(index);
            //var row = $('#tbDataTable').getRowData(index);
            window.location.href = "frmSavePersona.aspx?q=" + index;
        }

        function Fn_RecargarLista() {
            var inicio = $("input[id$=txtFechaInicio]").val().trim();
            var fin = $("input[id$=txtFechaFin]").val().trim();
            var idasistente = $("select[id$=ddlAsistente] option:selected").val();
            $("input[id$=hfFechaInicio]").val(inicio);
            $("input[id$=hfFechaFin]").val(fin);
            $("input[id$=hfIdAsistente]").val(idasistente);
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        $("#datatable-default").dataTable().fnDestroy();
                        Fn_LlenarTable(asw.d.lstIncidents);
                    } else if (asw.d.Result == "NoOk") {
                        fn_message('e', asw.d.Msg, 'message_row');
                    } else {
                        fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
            };

            fn_callmethod("ReportIncident.aspx/Cargar_Incidencias", JSON.stringify({fechaInicio : inicio, fechaFin:fin, idasistente:idasistente}), success, error);
        }
    </script>

    <div class="box">
        <div id="message_row"></div>
        <div class="box-header">
            <h3 class="box-title">Lista de Ventas</h3>

            <div class="form-group col-lg-5" style="margin-left: auto;margin-right: auto;text-align: center;float: none;">
                <label>Inicio:</label>
                <div class="input-group date">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <input type="text" class="form-control pull-right" id="txtFechaInicio">
                </div>
                <label>Fin:</label>
                <div class="input-group date">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <input type="text" class="form-control pull-right" id="txtFechaFin">
                </div>
                <label>Asistente</label>
                <asp:DropDownList ID="ddlAsistente" runat="server" CssClass="form-control"></asp:DropDownList>
                <div style="margin-top:10px">
                    <% 
                        if (BaseSession.SsUser.Id_TipoUsuario == (Int32)EnumTipoUsuario.Administrador)
                        {
                    %>
                    <a class="mb-xs mt-xs mr-xs btn btn-primary" onclick="Fn_RecargarLista()" id="a1"><span>Actualizar</span> </a>
                    <asp:Button ID="btnExport" runat="server" Text="Exportar" CssClass="mb-xs mt-xs mr-xs btn btn-default" OnClick="btnExport_Click" />

                    <%
                        }
                        else if (BaseSession.SsUser.Id_TipoUsuario == (Int32)EnumTipoUsuario.Asistente)
                        {
                    %>
                    <a class="mb-xs mt-xs mr-xs btn btn-primary" onclick="Fn_RecargarLista()" id="a1"><span>Actualizar</span> </a>
                    <%
                        }
                    %>
                </div>
            </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <table class="table table-bordered table-striped" style="width: 100%" id="datatable-default">
                <thead>
                    <tr>
                        <th style="display: none;"></th>
                        <th>
                            <input type="checkbox" id="all" name="all" /></th>
                        <th>#</th>
                        <th>Nombre</th>
                        <th>Apellido Paterno</th>
                        <th>Apellido Materno</th>
                        <th>Tipo Usuario</th>
                        <th>Piso Ambiente</th>
                        <th>Nombre Ambiente</th>
                        <th>Descripcion</th>
                        <th>Nombre Categoria</th>
                        <th>Nombre Equipo</th>
                        <th>Fecha crecion</th>
                        <th>Realizado</th>
                        <%--<th>Accion</th>--%>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hfData" />
    <asp:HiddenField runat="server" ID="hfFechaInicio" />
    <asp:HiddenField runat="server" ID="hfFechaFin" />
    <asp:HiddenField runat="server" ID="hfIdAsistente" />

    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
             <tr>
                 <td style="display: none;">{{Id_Incidencia}}</td>
                 {{#if IsCheckbox}}<td id='multiselect' style='text-align: center;'>
                     <input type='checkbox' id='msg_sel' name='msg_sel' /></td>
                 {{else}}<td id='multiselect' style='text-align: center;'></td>
                 {{/if}} 
                 <td style='text-align: center;'>{{Index}}</td>
                 <td>{{Nombre_Usuario}}</td>
                 <td>{{APaterno_Usuario}}</td>
                 <td>{{AMaterno_Usuario}}</td>
                 <td>{{Nombre_TipUsuario}}</td>
                 <td>{{Piso_Ambiente}}</td>
                 <td>{{Nombre_Ambiente}}</td>
                 <td>{{Descripcion}}</td>
                 <td>{{Nombre_Categoria}}</td>
                 <td>{{Nombre_Equipo}}</td>
                 <td>{{FechaCreacion}}</td>
                 <td>{{IsCompleto}}</td>
                 <%--<td style='text-align: center;'><a onclick="fn_RowEdit('{{UsuId}}')" title='Edit' class='gridActionBtn'><i class='fa fa-edit'></i></a><a onclick="fn_DownloadFile('{{Index}}')" title='Download' class='gridActionBtn'><i class='fa fa-download'></i></a></td>--%>
             </tr>
        {{/each}}

    </script>

</asp:Content>

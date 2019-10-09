<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Incident.aspx.cs" Inherits="System_Maintenance.Private.Incidents.Incident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        var idSelected = "";
        var obj;
        var table;
        var rowsSelected = [];
        var idequipoSet = 0;
        var idambienteSet = 0;
        $(function () {
            fn_init();
        });
        function fn_init() {
            Fn_InizializeDatatable();
            Fn_InitializeControls();
            Fn_content();
        }
        function Fn_content() {
            Fn_LlenarTable($("#<%=hfData.ClientID%>").val());
            var lst = $.parseJSON($("#<%=hfData.ClientID%>").val());
            if (lst != null && lst != "" && lst.length > 0) {
                $("#txtnumberIncidents").text(lst.length);
                $("#txtnumberIncidentsR").text(lst.length);
                $("#idTextExistIncidente").css("display", "block");
            } else {
                $("#txtnumberIncidents").text(0);
                $("#txtnumberIncidentsR").text(0);
                $("#idDivRegistroIncidencia").css("display", "block");
            }

        }

        function Fn_RecargarLista() {
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        $("#datatable-default").dataTable().fnDestroy();
                        Fn_LlenarTable(asw.d.lstIncidents);
                        if (asw.d.lstIncidents != null && asw.d.lstIncidents != "[]" && asw.d.lstIncidents.length > 0) {
                            $("#idDivRegistroIncidencia").css("display", "none");
                            $("#idTextExistIncidente").css("display", "block");
                            $("textarea[id$=txtDescripcionAccion]").val("");
                            $("#txtnumberIncidents").text(asw.d.lstIncidents.length);
                            $("#txtnumberIncidentsR").text(asw.d.lstIncidents.length);
                        } else {
                            $("#idDivRegistroIncidencia").css("display", "block");
                            $("#idTextExistIncidente").css("display", "none");
                            $("textarea[id$=txtDescripcionAccion]").val("");
                            $("select[id$=ddlPiso]").prop("disabled", false);
                            $("select[id$=ddlAmbiente]").prop("disabled", false);
                            $("select[id$=ddlCategoria]").prop("disabled", false);
                            $("select[id$=ddlEquipo]").prop("disabled", false);
                            $("#txtnumberIncidents").text(0);
                            $("#txtnumberIncidentsR").text(0);
                        }
                    }
                    //else if (asw.d.Result == "NoOk") {
                    //    fn_message('e', asw.d.Msg, 'message_row');
                    //} else {
                    //    fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
                    //}
                }
                $("input[id$=txtIdIncidencia]").val(0);
                idequipoSet = 0;
                idambienteSet = 0;
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
            };

            fn_callmethod("Incident.aspx/ReloadCargaIncidencias_ByUsuario", "", success, error);
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

        function Fn_InitializeControls() {
            $("select[id$=ddlCategoria]").on("change", function () {

                var success = function (asw) {

                    if (asw != null) {

                        if (asw.d.Result == "Ok") {
                            LoadTeams(asw.d.lstEquipo);
                            if (idequipoSet != 0) {
                                $("select[id$=ddlEquipo]").val(idequipoSet);
                            }
                        }
                    }
                };

                var error = function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                };

                var id = $(this).children("option:selected").val();
                fn_callmethod("Incident.aspx/LlenarEquipos", '{ categoryId: "' + id + '"}', success, error);
            });

            $("select[id$=ddlCategoria]").trigger('change');

            $("select[id$=ddlPiso]").on("change", function () {

                var success = function (asw) {

                    if (asw != null) {

                        if (asw.d.Result == "Ok") {
                            LoadEnvironment(asw.d.lstAmbiente);
                            if (idambienteSet != 0) {
                                $("select[id$=ddlAmbiente]").val(idambienteSet);
                            }
                        }
                    }
                };

                var error = function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                };

                var id = $(this).children("option:selected").val();
                fn_callmethod("Incident.aspx/LlenarAmbientes", '{ ambienteId: "' + id + '"}', success, error);
            });

            $("select[id$=ddlPiso]").trigger('change');

            if ($('#chkCompleto').is(':checked')) {
                $("#divUsuario").css("display", "none");
            } else {
                $("#divUsuario").css("display", "block");
            }
            $('#chkCompleto').on('change', function () {
                if ($('#chkCompleto').is(':checked')) {
                    $("#divUsuario").css("display", "none");
                } else {
                    $("#divUsuario").css("display", "block");
                }
            });
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

        function LoadTeams(lstTeams) {
            $("select[id$=ddlEquipo]").empty();
            $.each(lstTeams, function () {
                $("select[id$=ddlEquipo]").append($("<option></option>").attr("value", this.Id_Equipo).text(this.Nombre_Equipo))
            });
        }
        function LoadEnvironment(lstEnvironment) {
            $("select[id$=ddlAmbiente]").empty();
            $.each(lstEnvironment, function () {
                $("select[id$=ddlAmbiente]").append($("<option></option>").attr("value", this.Id_Ambiente).text(this.Nombre_Ambiente))
            });
        }

        function Fn_RegistrarIncidencia() {

            if ($("textarea[id$=txtDescripcionAccion]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                fn_message('i', 'Debe ingresar una descipcion de la Accion.', 'message_row');
                return;
            }
            if ($("select[id$=ddlAmbiente] option:selected").val() == undefined || $("select[id$=ddlAmbiente] option:selected").val() == 0) {
                fn_message('i', 'Debe seleccionar Ambiente.', 'message_row');
                return;
            }

            if ($("select[id$=ddlCategoria] option:selected").val() == undefined || $("select[id$=ddlCategoria] option:selected").val() == 0) {
                fn_message('i', 'Debe seleccionar Tipo de Incidencia.', 'message_row');
                return;
            }
            if ($("select[id$=ddlEquipo] option:selected").val() == undefined || $("select[id$=ddlEquipo] option:selected").val() == 0) {
                fn_message('i', 'Debe seleccionar Equipo.', 'message_row');
                return;
            }
            var isCompleto = 0;
            if ($('#chkCompleto').is(':checked')) {
                isCompleto = 1
            } else {
                if ($("select[id$=ddlUsuario] option:selected").val() == undefined || $("select[id$=ddlUsuario] option:selected").val() == 0) {
                    fn_message('i', 'Debe seleccionar Usuario.', 'message_row');
                    return;
                }
                isCompleto = 0;
            }

            obj = {
                Id_Incidencia: $("input[id$=txtIdIncidencia]").val().trim(),
                Id_Ambiente: $("select[id$=ddlAmbiente] option:selected").val(),
                Descripcion: $("textarea[id$=txtDescripcionAccion]").val().trim(),
                Id_Equipo: $("select[id$=ddlEquipo] option:selected").val(),
                Completo: isCompleto,
                Id_UsuarioAsignado: $("select[id$=ddlUsuario] option:selected").val()
            }
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                        if ($("input[id$=txtIdIncidencia]").val() > 0) {
                            Fn_RecargarLista();
                        }
                        $("textarea[id$=txtDescripcionAccion]").val("");
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error guardando la incidencia');
            };

            var dataIncidencia = { objIncidencia: obj };

            fn_callmethod("Incident.aspx/RegistrarIncidencia", JSON.stringify(dataIncidencia), success, error);
        }

        function Fn_VIewModal() {
            $("#IdPopupInicident").modal("show");
        }
        function Fn_LlenarRegistro(incidenciaId, pisoId, ambienteId, categoriaId, equipoId) {
            $("#idDivRegistroIncidencia").css("display", "block");
            $("input[id$=txtIdIncidencia]").val(incidenciaId)
            $("textarea[id$=txtDescripcionAccion]").val("");

            idambienteSet = ambienteId;
            idequipoSet = equipoId;
            $("select[id$=ddlPiso]").val(pisoId)
            $("select[id$=ddlPiso]").trigger('change');
            //$("select[id$=ddlAmbiente]").val(ambienteId);
            $("select[id$=ddlCategoria]").val(categoriaId);
            $("select[id$=ddlCategoria]").trigger('change');
            //$("select[id$=ddlEquipo]").val(equipoId);

            //Disabled
            $("select[id$=ddlPiso]").prop("disabled", true);
            $("select[id$=ddlAmbiente]").prop("disabled", true);
            $("select[id$=ddlCategoria]").prop("disabled", true);
            $("select[id$=ddlEquipo]").prop("disabled", true);

            $("#IdPopupInicident").modal("hide");
            $("#idTextExistIncidente").css("display", "none");
        }
    </script>

    <%--Cargar Incidencias Asiginadas--%>
    <div class="modal fade" id="IdPopupInicident" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">x</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Incidencias Asignadas</h4>
                </div>
                <div class="modal-body">
                    <div>
                        <div class="box-body">
                            <table class="table table-bordered table-striped" style="width: 100%" id="datatable-default">
                                <thead>
                                    <tr>
                                        <th style="display: none;"></th>
                                        <th style="display: none">
                                            <input type="checkbox" id="all" name="all" /></th>
                                        <th>Realizar</th>
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
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
             <tr>
                 <td style="display: none;">{{Id_Incidencia}}</td>
                 {{#if IsCheckbox}}<td id='multiselect' style='text-align: center; display: none'>
                     <input type='checkbox' id='msg_sel' name='msg_sel' /></td>
                 {{else}}<td id='multiselect' style='text-align: center; display: none'></td>
                 {{/if}} 
                 <td style='text-align: center;'><a onclick="Fn_LlenarRegistro('{{Id_Incidencia}}','{{Id_Piso}}','{{Id_Ambiente}}','{{Id_Categoria}}','{{Id_Equipo}}')" title='Edit' class='gridActionBtn'><i class='fa fa-edit'></i></a></td>
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
             </tr>
        {{/each}}

    </script>
    <%--End Carga Incidencias Asiginadas--%>

    <a style="text-align: center; display: none; cursor: pointer" id="idTextExistIncidente" onclick="Fn_VIewModal()">
        <%--<h3>Usted tiene Incidencias Asignadas...Click Aqui.</h3>--%>
        <div class="col-md-12">
            <div class="box box-solid box-default">
                <div class="box-header">
                    <h3 class="box-title">Incidencias</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    Usted tiene Incidencias Asignadas...Click Aqui.
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
    </a>
    <div class="box box-warning" id="idDivRegistroIncidencia" style="display: none">
        <div id="message_row"></div>
        <div class="box-header with-border">
            <div class="form-group" style="margin-left: auto; margin-right: auto; text-align: left;">
                <label>Fecha:</label>
                <asp:Label ID="fechaActualId" runat="server" type="text"></asp:Label>
            </div>
            <h3 style="text-align: center">Registro de Incidencias</h3>
        </div>
        <asp:TextBox ID="txtIdIncidencia" Text="0" runat="server" type="text" Style="width: 50%; margin: auto; margin-top: 5px; display: none;" disabled CssClass="form-control"></asp:TextBox>
        <div class="form-group" style="margin-left: auto; margin-right: auto; text-align: center;">
            <label>Piso:</label>
            <asp:DropDownList ID="ddlPiso" CssClass="form-control" runat="server" Style="width: 50%; margin: auto;"></asp:DropDownList>
            <label>Ambiente:</label>
            <asp:DropDownList ID="ddlAmbiente" CssClass="form-control" runat="server" Style="width: 50%; margin: auto;"></asp:DropDownList>
        </div>
        <div class="box-body">
            <div class="form-group">
                <label>Usuario</label>
                <asp:TextBox ID="nameCompleteUser" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Tipo de Incidencia</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Seleccione</label>
                <asp:DropDownList ID="ddlEquipo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group" style="display: none">
                <label>Selecciona estado    </label>
                <asp:DropDownList ID="ddlEstadoEquipo" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Descripcion</label>
                <asp:TextBox ID="txtDescripcionAccion" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" placeholder="Ingrese Accion que realizo..."></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="checkbox">
                    <label>
                        <input type="checkbox" id="chkCompleto">
                        Marque el Check si se completo?
                    </label>
                </div>
            </div>
            <div class="form-group" id="divUsuario">
                <label>Asignar a asistente:</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-sm-12 text-center">
                <button type="button" runat="server" class="btn btn-primary" onclick="Fn_RegistrarIncidencia()"><i class="fa fa-save"></i>Registrar</button>
            </div>
        </div>
    </div>



</asp:Content>

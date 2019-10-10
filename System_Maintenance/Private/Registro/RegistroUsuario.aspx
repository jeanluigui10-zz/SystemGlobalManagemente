<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="System_Maintenance.Private.Registro.RegistroUsuario" %>

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
                        Fn_LlenarTable(asw.d.lstUsers);
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error cargando la lista', 'message_row');
            };

            fn_callmethod("RegistroUsuario.aspx/Recargar_ListaAsistentes", "", success, error);
        }

        function Fn_Registro(issave) {
            if (issave == 1) {
                if ($("input[id$=txtNombre]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Nombre.', 'message_row');
                    return;
                }
                if ($("input[id$=txtApellidoPaterno]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Apellido Paterno', 'message_row');
                    return;
                }
                if ($("input[id$=txtApellidoMaterno]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Apellido Materno', 'message_row');
                    return;
                }
                if ($("input[id$=txtDni]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Dni', 'message_row');
                    return;
                }
                if ($("input[id$=txtContrasena]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Contraseña', 'message_row');
                    return;
                }
                if ($("select[id$=ddlTipoUsuario] option:selected").val() == undefined || $("select[id$=ddlTipoUsuario] option:selected").val() == 0) {
                    fn_message('i', 'Debe ingresar Tipo de usuario', 'message_row');
                    return;
                }
            } else {

                if ($("input[id$=txtIdUsuario]").val().replace(/^\s+|\s+$/g, "").length == 0 || $("input[id$=txtIdUsuario]").val() == 0) {
                    fn_message('i', 'Debe Seleccionar usuario para editar.', 'message_row');
                    return;
                }
                if ($("input[id$=txtNombre]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Nombre.', 'message_row');
                    return;
                }
                if ($("input[id$=txtApellidoPaterno]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Apellido Paterno', 'message_row');
                    return;
                }
                if ($("input[id$=txtApellidoMaterno]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Apellido Materno', 'message_row');
                    return;
                }
                if ($("input[id$=txtDni]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Dni', 'message_row');
                    return;
                }
                if ($("input[id$=txtContrasena]").val().replace(/^\s+|\s+$/g, "").length == 0) {
                    fn_message('i', 'Debe ingresar Contraseña', 'message_row');
                    return;
                }
                if ($("select[id$=ddlTipoUsuario] option:selected").val() == undefined || $("select[id$=ddlTipoUsuario] option:selected").val() == 0) {
                    fn_message('i', 'Debe ingresar Tipo de usuario', 'message_row');
                    return;
                }
            }



            var isChecked = 0;
            if ($('#chkEstado').is(':checked')) {
                isChecked = 1
            } else {
                isChecked = 0;
            }

            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                        Fn_Limpiar();
                        Fn_RecargarLista();
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error guardando el usuario');
            };

            if (issave == 2) {
                obj = {
                    Id_Usuario: $("input[id$=txtIdUsuario]").val(),
                    Nombre_Usuario: $("input[id$=txtNombre]").val().trim(),
                    APaterno_Usuario: $("input[id$=txtApellidoPaterno]").val().trim(),
                    AMaterno_Usuario: $("input[id$=txtApellidoMaterno]").val().trim(),
                    Dni_Usuario: $("input[id$=txtDni]").val().trim(),
                    Contrasena: $("input[id$=txtContrasena]").val().trim(),
                    Estado: isChecked,
                    Id_TipoUsuario: $("select[id$=ddlTipoUsuario] option:selected").val()

                }
            } else {
                obj = {
                    Nombre_Usuario: $("input[id$=txtNombre]").val().trim(),
                    APaterno_Usuario: $("input[id$=txtApellidoPaterno]").val().trim(),
                    AMaterno_Usuario: $("input[id$=txtApellidoMaterno]").val().trim(),
                    Dni_Usuario: $("input[id$=txtDni]").val().trim(),
                    Contrasena: $("input[id$=txtContrasena]").val().trim(),
                    Estado: isChecked,
                    Id_TipoUsuario: $("select[id$=ddlTipoUsuario] option:selected").val()

                }
            }
            var data = { obj: obj };



            fn_callmethod("RegistroUsuario.aspx/Registro", JSON.stringify(data), success, error);
        }

        function Fn_Eliminar(id) {

            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                        Fn_Limpiar();
                        Fn_RecargarLista();
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error guardando el usuario');
            };
            obj = {
                Id_Usuario: id
            }

            var data = { obj: obj };
            fn_callmethod("RegistroUsuario.aspx/Eliminacion", JSON.stringify(data), success, error);
        }

        function Fn_Limpiar() {
            $("input[id$=txtIdUsuario]").val(0);
            $("input[id$=txtNombre]").val("");
            $("input[id$=txtApellidoPaterno]").val("");
            $("input[id$=txtApellidoMaterno]").val("");
            $("input[id$=txtDni]").val("");
            $("input[id$=txtContrasena]").val("");
            $("input[id$=txtUsuario]").val("");
            $('#chkEstado').prop('checked', false);
        }
        function Fn_Editar(Id_Usuario, Id_TipoUsuario, Nombre_Usuario, APaterno_Usuario, AMaterno_Usuario, Dni_Usuario, Contrasena, Nombre_TipUsuario, Estado) {
            $("input[id$=txtIdUsuario]").val(Id_Usuario);
            $("input[id$=txtNombre]").val(Nombre_Usuario);
            $("input[id$=txtApellidoPaterno]").val(APaterno_Usuario);
            $("input[id$=txtApellidoMaterno]").val(AMaterno_Usuario);
            $("input[id$=txtDni]").val(Dni_Usuario);
            $("select[id$=ddlTipoUsuario]").val(Id_TipoUsuario)
            $("input[id$=txtContrasena]").val(Contrasena);
            if (Estado == 1) {
                $('#chkEstado').prop('checked', true);
            } else {
                $('#chkEstado').prop('checked', false);
            }
            $("html, body").animate({ scrollTop: $('#titleid').offset().top }, 1000);
        }
    </script>

    <!-- /.box -->
    <!-- general form elements disabled -->
    <div class="box box-warning">
        <div id="message_row"></div>
        <div class="box-header with-border">

            <h3 id="titleid" <%--class="box-title"--%> style="text-align: center">Registro de Usuario</h3>
        </div>

        <div class="box-body">
            <!-- text input -->
            <div class="form-group" style="display: none">
                <asp:TextBox ID="txtIdUsuario" runat="server" type="text" Text="0" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Apellido Paterno</label>
                <asp:TextBox ID="txtApellidoPaterno" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Apellido Materno</label>
                <asp:TextBox ID="txtApellidoMaterno" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Dni</label>
                <asp:TextBox ID="txtDni" runat="server" type="text" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" type="password" CssClass="form-control"></asp:TextBox>
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
                <label>Tipo de Usuario</label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-sm-12 text-center">
                <button type="button" runat="server" class="btn btn-primary" onclick="Fn_Registro(1)"><i class="fa fa-save"></i>Guardar</button>
                <button type="button" runat="server" class="btn btn-sec" onclick="Fn_Registro(2)"><i class="fa fa-refresh"></i>Actualizar</button>
                <button type="button" runat="server" class="btn btn-sec" onclick="Fn_Limpiar()"><i class="fa fa-circle"></i>Limpiar</button>
            </div>
        </div>

        <!-- /.box-body -->
        <div class="modal-body">
            <div>
                <div class="box-body">
                    <table class="table table-bordered table-striped" style="width: 100%" id="datatable-default">
                        <thead>
                            <tr>
                                <th style="display: none;"></th>
                                <th>Accion</th>
                                <th>#</th>
                                <th>Nombre</th>
                                <th>Apellido Paterno</th>
                                <th>Apellido Materno</th>
                                <th>Dni</th>
                                <th>Contrasena</th>
                                <th>Tipo Usuario</th>
                                <th>Estado</th>
                                <th style="display: none">EstadoValue</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- /.box -->
    <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
             <tr>
                 <td style="display: none;">{{Id_Usuario}}</td>
                 <td style='text-align: center;'>
                     <a onclick="Fn_Editar('{{Id_Usuario}}','{{Id_TipoUsuario}}','{{Nombre_Usuario}}','{{APaterno_Usuario}}','{{AMaterno_Usuario}}','{{Dni_Usuario}}','{{Contrasena}}','{{Nombre_TipUsuario}}','{{Estado}}')" title='Edit' class='gridActionBtn'><i class='fa fa-edit'></i></a>
                     <a onclick="Fn_Eliminar('{{Id_Usuario}}')" title='Edit' class='gridActionBtn'><i class='fa fa-remove'></i></a>
                 </td>
                 <td style='text-align: center;'>{{Index}}</td>
                 <td>{{Nombre_Usuario}}</td>
                 <td>{{APaterno_Usuario}}</td>
                 <td>{{AMaterno_Usuario}}</td>
                 <td>{{Dni_Usuario}}</td>
                 <td>{{Contrasena}}</td>
                 <td>{{Nombre_TipUsuario}}</td>
                 <td>{{EstadoDes}}</td>
                 <td style="display: none">{{Estado}}</td>
             </tr>
        {{/each}}
    </script>
</asp:Content>

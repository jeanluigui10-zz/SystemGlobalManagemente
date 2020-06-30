<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CategoryEntry.aspx.cs" Inherits="System_Maintenance.Private.CategoryManagement.CategoryEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
 
        var idSelected = "";
        var obj;
        var table;
        var rows_selected = [];
        var isTooltip = false;
        $(function () {
            Fn_init();
        });

        function Fn_init() {
            Fn_content();
            Fn_bind();
            Fn_setmenu();
        }
        function Fn_setmenu() {
            $('#mgcategory').attr("class", "nav-active");
            $('#menu_comm_center').addClass("nav-active nav-expanded");
            $(".labelDash").html("Global");
        }

        function Fn_bind() {
            $("td [role='gridcell'][aria-describedby='tbGrid_ACTION']").attr("title", '');
            $('#tbDataTable tbody').on('click', 'input[type="checkbox"]', function (e) {
                var $row = $(this).closest('tr');
                var data = table.row($row).data();
                var rowId = data[0];
                var index = $.inArray(rowId, rows_selected);
                if (this.checked && index === -1) {
                    rows_selected.push(rowId);
                } else if (!this.checked && index !== -1) {
                    rows_selected.splice(index, 1);
                }
                if (this.checked) {
                    $row.addClass('selected');
                } else {
                    $row.removeClass('selected');
                }
                updateDataTableSelectAllCtrl(table);
                e.stopPropagation();
            });

            $('#tbDataTable').on('click', 'tbody td, thead th:first-child', function (e) {
                $(this).parent().find('input[type="checkbox"]').trigger('click');
            });
            $('#tbDataTable thead input[name="all"]').on('click', function (e) {
                if (this.checked) {
                    $('#tbDataTable tbody input[type="checkbox"]:not(:checked)').trigger('click');
                } else {
                    $('#tbDataTable tbody input[type="checkbox"]:checked').trigger('click');
                }
                e.stopPropagation();
            });
        }
     
        function Fn_content() {
            Fn_fillTable2($("#<%=hfDataCategory.ClientID%>").val());
        }

        function Fn_fillTable2(data) {
            var glancedata = data;
            try {
                obj = $.parseJSON(glancedata);
                var object = {};
                object.request = obj;
                var item = fn_LoadTemplates("datatable-category", object);
                $("#tbDataTable tbody").html(item);
                table = $("#tbDataTable").DataTable({
                    'columnDefs': [{
                        'targets': 0,
                        'searchable': false,
                        'orderable': false,
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<input type="checkbox">';
                        }
                    }],
                    'order': [[2, 'asc']],
                    'rowCallback': function (row, data, dataIndex) {
                        var rowId = data[0];
                        if ($.inArray(rowId, rows_selected) !== -1) {
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
                fn_message('e', 'An error occurred while loading data...');
            }
        }        

        function Fn_RowEdit(Id) {
            window.location.href = "CategoryEntrySave.aspx?q=" + Id; 
        }

    	   function Fn_new() {
                    window.location.href = "CategoryEntrySave.aspx"; 
        }

        function fn_delete3() {
            var text = "";
            var lista = [];
            var len = table.rows('.selected').data().length;
            if (len > 0) {
                bootbox.confirm("¿Está seguro de que desea eliminar este registro(s)?", function (result) {
                    if (result) {
                        table.rows('.selected').data().each(function (element, index) {
                            lista[index] = element[0];
                        });
                        var json = JSON.stringify(lista);
                        var senddata = '{ jsondata:"' + fn_jsonreplace(json) + '" }';
                        var success = function (asw) {
                            if (asw.d.sJSON == "Deleted successfully") {
                                var lista = asw.d.Lista;
                                $("#<%=hfDataCategory.ClientID%>").val(lista);
                                table.destroy();
                                Fn_fillTable2(lista);
                                fn_message('s', 'Se elimino correctamente');
                            }
                            else
                                fn_message('e', 'No se puede eliminar el registro(s)');
                        };
                        var error = function (xhr, ajaxOptions, thrownError) {
                            fn_message('e', 'No se puede eliminar el registro(s)');
                        };

                        fn_callmethod("CategoryEntry.aspx/SendDelete", senddata, success, error);
                    }
                });
            }
            else fn_message('i', "Por favor, seleccione una fila para eliminar");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hfDataCategory" />
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <div id="message_row">
                </div>
                <header class="panel-heading">
                    <div class="panel-actions">
                    </div>
                    <h2 class="panel-title">Categorías</h2>
                    <div class="title" style="text-align: right; margin-top: -20px;">
                        <a id= "helpdesk" class="helpDesk" data-keyname="PROCESS_COMMUNICATION_CENTER_RESOURCES_MANAGEMENT"><i class="fa fa-question-circle fa-2x"></i></a>
                    </div>
                </header>
                
                <div class="panel-body" id="finfo">
                    <div class="form-horizontal form-bordered " id="fCompany">

                        <div class="row">
                            <div class="col-md-9 cnt-controles">
                                <a class="mb-xs mt-xs mr-xs btn btn-primary" onclick="Fn_new()"  id="a1"><i
                                    class="fa fa-plus"></i><span>&nbsp;Agregar</span> </a>
                                <a class="mb-xs mt-xs mr-xs btn btn-danger" onclick="fn_delete3()" id="A2"><i class="fa fa-times"></i><span>&nbsp;Eliminar</span> </a>
                            </div>
                        </div>
                        <div class="myForm1 themeBlue" style="margin-top:10px">
                            <div class="container-menunav">
                               
                                <div class="grid-container paddleft-3">
                                    <table id="tbDataTable" class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th style="display: none;"></th>
                                                <th></th>
                                                <th><input type="checkbox" id="all" name="all" /></th>
                                                <th>Nombre</th>
                                                <th>Descripción</th>
                                                <th>Tipo</th>
                                                <th>Imagen</th>
                                                <th>Fecha de Registro</th>
                                                <th>Estado</th>
                                                <th>Acción</th>
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
            </section>
        </div>
    </div>
    
    <script type="text/x-handlebars-template" id="datatable-category">
        {{# each request}}
            <tr>
                <td style="display: none;">{{Id}}</td> 
                <td style='text-align:center;'>{{Index}}</td> 
                {{#if isCheckbox}}
                    <td id='multiselect' style='text-align:center;'><input type='checkbox' id='msg_sel1' name='msg_sel'/></td>
                {{else}}
                    <td id='multiselect' style='text-align:center;'></td>
                {{/if}} 
                    <td>{{Name}}</td>
                    <td>{{Description}}</td>
                    <td>{{DocType}}</td>
                    <td><img style='max-height: 50px; max-width: 50px;' src='{{NameResource}}' onerror='this.src="../../../src/images/image_not_found_res.jpg"'/></td>  
                    <td>{{CreatedDate}}</td>
                    <td>{{Status}}</td>
                    <td style='text-align:center;'><a onclick="Fn_RowEdit('{{Id}}')" title='Edit' class='gridActionBtn'><i class='fa fa-edit'></i></a></td>                 
                  </tr>
        {{/each}}
    </script>

</asp:Content>

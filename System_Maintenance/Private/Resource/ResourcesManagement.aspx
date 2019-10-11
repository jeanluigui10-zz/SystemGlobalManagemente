<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ResourcesManagement.aspx.cs" Inherits="System_Maintenance.Private.Resource.ResourcesManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        #popup-languages div.modal-dialog div div.modal-body{
        height:auto;
        }
  </style>

 <script type="text/javascript">
 
     //var ucWebMethodResourceManagementDelete = '<%=ResolveUrl("~/src/control/ResourceManagement/ucWebMethodResourceManagement.aspx/SendDelete") %>';

        var idSelected = "";
        var obj;
        var table;
        var rows_selected = [];
        var isTooltip = false;
        $(function () {
            fn_init();
        });

        function fn_init() {
            fn_content();
            fn_bind();
            fn_setmenu();
        }
        function fn_setmenu() {
            $('#mgresources').attr("class", "nav-active");
            $('#menu_comm_center').addClass("nav-active nav-expanded");
            $(".labelDash").html("Global");
        }

        function fn_bind() {
            $("td [role='gridcell'][aria-describedby='tbGrid_ACTION']").attr("title", '');
           <%-- $("#<%=lnkbtnlanguage.ClientID %>").click(function () {
                $("#popup-languages").modal("show");
                return false;
            });--%>
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
     
        function fn_content() {
            fn_fillTable2($("#<%=hfData.ClientID%>").val());
        }

        function fn_fillTable2(data) {
            var glancedata = data;
            try {
                obj = $.parseJSON(glancedata);
                var object = {};
                object.request = obj;
                var item = fn_LoadTemplates("datatable-resources", object);
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

        function fn_RowEdit(index) {
            window.location.href = "ResourcesManagementSave.aspx?q=" + index + "&l=" + $("#<%=hfLng.ClientID %>").val();
        }

    	function fn_new() {
    		window.location.href = "ResourcesManagementSave.aspx?l=" + $("#<%=hfLng.ClientID %>").val();
        }

        function fn_delete3() {
            var text = "";
            var lista = [];
            var len = table.rows('.selected').data().length;
            if (len > 0) {
                bootbox.confirm("Are you sure you want to delete this record(s)?", function (result) {
                    if (result) {
                        table.rows('.selected').data().each(function (element, index) {
                            lista[index] = element[0];
                        });
                        var json = JSON.stringify(lista);
                        var senddata = '{ jsondata:"' + fn_jsonreplace(json) + '" }';
                        var success = function (asw) {
                            if (asw.d.sJSON == "Deleted successfully") {
                                var lista = asw.d.Lista;
                                $("#<%=hfData.ClientID%>").val(lista);
                                table.destroy();
                                fn_fillTable2(lista);
                                fn_message('s', 'SUCCESS_DELETED"),"Deleted successfully');
                            }
                            else
                                fn_message('e', 'Unable to delete the record(s)');
                        };
                        var error = function (xhr, ajaxOptions, thrownError) {
                            fn_message('e', 'An error occurred while sending data');
                        };

                        fn_callmethod("ResourcesManagement.aspx/SendDelete", senddata, success, error);
                    }
                });
            }
            else fn_message('i', "Please select at least one row to delete");
        }


        function fn_DownloadFile(resourceNameFile) {
            
            try {               
                resourceNameFile = decodeURI(resourceNameFile);
                var extensionFile = resourceNameFile.split('.')[1].toLowerCase();

                if (extensionFile != "pdf") {
                    window.location.href = resourceNameFile;
                }
                else {
                    window.open(resourceNameFile, "Download", "status=yes,min-width=300,height=300,scrollbars=yes");
                }

            } catch (e) {
                fn_message('e', 'An error occurred while downloading the file');
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <asp:HiddenField runat="server" ID="hfData" />
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <div id="message_row">
                </div>
                <header class="panel-heading">
                    <div class="panel-actions">
                    </div>
                    <h2 class="panel-title">Resources management</h2>
                    <div class="title" style="text-align: right; margin-top: -20px;">
                        <a id= "helpdesk" class="helpDesk" data-keyname="PROCESS_COMMUNICATION_CENTER_RESOURCES_MANAGEMENT"><i class="fa fa-question-circle fa-2x"></i></a>
                    </div>
                </header>
                
                <div class="panel-body" id="finfo">
                    <div class="form-horizontal form-bordered " id="fCompany">

                        <div class="row">
                            <div class="col-md-9 cnt-controles">
                                <a class="mb-xs mt-xs mr-xs btn btn-primary" onclick="fn_new()"  id="a1"><i
                                    class="fa fa-plus"></i><span>&nbsp;Add</span> </a>
                                <a class="mb-xs mt-xs mr-xs btn btn-danger" onclick="fn_delete3()" id="A2"><i class="fa fa-times"></i><span>&nbsp;Delete</span> </a>

                             <%--   <asp:LinkButton ID="lnkbtnlanguage" runat="server" class="mb-xs mt-xs mr-xs btn btn-info">
                                    <asp:Image ID="imgRegion" runat="server" />
                                    &nbsp; Elije tu lenguage
                                </asp:LinkButton>--%>

                            </div>
                        </div>
                        <div class="myForm1 themeBlue">
                            <div class="container-menunav">
                               
                                <div class="grid-container paddleft-3">
                                    <table id="tbDataTable" class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th style="display: none;"></th>
                                                <th><input type="checkbox" id="all" name="all" /></th>
                                                <th>ID</th>
                                                <th>TYPE</th>
                                                <th>CATEGORY</th>
                                                <th>DESCRIPTION</th>
                                                <th>FILE</th>
                                                <th>STATUS</th>
                                                <th>CREATED_DATE</th>
                                                <th>ACTION</th>
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
    <asp:HiddenField ID="hfLng" runat="server" />
    <div class="modal fade" id="popup-languages" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" >
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">x</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Choose your language</h4>
                </div>
                <div class="container-fluid modal-body">
                    <ul id="languages" runat="server">
                    </ul>
                </div>

            </div>
        </div>
    </div>
    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
            <tr>
                <td style="display: none;">{{Id}}</td> 
                {{#if isCheckbox}}
                    <td id='multiselect' style='text-align:center;'><input type='checkbox' id='msg_sel1' name='msg_sel'/></td>
                {{else}}
                    <td id='multiselect' style='text-align:center;'></td>
                {{/if}} 
                    <td style='text-align:center;'>{{Index}}</td>                      
                    <td>{{DocType}}</td>
                    <td>{{Category}}</td>
                    <td>{{FileDescription}}</td> 
                    <td><img style='max-height: 50px; max-width: 50px;' src='{{NameResource}}' onerror='this.src="../../../src/images/image_not_found_res.jpg"'/></td>  
                    <td>{{Status}}</td>  
                    <td>{{CreatedDate}}</td> 
                    <td style='text-align:center;'><a onclick="fn_RowEdit('{{Id}}')" title='Edit' class='gridActionBtn'><i class='fa fa-edit'></i></a><a onclick="fn_DownloadFile('{{{NameResource}}}')"  title='Download' class='gridActionBtn'><i class='fa fa-download'></i></a></td>                 
                  </tr>
        {{/each}}
    </script>
</asp:Content>

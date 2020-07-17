<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SubCategoryEntrySave.aspx.cs" Inherits="System_Maintenance.Private.SubCategoryManagement.SubCategoryEntrySave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

      function Fn_ValidateSubCategory(event) {
      
        if (!fn_validateform('divSubCategory')) {
            event.preventDefault();
            return false;
        }
       
        if (/[<>]+/.test($("#<%=txtSubCategoryName.ClientID %>").val().trim())) {
            fn_message('i', "Invalid Name input. The tags '>' and '<' are not allowed.");
            event.preventDefault();
            return false;
        }

        if ($("select[id$=ddlCategory] option:selected").val() == undefined || $("select[id$=ddlCategory] option:selected").val() == 0) {
                fn_message('i', 'Seleccione una Categoría');
                return false;
            }

        objSubCategory = { 
                Id: $("#<%=hfSubCategoryId.ClientID%>").val(),
                SubCategoryName: $("#<%=txtSubCategoryName.ClientID%>").val().trim(),
                CategoryId:  $("select[id$=ddlCategory] option:selected").val(),
                Status: $("#<%=chkStatus.ClientID%>").is(':checked') ? 1 : 0
        }
        Fn_saveSubCategory(objSubCategory);
    }

       function Fn_saveSubCategory(obj) {

        var success = function (asw) {
            if (asw != null) {
                if (asw.d.Result == "Ok") {
                    $("#<%=txtSubCategoryName.ClientID%>").text("");
                    fn_message("s", asw.d.Msg);
                } else {
                    fn_message('i', 'Ocurrio un error al guardar');
                }
            }
        };
        var error = function (xhr, ajaxOptions, thrownError) {
            fn_message('e', 'Ocurrio un error al guardar');
        };
        
        var senddata = { u: obj };

        fn_callmethod("SubCategoryEntrySave.aspx/SubCategory_Save", JSON.stringify(senddata), success, error);
    }
          
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <div class="col-lg-12">
            <asp:HiddenField ID="hfSubCategoryId" runat="server" />

            <section class="panel">
                <div id="message_row">
                </div>
                <header class="panel-heading">
                    <div class="panel-actions">
                    </div>
                    <h2 class="panel-title">
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h2>
                    <div class="title" style="text-align: right; margin-top: -20px;">
                        <a id="helpdesk" class="helpDesk" data-keyname="PROCESS_COMMUNICATION_CENTER_RESOURCES_MANAGEMENT_SAVE"><i class="fa fa-question-circle fa-2x"></i></a>
                    </div>
                </header>

                <div class="panel-body">
                    <div id="divSubCategory" class="form-horizontal form-bordered">
                        <div class="form-group">
                            <div class="col-sm-6 col-md-4 col-lg-4 cnt-text-label text-custom">
                                <asp:Label ID="lblRequiredFields" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="lblCategory" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:DropDownList runat="server" ID="ddlCategory" class="form-control mb-md">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblSubCategoryName" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:TextBox ID="txtSubCategoryName" runat="server" CssClass="form-control  validate[required]" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEnabled" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>

                            <div class="col-xs-2 col-sm-7 col-md-6 col-lg-7 cnt-text">
                                <asp:CheckBox runat="server" Checked="true" ID="chkStatus" />
                            </div>
                        </div>
                    </div>
                </div>

                <footer class="panel-footer" id="f_Company">
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3">
                            <button type="button" id="btnUpload" class="mb-xs mt-xs mr-xs btn btn-lg btn-primary" onclick="Fn_ValidateSubCategory(event);">Guardar</button>    
                            <asp:Button ID="btnCancel" runat="server" class="mb-xs mt-xs mr-xs btn btn-lg btn-default" Text="" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </footer>
            </section>
        </div>
    </div>

</asp:Content>

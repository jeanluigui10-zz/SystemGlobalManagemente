<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CategoryEntrySave.aspx.cs" Inherits="System_Maintenance.Private.CategoryManagement.CategoryEntrySave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
    function Fn_ValidateCategory(event) {
      
        if (!fn_validateform('divCategory')) {
            event.preventDefault();
            return false;
        }
        if (/[<>]+/.test($("#<%=txtDescription.ClientID %>").val())) {
                fn_message('i', "Invalid Description input. The tags '>' and '<' are not allowed.");
                return false;
            }

            if (/[<>]+/.test($("#<%=txtName.ClientID %>").val())) {
            fn_message('i', "Invalid Name input. The tags '>' and '<' are not allowed.");
            event.preventDefault();
            return false;
        }

        objUser = {
                Id: $("#<%=hfCategoryId.ClientID%>").val(),
                Name: $("#<%=txtName.ClientID%>").val(),
                Description: $("#<%=txtDescription.ClientID%>").val(),
                Status: $("#<%=chkStatus.ClientID%>").is(':checked') ? 1 : 0
        }
        Fn_saveCategory(objUser);
    }

    function Fn_saveCategory(obj) {

        var success = function (asw) {
            if (asw != null) {
                if (asw.d.Result == "Ok") {
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

        fn_callmethod("CategoryEntrySave.aspx/Category_Save", JSON.stringify(senddata), success, error);
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">t
        <div class="col-lg-12">
            <asp:HiddenField ID="hfCategoryId" runat="server" />

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
                    <div id="divCategory" class="form-horizontal form-bordered">
                        <div class="form-group">
                            <div class="col-sm-6 col-md-4 col-lg-4 cnt-text-label text-custom">
                                <asp:Label ID="lblRequiredFields" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblName" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control  validate[required,maxSize[50]]" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblDescription" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control " TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEnabled" runat="server" Text="" CssClass="col-xs-5 col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>

                            <div class="col-xs-2 col-sm-7 col-md-6 col-lg-7 cnt-text">
                                <asp:CheckBox runat="server" Checked="true" ID="chkStatus" />
                            </div>
                        </div>
                    </div>
                </div>

                <footer class="panel-footer" id="f_Company">
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3">
                            <button type="button" id="btnUpload" class="mb-xs mt-xs mr-xs btn btn-lg btn-primary" onclick="Fn_ValidateCategory(event);">Guardar</button>    
                            <asp:Button ID="btnCancel" runat="server" class="mb-xs mt-xs mr-xs btn btn-lg btn-default" Text="" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </footer>
            </section>
        </div>
    </div>

</asp:Content>

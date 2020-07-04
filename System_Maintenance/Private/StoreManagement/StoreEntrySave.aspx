<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StoreEntrySave.aspx.cs" Inherits="System_Maintenance.Private.StoreManagement.StoreEntrySave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .panel-actions {
            right: -95%;
            position: relative;
            top: 15px;
        }
        .panel-actions a {
            background-color: transparent;
            border-radius: 2px;
            color: #b4b4b4;
            font-size: 14px;
            height: 24px;
            line-height: 24px;
            text-align: center;
            width: 24px;
        }
    </style>

     <script type="text/javascript">

         var StoreData = {
             name: "",
             address: "",
             email: "",
             phone1: "",
             phone2: "",
             attentionHours: "",
             noteDelivery: "",
             noteSupport: "",
             notePromotions: "",
             notePayment: "",
             year: "",
             //banner: "",
             //logo: "",
             facebook: "",
             instagram: "",
             youtube: "",
             twitter: ""
         };
         $(function () {
             fn_init();
         });

         function fn_init() {
             fn_content();
         }

         function fn_content() {
             fn_setdata();
             fn_settags('all');
         }

         function fn_setdata() {
             this.StoreData.name = $("#<%=txtName.ClientID%>").val();
             this.StoreData.address = $("#<%=txtAddress.ClientID%>").val();
             this.StoreData.email = $("#<%=txtEmail.ClientID%>").val();
             this.StoreData.phone1 = $("#<%=txtPhone1.ClientID%>").val();
             this.StoreData.phone2 = $("#<%=txtPhone2.ClientID%>").val();
             this.StoreData.attentionHours = $("#<%=txtAttentionHours.ClientID%>").val();
             this.StoreData.noteDelivery = $("#<%=txtNoteDelivery.ClientID%>").val();
             this.StoreData.noteSupport = $("#<%=txtNoteSupport.ClientID%>").val();
             this.StoreData.notePromotions = $("#<%=txtNotePromotions.ClientID%>").val();
             this.StoreData.notePayment = $("#<%=txtNotePayment.ClientID%>").val();
             this.StoreData.year = $("#<%=txtYear.ClientID%>").val();
             <%--this.StoreData.banner = $("#<%=txtBanner.ClientID%>").val();
             this.StoreData.logo = $("#<%=txtLogo.ClientID%>").val();--%>
             this.StoreData.facebook = $("#<%=txtFacebook.ClientID%>").val();
             this.StoreData.instagram = $("#<%=txtInstagram.ClientID%>").val();
             this.StoreData.youtube = $("#<%=txtYoutube.ClientID%>").val();
             this.StoreData.twitter = $("#<%=txtTwitter.ClientID%>").val();
         }

         function fn_iconedit(e, fdiv, iconDis, section) {
             e.preventDefault();
             $('#edit' + section).css('display', 'block');
             $('#read' + section).css('display', 'none');
             $("#" + fdiv).slideDown("slow");
             $("#f_" + section).show();
         }

         function Cancel(e, iconDis, section) {
             e.preventDefault();
             fn_backToReadOnly(iconDis, section);
             fn_settags(section);
         }

         function fn_settags(section) {

             if (section == 'Store' || section == 'all') {

                 $("#<%=txtName.ClientID%>").val(StoreData.name);
                 $("#<%=txtAddress.ClientID%>").val(StoreData.address);
                 $("#<%=txtEmail.ClientID%>").val(StoreData.email);
                 $("#<%=txtPhone1.ClientID%>").val(StoreData.phone1);
                 $("#<%=txtPhone2.ClientID%>").val(StoreData.phone2);
                 $("#<%=txtAttentionHours.ClientID%>").val(StoreData.attentionHours);
                 $("#<%=txtNoteDelivery.ClientID%>").val(StoreData.noteDelivery);
                 $("#<%=txtNoteSupport.ClientID%>").val(StoreData.noteSupport);
                 $("#<%=txtNotePromotions.ClientID%>").val(StoreData.notePromotions);
                 $("#<%=txtNotePayment.ClientID%>").val(StoreData.notePayment);
                 $("#<%=txtYear.ClientID%>").val(StoreData.year);
                 <%--$("#<%=txtBanner.ClientID%>").val(StoreData.banner);
                 $("#<%=txtLogo.ClientID%>").val(StoreData.logo);--%>
                 $("#<%=txtFacebook.ClientID%>").val(StoreData.facebook);
                 $("#<%=txtInstagram.ClientID%>").val(StoreData.instagram);
                 $("#<%=txtYoutube.ClientID%>").val(StoreData.youtube);
                 $("#<%=txtTwitter.ClientID%>").val(StoreData.twitter);

                 $("#lblName3").text(StoreData.name);
                 $("#lblAddress3").text(StoreData.address);
                 $("#lblEmail3").text(StoreData.email);
                 $("#lblPhone13").text(StoreData.phone1);
                 $("#lblPhone23").text(StoreData.phone2);
                 $("#lblAttentionHours3").text(StoreData.attentionHours);
                 $("#lblNoteDelivery3").text(StoreData.noteDelivery);
                 $("#lblNoteSupport3").text(StoreData.noteSupport);
                 $("#lblNotePromotions3").text(StoreData.notePromotions);
                 $("#lblNotePayment3").text(StoreData.notePayment);
                 $("#lblYear3").text(StoreData.year);
                 //$("#lblBanner3").text(StoreData.banner);
                 //$("#lblLogo3").text(StoreData.logo);
                 $("#lblFacebook3").text(StoreData.facebook);
                 $("#lblInstagram3").text(StoreData.instagram);
                 $("#lblYoutube3").text(StoreData.youtube);
                 $("#lblTwitter3").text(StoreData.twitter);
             }
         }

         function fn_backToReadOnly(iconDis, section) {
             $('#edit' + section).css('display', 'none');
             $('#read' + section).css('display', 'block');

             $("#" + iconDis + " .edit-pencil").css('display', 'inline-block');
             $("#f_" + section).hide();
         }

         function Save(e, section, wmethod, icon) {
             if (!fn_validateform("edit" + section)) {
                 e.preventDefault();
                 return false;
             }
           
             obj = {
                 Id: $("#<%=hfStoreId.ClientID%>").val(),
                 Name: $("#<%=txtName.ClientID%>").val(),
                 Address: $("#<%=txtAddress.ClientID%>").val(),
                 Email: $("#<%=txtEmail.ClientID%>").val(),
                 Phone1: $("#<%=txtPhone1.ClientID%>").val(),
                 Phone2: $("#<%=txtPhone2.ClientID%>").val(),
                 AttentionHours: $("#<%=txtAttentionHours.ClientID%>").val(),
                 NoteDelivery: $("#<%=txtNoteDelivery.ClientID%>").val(),
                 NoteSupport: $("#<%=txtNoteSupport.ClientID%>").val(),
                 NotePromotions: $("#<%=txtNotePromotions.ClientID%>").val(),
                 NotePayment: $("#<%=txtNotePayment.ClientID%>").val(),
                 Year: $("#<%=txtYear.ClientID%>").val(),
                 Facebook: $("#<%=txtFacebook.ClientID%>").val(),
                 Instagram: $("#<%=txtInstagram.ClientID%>").val(),
                 Youtube: $("#<%=txtYoutube.ClientID%>").val(),
                 Twitter: $("#<%=txtTwitter.ClientID%>").val(),
             };
             fn_saveInfoStore(section, obj, icon);
         }

         function fn_saveInfoStore(section, objStore, icon) {

             var success = function (asw) {
                 if (asw != null) {
                     if (asw.d.Result == "Ok") {
                         fn_refreshinfo(section);
                         fn_settags(section);
                         fn_backToReadOnly(icon, section);
                         fn_content();
                         fn_message("s", asw.d.Msg);
                     } else {
                         fn_message('i', 'Ocurrio un error al guardar');
                     }
                 }
             };
             var error = function (xhr, ajaxOptions, thrownError) {
                 fn_message('e', 'Ocurrio un error al guardar');
             };

             var senddata = { obj: objStore };

             fn_callmethod("StoreEntrySave.aspx/Store_UpdateInfo", JSON.stringify(senddata), success, error);
         }

         function fn_refreshinfo(div) {

             switch (div) {

                 case "Store":

                   <%-- this.emailData.EmailSender = $("#<%=txtEmailNotify.ClientID%>").val();
                    this.emailData.smtp = $("#<%=txtSMTP.ClientID%>").val();
                    this.emailData.port = $("#<%=txtPort.ClientID%>").val();
                    this.emailData.username = $("#<%=txtUsername.ClientID%>").val();
                     this.emailData.password = $("#<%=txtPaswordsmtp.ClientID%>").val(); this.StoreData.twitter = $("#<%=txtTwitter.ClientID%>").val();--%>

                     this.StoreData.name = $("#<%=txtName.ClientID%>").val();
                     this.StoreData.address = $("#<%=txtAddress.ClientID%>").val();
                     this.StoreData.email = $("#<%=txtEmail.ClientID%>").val();
                     this.StoreData.phone1 = $("#<%=txtPhone1.ClientID%>").val();
                     this.StoreData.phone2 = $("#<%=txtPhone2.ClientID%>").val();
                     this.StoreData.attentionHours = $("#<%=txtAttentionHours.ClientID%>").val();
                     this.StoreData.noteDelivery = $("#<%=txtNoteDelivery.ClientID%>").val();
                     this.StoreData.noteSupport = $("#<%=txtNoteSupport.ClientID%>").val();
                     this.StoreData.notePromotions = $("#<%=txtNotePromotions.ClientID%>").val();
                     this.StoreData.notePayment = $("#<%=txtNotePayment.ClientID%>").val();
                     this.StoreData.year = $("#<%=txtYear.ClientID%>").val();
                     <%--this.StoreData.banner = $("#<%=txtBanner.ClientID%>").val();
                     this.StoreData.logo = $("#<%=txtLogo.ClientID%>").val();--%>
                     this.StoreData.facebook = $("#<%=txtFacebook.ClientID%>").val();
                     this.StoreData.instagram = $("#<%=txtInstagram.ClientID%>").val();
                     this.StoreData.youtube = $("#<%=txtYoutube.ClientID%>").val();
                     this.StoreData.twitter = $("#<%=txtTwitter.ClientID%>").val();
                    break;               
             }
         }

     </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfStoreId" runat="server" />
      <section class="panel">
                <div id="message_row"></div>
                <header class="panel-footer">
                    <div class="panel-actions">
                       <%-- <a href="#" class="fa fa-caret-down"></a>--%>
                        <a href="#" class="fa fa-edit" onclick="fn_iconedit(event,'fStore','store-settings','Store');"></a>
                    </div>
                    <h2 class="panel-title">Información de Mi Tienda</h2>
                </header>

                <div class="panel-body" id="fStore">
                    <div class="form-horizontal form-bordered" id="Div2">
                        <div id="editStore" class="edit" style="display: none;">
                            <div class="form-group">
                                <div class="col-sm-6 col-md-4 col-lg-4 cnt-text-label text-custom">
                                    <asp:Label ID="lblRequiredFields3" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                           <div class="form-group">
                                <asp:Label ID="lblName" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtName"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblAddress" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtAddress"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblEmail" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtEmail"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblPhone1" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtPhone1"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblPhone2" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtPhone2"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblAttentionHours" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtAttentionHours"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNoteDelivery" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtNoteDelivery"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNoteSupport" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtNoteSupport"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNotePromotions" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtNotePromotions"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNotePayment" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtNotePayment"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblYear" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required,custom[onlyNumberSp]]" ID="txtYear"></asp:TextBox>
                                </div>
                            </div>
                           <%-- <div class="form-group">
                                <asp:Label ID="lblBanner" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtBanner"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblLogo" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtLogo"></asp:TextBox>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <asp:Label ID="lblFacebook" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtFacebook"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblInstagram" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtInstagram"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblYoutube" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtYoutube"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblTwitter" runat="server" Text="" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label"></asp:Label>

                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-controles">
                                    <asp:TextBox runat="server" CssClass="form-control validate[required]" ID="txtTwitter"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="readStore" class="read">
                            <div class="form-group">
                                <asp:Label ID="lblName2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblName3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblAddress2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblAddress3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblEmail2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblEmail3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblPhone12" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblPhone13">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblPhone22" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblPhone23">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblAttentionHours2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblAttentionHours3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNoteDelivery2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblNoteDelivery3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNoteSupport2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblNoteSupport3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNotePromotions2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblNotePromotions3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblNotePayment2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblNotePayment3">
                                    </label>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label ID="lblYear2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblYear3">
                                    </label>
                                </div>
                            </div>
                            <%--<div class="form-group">
                                <asp:Label ID="lblBanner2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblBanner3">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblLogo2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblLogo3">
                                    </label>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <asp:Label ID="lblFacebook2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblFacebook3">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblInstagram2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblInstagram3">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblYoutube2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblYoutube3">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblTwitter2" runat="server" CssClass="col-sm-4 col-md-4 col-lg-3 cnt-text-label" Text=""></asp:Label>
                                <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7   cnt-text">
                                    <label id="lblTwitter3">
                                    </label>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <footer class="panel-footer" id="f_Store" style="display: none;">
                    <div class="row">
                        <div class="col-sm-9 col-sm-offset-3">
                            <input id="btnSaveBasic" value="Guardar" type="button" class="mb-xs mt-xs mr-xs btn btn-lg btn-primary" onclick="Save(event, 'Store', 'Store_UpdateInfo', 'store-settings')" />
                            <input id="btnCancelBasic" value="Atrás" type="button" class="mb-xs mt-xs mr-xs btn btn-lg btn-default" onclick="Cancel(event, 'store-settings', 'Store')" />

                        </div>
                    </div>
                </footer>
            </section>

</asp:Content>

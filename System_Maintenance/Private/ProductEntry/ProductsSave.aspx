<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ProductsSave.aspx.cs" Inherits="System_Maintenance.Private.Resource.ProductsSave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../src/js/jquery.MultiFile.js"></script>

    <style type="text/css"> 
         .modal-block{
                 background: transparent;
                 padding: 0;
                 text-align: left;
                 max-width: 600px;
                 margin: 40px auto;
                 position: relative;
         }
    </style>

    <script type="text/javascript">

        $(document).ready(function () {
            fn_init();
            $('form').preventDoubleSubmission();
        });
        var PreviewOriginal = "";
        var Edit = 0;
        var image;
        var sizeImage = "";
        jQuery.fn.preventDoubleSubmission = function () {
            $(this).on('submit', function (e) {
                var $form = $(this);
                if ($form.data('submitted') === true) {
                    e.preventDefault();
                } else {
                    $form.data('submitted', true);
                }
            });
            return this;
        };

        function fn_init() {
            fn_setimage();
            fn_bind();
            fn_setValidator();
            fn_setmenu();
            fn_validate();
        }
        function fn_validate() {
            $("#<%=btnUpload.ClientID%>").on("click", function () {
                if ($.trim($("#<%=txtName.ClientID%>").val()) == "" || $.trim($("#<%=txtDescription.ClientID%>").val()) == "")
                    return false;
            });
        }

        function fn_setmenu() {
            $('#mgresources').attr("class", "nav-active");
            $('#menu_comm_center').addClass("nav-active nav-expanded");
            $(".labelDash").html("Global");
            if ($("<input>").is(":text")) {
                $(this).keypress(function (e) {
                    var keycode = (e.keyCode ? e.keyCode : e.which);
                    if (keycode === 13) {
                        e.preventDefault();
                    }
                });
            }
        }

        function fn_setValidator() {
            $("#editBasic").validationEngine();
        }

        function fn_validate2(event) {
         
            if (sizeImage > 10485760) {
                fn_message('i', "The image upload is too big");
                return false;
            }
           
            if (!fn_validateform('editBasic')) {
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
            return true;
        }


        function fn_setimage() {
            var path = $("#<%=hfPathImage.ClientID%>").val();
            if (path != "") {
                var prev = "";
                var filenamesplited = path.split('.');
                var extension = filenamesplited[filenamesplited.length - 1].toLowerCase();
                if (extension == "jpg" || extension == "png" || extension == "jpeg") {
                    prev = "/src/images/FileTypeIcon/" + extension + ".png";
                    $(".previewFile").show();
                    PreviewOriginal = path;
                    $("#divImage").append("<a class='MultiFile-remove' href='#' title='Delete' onclick='fn_delete()'>x</a><img style='max-height: 50px;max-width: 50px;margin:0 auto;' src='" + PreviewOriginal + "' /> ");
                    $("#divImage").show();
                    Edit = 1;
                }
                else {
                    $(".previewFile").show();
                    PreviewOriginal = path;
                    $("#divImage").append("<a class='MultiFile-remove' href='#' title='Delete' onclick='fn_delete()'>x</a><img style='max-height: 50px;max-width: 50px;margin:0 auto;' src='http://www.sciencedomain.org/assets/themes/frontend/images/icon-file.png' /> ");
                    $("#divImage").show();
                    Edit = 1;

                }
            }
            else {
                $("#divImage").hide();
            }
        }

        function fn_delete() {
            $("#divImage").hide();
            $(".previewFile").hide();
            PreviewOriginal = "";
            Edit = 0;
        }

        function fn_bind() {
            
            $("#<%=fuResource.ClientID%>").bind('change', function () {
                if ($("#<%=fuResource.ClientID%>").val() != "") {

                    if (this.files[0].size > 10485760) {
                        image = true;
                        this.files[0] = null;
                        $(".previewFile").hide();
                        fn_message('i', 'The image upload is too big');
                        PreviewOriginal = "";
                        Edit = 0;
                        sizeImage = this.files[0].size;
                    } else {
                        image = false;
                        console.log("1");
                        $(".previewFile").show();
                        $("#divImage").hide();
                        PreviewOriginal = "";
                        Edit = 0;
                        sizeImage = this.files[0].size;

                    }
                } else {
                    image = null;
                    $(".previewFile").hide();
                    PreviewOriginal = "";
                    Edit = 0;
                }
            });


            $("#<%=rbLink.ClientID%>").click(function () {
                fn_hide_show();
            });
            $("#<%=ddlResourceType.ClientID%>").change(function () {
                fn_change_show();
            });
            $("#<%=rbFile.ClientID%>").click(function () {
                fn_hide_show();
            });

            fn_change_show();
            fn_hide_show();
            $("#piframe").hide();
            $("#imgpreview").hide();
            if ($('#<%=rbLink.ClientID%>').is(':checked')) {
                $("#divImage").hide();
            }

            $('#dialogClose').on('click', function (e) {
                $("#piframe").attr("src", "");
                $.magnificPopup.close();
            });
        }

        function fn_change_show() {
            var ddl = $("#<%=ddlResourceType.ClientID%>").val();
            if (ddl == "Audio" || ddl == "Video" || ddl == "Video Tutorial" || ddl == "Webinar Link" || ddl == "Webcast") {
                $("#divDuration").show();
            } else {
                $("#divDuration").hide();
            }
            if (ddl == "Webinar Link" || ddl == "Webcast") {
                $("#<%=rbFile.ClientID%>").attr("disabled", true);
                $("#<%=rbFile.ClientID%>").parent().removeClass("checked");
                $("#<%=rbFile.ClientID%>").attr(":checked", "");
                $("#<%=rbLink.ClientID%>").attr(":checked", "checked");
                $("#<%=rbLink.ClientID%>").parent().addClass("checked");
                $("#DivFile").hide();
                $("#DivLink").show();
            } else {
                $("#<%=rbFile.ClientID%>").attr("disabled", false);
                $("#<%=rbFile.ClientID%>").parent().addClass("checked");
                $("#<%=rbFile.ClientID%>").attr(":checked", "checked");
                $("#<%=rbLink.ClientID%>").attr(":checked", "");
                $("#<%=rbLink.ClientID%>").parent().removeClass("checked");
                $("#DivFile").show();
                $("#DivLink").hide();
            }
        }

        function fn_hide_show() {
            var rbFile = $('#<%=rbFile.ClientID%>');
            var rbLink = $('#<%=rbLink.ClientID%>');
            if (rbFile.is(':checked')) {
                $("#DivFile").show();
                $("#DivLink").hide();
                $("#<%=txtLink.ClientID%>").removeClass();
                $("#<%=txtLink.ClientID%>").addClass("form-control")
            }
            if (rbLink.is(':checked')) {
                $("#DivFile").hide();
                $("#DivLink").show();
                $("#<%=txtLink.ClientID%>").removeClass();
                $("#<%=txtLink.ClientID%>").addClass("form-control validate[custom[url]]")
            }
        }

        function preview(type) {
            if (Edit === 1) {
                $("#piframe").show();
                $("#piframe").attr("src", PreviewOriginal);
                $.magnificPopup.open({
                    items: {
                        src: '#resource',
                        type: 'inline'
                    },
                    preloader: false,
                    modal: true,
                });
                return;
            }
            $("#piframe").show();
            if (type == 'link') {
                var link = $('#<%=txtLink.ClientID%>').val();
                var regLink = /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i;
                if (link == "") { fn_message('i', 'Enter the link'); return }
                if (!regLink.test(link)) {
                    fn_message('i', '"Enter the link'); return
                }
                $("#divImage").hide();
                if (link != "") {
                    $("#piframe").attr("src", link);
                }
            } else {
                var input = document.querySelector("input[type=file]");
                if (input.value == "" && $("#<%=hfPathImage.ClientID%>").val() == "") { fn_message('i', 'Select a file'); return; }

                if (input.value != "") {
                    if ((input.value.indexOf(".docx") != -1) || (input.value.indexOf(".doc") != -1) || (input.value.indexOf(".ppt") != -1) || (input.value.indexOf(".pptx") != -1) || (input.value.indexOf(".pptx") != -1) || (input.value.indexOf(".xls") != -1) || (input.value.indexOf(".xlsx") != -1)) {
                        fn_message('i', 'No preview available for this type document'); return;
                    }

                    if (input.files && input.files[0]) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $("#piframe").attr("src", e.target.result);
                        }
                        reader.readAsDataURL(input.files[0]);
                    }
                }
                else {
                    if ($("#<%=hfPathImage.ClientID%>").val() != "") {
                        var viewWord = "http://xbackoffice.xssdemos.com";
                        viewWord += $("#<%=hfPathImage.ClientID%>").val();
                        $("#piframe").attr("src", viewWord);
                    }
                }
            }

            $.magnificPopup.open({
                items: {
                    src: '#resource',
                    type: 'inline'
                },
                preloader: false,
                modal: true,
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="row">
        <div class="col-lg-12">
            <asp:HiddenField ID="hfDistributorId" runat="server" />
            <asp:HiddenField ID="hfPathImage" runat="server" />
            <asp:HiddenField ID="hfFileName" runat="server" />
            <asp:HiddenField ID="hfPublicName" runat="server" />
            <asp:HiddenField ID="hfFileExtension" runat="server" />

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
                    <div id="editBasic" class="form-horizontal form-bordered">
                        <div class="form-group">
                            <div class="col-sm-6 col-md-4 col-lg-4 cnt-text-label text-custom">
                                <asp:Label ID="lblRequiredFields" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblResourceCategory" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:DropDownList runat="server" ID="ddlResourceCategory" CssClass="form-control mb-md">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblResourceType" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:DropDownList runat="server" ID="ddlResourceType" CssClass="form-control mb-md">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblExtDesc" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="form-group" style="display: none;">
                            <asp:Label ID="lblSystemContact" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:DropDownList runat="server" ID="ddlSystemContact" CssClass="">
                                </asp:DropDownList>
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
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control  validate[required,maxSize[50]]" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label">Precio Unitario</asp:Label>
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control  validate[required]"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group" id="dvUrl" style="display: none">
                            <asp:Label ID="lblUrl" runat="server" Text="" CssClass="col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>
                       
                            <div class=" col-xs-11 col-sm-7 col-md-6 col-lg-7 cnt-controles">
                                <div class="input-group">
                                    <asp:Label runat="server" CssClass="input-group-addon"> user.&nbsp;</asp:Label>
                                    <asp:TextBox runat="server" ID="txtUrl" class="form-control"></asp:TextBox>
                                </div>
                                <div>
                                    <span>For example: user.<strong>xirectss.com/newsite/products/Xirect.aspx</strong></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblUploadFile" runat="server" Text="" CssClass="col-xs-5 col-sm-4 col-md-3 col-lg-3 cnt-text-label"></asp:Label>
                            <div class="col-md-6">
                                <asp:RadioButton ID="rbFile" Text="" GroupName="Location" runat="server" Checked="true" />
                                <asp:RadioButton ID="rbLink" Text="" GroupName="Location" class="col-md-offset-1" runat="server" Checked="false" />

                            </div>
                        </div>
                        <div class="form-group" id="DivLink" style="display: none">
                            <asp:Label ID="Label22" runat="server" Text="" CssClass="col-xs-5 col-sm-4 col-md-3 col-lg-3 cnt-text-label" data-trigger="hover" data-placement="top" data-content="&nbsp;" data-original-title="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">"Link"<i class="icon-question-sign"></i></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtLink" placeholder="ex. http://www.youtube.com/embed/w8IfaW-38yE" runat="server" CssClass="form-control"></asp:TextBox>
                                <input type="button" value="Preview" onclick="preview('link')" class="btn btn-default" style="margin-top: 5px;" />
                            </div>
                        </div>
                        <div class="form-group" id="DivFile">
                            <asp:Label ID="lblFileNameL" runat="server" CssClass="col-xs-5 col-sm-4 col-md-3 col-lg-3 cnt-text-label" Text=""></asp:Label>
                            <div class="col-md-6">
                                <asp:FileUpload ID="fuResource" runat="server" CssClass="Width_2_file fuResource" />
                                <input type="button" value="Preview" onclick="preview('file')" class="btn btn-default previewFile" style="margin-top: 5px; display: none" />                         
                            </div>
                            <div id="divImage" style="margin-left: 210px;"></div>
                        </div>


                        <div class="form-group">
                            <asp:Label ID="lblEnabled" runat="server" Text="" CssClass="col-xs-5 col-sm-4 col-md-3 col-lg-3  cnt-text-label"></asp:Label>

                            <div class="col-xs-2 col-sm-7 col-md-6 col-lg-7 cnt-text">
                                <asp:CheckBox runat="server" Checked="true" ID="chkEnable" />
                            </div>
                        </div>
               
                    </div>
                </div>

                <footer class="panel-footer" id="f_Company">
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3">
                            <asp:Button ID="btnUpload" runat="server" class="mb-xs mt-xs mr-xs btn btn-lg btn-primary" Text="" OnClick="btnSave_Click" OnClientClick="fn_validate2(event);" />
                            <asp:Button ID="btnCancel" runat="server" class="mb-xs mt-xs mr-xs btn btn-lg btn-default" Text="" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </footer>
                <asp:HiddenField ID="hfCi" runat="server" />
            </section>
        </div>
    </div>

    <div id="resource" class="modal-block mfp-hide">
        <section class="panel">
            <header class="panel-heading">
                <h2 class="panel-title">View resource</h2>
            </header>
            <div class="panel-body">
                <div class='embed-responsive embed-responsive-16by9'>
                    <iframe id="piframe" class="embed-responsive-item" width="610" height="345" src="" frameborder="0" allowfullscreen></iframe>
                </div>
                <img id="imgpreview" class="img-responsive">
            </div>
            <footer class="panel-footer">
                <div class="row">
                    <div class="col-md-12 text-right">
                        <button id="dialogClose" class="btn btn-default" type="button">Cerrar</button>
                    </div>
                </div>
            </footer>
        </section>
    </div>


</asp:Content>

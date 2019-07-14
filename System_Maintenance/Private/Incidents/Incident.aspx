<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Incident.aspx.cs" Inherits="System_Maintenance.Private.Incidents.Incident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
            $(function () {
            fn_init();
          });
           function fn_init() {
            fn_bind(); 
          }

          function fn_bind()
          {
               $("select[id$=ddlCategoria]").on("change", function () {

                var success = function (asw) {

                    if (asw != null) {

                        if (asw.d.Result == "Ok") {
                            LoadTeams(asw.d.lstEquipo);
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
          }

          function LoadTeams(lstTeams)
          {
            $("select[id$=ddlEquipo]").empty();
            $.each(lstTeams, function () {
                $("select[id$=ddlEquipo]").append($("<option></option>").attr("value", this.Id_Equipo).text(this.Nombre_Equipo))
            });
        }
 
    </script>
 
    <!-- /.box -->
    <!-- general form elements disabled -->
    <div class="box box-warning">
        <div class="box-header with-border">
            <h3 class="box-title">General Elements</h3>
        </div>
        <!-- /.box-header -->
        <div class="box-body">
                <!-- text input -->
                <div class="form-group">
                    <label>Usuario</label>
                    <asp:TextBox ID="nameCompleteUser" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                </div>


                <!-- select -->
                <div class="form-group">
                    <label>Selecciona Categoria</label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                   <%-- <select class="form-control">
                        <option>option 1</option>
                        <option>option 2</option>
                        <option>option 3</option>
                        <option>option 4</option>
                        <option>option 5</option>
                    </select>--%>
                </div>
                <!-- input states -->

                <!-- checkbox -->

                <!-- radio -->

                <!-- select -->
                <div class="form-group">
                    <label>Selecciona equipo</label>
                    <asp:DropDownList ID="ddlEquipo" runat="server" CssClass="form-control"></asp:DropDownList>
             <%--       <select class="form-control">
                        <option>option 1</option>
                        <option>option 2</option>
                        <option>option 3</option>
                        <option>option 4</option>
                        <option>option 5</option>
                    </select>--%>
                </div>

                <!-- select -->
                <div class="form-group">
                    <label>Selecciona estado    </label>
                    <asp:DropDownList ID="ddlEstadoEquipo" runat="server" CssClass="form-control"></asp:DropDownList>
                    <%--<select class="form-control">
                        <option>option 1</option>
                        <option>option 2</option>
                        <option>option 3</option>
                        <option>option 4</option>
                        <option>option 5</option>
                    </select>--%>
                </div>

                <!-- textarea -->
                <div class="form-group">
                    <label>Descripcion</label>
                    <textarea class="form-control" rows="3" placeholder="Ingrese Accion que realizo..."></textarea>
                </div>

        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->
</asp:Content>

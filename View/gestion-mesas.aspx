<%@ Page Title="" Language="C#" MasterPageFile="~/Mesa.master" AutoEventWireup="true" CodeBehind="gestion-mesas.aspx.cs" Inherits="Vista.gestion_mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMesaDashboard" runat="server">

      <!--MESSAGE SECTION-->
    <div class="col-lg-12" style="margin: 1%">
        <div class="form-group">
            <asp:Label ID="lblErrorMessageMesaMaster" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </div>
    

        <%= sb.ToString() %>


    <div class="modal fade" id="AsignarMesa">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Asignar Mesa</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                   <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="card-text">

                                <fieldset>
                                    <div class="form-group">
                                        <asp:Label ID="lblMesa" runat="server" Text="Mesa Nº"></asp:Label>
                                        <asp:TextBox ID="txtMesa_id" runat="server"  Text="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre del Cliete"></asp:Label>
                                        <asp:TextBox ID="txtNombreCliente" runat="server"  Text="" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rdfNombreCliente" runat="server" ErrorMessage="Ingrese un texto válido" ControlToValidate="txtNombreCliente" ValidationGroup="asignarMesa"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
               
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="cmdAsignarMesa" runat="server" Text="Confirmar" CssClass="btn btn-raised btn-primary" OnClick="cmdAsignarMesa_Click" ValidationGroup="asignarMesa"/>
                                    </div>
                                </fieldset>

                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-raised btn-danger" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>
   </div>


    <!--CUADRO DE DIALOGO MODAL DE ADMINISTRACION DE COMANDA-->
    <div class="modal fade" id="administrarComanda">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Confirmación</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="col-lg-12" >
                        <div class="card">
                            <div class="card-body">
                                <div class="card-text">
                                    <div class="form-group">
                                        <asp:Label ID="lblMesaId2" runat="server" Text="Mesa Nº"></asp:Label>
                                        <asp:TextBox ID="txtMesaId2" runat="server"  Text="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <p>¿Que acción desea realizar?</p>
                                    </div>
                                     <div class="form-group">
                                        <asp:Button ID="cmdOrdenar" runat="server" Text="Ordenar" CssClass="btn btn-raised btn-dark" OnClick="cmdOrdenar_Click" ValidationGroup="administracionComanda"/>
                                        <asp:Button ID="cmdFacturar" runat="server" Text="Facturar" CssClass="btn btn-raised btn-dark"  OnClick="cmdFacturar_Click" ValidationGroup="administracionComanda"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>


</asp:Content>

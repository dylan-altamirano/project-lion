<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="facturacion.aspx.cs" Inherits="View.facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--MESSAGE SECTION-->
    <div class="col-lg-12" style="margin: 1%">
        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </div>


    <!--AGREGAR METODO DE PAGO-->
    <div class="col-lg-6">
        <div class="card">
            <div class="card-header">
                <div class="card-title"><h4>Método de Pago</h4></div>
            </div>
            <div class="card-body">
                <div class="card-text">
                <div class="form-group">
                    <asp:Label ID="lblSeleccionarMetodoPago" runat="server" Text="Seleccione un método de pago"></asp:Label>
                        <asp:DropDownList ID="cboMetodosPago" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="rdfMetodosPago" runat="server" ErrorMessage="Debe seleccionar un método de pago" ControlToValidate="cboMetodosPago" ValidationGroup="metodosPago"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="cmdAgregarMetodoPago" runat="server" Text="Agregar" CssClass="btn btn-raised btn-dark" OnClick="cmdAgregarMetodoPago_Click" ValidationGroup="metodosPago"/>
                </div>
                </div>
            </div>
        </div>
    </div>
    <!--End of Agregar Metodo Pago-->

     <!--Detalle Pago-->
    <div class="col-lg-6">
        <div class="card">
            <div class="card-header">
               <strong>Detalle del pago</strong> 
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblTotalEfectivo" runat="server" Text="Total Efectivo"></asp:Label>
                    <asp:TextBox ID="txtTotalEfectivo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNumeroTarjeta" runat="server" Text="Nº Tarjeta"></asp:Label>
                    <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblExpirationDate" runat="server" Text="Expiración de la Tarjeta"></asp:Label>
                    <asp:DropDownList ID="cboMeses" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="cboAnnos" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTotalTarjeta" runat="server" Text="Total En Tarjeta"></asp:Label>
                    <asp:TextBox ID="txtTotalTarjeta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <div class="card-title">Total Por Facturar:  <asp:Label ID="lblTotalFactura" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                <div class="form-group">
                    <asp:Button ID="cmdRealizarPago" runat="server" Text="Realizar Pago" CssClass="btn btn-raised btn-dark"  OnClick="cmdRealizarPago_Click"/>
                </div>
            </div>
        </div>
        <!--End of card -->
    </div>
    <!--End of detalle pago section-->

     <!--COMANDA HEADER INFORMATION-->
    <div class="col-lg-12" style="margin-top:20px">
        <div class="card">
            <div class="card-header">
                <strong>Resumen de la comanda</strong> 
            </div>
            <div class="card-body">

                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblComandaID" runat="server" Text="Comanda Nº"></asp:Label>
                            <asp:TextBox ID="txtComandaID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblEstadoComanda" runat="server" Text="Estado"></asp:Label>
                            <asp:DropDownList ID="cboEstadoComanda" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="w-100"></div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre del Cliente"></asp:Label>
                            <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="w-100"></div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblEstadoCuenta" runat="server" Text="Estado de Cuenta"></asp:Label>
                            <asp:TextBox ID="txtEstadoCuenta" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblMesa" runat="server" Text="Mesa Nº "></asp:Label>
                            <asp:TextBox ID="txtMesa" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <!--End-of-card-row-->

            </div>
            <!--End-of-card-body-->
        </div>
        <!--End-of-card-->
    </div>


    

</asp:Content>

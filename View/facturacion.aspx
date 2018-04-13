<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="facturacion.aspx.cs" Inherits="View.facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--AGREGAR METODO DE PAGO-->
    <div class="col-lg-6">
        <div class="card" style="margin:1%;">
            <div class="card-header">
                <div class="card-title"><h4>Método de Pago</h4></div>
            </div>
            <div class="card-body">
                <div class="card-text">
                <div class="form-group">
                    <asp:Label ID="lblSeleccionarMetodoPago" runat="server" Text="Seleccione un método de pago"></asp:Label>
                        <asp:DropDownList ID="cboMetodosPago" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="rdfMetodosPago" runat="server" ErrorMessage="Debe seleccionar un método de pago" ControlToValidate="cboMetodosPago" ValidationGroup="metodosPago"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="cmdAgregarMetodoPago" runat="server" Text="Agregar" CssClass="btn btn-dark" OnClick="cmdAgregarMetodoPago_Click" ValidationGroup="metodosPago"/>
                </div>
                </div>
            </div>
        </div>
    </div>
    <!--End of Agregar Metodo Pago-->

     <!--Detalle Pago-->
    <div class="col-lg-6" style="margin:1%">
        <div class="card">
            <div class="card-header">
                Detalle del pago
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblTotalEfectivo" runat="server" Text="Total"></asp:Label>
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
                    <asp:Label ID="lblTotalTarjeta" runat="server" Text="Total"></asp:Label>
                    <asp:TextBox ID="txtTotalTarjeta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer">
                <div class="form-group">
                    <asp:Button ID="cmdRealizarPago" runat="server" Text="Realizar Pago" CssClass="btn btn-dark" />
                </div>
            </div>
        </div>
        <!--End of card -->
    </div>
    <!--End of detalle pago section-->
</asp:Content>

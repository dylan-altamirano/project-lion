<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="administrar-comanda.aspx.cs" Inherits="View.administrar_comanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--MESSAGE SECTION-->
    <div class="col-lg-12" style="margin: 1%">
        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </div>


    <!--COMANDA HEADER INFORMATION-->
    <div class="col-lg-12" style="margin:1%">
        <div class="card">
            <div class="card-header">
                Información General de la comanda
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
                </div>
                <!--End-of-card-row-->
                <div class="form-group">
                    <asp:Button ID="cmdOrdenar" runat="server" Text="Ordenar" CssClass="btn btn-raised btn-dark" OnClick="cmdOrdenar_Click" />
                </div>

            </div>
            <!--End-of-card-body-->
        </div>
        <!--End-of-card-->
    </div>

    <!--Comanda Detalle-->
    <div class="col-lg-12" style="margin:1%">
        <div class="card">
            <div class="card-header">
                Detalle de la comanda
            </div>
            <div class="card-body">
                <asp:GridView ID="grvComandaDetalle" runat="server" AutoGenerateColumns="false" OnRowCommand="grvComandaDetalle_RowCommand" CssClass="table table-bordered table-hover">

                    <Columns>
                        <asp:BoundField DataField="producto.producto_id" HeaderText="N&#186;"></asp:BoundField>
                        <asp:BoundField DataField="producto.nombreProducto" HeaderText="Producto" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="producto.categoria.nombreCategoria" HeaderText="Categoria" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="producto.precio" HeaderText="Precio (CRC)" ReadOnly="True"></asp:BoundField>
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" HeaderText="Acción"></asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!--End of card -->
    </div>
    <!--End of comanda detalle section-->


     <!--Detalle monetario de la comanda-->
    <div class="col-lg-12" style="margin:1%">
        <div class="card">
          
            <div class="card-body" style="text-align:right">

                <!--Table-->
                <asp:Table ID="tableDetalleMonetario" runat="server" CssClass="table table-bordered">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" ColumnSpan="2">
                            <asp:Label ID="lblIVA" runat="server" Text="IVA 13%"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell ID="tdIVA" runat="server" Text="" Font-Italic="true">
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                         <asp:TableCell runat="server" ColumnSpan="2">
                            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell ID="tdSubtotal" runat="server" Text="">
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                         <asp:TableCell runat="server" ColumnSpan="2">
                            <asp:Label ID="lblTotal" runat="server" Text="Total" Font-Bold="true"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell ID="tdTotal" runat="server" Text="" Font-Bold="true">
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <!--End of table-->

                <asp:Button ID="cmdFormalizar" runat="server" Text="Formalizar Orden"  CssClass="btn btn-raised btn-dark btn-lg" OnClick="cmdFormalizar_Click"/>
                <asp:Button ID="cmdEntregar" runat="server" Text="Entregar Orden"  CssClass="btn btn-raised btn-dark btn-lg" OnClick="cmdEntregar_Click"/>
                <asp:Button ID="cmdFacturar" runat="server" Text="Facturar" CssClass="btn btn-raised btn-dark btn-lg" OnClick="cmdFacturar_Click"/>
            </div>
        </div>
        <!--End of card -->
    </div>
    <!--End of detalle monetario section-->


   

</asp:Content>

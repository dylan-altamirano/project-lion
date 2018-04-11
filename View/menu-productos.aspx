<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="menu-productos.aspx.cs" Inherits="View.menu_productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <!--MESSAGE SECTION-->
    <div class="col-lg-12" style="margin: 1%">
        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </div>



    <!--Filtrar productos-->
    <div class="col-lg-12" style="margin:1%">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Buscar Productos</h4>
                </div>
                <div class="card-body">
                    <div class="card-text">
                        <div class="form-group">
                            <asp:Label ID="lblFiltrado" runat="server" Text="Buscar"></asp:Label>
                            <asp:DropDownList ID="cboCategorias" runat="server" CssClass="dropdown form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rdfBuscarCategorias" runat="server" ErrorMessage="Seleccione una categoría" ControlToValidate="cboCategorias"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="cmdBuscarProductos" runat="server" Text="Buscar" CssClass="btn btn-raised btn-dark" OnClick="cmdBuscarProductos_Click" ValidationGroup="buscarProducto"/>
                            <asp:Button ID="cmdRegresar" runat="server" Text="Revisar Orden" CssClass="btn btn-raised btn-dark"  OnClick="cmdRegresar_Click" ValidationGroup="none"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!--End of filtro-->

    <!--Productos-->
   
         <%= sb.ToString() %>
    

    <!--CUADRO MODAL ORDENAR PRODUCTO-->
    <div class="modal fade" id="ordenarProducto">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Selección del Producto</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="col-lg-12" >
                        <div class="card">
                            <div class="card-body">
                                <div class="card-text">
                                    <div class="form-group">
                                        <asp:Label ID="lblProductoID" runat="server" Text="Producto Nº"></asp:Label>
                                        <asp:TextBox ID="txtProductoID" runat="server"  Text="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblNotas" runat="server" Text="Anotaciones del cliente"></asp:Label>
                                        <asp:TextBox ID="txaNotas" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                                        <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                        <asp:RangeValidator ID="rgvCantidad" runat="server" ErrorMessage="Debe ingresar una cantidad numérica entre 1-99" ControlToValidate="txtCantidad" MinimumValue="1" MaximumValue="99" ValidationGroup="confirmarProducto"></asp:RangeValidator>
                                    </div>
                                    <div class="form-group">
                                        <p>¿Desea agregar este producto a su orden?</p>
                                    </div>
                                     <div class="form-group">
                                        <asp:Button ID="cmdAfirmacion" runat="server" Text="Confirmar" CssClass="btn btn-raised btn-dark" OnClick="cmdAfirmacion_Click"  ValidationGroup="confirmarProducto"/>
                                        
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="gestion-productos.aspx.cs" Inherits="View.gestion_productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfRolProducto" runat="server" />
    <!--MESSAGE SECTION-->
    <div class="col-lg-12" style="margin: 1%">
        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </div>


     <div class="col-lg-6" id="ProductoMOG">
        <div class="card">
            <div class="card-body">
                 <div class="form-group">
                <asp:Label ID="lblIdentificador" runat="server" Text="Nº Producto" Enabled="false">
                    <asp:TextBox ID="txtIdentificador" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rdfIdentificador" runat="server" ErrorMessage="Debe proporcionar un identificador válido..." ControlToValidate="txtIdentificador" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre del Producto">
                    <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfNombreProducto" runat="server" ErrorMessage="Debe proporcionar un nombre válido..." ControlToValidate="txtNombreProducto" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
        
            <div class="form-group">
                <asp:Label ID="lblCategorias" runat="server" Text="Categoria">
                    <asp:DropDownList ID="cboCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqfCategorias" runat="server" ErrorMessage="Debe seleccionar al menos una categoria..." ControlToValidate="cboCategorias" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
             
            </div>
                <div class="form-group">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txaDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio">
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfPrecio" runat="server" ErrorMessage="Debe proporcionar un precio válido..." ControlToValidate="txtPrecio" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rgePrecio" runat="server" ErrorMessage="Solo valores numéricos" ValidationExpression="^\d+$" ValidationGroup="guardar" ControlToValidate="txtPrecio"></asp:RegularExpressionValidator>
                </asp:Label>
            </div>

           <div class="form-group">
                <asp:Label ID="lblActivo" runat="server" Text="Estado">
                    <asp:DropDownList ID="cboActivo" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqfActivo" runat="server" ErrorMessage="Debe seleccionar al menos una estado..." ControlToValidate="cboActivo" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
             
            </div>
            <div class="form-group">
               <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="btn btn-raised btn-dark" ValidationGroup="guardar" OnClick="cmdGuardar_Click"/>
                <asp:Button ID="cmdLimpiar" runat="server" Text="Restablecer" CssClass="btn btn-raised btn-dark" ValidationGroup="guardar" OnClick="cmdLimpiar_Click" />
            </div>
           </div> 
        </div>
    </div>

    <!--BUSQUEDA-->
    <div class="col-lg-6" id="busqueda">
        <div class="card" style="margin-bottom:2%;">
            <div class="card-body">
                <div class="card-title"><h4>Búsqueda de producto</h4></div>
                <div class="card-text">
                    <div class="form-group">
                        <asp:Label ID="lblFiltrado" runat="server" Text="Buscar"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rdfBuscarCategorias" runat="server" ErrorMessage="Seleccione una categoría" ControlToValidate="cboCategorias" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                    </div>
                <div class="form-group">
                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfBuscarTextField" runat="server" ErrorMessage="Ingrese al menos un criterio de búsqueda válido" ControlToValidate="txtBuscar" CssClass="form-control" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                    <asp:Button ID="cmdBuscar" runat="server" Text="BUSCAR" CssClass="btn btn-raised btn-dark" ValidationGroup="buscar" OnClick="cmdBuscar_Click"/>
                </div>
                </div>
            </div>
        </div>

        <!--LISTADO DE USUARIOS-->
        <div class="card">
            <div class="card-body">
                <div class="card-title" >
                    Listado de Productos
                </div> 
                <div class="card-text">
                    
               
                            <asp:GridView ID="grvProductos" runat="server"
                                AutoGenerateColumns="false"
                                CssClass="table table-bordered" OnRowCommand="grvProductos_RowCommand">
                                <Columns>
                                    
                                    <asp:BoundField DataField="producto_id" HeaderText="N&#186;"></asp:BoundField>
                                    <asp:BoundField DataField="nombreProducto" HeaderText="Producto" ReadOnly="True"></asp:BoundField>
                                    <asp:BoundField DataField="categoria.nombreCategoria" HeaderText="Categoria" ReadOnly="true"></asp:BoundField>
                                    <asp:BoundField DataField="precio" HeaderText="Precio" ReadOnly="true"></asp:BoundField>

                                    <asp:BoundField DataField="activo" HeaderText="Activo" ReadOnly="True"></asp:BoundField>
                                    <asp:ButtonField CommandName="Select" Text="Select" HeaderText="Select"></asp:ButtonField>
                                </Columns>

                    </asp:GridView>

                </div> 
            </div>
            <div class=" card-footer">
                <nav aria-label="Page navigation example">
                    <ul class="pagination">
                        <li class="page-item">
                            <asp:LinkButton ID="previousRows" runat="server" CssClass="page-link" OnClick="previousRows_Click">Previous</asp:LinkButton>
                        </li>
                        <li class="page-item">
                            <asp:LinkButton ID="nextRows" runat="server" CssClass="page-link" OnClick="nextRows_Click">Next</asp:LinkButton>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>


    </div>
</asp:Content>

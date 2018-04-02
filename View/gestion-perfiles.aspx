<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="gestion-perfiles.aspx.cs" Inherits="View.gestion_perfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-6">
        <div class="card">
            <div class="card-body">
            <div class="form-group">
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación">
                    <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rqfIdentificacion" runat="server" ErrorMessage="Debe proporcionar una identificación válida..." ControlToValidate="txtIdentificacion" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre de Usuario">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfNombre" runat="server" ErrorMessage="Debe proporcionar un nombre válido..." ControlToValidate="txtNombre" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombreCompleto" runat="server" Text="Nombre Completo">
                    <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rqfNCompleto" runat="server" ErrorMessage="Por favor, ingrese un texto válido..." ControlToValidate="txtNombreCompleto" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRol" runat="server" Text="Rol">
                    <asp:DropDownList ID="cboRoles" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqfRoles" runat="server" ErrorMessage="Debe seleccionar al menos un rol..." ControlToValidate="cboRoles" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
             
            </div>
            <div class="form-group">
                <asp:Label ID="lblClave" runat="server" Text="Clave">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rdfClave" runat="server" ErrorMessage="Por favor, proporcione una clave" ControlToValidate="txtClave" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
           
            <div class="form-group">
                <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" CssClass="btn btn-dark"  OnClick="cmdGuardar_Click" ValidationGroup="guardar"/>
            </div>
           </div> 
        </div>
    </div>

    <!--BUSQUEDA-->
    <div class="col-lg-6">
        <div class="card" style="margin-bottom:2%;">
            <div class="card-body">
                <div class="card-title"><h4>Búsqueda</h4></div>
                <div class="card-text">
                <div class="form-group">
                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar">
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rdfBuscar" runat="server" ErrorMessage="Debe ingresar un dato" ControlToValidate="DropDownList1" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfBuscarTextField" runat="server" ErrorMessage="Ingrese al menos un criterio de búsqueda válido" ControlToValidate="txtBuscar" CssClass="form-control" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                    <asp:Button ID="cmdBuscar" runat="server" Text="BUSCAR" CssClass="btn btn-dark" OnClick="cmdBuscar_Click" ValidationGroup="buscar"/>
                </div>
                </div>
            </div>
        </div>

        <!--LISTADO DE USUARIOS-->
        <div class="card">
            <div class="card-body">
                <div class="card-title" >
                    Listado de Usuarios
                </div> 
                <div class="card-text">
                    
               
                            <asp:GridView ID="grvUsuarios" runat="server"
                                AutoGenerateColumns="false"
                                CssClass="table table-bordered" OnRowCommand="grvUsuarios_RowCommand">
                                <Columns>

                                    <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" ReadOnly="True"></asp:BoundField>
                                    <asp:BoundField DataField="rolUsuario" HeaderText="Rol" ReadOnly="True"></asp:BoundField>

                                    <asp:BoundField DataField="activo" HeaderText="Activo" ReadOnly="true"></asp:BoundField>

                                    <asp:ButtonField CommandName="Select" Text="Select" HeaderText="Select"></asp:ButtonField>
                                </Columns>

                    </asp:GridView>

                </div> 
            </div>
        </div>


    </div>


    

</asp:Content>

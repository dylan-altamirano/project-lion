<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="gestion-perfiles.aspx.cs" Inherits="View.gestion_perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-lg-6">
        <div class="card">
            <div class="card-body">
            <div class="form-group">
                <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación">
                    <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rqfIdentificacion" runat="server" ErrorMessage="Debe proporcionar una identificación válida..." ControlToValidate="txtIdentificacion"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre de Usuario">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqfNombre" runat="server" ErrorMessage="Debe proporcionar un nombre válido..." ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombreCompleto" runat="server" Text="Fecha">
                    <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="rqfFecha" runat="server" ErrorMessage="Por favor, escoga una fecha válida..." ControlToValidate="txtNombreCompleto"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRol" runat="server" Text="Rol">
                    <asp:DropDownList ID="cboRoles" runat="server" OnSelectedIndexChanged="cboRoles_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqfRoles" runat="server" ErrorMessage="Debe seleccionar al menos un rol..." ControlToValidate="cboRoles"></asp:RequiredFieldValidator>
                </asp:Label>
             
            </div>
            <div class="form-group">
                <asp:Label ID="lblClave" runat="server" Text="Clave">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rdfClave" runat="server" ErrorMessage="Por favor, proporcione una clave" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                </asp:Label>
            </div>
           
            <div class="form-group">
                <asp:Button ID="cmdRegistrarUsuario" runat="server" Text="Guardar" cssClass="btn btn-primary" OnClick="cmdRegistrarUsuario_Click"/>
            </div>
           </div> 
        </div>
    </div>

    <!--LISTADO DE USUARIOS-->
    <div class="col-lg-6">
        <div class="card">
            <div class="card-body">
                <div class="card-title" >
                    Listado de Usuarios
                </div> 
                <div class="card-text">
                    
                        <%--<asp:GridView ID="grvUsuarios1" runat="server"
                            DataKeyNames="usuario_id"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="true"
                            <%--OnRowCancelingEdit="grvAlquilerVillas_RowCancelingEdit"
                            OnRowEditing="grvAlquilerVillas_RowEditing"
                            OnRowDataBound="grvAlquilerVillas_RowDataBound"
                            OnRowUpdating="grvAlquilerVillas_RowUpdating">

                            <Columns>
                          
                                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="rol" HeaderText="Rol" ReadOnly="True"></asp:BoundField>
                              
                                
                            

                                <asp:BoundField DataField="activo" HeaderText="Activo" ReadOnly="true"></asp:BoundField>
                            </Columns>

                        </asp:GridView>--%>

                    <asp:GridView ID="grvUsuarios" runat="server" 
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="true" CssClass="table table-bordered">
                        <Columns>
                          
                                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="rolUsuario" HeaderText="Rol" ReadOnly="True"></asp:BoundField>
                              
                                <asp:BoundField DataField="activo" HeaderText="Activo" ReadOnly="true"></asp:BoundField>
                        </Columns>

                    </asp:GridView>
                    
                </div> 
            </div>
        </div>
    </div>
</asp:Content>

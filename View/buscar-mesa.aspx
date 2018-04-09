<%@ Page Title="" Language="C#" MasterPageFile="~/Mesa.master" AutoEventWireup="true" CodeBehind="buscar-mesa.aspx.cs" Inherits="View.buscar_mesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMesaDashboard" runat="server">
    <!--MESSAGE SECTION-->
    
        <div class="col-lg-12" style="margin:1%">
            <div class="form-group">
                <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
            </div>
        </div>
    

    <!--BUSCAR MESA SECTION-->
  
        <div class="col-lg-12" style="margin:1%">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Buscar Mesa</h4>
                </div>
                <div class="card-body">
                    <div class="card-text">
                        <div class="form-group">
                            <asp:Label ID="lblFiltrado" runat="server" Text="Buscar"></asp:Label>
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdfBuscar" runat="server" ErrorMessage="Por favor, provea un dato válido..." ControlToValidate="txtBuscar" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="cmdBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" OnClick="cmdBuscar_Click" ValidationGroup="buscar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    

    <!--MODIFICAR MESA SECTION-->
    <div class="col-lg-12" style="margin:1%">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Modificar Mesa</h4>
            </div>
            <div class="card-body">
                <div class="card-text">
                    <div class="form-group">
                        <asp:Label ID="lblMesaId" runat="server" Text="Nº Mesa"></asp:Label>
                        <asp:TextBox ID="txtIdentificacionMesa" runat="server" ReadOnly="true" Font-Bold="true" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblFiltroEstado" runat="server" Text="Ocupado"></asp:Label>
                        <asp:RadioButtonList ID="rblOcupado" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rdfOcupado" runat="server" ErrorMessage="Por favor, ingrese un valor" ValidationGroup="modificar" ControlToValidate="rblOcupado"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblActivo" runat="server" Text="Activo"></asp:Label>
                        <asp:RadioButtonList ID="rblActivo" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rdfActivo" runat="server" ErrorMessage="Por favor, ingrese un valor" ValidationGroup="modificar" ControlToValidate="rblActivo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="cmdGuardarMesa" runat="server" Text="Guardar" CssClass="btn btn-dark" OnClick="cmdGuardarMesa_Click" ValidationGroup="modificar"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--END-OF-MODIFICAR SECTION-->

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Mesa.master" AutoEventWireup="true" CodeBehind="crear-mesa.aspx.cs" Inherits="View.crear_mesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMesaDashboard" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <h4 class=" card-title">Crear Mesa</h4>
            </div>
            <div class="card-body">
                <div class="card-text">
                    <div class="form-group">
                        <asp:Label ID="lblOcupado" runat="server" Text="Ocupado"></asp:Label>
                        <asp:RadioButtonList ID="rblOcupado" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblActivo" runat="server" Text="Activo"></asp:Label>
                        <asp:RadioButtonList ID="rblActivo" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="cmdGuardarMesa" runat="server" Text="Guardar" CssClass="btn btn-dark" OnClick="cmdGuardarMesa_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="gestion-reportes.aspx.cs" Inherits="View.gestion_reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Reporte Ventas</strong></p>
                <div class="card-text">
                    <%--<button type="button" class="btn btn-raised" onclick="document.location.href='gestion-perfiles.aspx'"><i class="fas fa-users" style="font-size:150px"></i></button>--%>
                    <asp:LinkButton ID="cmdlReporteVentas" runat="server" CssClass="btn btn-raised" OnClick="cmdlReporteVentas_Click"><i class="fas fa-chart-line" style="font-size:150px"></i></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
     <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Reporte por Método de Pago</strong></p>
                <div class="card-text">
                    <asp:LinkButton ID="cmdlReporteMetodoPago" runat="server" CssClass="btn btn-raised" OnClick="cmdlReporteMetodoPago_Click"><i class="fas fa-credit-card" style="font-size:150px"></i></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Reporte de Comandas</strong></p>
                <div class="card-text">
                    <asp:LinkButton ID="cmdlReporteFiltrado" runat="server" CssClass="btn btn-raised" OnClick="cmdlReporteFiltrado_Click"><i class="fas fa-filter" style="font-size:150px"></i></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

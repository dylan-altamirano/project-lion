<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporteVentas.aspx.cs" Inherits="View.reporteVentas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class=" col-lg-12">
        <div class="form-group">
            <asp:Label ID="lblFechaIni" runat="server" Text="Fecha Inicial"></asp:Label>
            <asp:Calendar ID="calFechaIni" runat="server" CssClass="form-control" Font-Size="XX-Small" BorderStyle="Solid"></asp:Calendar>

            <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final"></asp:Label>
            <asp:Calendar ID="calFechaFin" runat="server" CssClass="form-control" Font-Size="XX-Small"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEstadoCuenta" runat="server" Text="Estado Cuenta"></asp:Label>
            <asp:DropDownList ID="cboEstadoCuenta" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="cmdFiltrarReporte" runat="server" Text="Filtrar" CssClass="btn btn-raised btn-dark" OnClick="cmdFiltrarReporte_Click"/>
        </div>
    </div>

    <!--REPORT VIEWER-->
    <div class="col-lg-12">

        <div class="card">
            <div class="card-header"></div>
            <div class="card-body">
                <div class="card-text">
                    <rsweb:ReportViewer ID="ReportViewerVentas" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="reporteVentasPorFecha.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource Name="DataSet1" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="Vista.DataSetVentasTableAdapters.sp_obtener_ventasTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporteFactura.aspx.cs" Inherits="View.Reportes.reporteFactura" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--REPORT VIEWER-->
    <div class="col-lg-12">

        <div class="card">
            <div class="card-header"><strong>Detalle de la Factura</strong></div>
            <div class="card-body">
                <div class="card-text">
                    <rsweb:ReportViewer ID="reportViewerFactura" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="factura.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource Name="DataSet1" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="Vista.DataSetFacturaTableAdapters.sp_seleccionar_comanda_detalleTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
                </div>
            </div>
            <div class="card-footer">
                <asp:Button ID="cmdCerrar" runat="server" Text="Finalizar" CssClass="btn btn-raised btn-dark" OnClick="cmdCerrar_Click"/>
            </div>
        </div>
    </div>
    <!--End of report viewer-->


</asp:Content>

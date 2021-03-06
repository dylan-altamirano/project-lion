﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporteVentasMetodoPago.aspx.cs" Inherits="View.reporteVentasMetodoPago" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--CONTROLES DE FILTRO-->
    <div class=" col-lg-12" style="margin-bottom:5px;">

        <div class="card">
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblFechaIni" runat="server" Text="Fecha Inicial"></asp:Label>
                    <asp:TextBox ID="txtFechaIni" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calExtFechaIni" runat="server" TargetControlID="txtFechaIni" Format="yyyy-MM-dd" PopupButtonID="imgPopup" />
                    <asp:RequiredFieldValidator ID="rqvFechaIni" runat="server" ErrorMessage="Debe ingresar una fecha de inicio" ControlToValidate="txtFechaIni" ValidationGroup="filtroReporte"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calExtFechaFin" runat="server" TargetControlID="txtFechaFin" Format="yyyy-MM-dd" PopupButtonID="imgPopup" />
                    <asp:RequiredFieldValidator ID="rdvFechaFin" runat="server" ErrorMessage="Debe ingresar una fecha final" ControlToValidate="txtFechaFin" ValidationGroup="filtroReporte"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMetodoPago" runat="server" Text="Metodo Pago"></asp:Label>
                    <asp:DropDownList ID="cboMetodosPago" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button ID="cmdFiltrarReporte" runat="server" Text="Filtrar" CssClass="btn btn-raised btn-dark" OnClick="cmdFiltrarReporte_Click" />
                </div>
            </div>
        </div> 
        <!--End of card-->

    </div>
    <!--End of filtro-->

     <!--REPORT VIEWER-->
    <div class="col-lg-12">

        <div class="card">
            <div class="card-header"></div>
            <div class="card-body">
                <div class="card-text">
                    <rsweb:ReportViewer ID="reportViewerMetodoPago" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="reporteMetodoPago.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource Name="DataSet1" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>

                    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="Vista.DataSetMetodoPagoTableAdapters.sp_obtener_reporte_metodo_pagoTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
    <!--End of report viewer-->

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Vista.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Gestion de Perfiles</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-users" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
     <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Gestion de Mesas</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-utensils" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Comandas</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-shopping-cart" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Productos</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-shopping-basket" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
    
    <div class="col-md-6" style="margin-top:1%;">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Facturación</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-money-bill-alt" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-6" style="margin-top:1%;">
        <div class="card">
            <div class="card-body">
                <p class="card-title"><strong>Reportes</strong></p>
                <div class="card-text">
                    <button type="button" class="btn btn-light"><i class="fas fa-file-alt" style="font-size:150px"></i></button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

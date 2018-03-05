<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ingreso.aspx.cs" Inherits="View.ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge;  charset=windows-1252" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Web Development II - Final Project" />
    <meta name="author" content="Dilan Altamirano" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
    <link type="text/css" rel="stylesheet" href="css/font-awesome.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <link type="text/css" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container" style="margin-top: 2%; padding-top: 1%;">
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="card-title">
                                <h3>Ingreso al sistema</h3>
                            </div>
                            <div class="card-text">

                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsuario" runat="server" ErrorMessage="Ingrese un usuario válido" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Ingrese una contraseña válida" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="cmdIngresar" runat="server" Text="INGRESAR" CssClass="btn btn-primary" />
                                    </div>
                                </fieldset>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                <div class="jumbotron jumbotron-fluid">
                    <div class="container">
                        <h1 class="display-4">Sistema Restaurante</h1>
                        <p class="lead">Maneja fácil y sencillo el flujo de trabajo de tu servicio de comidas</p>
                    </div>
                </div>
            </div>
            </div>
            <hr />
            <!--FOOTER-->
            <footer>
                <div class="row">
                    <div class="col-lg-12">
                        <p>Copyright &copy; Dilan Altamirano 2018</p>
                    </div>
                </div>
            </footer>
        </div>

    </form>

    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/popper.min.js"></script>

    <script>

        $('#txtUsuario').attr("placeholder", "Nombre de Usuario");
        $('#txtPassword').attr("placeholder", "Clave");
    </script>

</body>
</html>

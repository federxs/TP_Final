<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="prueba" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/bootstrap.js"></script>
        <!-- FIN BS-->

        <div class="container">
            <br />
            <br />
            <h3><a href="ClientesWF.aspx">Ir al ABMC de Clientes</a>
            </h3>
            <h3><a href="#">Ir al ABMC de Productos</a>
            </h3>
        </div>

    </body>
    </html>
</asp:Content>

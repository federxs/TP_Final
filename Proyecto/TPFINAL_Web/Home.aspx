<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="prueba" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <div class="container">
            <br />
            <br />
            <br />
            <asp:Label ID="txtBienvenida" Text="Bienvenido !" runat="server" CssClass="label label-success" />
            <h3><a href="ABMClientesWF.aspx">Ir al ABMC de Clientes</a>
            </h3>
            <h3><a href="ABMProducto.aspx">Ir al ABMC de Productos</a>
            </h3>
        </div>

    </body>
    </html>
</asp:Content>

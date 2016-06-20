<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="prueba" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <div class="container">
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="txtBienvenida" Text="Bienvenido !" Font-Size="Larger" runat="server" CssClass="label label-success" />
            <br />
            <p>A continuación será redirigido...</p>
        </div>

    </body>
    </html>
</asp:Content>

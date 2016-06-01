<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="LoginWF.aspx.cs" Inherits="LoginWF" %>

<asp:Content ID="contentLogin" runat="server" ContentPlaceHolderID="ContentPlaceHolderMaster">
    <br />
    <br />
    <br />
    <div class="col-lg-3 col-md-3"></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
        <form runat="server" method="post">
            <div class="form-group">
                <asp:ValidationSummary runat="server" ValidationGroup="A" />
            </div>
            <div class="form-group">
                <label>Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" />
                <asp:RequiredFieldValidator ID="rfvUsuario" ErrorMessage="El campo usuario no puede estar vacío" Text="*" ControlToValidate="txtUsuario" runat="server" ValidationGroup="A" />
            </div>
            <div class="form-group">
                <label for="txtClave">Clave</label>
                <asp:TextBox ID="txtClave" TextMode="Password" runat="server" ToolTip="La clave debe tener entre 4 y 8 caracteres de largo, y contener al menos un número" />
                <asp:RequiredFieldValidator ID="rfvClave" ErrorMessage="El campo clave no puede estar vacío" Display="Dynamic" Text="*" ControlToValidate="txtClave" runat="server" ValidationGroup="A" />
                <%--<asp:RegularExpressionValidator ErrorMessage="La clave no cumple los requisitos de seguridad" Text="*" ControlToValidate="txtClave" runat="server" ValidationExpression="^(?=.*\d).{4,8}$" ValidationGroup="A" />--%>
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="Server" Text="Iniciar sesión" OnClick="btnLogin_Click" ValidationGroup="A" />
            </div>
        </form>
    </div>
    <div class="col-lg-3 col-md-3"></div>
</asp:Content>

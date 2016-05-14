<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="Inicio_WF.aspx.cs" Inherits="Inicio_WF" %>
<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.js"></script>

    <!--INICIO PAGINA-->
    <form class="form form-inline form-multiline" id="frm_inicio" role="form" runat="server" method="post">
        <h3>Clientes</h3>
        <p style="color: gray">
            Los marcados con (*) son obligatorios
        </p>

        <div class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">

            <div class="form-group">
                <asp:Label ID="lbl_apellido" runat="server" Text="Apellido: ">
                    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_nombre" runat="server" Text="Nombre: ">
                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:Label>
            </div>
            <br />
            <div class="form-group" runat="server" id="fieldRazon">
                <asp:Label ID="lbl_razonSocial" runat="server" Text="Razon Social: ">
                    <asp:TextBox ID="txt_razonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Tipo Doc: *">
                    <asp:DropDownList CssClass="form-control" ID="ddl_tipoDoc" runat="server" AutoPostBack="false"></asp:DropDownList>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Núm Doc: *">
                    <asp:TextBox ID="txt_doc" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:Label>
                <asp:RequiredFieldValidator runat="server" ID="reqFieldDoc" ControlToValidate="txt_doc" Text="*" ErrorMessage="El número de documento no puede estar vacío" InitialValue="" Display="Dynamic" />
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_direccion" runat="server" Text="Direccion: *">
                    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" />
                </asp:Label>
                <asp:RequiredFieldValidator runat="server" ID="reqFieldDirec" ControlToValidate="txt_direccion" Text="*" ErrorMessage="La direccion no puede estar vacía" InitialValue="" Display="Dynamic" />
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_email" runat="server" Text="Email: *">
                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox>
                </asp:Label>
                <asp:RequiredFieldValidator runat="server" ID="reqFieldEmail" ControlToValidate="txt_email" Text="*" ErrorMessage="El email no puede estar vacío" InitialValue="" Display="Dynamic" />
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_cuit" runat="server" Text="Cuit: *">
                    <asp:TextBox ID="txt_cuit" runat="server" CssClass="form-control" />
                </asp:Label>
                <asp:RequiredFieldValidator runat="server" ID="reqFieldCuit" ControlToValidate="txt_cuit" Text="*" ErrorMessage="El cuit no puede estar vacío" InitialValue="" Display="Dynamic" />
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_telefono" runat="server" Text="Telefono: *">
                    <asp:TextBox ID="txt_numeroTel" runat="server" CssClass="form-control" />
                </asp:Label><br />
                <label style="color: gray; font-weight: 100">Código de área + Nº. Ej.: 11 43234556</label>
                <asp:RequiredFieldValidator runat="server" ID="reqFieldNumero" ControlToValidate="txt_numeroTel" Text="*" ErrorMessage="El número de telefono no puede estar vacío" InitialValue="" Display="Static" />
            </div>
            <br />
                <asp:Label ID="lbl_sexo" runat="server" Text="Sexo: *"></asp:Label>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_sexoMasc" runat="server" Text="Masculino">
                    <asp:RadioButton CssClass="radio" ID="rbt_sexoMasc" GroupName="sexo" Checked="true" runat="server" />
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl_sexoFem" runat="server" Text="Femenino">
                    <asp:RadioButton CssClass="radio" ID="rbt_sexoFem" GroupName="sexo" runat="server" />
                </asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_provincia" runat="server" Text="Provincia: *">
                    <asp:DropDownList CssClass="form-control" ID="ddl_provincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_provincia_SelectedIndexChanged"></asp:DropDownList>
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl_localidad" runat="server" Text="Localidad: *">
                    <asp:DropDownList CssClass="form-control" ID="ddl_localidad" runat="server" AutoPostBack="true"></asp:DropDownList></asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lbl_saldo" runat="server" Text="Saldo: *">
                    <asp:TextBox CssClass="form-control" ID="txt_saldo" runat="server"></asp:TextBox>
                </asp:Label>
            </div>
            <br />
            <div class="form-group">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" />
            </div>
            <br />
            <br />
            <asp:ValidationSummary runat="server" ID="valSummary" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" />
            <asp:Panel ID="pnl_mensajes" runat="server">
                <asp:Label ID="lbl_mensajes" runat="server"></asp:Label>
            </asp:Panel>


        </div>
        <div id="div_grillaClientes" runat="server" class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <asp:DataGrid ID="dg_grillaClientes" AutoGenerateColumns="False" runat="server" DataKeyField="idCliente"
                OnSelectedIndexChanged="dg_grillaClientes_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Seleccionar" Text="Seleccionar"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="Apellido" HeaderText="Apellido">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Nombre" HeaderText="Nombre">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Saldo" HeaderText="Saldo">
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:HyperLinkColumn HeaderText="Detalles" Text="Detalles..." Target="_blank"></asp:HyperLinkColumn>
                </Columns>
                <EditItemStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:DataGrid>
        </div>

    </form>
</body>
</html>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio_WF.aspx.cs" Inherits="Inicio_WF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>ABMC Clientes</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.js"></script>

    <form id="frm_inicio" runat="server" method="post">
        <div class="col-lg-1 col-xs-1">
        </div>
        <div class="col-lg-5 col-xs-5">
            <h2>Registrar Cliente</h2>
            <h3>Ingrese los siguientes datos</h3>
            <p>
                <asp:Label ID="lbl_apellido" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txt_apellido" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_razonSocial" runat="server" Text="Razon Social"></asp:Label>
                <asp:TextBox ID="txt_razonSocial" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_tipoDoc" runat="server" Text="Tipo Doc"></asp:Label>
                <asp:DropDownList ID="ddl_tipoDoc" runat="server" CssClass="dropdown"></asp:DropDownList>
                <asp:Label ID="lbl_doc" runat="server" Text="Doc"></asp:Label>
                <asp:TextBox ID="txt_doc" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_direccion" runat="server" Text="Direccion"></asp:Label>
                <asp:TextBox ID="txt_direccion" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_cuit" runat="server" Text="Cuit"></asp:Label>
                <asp:TextBox ID="txt_cuit" runat="server" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Telefono"></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text="Caracteristica"></asp:Label>
                <asp:TextBox ID="txt_caracteristicaTel" runat="server" CssClass="" />
                <asp:Label ID="Label3" runat="server" Text="Numero"></asp:Label>
                <asp:TextBox ID="txt_numeroTel" runat="server" />
            </p>
            <p>
                <asp:Label ID="lbl_sexo" runat="server" Text="Sexo"></asp:Label><br />
                <asp:Label ID="lbl_sexoMasc" runat="server" Text="Masculino"></asp:Label>
                <asp:RadioButton ID="rbt_sexoMasc" GroupName="sexo" Checked="true" runat="server"></asp:RadioButton>
                <asp:Label ID="lbl_sexoFem" runat="server" Text="Femenino"></asp:Label>
                <asp:RadioButton ID="rbt_sexoFem" GroupName="sexo" runat="server"></asp:RadioButton>
            </p>
            <p>
                <asp:Label ID="lbl_provincia" runat="server" Text="Provincia"></asp:Label>
                <asp:DropDownList ID="ddl_provincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_provincia_SelectedIndexChanged" CssClass="dropdown"></asp:DropDownList>
                <asp:Label ID="lbl_localidad" runat="server" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="ddl_localidad" runat="server" AutoPostBack="true" CssClass="dropdown"></asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lbl_saldo" runat="server" Text="Saldo"></asp:Label>
                <asp:TextBox ID="txt_saldo" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" />
            </p>
            <div id="div_grillaClientes" runat="server">
                <asp:DataGrid ID="dg_grillaClientes" AutoGenerateColumns="False" runat="server" DataKeyField="idCliente"
                    OnSelectedIndexChanged="dg_grillaClientes_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Seleccionar" Text="Seleccionar"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="Apellido" HeaderText="Apellido" HeaderStyle-Width="100px">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" HeaderStyle-Width="100px">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Saldo" HeaderText="Saldo" HeaderStyle-Width="100px">
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
            <br />
            <br />
            <asp:Panel ID="pnl_mensajes" runat="server">
                <asp:Label ID="lbl_mensajes" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </form>

</body>
</html>

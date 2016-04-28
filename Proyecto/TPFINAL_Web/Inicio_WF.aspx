<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio_WF.aspx.cs" Inherits="Inicio_WF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Inicio Proyecto Final</title>

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
                <asp:DropDownList ID="cmb_tipoDoc" runat="server" AutoPostBack="true" CssClass="dropdown"></asp:DropDownList>
                <asp:Label ID="lbl_doc" runat="server" Text="Doc"></asp:Label>
                <asp:TextBox ID="txt_doc" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_fechaNac" runat="server" Text="Fecha Nac"></asp:Label>
                <asp:TextBox ID="txt_fechaNac" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbl_regular" runat="server" Text="Regular"></asp:Label>
                <asp:CheckBox ID="chk_regular" runat="server" />
            </p>
            <p>
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar en Clase" />
            </p>
            <p>
                <asp:ListBox ID="lb_datos" runat="server"></asp:ListBox>
                <br />
            </p>
            <asp:Label ID="lbl_mensajes" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

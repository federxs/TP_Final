﻿<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="ClientesWF.aspx.cs" Inherits="Inicio_WF" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
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
                <br />
                <asp:ValidationSummary runat="server" ID="valSummary" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="A" />

                <div class="form-group">
                    <label for="txt_apellido" runat="server">Apellido:</label>
                    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <!--<asp:Label ID="lbl_nombre" runat="server" Text="Nombre: "></asp:Label>-->
                    <label for="txt_nombre">Nombre:</label>
                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txt_razonSocial">Razon Social:</label>
                    <asp:TextBox ID="txt_razonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddl_tipoDoc">Tipo Doc: *</label>
                    <asp:DropDownList CssClass="form-control" ID="ddl_tipoDoc" runat="server" AutoPostBack="false"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txt_doc">Num. de Doc: *</label>
                    <asp:TextBox ID="txt_doc" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldDoc" ControlToValidate="txt_doc" Text="*" ErrorMessage="Debe completar el campo número de documento" InitialValue="" Display="Dynamic" ValidationGroup="A" />
                    <asp:RangeValidator ID="rvDoc" ErrorMessage="El número de documento ingresado no es válido" ControlToValidate="txt_doc" runat="server" Text="*" ValidationGroup="A" MinimumValue="0" MaximumValue="50000000" Type="Integer" />
                </div>
                <div class="form-group">
                    <label for="txt_direccion">Domicilio: *</label>
                    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldDirec" ControlToValidate="txt_direccion" Text="*" ErrorMessage="Debe completar el campo domicilio " InitialValue="" Display="Dynamic" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_email">Email: *</label>
                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="reqFieldEmail" ControlToValidate="txt_email" Text="*" ErrorMessage="El email no puede estar vacío" InitialValue="" Display="Dynamic" ValidationGroup="A" />
                    <asp:RegularExpressionValidator ID="regExEmail" ErrorMessage="El email ingresado no es válido" ControlToValidate="txt_email" runat="server" Text="*" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </div>
                <div class="form-group">
                    <label for="txt_cuit">CUIT: *</label>
                    <asp:TextBox ID="txt_cuit" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldCuit" ControlToValidate="txt_cuit" Text="*" ErrorMessage="El cuit no puede estar vacío" InitialValue="" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_numeroTel">Teléfono: *</label>
                    <asp:TextBox ID="txt_numeroTel" runat="server" CssClass="form-control" />
                    <br />
                    <label style="color: gray; font-weight: 100">Código de área + Nº. Ej.: 11 43234556</label>
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldNumero" ControlToValidate="txt_numeroTel" Text="*" ErrorMessage="El número de telefono no puede estar vacío" InitialValue="" Display="Static" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label>Sexo: *</label>
                    <br />
                    <asp:RadioButton CssClass="radio" ID="rbt_sexoMasc" GroupName="sexo" Checked="true" runat="server" Text="Masculino" />
                    <asp:RadioButton CssClass="radio" ID="rbt_sexoFem" GroupName="sexo" runat="server" Text="Femenino" />
                </div>
                <div class="form-group">
                </div>
                <div class="form-group">
                    <label for="ddl_provincia">Provincia: *</label>
                    <asp:DropDownList CssClass="form-control" ID="ddl_provincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_provincia_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddl_localidad">Localidad: *</label>
                    <asp:DropDownList CssClass="form-control" ID="ddl_localidad" runat="server" AutoPostBack="true" />
                </div>
                <div class="form-group">
                    <label for="txt_saldo">Saldo: *</label>
                    <asp:TextBox CssClass="form-control" ID="txt_saldo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfSaldo" ErrorMessage="Debe completar el campo saldo" ControlToValidate="txt_saldo" runat="server" ValidationGroup="A" />
                    <asp:CompareValidator ID="cvSaldo" ErrorMessage="El saldo ingresado no es válido" ControlToValidate="txt_saldo" runat="server" ValidationGroup="A" ValueToCompare="0" Type="Currency" Operator="GreaterThanEqual" />
                </div>
                <!--Fin Campos-->
                <!--Botones-->
                <br />
                <div class="form-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" />
                </div>
                <!--Fin Botones-->
                <br />
                <br />
                <asp:Panel ID="pnl_mensajes" runat="server">
                    <asp:Label ID="lbl_mensajes" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <!-- Grilla Clientes -->
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
            <!-- Fin Grilla Clientes -->
        </form>
    </body>
    </html>
</asp:Content>

<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="ABMClientesWF.aspx.cs" Inherits="Inicio_WF" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <!--INICIO FORMULARIO CLIENTES-->
        <form class="form form-inline form-multiline" id="frm_inicio" role="form" runat="server" method="post">
            <h3>Clientes</h3>
            <p style="color: gray">
                Los marcados con (*) son obligatorios
            </p>
            <!--Mensajes-->
            <div>
                <asp:Label CssClass="label" ID="lblMensajes" Text="" runat="server" Font-Size="Large" />
            </div>
            <!--Fin Mensajes-->
            <div class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <br />
                <div class="container col-lg-9 col-md-9 col-sm-9 col-xs-12" style="background-color: lightsalmon">
                    <asp:ValidationSummary runat="server" ID="valSummary" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="A" ShowMessageBox="False" />
                </div>
                <div class="form-group">
                    <label for="txt_apellido" runat="server">Apellido: *</label>
                    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" PlaceHolder="Apellido" MaxLength="35"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un apellido" Text="*" ValidationGroup="A" ID="rfvApellido" ControlToValidate="txt_apellido" runat="server" />
                </div>
                <div class="form-group">
                    <label for="txt_nombre">Nombre:</label>
                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" PlaceHolder="Nombre: *" MaxLength="35"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un nombre" Text="*" ValidationGroup="A" ID="rfvNombre" ControlToValidate="txt_nombre" runat="server" />
                </div>
                <div class="form-group">
                    <label for="ddl_tipoDoc">Tipo Doc: *</label>
                    <asp:DropDownList CssClass="form-control" ID="ddl_tipoDoc" runat="server" AutoPostBack="false"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoDoc" ErrorMessage="Debe seleccionar un tipo de documento" Text="*" ControlToValidate="ddl_tipoDoc" InitialValue="" runat="server" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_doc">Num. de Doc: *</label>
                    <asp:TextBox ID="txt_doc" runat="server" CssClass="form-control" PlaceHolder="N° de Doc"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldDoc" ControlToValidate="txt_doc" Text="*" ErrorMessage="El número de documento no puede estar vacío" InitialValue="" Display="Dynamic" ValidationGroup="A" />
                    <asp:RangeValidator ID="rvDoc" ErrorMessage="El número de documento ingresado no es válido" ControlToValidate="txt_doc" runat="server" Text="*" ValidationGroup="A" MinimumValue="0" MaximumValue="99999999" Type="Integer" />
                </div>
                <div class="form-group">
                    <label for="txt_direccion">Domicilio: *</label>
                    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" PlaceHolder="Domicilio" MaxLength="35" />
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldDirec" ControlToValidate="txt_direccion" Text="*" ErrorMessage="El domicilio no puede estar vacío" InitialValue="" Display="Dynamic" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_email">Email: *</label>
                    <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" PlaceHolder="Email" MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="reqFieldEmail" ControlToValidate="txt_email" Text="*" ErrorMessage="El email no puede estar vacío" InitialValue="" Display="Dynamic" ValidationGroup="A" />
                    <asp:RegularExpressionValidator ID="regExEmail" ErrorMessage="El email ingresado no es válido" ControlToValidate="txt_email" runat="server" Text="*" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </div>
                <div class="form-group">
                    <label for="txt_cuit">CUIT: *</label>
                    <asp:TextBox ID="txt_cuit" runat="server" CssClass="form-control" PlaceHolder="CUIT" MaxLength="15" />
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldCuit" ControlToValidate="txt_cuit" Text="*" ErrorMessage="El cuit no puede estar vacío" InitialValue="" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_numeroTel">Teléfono: *</label>
                    <asp:TextBox ID="txt_numeroTel" runat="server" CssClass="form-control" PlaceHolder="N° de TE" />
                    <br />
                    <label style="color: gray; font-weight: 100">Código de área + Nº. Ej.: 11 43234556</label>
                    <asp:RequiredFieldValidator runat="server" ID="reqFieldNumero" ControlToValidate="txt_numeroTel" Text="*" ErrorMessage="El número de telefono no puede estar vacío" InitialValue="" ValidationGroup="A" />
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
                    <asp:RequiredFieldValidator ID="rfvProvincia" ErrorMessage="Debe seleccionar una provincia" Text="*" ControlToValidate="ddl_provincia" InitialValue="" runat="server" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="ddl_localidad">Localidad: *</label>
                    <asp:DropDownList CssClass="form-control" ID="ddl_localidad" runat="server" AutoPostBack="true" />
                    <asp:RequiredFieldValidator ID="rfvLocalidad" ErrorMessage="Debe seleccionar una localidad" Text="*" ControlToValidate="ddl_localidad" InitialValue="" runat="server" ValidationGroup="A" />
                </div>
                <div class="form-group">
                    <label for="txt_saldo">Saldo: *</label>
                    <asp:TextBox CssClass="form-control" ID="txt_saldo" runat="server" PlaceHolder="Saldo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfSaldo" ErrorMessage="El saldo no puede estar vacío" Text="*" ControlToValidate="txt_saldo" runat="server" ValidationGroup="A" />
                    <asp:CompareValidator ID="cvSaldo" ErrorMessage="El saldo ingresado no es válido" Text="*" ControlToValidate="txt_saldo" runat="server" ValidationGroup="A" ValueToCompare="0" Type="Currency" Operator="GreaterThanEqual" />
                </div>
                <!--Fin Campos-->

                <!--Botones-->
                <br />
                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btn_guardar_Click" ValidationGroup="A" />

                    <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="btn_modificar_Click" ValidationGroup="A" />

                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo" CssClass="btn btn-success" OnClick="btn_nuevo_Click" ValidationGroup="B" />

                    <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btn_eliminar_Click" ValidationGroup="A" />
                </div>
                <!--Fin Botones-->
                <br />

                <br />
                <br />
            </div>
            <!-- Grilla Clientes -->
            <div id="div_grillaClientes" runat="server" class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <!--Buscador-->
                <div class="form-group">
                    <h5>Buscar por apellido:</h5>
                    <label for="txtBuscar" runat="server">Apellido</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar" PlaceHolder="Apellido" />
                    <asp:Button CssClass="btn btn-success" Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
                <!--Fin Buscador-->
                <div class="form-group">
                    <asp:GridView ID="gv_grillaClientes" AutoGenerateColumns="False" OnSelectedIndexChanged="dg_grillaClientes_SelectedIndexChanged" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" EmptyDataText='"No se encontraron resultados"' AllowPaging="True" PageSize="15" OnPageIndexChanging="gv_grillaClientes_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Saldo" HeaderText="Saldo" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                    <i>Estas viendo la pagina
                    <%=gv_grillaClientes.PageIndex + 1%>
                    de
                    <%=gv_grillaClientes.PageCount%>
                    </i>
                </div>

            </div>
            <!-- Fin Grilla Clientes -->
        </form>
    </body>
    </html>
</asp:Content>

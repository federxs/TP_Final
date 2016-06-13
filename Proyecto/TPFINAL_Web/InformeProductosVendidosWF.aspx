<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="InformeProductosVendidosWF.aspx.cs" Inherits="InformeProductosVendidos" %>
<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <form id="form1" runat="server">
            <div>
                 <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lbl_InformePVendidos" runat="server" Text="Informe Productos Vendidos" ForeColor="Black"></asp:Label>
                 <br />
                 <br />
                <br />
                 <asp:Label ID="lbl_SeleccionFiltros" runat="server" Text="Seleccione los Filtros a aplicar:"></asp:Label>
                 <br />
                 <br />
                 <asp:CheckBox ID="chk_Fnombre" runat="server" AutoPostBack="True" OnCheckedChanged="chk_Fnombre_CheckedChanged" Text="Filtrar Por Nombre:" />
&nbsp;<asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rvf_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ErrorMessage="Ingrese un nombre." ValidationGroup="A">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;
                 <asp:CheckBox ID="chk_FtipoProduto" runat="server" AutoPostBack="True" OnCheckedChanged="chk_FtipoProduto_CheckedChanged" Text="Filtrar Por Tipo Producto:" />
                 <asp:DropDownList ID="cmb_TipoProducto" runat="server">
                 </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:CheckBox ID="chk_Fprecio" runat="server" AutoPostBack="True" OnCheckedChanged="chk_Fprecio_CheckedChanged" Text="Filtrar por Pecio:" />
                 <asp:TextBox ID="txt_precio" runat="server" Width="72px"></asp:TextBox>
                 <asp:RangeValidator ID="rvg_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" ErrorMessage="El precio Ingresado es incorrecto" MaximumValue="99999999" MinimumValue="0" ValidationGroup="A">*</asp:RangeValidator>
                 <asp:RequiredFieldValidator ID="rvf_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" ErrorMessage="Ingrese un precio." ValidationGroup="A">*</asp:RequiredFieldValidator>
                 <br />
                 <br />
                 <asp:CheckBox ID="chk_Ffecha" runat="server" AutoPostBack="True" OnCheckedChanged="chk_Ffecha_CheckedChanged" Text="Filtrar por Fecha:" />
&nbsp;
                 <asp:Label ID="lbl_Fdesde" runat="server" Text="Pedidos generados desde:"></asp:Label>
                 <asp:TextBox ID="txt_Desde" runat="server"></asp:TextBox>
&nbsp;<asp:RegularExpressionValidator ID="vl_fechaDesde" runat="server" ControlToValidate="txt_Desde" ErrorMessage="Formato de fecha Desde incorrecto." ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" ValidationGroup="A" Display="Dynamic">*</asp:RegularExpressionValidator>
&nbsp;<asp:RequiredFieldValidator ID="rvf_Desde" runat="server" ControlToValidate="txt_Desde" Display="Dynamic" ErrorMessage="Ingrese fecha Desde" ValidationGroup="A">*</asp:RequiredFieldValidator>
                 &nbsp;
                 <asp:Label ID="lbl_Hasta" runat="server" Text="Pedidos generados hasta:"></asp:Label>
                 <asp:TextBox ID="txt_Hasta" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Hasta" ErrorMessage="Formato de Fecha Hasta incorrecto." ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" ValidationGroup="A" Display="Dynamic">*</asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator ID="rvf_Hasta" runat="server" ControlToValidate="txt_Hasta" Display="Dynamic" ErrorMessage="Ingrese una fecha Hasta." ValidationGroup="A">*</asp:RequiredFieldValidator>
                 <br />
                 <asp:ValidationSummary ID="vld_sumarry" runat="server" ValidationGroup="A" />
                 <br />
                 <asp:Button ID="btn_generar" runat="server" OnClick="btn_generar_Click" Text="Generar" ValidationGroup="A" />
                 <br />
                 <asp:Label ID="lbl_resultados" runat="server"></asp:Label>
                 <br />
                 <asp:GridView ID="dgv_pedido" runat="server" AutoGenerateColumns="False">
                     <Columns>
                         <asp:BoundField DataField="nombre" HeaderText="Nombre Producto" />
                         <asp:BoundField DataField="precio" HeaderText="Precio Prodcuto" />
                         <asp:BoundField DataField="descripcionTipoProducto" HeaderText="Tipo de Producto" />
                         <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta del Producto" DataFormatString="{0:d}" />
                         <asp:BoundField DataField="idPedido" HeaderText="Id del Pedido" />
                         <asp:BoundField DataField="fechaGeneracionPedido" HeaderText="Fecha de Generacion del Pedido" DataFormatString="{0:d}" />
                     </Columns>
                 </asp:GridView>
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                 <br />
                <br />
                <br />
            </div>
        </form>
    </body>
    </html>
</asp:Content>

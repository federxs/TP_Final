<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="ABMProducto.aspx.cs" Inherits="ABMProducto" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <form id="form1" runat="server">
            <div>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lbl_ABMProducto" runat="server" Text="ABM Producto" ForeColor="Black"></asp:Label>
                <br />
                <br />
                <br />
                <div class="form-group">
                    <asp:Label ID="lbl_nombre" runat="server"  Text="Nombre: "></asp:Label>
                    <asp:TextBox ID="txt_nombre" CssClass="text-primary" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID = "rfv_nombre" runat="server" ControlToValidate="txt_nombre" Text="*" ErrorMessage="Debe ingresar el nombre." ValidationGroup="A">*</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server"  Text="Tipo Producto:  "></asp:Label>
                    <asp:DropDownList ID="cmb_tipoProducto" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lbl_precio" runat="server"  Text="Precio:"></asp:Label>
                    <asp:TextBox ID="txt_precio" CssClass="text-primary" runat="server" Width="131px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_precio" runat="server" Text="*" ControlToValidate="txt_precio"
                         Display="Dynamic" ErrorMessage="Ingrese un precio." ValidationGroup="A">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rv_precio" runat="server" Text="*" ControlToValidate="txt_precio" Display="Dynamic"
                         ErrorMessage="Precio debe tener un valor positivo." ValidationGroup="A" MaximumValue="999999999" MinimumValue="0"></asp:RangeValidator>
                    <br />
                    <br />
                    <asp:Label ID="lbl_fechaAlta" runat="server"  Text="Fecha Alta:"></asp:Label>
                    <asp:TextBox ID="txt_fechaAlta" CssClass="text-primary" runat="server" Width="101px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rev_fecha"  runat="server" ControlToValidate="txt_fechaAlta"
                         Display="Dynamic" ErrorMessage="La fecha no tiene un formato valido." ValidationGroup="A" ValidationExpression="(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d\d">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fechaAlta" ErrorMessage="Ingrese una Fecha." ValidationGroup="A">*</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lbl_Url" runat="server" Text="Url de la imagen:"></asp:Label>
&nbsp;<asp:TextBox ID="txt_url" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvf_url" runat="server" ControlToValidate="txt_url" Display="Dynamic" ErrorMessage="Ingrese un url de la imagen." ValidationGroup="A">*</asp:RequiredFieldValidator>
                </div>
            <br />
            <br />
            <div class="form-group">
                <asp:ValidationSummary ID="valResumen"
                    runat="server" ValidationGroup="A" CssClass="text-warning" />
            </div>
            <br />
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar"  OnClick="btn_guardar_Click" ValidationGroup="A"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_modificar" runat="server" Text="Modificar"  OnClick="btn_modificar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar"  OnClick="btn_eliminar_Click" />

            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_Nuevo" runat="server" OnClick="btn_Nuevo_Click" Text="Nuevo" />

            <br />
            <asp:GridView ID="dgv_producto" AutoGenerateColumns="False"
                runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="dgv_producto_SelectedIndexChanged"
                DataKeyNames="idProducto">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

            </div>
        </form>
    </body>
    </html>
</asp:Content>

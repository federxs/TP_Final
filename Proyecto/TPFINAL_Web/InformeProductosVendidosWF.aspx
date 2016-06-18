<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="InformeProductosVendidosWF.aspx.cs" Inherits="InformeProductosVendidos" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <form id="form1" runat="server">
            <div>
                <br />
                <br />
                <h3>Informe Productos Vendidos</h3>
                <div class="form-group"></div>
                <p>Seleccione los Filtros a aplicar:</p>
                <br />
                <br />
                <div class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                        <label>Filtrar Por Nombre:</label>
                        <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Filtrar Por Tipo Producto:</label>
                        <asp:DropDownList ID="cmb_TipoProducto" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Filtrar por Precio mayor a:</label>
                        <asp:TextBox ID="txt_precio" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="rvg_precio" runat="server" ControlToValidate="txt_precio" Display="Dynamic" ErrorMessage="El precio Ingresado es incorrecto" MaximumValue="99999999" MinimumValue="0" ValidationGroup="A">*</asp:RangeValidator>
                    </div>
                    <div class="form-group">
                        <label>Filtrar por Fecha:</label>
                        <br />
                        <asp:Label ID="lbl_Fdesde" AssociatedControlID="txt_Desde" runat="server" Text="Pedidos generados desde:"></asp:Label>
                        <asp:TextBox ID="txt_Desde" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CompareValidator ValidationGroup="A" ID="cvFechaDesde" ErrorMessage="El formato de la fecha desde no es correcto" Display="Dynamic" Text="*" ControlToValidate="txt_Desde" Type="Date" Operator="DataTypeCheck" runat="server" />
                        <asp:CompareValidator ID="cmp_fechaDesde" runat="server" ControlToCompare="txt_Hasta" ControlToValidate="txt_Desde" Display="Dynamic" ErrorMessage="La fecha Desde no puede ser mas grande que la fecha Hasta" Operator="LessThanEqual" ValidationGroup="A" Type="Date">*</asp:CompareValidator>
                        <asp:Label ID="lbl_Hasta" AssociatedControlID="txt_Hasta" runat="server" Text="Pedidos generados hasta:"></asp:Label>
                        <asp:TextBox ID="txt_Hasta" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CompareValidator ValidationGroup="A" ID="cvFechaHasta" ErrorMessage="El formato de la fecha hasta no es correcto" Display="Dynamic" Text="*" ControlToValidate="txt_Hasta" Type="Date" Operator="DataTypeCheck" runat="server" />
                        <asp:CompareValidator ID="cmp_FechaHasta" runat="server" Display="Dynamic" ErrorMessage="Fecha Hasta ingresada no puede ser mayor que hoy" ValueToCompare='<%# DateTime.Today.ToShortDateString() %>' Type="Date" ValidationGroup="A" ControlToValidate="txt_Hasta" Operator="LessThanEqual">*</asp:CompareValidator>
                    </div>
                    <br />
                    <asp:ValidationSummary ID="vld_sumarry" runat="server" ValidationGroup="A" />
                    <br />
                    <asp:Button ID="btn_generar" runat="server" OnClick="btn_generar_Click" Text="Generar" ValidationGroup="A" />
                    &nbsp;
                    <asp:Button ID="btn_mostrarTodos" runat="server" OnClick="btn_mostrarTodos_Click" Text="MostrarTodos" />
                    <br />
                    <asp:Label ID="lbl_resultados" runat="server"></asp:Label>
                    <br />
                    <div class="form-group">
                        <asp:GridView ID="dgv_pedido" runat="server" EmptyDataText="No se encontraron resultados" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" PageSize="15" OnPageIndexChanging="dgv_pedido_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="Nombre Producto" />
                                <asp:BoundField DataField="precio" HeaderText="Precio Prodcuto" />
                                <asp:BoundField DataField="descripcionTipoProducto" HeaderText="Tipo de Producto" />
                                <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta del Producto" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="idPedido" HeaderText="Id del Pedido" />
                                <asp:BoundField DataField="fechaGeneracionPedido" HeaderText="Fecha de Generacion del Pedido" DataFormatString="{0:d}" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <i>Estas viendo la pagina
                    <%=dgv_pedido.PageIndex + 1%>
                    de
                    <%=dgv_pedido.PageCount%>
                        </i>
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
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>

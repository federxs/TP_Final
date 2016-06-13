<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="RegistrarPedidoWF.aspx.cs" Inherits="RegistrarPedidoWF" %>

<asp:Content ID="contentPrincipal" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <div class="col-lg-2 col-md-2">
        </div>
        <form class="form form-inline form-multiline" id="formPrincipal" runat="server" method="post" role="form">
            <div class="container col-lg-8 col-md-8">
                <h2>Registrar Pedido</h2>
                <h3>Pedido</h3>
                <asp:Panel runat="server">
                    <%--<div class="form-group">
                        <label for="txtCliente">Cliente:</label>
                        <asp:GridView runat="server" ID="gvClientes" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="2" OnPageIndexChanged="gvClientes_PageIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField HeaderText="Seleccion" SelectText="Seleccionar" ShowSelectButton="True" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                                <asp:BoundField DataField="NumeroDoc" HeaderText="N° Doc" />
                                <asp:BoundField DataField="TipoDoc" HeaderText="Tipo Doc" />
                                <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
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
                    </div>--%>
                    <div class="form-group">
                        <label for="txtIdPedido">N° Pedido:</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIdPedido" placeholder="N° Pedido" Enabled="false" />
                    </div>
                    <div class="form-group">
                        <label for="txtIdCliente">N° de Cliente:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtIdCliente" placeholder="N° de Cliente" />
                    </div>
                    <div class="form-group">
                        <label for="txtFechaEntrega">Fecha de Entrega:</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaEntrega" placeholder="dd/MM/AAAA" />
                    </div>
                    <div class="form-group">
                        <label for="ddlEstado">Estado:</label>
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtTotal">Total:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtTotal" placeholder="Total" />
                    </div>
                </asp:Panel>
                <asp:Panel runat="server">
                    <h3>Detalle</h3>
                    <div class="form-group">
                        <label for="txtIdDetalle">N° Detalle:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtIdDetalle" placeholder="N° Detalle" Enabled="false" />
                    </div>
                    <div class="form-group">
                        <label for="ddlProductos">Producto:</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlProductos" />
                    </div>
                    <div class="form-group">
                        <label for="txtCantidad">Cantidad:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCantidad" placeholder="Cantidad" />
                    </div>
                    <div class="btn-group">
                        <asp:Button Text="Agregar" runat="server" id="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success"/>
                        <asp:Button Text="Modificar" runat="server" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning"/>
                        <asp:Button Text="Eliminar" runat="server" id="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger"/>
                        <asp:Button Text="Nuevo" runat="server" id="btnNuevo" OnClick="btnNuevo_Click" CssClass="btn btn-success" />
                    </div>
                    <div class="form-group">
                        <label for="gvDetalles">Detalles:</label>
                        <asp:GridView runat="server" ID="gvDetalles" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField HeaderText="Seleccion" SelectText="Seleccionar" ShowSelectButton="True" />
                                <asp:BoundField DataField="IdDetalle" HeaderText="N°" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
            <hr />
            <div class="btn-group">

            </div>
        </form>
        <div class="col-lg-2 col-md-2"></div>
    </div>
</asp:Content>

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
                <asp:Label Text="" CssClass="label" ID="lblMensajes" Font-Size="Larger" runat="server" />
                <br />
                <h3>Pedido</h3>
                <asp:Panel runat="server">
                    <div class="container col-lg-9 col-md-9 col-sm-9 col-xs-12" style="background-color: lightsalmon">
                        <asp:ValidationSummary runat="server" ID="valSummary" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="A" ShowMessageBox="False" />
                    </div>
                    <div class="form-group">
                        <label for="txtIdPedido">N° Pedido:</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIdPedido" placeholder="N° Pedido" Enabled="false" />
                    </div>
                    <div class="form-group">
                        <label for="txtIdCliente">N° Doc de Cliente:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtIdCliente" placeholder="N° Doc de Cliente" />
                        <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un número de documento de cliente" ValidationGroup="A" Text="*" ControlToValidate="txtIdCliente" runat="server" />
                        <asp:CompareValidator ErrorMessage="El formato del n° de doc de cliente no es válido" ValidationGroup="A" Text="*" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtIdCliente" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoDoc">Tipo Doc: *</label>
                        <asp:DropDownList CssClass="form-control" ID="ddlTipoDoc" runat="server" AutoPostBack="false"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoDoc" ErrorMessage="Debe seleccionar un tipo de documento" Text="*" ControlToValidate="ddlTipoDoc" InitialValue="" runat="server" ValidationGroup="A" />
                    </div>
                    <div class="form-group">
                        <label for="txtFechaEntrega">Fecha de Entrega:</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFechaEntrega" placeholder="dd/MM/AAAA" />
                        <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una fecha de entrega" ValidationGroup="A" Text="*" ControlToValidate="txtFechaEntrega" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="ddlEstado">Estado:</label>
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" Enabled="false">
                            <asp:ListItem Text="Generado" Value="1" />
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
                <hr />
                <asp:Panel runat="server">
                    <h3>Detalle</h3>
                    <div class="container col-lg-9 col-md-9 col-sm-9 col-xs-12" style="background-color: lightsalmon">
                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="B" ShowMessageBox="False" />
                    </div>
                    <div class="form-group">
                        <label for="txtIdDetalle">N° Detalle:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtIdDetalle" placeholder="N° Detalle" Enabled="false" />
                    </div>
                    <div class="form-group">
                        <label for="ddlProductos">Producto:</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlProductos" />
                        <asp:RequiredFieldValidator ErrorMessage="Debe seleccionar un producto" Text="*" ValidationGroup="B" InitialValue="0" ControlToValidate="ddlProductos" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="txtCantidad">Cantidad:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCantidad" placeholder="Cantidad" />
                        <asp:CompareValidator ErrorMessage="El formato de la cantidad no es correcto" Text="*" ControlToValidate="txtCantidad" ValidationGroup="B" Operator="DataTypeCheck" Type="Integer" runat="server" />
                        <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una cantidad" Text="*" ValidationGroup="B" ControlToValidate="txtCantidad" runat="server" />
                    </div>
                    <div class="btn-group">
                        <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CausesValidation="true" ValidationGroup="B" OnClick="btnAgregar_Click" CssClass="btn btn-success" />
                        <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="gvDetalles">Detalles:</label>
                        <asp:GridView runat="server" ID="gvDetalles" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDetalles_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField HeaderText="Seleccion" SelectText="Seleccionar" ShowSelectButton="True" />
                                <asp:BoundField DataField="IdDetalle" HeaderText="N°" />
                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
                <div class="form-group">
                    <label for="txtTotal">Total:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTotal" placeholder="Total" Enabled="false" />
                </div>
                <hr />
                <div class="btn-group">
                    <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="A" />
                    <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-warning" />
                </div>
            </div>
        </form>
        <div class="col-lg-2 col-md-2"></div>
    </div>
</asp:Content>

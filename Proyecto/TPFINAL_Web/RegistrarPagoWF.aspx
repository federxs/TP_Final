<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="RegistrarPagoWF.aspx.cs" Inherits="RegistrarPago" %>

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
                <h2>Registrar Pago</h2>
                <div class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                        <br />
                        <h5>Seleccione el Cliente al cual desea registrarle un pago:</h5>
                        <asp:DropDownList ID="cmb_clientes" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_clientes_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ControlToValidate="cmb_clientes" ID="rfv_cliente"
                            ValidationGroup="A" CssClass="errormesg" ErrorMessage="Seleccione un Cliente."
                            InitialValue="0" runat="server" Operator="equalto" Valuetocompare="0" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <br />
                        <h5>Seleccione el pedido que desea pagar:</h5>
                        <asp:DropDownList ID="cmb_pedidos" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_pedidos_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ControlToValidate="cmb_pedidos" ID="rvf_Pedido"
                            ValidationGroup="A" CssClass="errormesg" ErrorMessage="Seleccione un Pedido."
                            InitialValue="0" runat="server" Operator="equalto" Valuetocompare="0" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group ">
                        <h5>Monto a Abonar: </h5>
                        <asp:TextBox ID="lbl_monto" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group ">
                        <h5>Seleccione la forma de pago: </h5>
                        <asp:DropDownList ID="cmb_pago" CssClass="form-control" runat="server"></asp:DropDownList>
                        <h5>Monto a pagar: </h5>
                        <asp:TextBox ID="txt_monto" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RangeValidator ID="rvg_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ErrorMessage="El monto Ingresado es incorrecto" MaximumValue="99999999" MinimumValue="0" ValidationGroup="A">*</asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="rvf_monto" runat="server" ControlToValidate="txt_monto" Display="Dynamic" ErrorMessage="Ingrese un monto" ValidationGroup="A">*</asp:RequiredFieldValidator>
                        <asp:Button CssClass="btn btn-success" ID="btn_Agregar" Text="Agregar" runat="server" ValidationGroup="A" OnClick="btn_Agregar_Click"></asp:Button>
                        <asp:Button CssClass="btn btn-danger" ID="btn_quitar" Text="Quitar" runat="server" OnClick="btn_quitar_Click"></asp:Button>
                        <asp:CompareValidator ID="cmp_labels" runat="server" Display="Dynamic" ErrorMessage="El monto a pagar no cubre el monto del pedido." Type="Double" ValidationGroup="B" ControlToCompare="lbl_monto" ControlToValidate="lbl_montoAcumulado">*</asp:CompareValidator>
                        <asp:ValidationSummary ID="vld_sumarry" runat="server" ValidationGroup="A" />
                        <asp:GridView ID="dgv_pagos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgv_pagos_SelectedIndexChanged" BackColor="#CCCCCC"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                            CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="idDetallePago">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="formaPago" HeaderText="Forma de Pago" />
                                <asp:BoundField DataField="cantidad" HeaderText="Monto" />
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
                        <h6>Monto acumulado: </h6>
                        <asp:TextBox ID="lbl_montoAcumulado" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group ">
                        <asp:Button ID="btn_RegistrarPago" Text="Registrar Pago" runat="server" CssClass="btn btn-success" OnClick="btn_RegistrarPago_Click" ValidationGroup="B"></asp:Button>
                        <br />
                        <asp:Label ID="lbl_transaccion" runat="server"></asp:Label>
                    </div>
                    <asp:ValidationSummary ID="vld_summaryB" runat="server" ValidationGroup="B" />
                    <br />
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>

<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="RegistrarPago.aspx.cs" Inherits="RegistrarPago" %>


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
                <asp:Label ID="lbl_RegistrarPago" runat="server" Text="Registrar Pago" ForeColor="Black"></asp:Label>
                <br />
                <br />
                <div class="form-group ">
                    <asp:Label ID="lbl_cliente" runat="server" Text="Seleccione el Cliente:"></asp:Label>
                    &nbsp;              
                <asp:DropDownList ID="cmb_cliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_cliente_SelectedIndexChanged">
                </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lbl_pedido" runat="server" Text="Seleccione el Pedido:"></asp:Label>
                    &nbsp;
                <asp:DropDownList ID="cmb_pedido" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_pedido_SelectedIndexChanged">
                </asp:DropDownList>
                </div>
                <br />
                <br />
                <div class="form-group ">
                    <asp:Label ID="lbl_Abonar" runat="server" Text="Monto a Abonar:"></asp:Label>
                    &nbsp;&nbsp;
                <asp:Label ID="lbl_monto" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lbl_formaPago" runat="server" Text="Seleccione Forma de Pago:"></asp:Label>
                    &nbsp;
                <asp:DropDownList ID="cmb_formaPago" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                    &nbsp;&nbsp;
                <asp:Label ID="lbl_montoFormaPago" runat="server" Text="Monto a Pagar:"></asp:Label>
                    &nbsp;
                <asp:TextBox ID="txt_Monto" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" OnClick="btn_Agregar_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="dgv_FormaPago" runat="server" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="formaPago" HeaderText="Forma de Pago" />
                            <asp:BoundField DataField="monto" HeaderText="Monto" />
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <asp:Button ID="btn_RegistrarPago" runat="server" Text="Registrar Pago" />
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

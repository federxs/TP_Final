<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="InformePedidosWF.aspx.cs" Inherits="InformePedidosWF" %>

<asp:Content runat="server" ID="contentInformePedidos" ContentPlaceHolderID="ContentPlaceHolderMaster">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <br />
        <br />
        <br />
        <br />
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1">
        </div>
        <form class="form form-inline form-multiline" id="frm_inicio" role="form" runat="server" method="post">
            <div class="container col-lg-10 col-md-10 col-sm-10 col-xs-10">
                <h3>Informe de Pedidos</h3>
                <div class="form-group">
                    <div class="form-group">
                        <label for="txtFechaDesde">Fecha Desde:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaDesde" placeholder="Fecha Desde" />
                    </div>
                    <div class="form-group">
                        <label for="txtFechaHasta">Fecha Hasta:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaHasta" placeholder="Fecha Hasta" />
                    </div>
                    <div class="form-group">
                        <label for="txtTotal">Total:</label>
                        <asp:TextBox runat="server" CssClass="form-control" id="txtTotal" placeholder="Total"/>
                    </div>
                    <div class="form-group">
                        <label for="ddlEstado">Estado:</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado" AutoPostBack="false"/>
                    </div>
                    <div class="form-group">
                        <asp:Button CssClass="btn btn-success" Text="Buscar" runat="server" id="btnBuscar" OnClick="btnBuscar_Click"/>
                    </div>
                </div>
                <div class="form-group">
                    <asp:GridView runat="server" ID="gvPedidos" AutoGenerateColumns="False" EmptyDataText="No se encontraron resultados" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="IdPedido" HeaderText="N° Pedido" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha Entrega" DataFormatString="{0:dd/mm/yyyy}" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
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
                </div>

            </div>
        </form>
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1">
        </div>
    </body>
    </html>
</asp:Content>

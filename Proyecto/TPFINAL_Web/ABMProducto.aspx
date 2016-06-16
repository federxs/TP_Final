<%@ Page MasterPageFile="~/DefaultMP.master" Language="C#" AutoEventWireup="true" CodeFile="ABMProducto.aspx.cs" Inherits="ABMProducto" %>

<asp:Content ID="Contenido1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <script>
            $(function () {
                $("#txt_fecha").datepicker({ dateFormat: 'dd/MM/yyyy' }).val();
            });
        </script>
        <form id="form1" runat="server">
            <div>
                <br />
                <br />
                <br />
                <h2>ABM Producto</h2>
                <div class="container col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                        <div class="container col-lg-9 col-md-9 col-sm-9 col-xs-12" style="background-color: lightsalmon">
                            <asp:ValidationSummary runat="server" ID="valSummary" HeaderText="Revise los siguientes errores:" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="A" ShowMessageBox="False" />
                        </div>
                        <br />
                        <div class="form-group">
                            <asp:Label ID="lbl_nombre" runat="server" Text="Nombre: " AssociatedControlID="txt_nombre"></asp:Label>
                            <asp:TextBox ID="txt_nombre" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Text="*" ErrorMessage="Debe ingresar el nombre." ValidationGroup="A">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Tipo Producto:  " AssociatedControlID="cmb_tipoProducto"></asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="cmb_tipoProducto" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_precio" runat="server" Text="Precio:" AssociatedControlID="txt_precio"></asp:Label>
                            <asp:TextBox ID="txt_precio" CssClass="form-control" runat="server" Width="131px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_precio" runat="server" Text="*" ControlToValidate="txt_precio"
                                Display="Dynamic" ErrorMessage="Ingrese un precio." ValidationGroup="A">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rv_precio" runat="server" Text="*" ControlToValidate="txt_precio" Display="Dynamic"
                                ErrorMessage="Precio debe tener un valor positivo." ValidationGroup="A" MaximumValue="999999999" MinimumValue="0"></asp:RangeValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_fechaAlta" runat="server" Text="Fecha Alta:" AssociatedControlID="txt_fechaAlta"></asp:Label>
                            <asp:TextBox ID="txt_fechaAlta" CssClass="form-control" runat="server" Width="101px"></asp:TextBox>
                            <asp:CompareValidator Text="*" ErrorMessage="La fecha no tiene un formato valido." ControlToValidate="txt_fechaAlta" runat="server" Type="Date" ValidationGroup="A" Operator="DataTypeCheck" Display="Dynamic" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fechaAlta" ErrorMessage="Ingrese una Fecha." ValidationGroup="A">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmp_fechaAlta" runat="server" ControlToValidate="txt_fechaAlta" Display="Dynamic" ErrorMessage="Fecha ingresada incorrecta." ValueToCompare='<%# DateTime.Today.ToShortDateString() %>' Operator="LessThanEqual" Type="Date" ValidationGroup="A"></asp:CompareValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_Url" runat="server" Text="Url de la imagen:" AssociatedControlID="txt_url"></asp:Label>
                            &nbsp;<asp:TextBox ID="txt_url" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvf_url" runat="server" ControlToValidate="txt_url" Display="Dynamic" ErrorMessage="Ingrese un url de la imagen." ValidationGroup="A">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="btn-group">
                        <asp:Button CssClass="btn btn-success" ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" ValidationGroup="A" />
                        <asp:Button CssClass="btn" ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click" />
                        <asp:Button CssClass="btn btn-danger" ID="btn_eliminar" runat="server" Text="Eliminar" OnClick="btn_eliminar_Click" />
                        <asp:Button CssClass="btn" ID="btn_Nuevo" runat="server" OnClick="btn_Nuevo_Click" Text="Nuevo" />
                    </div>
                    <br />
                    <!--Buscador-->
                    <h5>Buscar por nombre:</h5>
                    <div class="form-group">
                        <asp:Label Text="Nombre:" ID="lblBusqueda" AssociatedControlID="txtBuscar" runat="server" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar" PlaceHolder="Nombre" />
                    </div>
                    <div class="btn-group">
                        <asp:Button CssClass="btn btn-success" Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                    <!--Fin Buscador-->
                    <!--Inicio Grilla-->
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
            </div>
        </form>
    </body>
    </html>
</asp:Content>

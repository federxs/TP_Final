using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAOs;

public partial class InformeProductosVendidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                Response.Redirect("LoginWF.aspx");
            }
            btn_mostrarTodos_Click(sender,e);
            Page.DataBind();
            cargarCombo();
            cmp_fechaDesde.Enabled = false;
        }
        else
        {

        }

    }
    protected void cargarCombo()
    {
        cmb_TipoProducto.DataTextField = "descripcion";
        cmb_TipoProducto.DataValueField = "idTipoProducto";
        cmb_TipoProducto.DataSource = DAO_Producto.obtenerTipo();
        cmb_TipoProducto.DataBind();
        ListItem lista2 = new ListItem("-- Seleccione --", "0");
        cmb_TipoProducto.Items.Insert(0, lista2);
    }
    protected void btn_generar_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }
    protected void cargarGrilla()
    {
        if ((txt_Hasta.Text != String.Empty) && (txt_Desde.Text != String.Empty))
            cmp_fechaDesde.Enabled = true;

        int? idTipoProducto = null;
        if (int.Parse(cmb_TipoProducto.SelectedValue) != 0)
            idTipoProducto = int.Parse(cmb_TipoProducto.SelectedValue);

        String nombre = null;
        if (txt_nombre.Text != String.Empty)
            nombre = txt_nombre.Text;

        float? precio = null;
        if (txt_precio.Text != String.Empty)
            precio = float.Parse(txt_precio.Text);

        DateTime? fechaDesde = null;
        DateTime? fechaHasta = null;
        if (txt_Desde.Text != String.Empty)
            fechaDesde = DateTime.Parse(txt_Desde.Text);

        if (txt_Hasta.Text != String.Empty)
            fechaHasta = DateTime.Parse(txt_Hasta.Text);


        List<ProductoFiltrado> lista = DAOs.DAO_Pedido.obtenerProductosPorFiltro(idTipoProducto, nombre, precio, fechaDesde, fechaHasta);
        if (lista.Count() > 0)
        {
            dgv_pedido.DataSource = lista;
            dgv_pedido.DataBind();
            lbl_resultados.Text = "Resultados:";
        }
        else
        {
            //lbl_resultados.Text = "No se Encontraron Resultados.";
            dgv_pedido.DataSource = null;
            dgv_pedido.DataBind();
        }
    }

    protected void btn_mostrarTodos_Click(object sender, EventArgs e)
    {
        List<ProductoFiltrado> lista = DAOs.DAO_Pedido.obtenerProductosPorFiltro(null, null, null, null, null);
        dgv_pedido.DataSource = lista;
        dgv_pedido.DataBind();
        txt_Desde.Text = String.Empty;
        txt_Hasta.Text = String.Empty;
        txt_nombre.Text = String.Empty;
        txt_precio.Text = String.Empty;
        cmb_TipoProducto.SelectedIndex = 0;
    }
    protected void dgv_pedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        cargarGrilla();
        dgv_pedido.PageIndex = e.NewPageIndex;
        dgv_pedido.DataBind();
    }
}
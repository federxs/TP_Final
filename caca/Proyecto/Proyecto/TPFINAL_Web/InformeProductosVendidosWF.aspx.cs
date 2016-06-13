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
            cmb_TipoProducto.Enabled = false;
            txt_Desde.Enabled = false;
            txt_Hasta.Enabled = false;
            txt_nombre.Enabled = false;
            txt_precio.Enabled = false;
            cargarCombo();
            rvf_Desde.Enabled = false;
            rvf_Hasta.Enabled = false;
            rvf_precio.Enabled = false;
            rvf_nombre.Enabled = false;
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
    }
    protected void btn_generar_Click(object sender, EventArgs e)
    {       
        if ((chk_Fnombre.Checked == false) && (chk_Fprecio.Checked == false) && (chk_Ffecha.Checked == false)&& (chk_FtipoProduto.Checked == false))
        {
            dgv_pedido.DataSource = null;
            dgv_pedido.DataBind();
            lbl_resultados.Text = "Seleccione algun filtro.";
        }
        else
        {
            int?  idTipoProducto = null;
            if (chk_FtipoProduto.Checked == true) {
                 idTipoProducto = int.Parse(cmb_TipoProducto.SelectedValue);
            }
            String nombre = null;
            if (chk_Fnombre.Checked == true)
            {
                nombre = txt_nombre.Text;
            }
            float? precio = null;
            if (chk_Fprecio.Checked == true)
            {
                precio = float.Parse(txt_precio.Text);
            }
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            if (chk_Ffecha.Checked == true)
            {
                fechaDesde = DateTime.Parse(txt_Desde.Text);
                fechaHasta = DateTime.Parse(txt_Hasta.Text);
            }

            List<ProductoFiltrado> lista = DAOs.DAO_Pedido.obtenerProductosPorFiltro(idTipoProducto, nombre, precio, fechaDesde, fechaHasta); ;
            if (lista.Count() > 0)
            {
                dgv_pedido.DataSource = lista;
                dgv_pedido.DataBind();
                lbl_resultados.Text = "Resultados:";
            }
            else
            {
                lbl_resultados.Text = "No se Encontraron Resultados.";
                dgv_pedido.DataSource = null;
                dgv_pedido.DataBind();
            }
        }

    }

    protected void chk_Fnombre_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_Fnombre.Checked == true)
        {
            rvf_nombre.Enabled = true;
            lbl_resultados.Text = String.Empty;
            txt_nombre.Enabled = true;
        }
        else
        {
            rvf_nombre.Enabled = false;
            lbl_resultados.Text = String.Empty;
            txt_nombre.Text = String.Empty;
            txt_nombre.Enabled = false;
        }
    }

    protected void chk_FtipoProduto_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_FtipoProduto.Checked == true)
        {
            lbl_resultados.Text = String.Empty;
            cmb_TipoProducto.Enabled = true;
        }
        else
        {
            lbl_resultados.Text = String.Empty;
            cmb_TipoProducto.Enabled = false;
        }
    }

    protected void chk_Fprecio_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_Fprecio.Checked == true)
        {
            rvf_precio.Enabled = true;
            lbl_resultados.Text = String.Empty;
            txt_precio.Enabled = true;
        }
        else
        {
            rvf_precio.Enabled = false;
            lbl_resultados.Text = String.Empty;
            txt_precio.Text = String.Empty;
            txt_precio.Enabled = false;
        }
    }

    protected void chk_Ffecha_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_Ffecha.Checked == true)
        {
            rvf_Hasta.Enabled = true;
            rvf_Desde.Enabled = true;
            lbl_resultados.Text = String.Empty;
            txt_Desde.Enabled = true;
            txt_Hasta.Enabled = true;
        }
        else
        {
            rvf_Desde.Enabled = false;
            rvf_Hasta.Enabled = false;
            lbl_resultados.Text = String.Empty;
            txt_Hasta.Text = String.Empty;
            txt_Desde.Text = String.Empty;
            txt_Desde.Enabled = false;
            txt_Hasta.Enabled = false;
        }
    }
}
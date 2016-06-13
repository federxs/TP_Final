using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistrarPedidoWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Registrar Pedido";
        if (!Page.IsPostBack)
        {
            Page.Title = "Registrar Pedido";
        }
    }
    protected void gvClientes_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {

    }
}
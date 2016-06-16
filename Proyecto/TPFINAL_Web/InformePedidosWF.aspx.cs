using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformePedidosWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                Response.Redirect("LoginWF.aspx");
            }
            cargarCombo();
            cargarGrilla();
        }
        Page.Title = "Informe de Pedidos";
    }

    protected void cargarGrilla()
    {
        gvPedidos.DataSource = DAOs.DAO_TblPedido.ObtenerTodos("", "", 0F, ddlEstado.SelectedItem.Text);
        gvPedidos.DataKeyNames = new string[] { "IdPedido" };
        gvPedidos.DataBind();
    }

    protected void cargarCombo()
    {
        ddlEstado.DataSource = DAOs.DAO_TblPedido.ObtenerEstados();
        ddlEstado.DataTextField = "Nombre";
        ddlEstado.DataValueField = "idEstado";
        ddlEstado.DataBind();
        ddlEstado.Items.Insert(0, new ListItem("Seleccionar", ""));
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        float total = 0f;
        float.TryParse(txtTotal.Text.ToString(), out total);
        gvPedidos.DataSource = DAOs.DAO_TblPedido.ObtenerTodos(txtFechaDesde.Text, txtFechaHasta.Text, total, ddlEstado.SelectedItem.Text);
        gvPedidos.DataKeyNames = new string[] { "IdPedido" };
        gvPedidos.DataBind();
    }
    protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        cargarGrilla();
        gvPedidos.PageIndex = e.NewPageIndex;
        gvPedidos.DataBind();
    }
}
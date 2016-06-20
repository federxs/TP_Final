using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAOs;
using System.Data.SqlClient;
public partial class RegistrarPedidoWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Registrar Pedido";
        lblMensajes.Text = "";
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                Response.Redirect("LoginWF.aspx");
            }
            Page.Title = "Registrar Pedido";
            cargarProductos();
            Detalles = new List<DetallePedido>();
            limpiarDetalle();
            limpiarEncabezado();
            btnEliminar.Enabled = false;
        }
    }

    protected void cargarProductos()
    {
        ddlProductos.DataSource = DAOs.DAO_Producto.obtenerTodos();
        ddlProductos.DataValueField = "idProducto";
        ddlProductos.DataTextField = "nombre";
        ddlProductos.DataBind();
        ddlProductos.Items.Insert(0, new ListItem("Seleccionar", "0"));
    }

    protected List<DetallePedido> Detalles
    {
        get
        {
            if (Session["detalles"] == null)
                Session["detalles"] = new List<DetallePedido>();
            return (List<DetallePedido>)Session["detalles"];
        }
        set
        {
            Session["detalles"] = (List<DetallePedido>)value;
        }
    }

    protected void gvClientes_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int nro = Detalles.Count;
            bool banderaDetalleExistente = false;
            foreach (DetallePedido detalle in Detalles)
            {
                if (detalle.IdProducto == int.Parse(ddlProductos.SelectedValue))
                    banderaDetalleExistente = true;
            }
            if (banderaDetalleExistente)
            {
                foreach (DetallePedido detalle in Detalles)
                {
                    if (detalle.IdProducto == int.Parse(ddlProductos.SelectedValue))
                        detalle.Cantidad += int.Parse(txtCantidad.Text);
                }
            }
            else
            {
                DetallePedido detalleNuevo = new DetallePedido()
                {
                    Cantidad = int.Parse(txtCantidad.Text),
                    IdDetalle = nro + 1,
                    IdProducto = int.Parse(ddlProductos.SelectedValue),
                    Producto = ddlProductos.SelectedItem.Text
                };
                Detalles.Add(detalleNuevo);
            }
            calcularTotal();
            limpiarDetalle();
            cargarGrillaDetalles();
        }
    }

    protected void cargarGrillaDetalles()
    {
        gvDetalles.DataSource = Detalles;
        gvDetalles.DataKeyNames = new string[] { "IdDetalle" };
        gvDetalles.DataBind();
    }

    protected void calcularTotal()
    {
        float total = 0f;
        foreach (DetallePedido detalle in Detalles)
        {
            Producto prod = DAO_Producto.obtenerPorID(detalle.IdProducto);
            total += prod.precio * detalle.Cantidad;
        }
        txtTotal.Text = total.ToString();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int numDetalleSeleccionado = (int)gvDetalles.SelectedDataKey.Value;
        DetallePedido detalleABorrar = new DetallePedido();
        foreach (DetallePedido detalle in Detalles)
        {
            if (detalle.IdDetalle == numDetalleSeleccionado)
            {
                detalleABorrar = detalle;
            }
        }
        Detalles.Remove(detalleABorrar);
        //re enumeramos
        int numeroDetalle = 1;
        foreach (DetallePedido detalle in Detalles)
        {
            detalle.IdDetalle = numeroDetalle;
            numeroDetalle += 1;
        }
        calcularTotal();
        cargarGrillaDetalles();
        limpiarDetalle();
        btnEliminar.Enabled = false;
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string resultado = "";
        bool hayDetalles = false;
        bool clienteTieneSaldo = false;
        //verificamos que haya al menos un detalle
        if (Detalles.Count > 0)
            hayDetalles = true;
        else
        {
            resultado = "Debe ingresar al menos un detalle de pedido";
            lblMensajes.CssClass = "label label-danger";
        }
        //verificamos que el cliente posea saldo
        float total = 0f;
        if (!string.IsNullOrEmpty(txtTotal.Text))
            total = float.Parse(txtTotal.Text);
        if (DAO_Cliente.ObtenerPorID(int.Parse(txtIdCliente.Text)).Saldo >= total)
            clienteTieneSaldo = true;
        else
        {
            resultado = "El cliente no posee el saldo suficiente";
            lblMensajes.CssClass = "label label-danger";
        }
        //Si no hay problemas procedemos con el registro del pedido
        if (Page.IsValid && hayDetalles && clienteTieneSaldo)
        {
            Pedido pedidoNuevo = new Pedido()
            {
                IdCliente = int.Parse(txtIdCliente.Text),
                IdEstado = int.Parse(ddlEstado.Items[0].Value),
                FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text),
                FechaGeneracion = DateTime.Today,
                Total = float.Parse(txtTotal.Text)
            };
            List<DetallePedido> detalles = Detalles;
            try
            {
                DAOs.DAO_Pedido.Insertar(pedidoNuevo, detalles);
            }
            catch (SqlException) { lblMensajes.CssClass = "label label-danger"; resultado = "Ha ocurrido un error en la transaccion"; }
            if (string.IsNullOrEmpty(resultado)) { resultado = "La transacción se registró exitosamente"; lblMensajes.CssClass = "label label-success"; }
            //limpiamos
            limpiarDetalle();
            limpiarEncabezado();
            txtTotal.Text = "";
            Detalles = new List<DetallePedido>();
            cargarGrillaDetalles();
        }
        lblMensajes.Text = resultado;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        limpiarDetalle();
        limpiarEncabezado();
        Detalles = new List<DetallePedido>();
        cargarGrillaDetalles();
        cargarProductos();
        lblMensajes.Text = "";
    }

    protected void limpiarEncabezado()
    {
        txtIdPedido.Text = "";
        txtIdCliente.Text = "";
        txtFechaEntrega.Text = "";
        ddlEstado.SelectedIndex = 0;
    }

    protected void limpiarDetalle()
    {
        txtCantidad.Text = "";
        ddlProductos.SelectedIndex = 0;
        txtIdDetalle.Text = "";
    }
    protected void gvDetalles_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtIdDetalle.Text = gvDetalles.SelectedRow.Cells[1].Text;
        txtCantidad.Text = gvDetalles.SelectedRow.Cells[3].Text;
        ddlProductos.SelectedValue = Detalles[gvDetalles.SelectedIndex].IdProducto.ToString();
        btnEliminar.Enabled = true;
    }
}
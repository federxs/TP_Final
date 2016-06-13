using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAOs;
public partial class RegistrarPago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarClientes();
            int idCliente = int.Parse(cmb_cliente.SelectedValue.ToString());
            cargarPedido(idCliente);
            cargarFormaPago();
            cargarLabel();
        }
        else
        {

        }
    }
    protected void cargarClientes()
    {
        List<Cliente> lista = DAOs.DAO_Cliente.ObtenerClientesQueDeben();
        cmb_cliente.DataTextField = "nombre";
        cmb_cliente.DataValueField = "IdCliente";
        cmb_cliente.DataSource = lista;
        cmb_cliente.DataBind();
    }

    protected void cmb_cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCliente = int.Parse(cmb_cliente.SelectedValue.ToString());
        cargarPedido(idCliente);
    }

    protected void cargarPedido(int idCliente)
    {
        cmb_pedido.DataSource = DAOs.DAO_Pedido.obtenerPedidosCliente(idCliente);
        cmb_pedido.DataTextField = "fechaGeneracion";
        cmb_pedido.DataValueField = "idPedido";
        cmb_pedido.DataBind();
        cargarLabel();
    }
    protected void cargarFormaPago()
    {
        cmb_formaPago.DataSource = DAOs.DAO_FormaPago.obtenerTodos();
        cmb_formaPago.DataTextField = "descripcion";
        cmb_formaPago.DataValueField = "idFormaPago";
        cmb_formaPago.DataBind();
    }
    protected List<Pedido> listaPedido
    {
        set
        {
            Session["listaPedido"] = value;
        }
        get
        {
            if (Session["listaPedido"] == null)
            {
                int idCliente = int.Parse(cmb_cliente.SelectedValue.ToString());
                listaPedido = DAOs.DAO_Pedido.obtenerPedidosCliente(idCliente);
                Session["listaPedido"] = listaPedido;
                return (List<Pedido>)Session["listaPedido"];
            }
            else
            {
                return (List<Pedido>)Session["listaPedido"];
            }
        }
    }
    protected void cmb_pedido_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarLabel();
    }
    protected void cargarLabel()
    {
        if (cmb_pedido.SelectedValue.ToString()== String.Empty )
        {
            lbl_monto.Text = String.Empty;
        }
        else
        {
            foreach (Pedido p in listaPedido)
            {

                if (p.idPedido == int.Parse(cmb_pedido.SelectedValue.ToString()))
                {
                    lbl_monto.Text = p.total.ToString();
                    break;
                }
                else
                {
                    lbl_monto.Text = String.Empty;
                }
            }
        }
    }

    protected void btn_Agregar_Click(object sender, EventArgs e)
    {
        if((cmb_pedido.SelectedValue.ToString() != String.Empty) &&((float.Parse(lbl_monto.Text)> 0) &&(float.Parse(txt_Monto.Text)>0 && float.Parse(txt_Monto.Text)< float.Parse(lbl_monto.Text)))){
            
        }
    }
}
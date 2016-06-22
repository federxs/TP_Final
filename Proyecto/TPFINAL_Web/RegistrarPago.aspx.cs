using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
using Entidades;
using System.Drawing;

public partial class RegistrarPago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                Response.Redirect("LoginWF.aspx");
            }
            rvf_monto.Enabled = false;
            rvf_Pedido.Enabled = false;
            cargarFormaPago();
            cargarClientes();
        }
    }
    private void cargarClientes()
    {
        cmb_clientes.DataValueField = "IdCliente";
        cmb_clientes.DataTextField = "Apellido";
        cmb_clientes.DataSource = DAOs.DAO_Cliente.obtenerClientesTransaccion();
        cmb_clientes.DataBind();
        ListItem lista2 = new ListItem("-- Seleccione --", "0");
        cmb_clientes.Items.Insert(0, lista2);
        cmb_pedidos.Items.Clear();
        cmb_pedidos.DataBind();
    }

    protected void cmb_clientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagos = null;
        cargarGrilla();
        txt_monto.Text = String.Empty;
        lbl_montoAcumulado.Text = String.Empty;
        lbl_monto.Text = String.Empty;
        rvf_Pedido.Enabled = true;
        cargarPedidos();
    }
    private void cargarPedidos()
    {
        cmb_pedidos.DataValueField = "idPedido";
        cmb_pedidos.DataTextField = "fechaGeneracion";
        cmb_pedidos.DataTextFormatString = "{0:dd-MM-yyyy}";
        cmb_pedidos.DataSource = DAOs.DAO_Pedido.obtenerPedidoPorCliente(int.Parse(cmb_clientes.SelectedValue.ToString()));
        cmb_pedidos.DataBind();
        ListItem lista2 = new ListItem("-- Seleccione --", "0");
        cmb_pedidos.Items.Insert(0, lista2);
    }

    protected void cmb_pedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagos = null;
        cargarGrilla();
        txt_monto.Text = String.Empty;
        lbl_montoAcumulado.Text = String.Empty;
        rvf_monto.Enabled = true;
        lbl_monto.Text = DAOs.DAO_Pedido.obtenerMontoPorPedido(int.Parse(cmb_pedidos.SelectedValue.ToString())).ToString();
    }
    protected void cargarFormaPago()
    {
        cmb_pago.DataValueField = "idFormaPago";
        cmb_pago.DataTextField = "descripcion";
        cmb_pago.DataSource = DAOs.DAO_FormaPago.obtenerTodos();
        cmb_pago.DataBind();
    }
    protected List<DetallePagoGrillaEntidad> pagos
    {
        get
        {
            if (Session["pagos"] == null)
            {
                List<DetallePagoGrillaEntidad> pagos = new List<DetallePagoGrillaEntidad>();
                Session["pagos"] = pagos;
                return (List<DetallePagoGrillaEntidad>)Session["pagos"];
            }
            else return (List<DetallePagoGrillaEntidad>)Session["pagos"];
        }
        set
        {
            Session["pagos"] = value;
        }
    }
    protected int contador
    {
        get
        {
            if (Session["contador"] == null)
            {
                contador = 1;
                Session["contador"] = contador;
                return (int)Session["contador"];
            }
            else return (int)Session["contador"];
        }
        set
        {
            Session["contador"] = value;
        }
    }

    protected void btn_Agregar_Click(object sender, EventArgs e)
    {
        lbl_transaccion.Text = String.Empty;
        if ((int.Parse(cmb_clientes.SelectedValue.ToString()) == 0)||(int.Parse(cmb_pedidos.SelectedValue.ToString())== 0)) {
            rvf_monto.Enabled = false;
            txt_monto.Text = String.Empty;
            return;
        }

        float acumulador = 0;
        if (pagos.Count > 0)
        {
            for (int i = 0; i < pagos.Count; i++)
            {
                acumulador += pagos.ElementAt(i).cantidad;
            }
            float suma = (float.Parse(txt_monto.Text) + acumulador);
            if (suma <= float.Parse(lbl_monto.Text))
            {
                lbl_montoAcumulado.Text = (acumulador + float.Parse(txt_monto.Text)).ToString();
                DetallePagoGrillaEntidad p = new DetallePagoGrillaEntidad();
                p.cantidad = float.Parse(txt_monto.Text);
                p.idFormaPago = int.Parse(cmb_pago.SelectedValue.ToString());
                p.formaPago = cmb_pago.SelectedItem.ToString();
                p.idDetallePago = contador;
                contador++;
                Boolean ban = false;
                for (int i = 0; i < pagos.Count; i++)
                {
                    if (pagos.ElementAt(i).idFormaPago == p.idFormaPago)
                    {
                        pagos.ElementAt(i).cantidad += p.cantidad;
                        ban = true;
                        break;
                    }
                }
                if (!ban)
                    pagos.Add(p);
                cargarGrilla();
                txt_monto.Text = String.Empty;
            }
            else
            {
                lbl_transaccion.Text = "El monto ingresado es superior al monto total que se tiene que abonar.";
                txt_monto.Text = String.Empty;
            }
        }
        else
        {
            float suma = (float.Parse(txt_monto.Text) + acumulador);
            if (suma <= float.Parse(lbl_monto.Text))
            {
                acumulador = float.Parse(txt_monto.Text);
                lbl_montoAcumulado.Text = acumulador.ToString();
                DetallePagoGrillaEntidad p = new DetallePagoGrillaEntidad();
                p.cantidad = float.Parse(txt_monto.Text);
                p.idFormaPago = int.Parse(cmb_pago.SelectedValue.ToString());
                p.formaPago = cmb_pago.SelectedItem.ToString();
                p.idDetallePago = contador;
                contador++;
                Boolean ban = false;
                for (int i = 0; i < pagos.Count; i++)
                {
                    if (pagos.ElementAt(i).idFormaPago == p.idFormaPago)
                    {
                        pagos.ElementAt(i).cantidad += p.cantidad;
                        ban = true;
                        break;
                    }
                }
                if (!ban)
                    pagos.Add(p);

                cargarGrilla();
                txt_monto.Text = String.Empty;
            }
            else
            {
                lbl_transaccion.Text = "El monto ingresado es superior al monto total que se tiene que abonar.";
                txt_monto.Text = String.Empty;
            }
        }

    }
    protected void cargarGrilla()
    {
        if (pagos == null)
        {
            dgv_pagos.DataSource = null;
        }
        else
        {
            dgv_pagos.DataSource = pagos;
            dgv_pagos.DataKeyNames = new String[] { "idDetallePago" };
            Color clr = ColorTranslator.FromHtml("White");
            dgv_pagos.RowStyle.BackColor = clr;
            dgv_pagos.DataBind();
        }
    }
    protected int? ID
    {
        get
        {
            if (Session["ID"] != null)
                return (int)Session["ID"];
            else
            {
                return null;
            }
        }
        set { Session["ID"] = value; }
    }
    protected void btn_quitar_Click(object sender, EventArgs e)
    {
        float descuento = 0;
        if (ID.HasValue)
        {
            for (int i = 0; i < pagos.Count; i++)
            {
                if (pagos.ElementAt(i).idDetallePago == ID.Value)
                {
                    descuento = pagos.ElementAt(i).cantidad;
                    pagos.RemoveAt(i);
                    ID = null;
                    break;
                }
            }
            lbl_montoAcumulado.Text = (float.Parse(lbl_montoAcumulado.Text) - descuento).ToString();
            cargarGrilla();
            dgv_pagos.SelectedIndex = -1;
        }
    }

    protected void dgv_pagos_SelectedIndexChanged(object sender, EventArgs e)
    {
        ID = int.Parse(dgv_pagos.SelectedDataKey.Value.ToString());
    }

    protected void btn_RegistrarPago_Click(object sender, EventArgs e)
    {
        int idPedido = int.Parse(cmb_pedidos.SelectedValue.ToString());
        int idCliente = int.Parse(cmb_clientes.SelectedValue.ToString());
        float monto = float.Parse(lbl_monto.Text);
        Boolean ban = DAO_RegistrarPago.registrarPago(pagos, idPedido, idCliente, monto);
        if (ban)
        {
            lbl_transaccion.Text = "Pago registrado con exito.";
        }
        else {
            lbl_transaccion.Text = "Error al registrar pago.";
        }
        lbl_montoAcumulado.Text = String.Empty;
        lbl_monto.Text = String.Empty;
        txt_monto.Text = String.Empty;
        cargarClientes();
        pagos = null;
        cargarGrilla();
    }
}
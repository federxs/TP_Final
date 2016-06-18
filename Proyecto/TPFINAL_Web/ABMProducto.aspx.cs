using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAOs;
public partial class ABMProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty((string)Session["Usuario"]))
            {
                Response.Redirect("LoginWF.aspx");
            }
            Page.DataBind();
            cargarGrilla();
            cmb_tipoProducto.DataTextField = "descripcion";
            cmb_tipoProducto.DataValueField = "idTipoProducto";
            cmb_tipoProducto.DataSource = DAO_Producto.obtenerTipo();
            cmb_tipoProducto.DataBind();
            btn_eliminar.CssClass = "btn btn-warning disabled";
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            txt_fechaAlta.Enabled = false;
            txt_nombre.Enabled = false;
            txt_precio.Enabled = false;
            txt_url.Enabled = false;
            btn_guardar.Enabled = false;
            cmb_tipoProducto.Enabled = false;
        }
    }

    protected void cargarGrilla()
    {
        //Establezco la fuente de los datos de la grilla
        dgv_producto.DataSource = (from p in DAO_Producto.obtenerTodos()
                                   orderby p.nombre
                                   select p);
        //Establezco un atributo identificador de cada una de las filas de la grilla, en nuestro caso la clave primaria
        dgv_producto.DataKeyNames = new string[] { "idProducto" };
        //Indico que llene la grilla
        dgv_producto.DataBind();
    }

    protected Boolean update
    {
        get
        {
            if (Session["update"] == null)
            {
                update = true;
                Session["update"] = update;
                return (Boolean)Session["update"];
            }
            else return (Boolean)Session["update"];
        }
        set
        {
            Session["update"] = value;
        }
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        Producto p = null;
        String nombre = txt_nombre.Text;
        float precio = float.Parse(txt_precio.Text);
        DateTime fechaAlta = DateTime.Parse(txt_fechaAlta.Text);
        int tipoProducto = int.Parse(cmb_tipoProducto.SelectedItem.Value);
        String imagen = txt_url.Text;
        p = new Producto(nombre, precio, fechaAlta, tipoProducto, imagen);
        if (update)
        {
            p.idProducto = ID.Value;
            DAO_Producto.actualizar(p);
            update = false;
        }
        else
        {
            DAO_Producto.insertar(p);
        }
        cargarGrilla();
        limpiar();

    }
    protected void limpiar()
    {
        txt_fechaAlta.Text = string.Empty;
        txt_nombre.Text = string.Empty;
        txt_precio.Text = string.Empty;
        txt_url.Text = string.Empty;

    }
    protected int? ID
    {
        get
        {
            if (ViewState["ID"] != null)
                return (int)ViewState["ID"];
            else
            {
                return null;
            }
        }
        set { ViewState["ID"] = value; }
    }

    protected void dgv_producto_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_modificar.Enabled = true;
        limpiar();
        //Recupero la clave primaria de la fila seleccionada de la grilla
        ID = int.Parse(dgv_producto.SelectedDataKey.Value.ToString());
        Producto p = DAO_Producto.obtenerPorID(ID.Value);
        txt_fechaAlta.Text = p.fechaAlta.ToString("dd/MM/yyyy");
        txt_nombre.Text = p.nombre.ToString();
        txt_precio.Text = p.precio.ToString();
        txt_url.Text = p.imagen.ToString();
        cmb_tipoProducto.DataTextField = "descripcion";
        cmb_tipoProducto.DataValueField = "idTipoProducto";
        cmb_tipoProducto.DataSource = DAO_Producto.obtenerTipo();
        cmb_tipoProducto.DataBind();
        cmb_tipoProducto.SelectedIndex = p.idTipoProducto - 1;
    }

    protected void btn_eliminar_Click(object sender, EventArgs e)
    {
        if (ID.HasValue)
        {
            DAOs.DAO_Producto.eliminar(ID.Value);
            limpiar();
            cargarGrilla();
            ID = null;
            btn_modificar.Enabled = false;
        }
    }

    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        if (ID.HasValue)
        {
            update = true;
            btn_eliminar.CssClass = "btn btn-warning";
            btn_eliminar.Enabled = true;
            txt_fechaAlta.Enabled = true;
            txt_nombre.Enabled = true;
            txt_url.Enabled = true;
            txt_precio.Enabled = true;
            btn_guardar.Enabled = true;
            cmb_tipoProducto.Enabled = true;
            btn_guardar.Enabled = true;
        }
    }

    protected void btn_Nuevo_Click(object sender, EventArgs e)
    {
        btn_eliminar.CssClass = "btn btn-warning disabled";
        btn_eliminar.Enabled = false;
        txt_fechaAlta.Enabled = true;
        txt_nombre.Enabled = true;
        txt_precio.Enabled = true;
        txt_url.Enabled = true;
        cmb_tipoProducto.Enabled = true;
        btn_guardar.Enabled = true;
        limpiar();
        ID = null;
        update = false;

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        dgv_producto.DataSource = DAO_Producto.obtenerTodos(txtBuscar.Text);
        dgv_producto.DataKeyNames = new string[] { "idProducto" };
        dgv_producto.DataBind();
    }
}
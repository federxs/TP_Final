using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
using Entidades;
using System.Data.SqlClient;

public partial class Inicio_WF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Clientes";
        if (!Page.IsPostBack)
        {
            cargarTipoDoc();
            cargarProvincias();
            cargarGrilla();
            Page.Title = "Clientes";
            bloquearCampos(true);
            btn_guardar.Enabled = false;
            btn_modificar.Enabled = false;
            btn_eliminar.Enabled = false;
        }
    }

    private void cargarGrilla()
    {
        gv_grillaClientes.DataSource = (from cli in DAO_Cliente.ObtenerTodos() orderby cli.Apellido, cli.Nombre select cli);
        gv_grillaClientes.DataKeyNames = new string[] { "idCliente" };
        gv_grillaClientes.DataBind();
    }

    private void cargarTipoDoc()
    {
        List<TipoDoc> listaTipoDoc = DAOs.DAO_TipoDoc.ObtenerTodos();
        ddl_tipoDoc.DataSource = listaTipoDoc;
        ddl_tipoDoc.DataTextField = "Nombre";
        ddl_tipoDoc.DataValueField = "IdTipoDoc";
        ddl_tipoDoc.DataBind();
        ddl_tipoDoc.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
    }

    private void cargarProvincias()
    {
        List<Provincia> listaProvincias = DAOs.DAO_Provincia.ObtenerTodos();
        listaProvincias.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
        ddl_provincia.DataSource = listaProvincias;
        ddl_provincia.DataTextField = "Nombre";
        ddl_provincia.DataValueField = "idProvincia";
        ddl_provincia.DataBind();
        ddl_provincia.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
        ddl_localidad.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
    }

    private void cargarLocalidades()
    {
        List<Localidad> listaLocalidades = DAOs.DAO_Localidad.ObtenerPorProvincia(int.Parse(ddl_provincia.SelectedValue.ToString()));
        listaLocalidades.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
        ddl_localidad.DataSource = listaLocalidades;
        ddl_localidad.DataTextField = "Nombre";
        ddl_localidad.DataValueField = "idLocalidad";
        ddl_localidad.DataBind();
        ddl_localidad.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
    }

    protected void ddl_provincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarLocalidades();
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string resultadoOperacion = "";
            Cliente clienteNuevo = new Cliente();
            clienteNuevo.Apellido = txt_apellido.Text;
            clienteNuevo.Nombre = txt_nombre.Text;
            clienteNuevo.RazonSocial = txt_razonSocial.Text;
            clienteNuevo.FechaAlta = DateTime.Now;
            clienteNuevo.Email = txt_email.Text;
            clienteNuevo.TipoDoc = int.Parse(ddl_tipoDoc.SelectedItem.Value);
            int nroDocumento;
            if (int.TryParse(txt_doc.Text, out nroDocumento))
                clienteNuevo.NumeroDoc = nroDocumento;
            clienteNuevo.Direccion = txt_direccion.Text;
            clienteNuevo.Cuit = txt_cuit.Text;
            clienteNuevo.Telefono = long.Parse(txt_numeroTel.Text.Trim().ToString());
            if (rbt_sexoMasc.Checked)
                clienteNuevo.Sexo = "Masculino";
            else
                clienteNuevo.Sexo = "Femenino";
            clienteNuevo.Localidad = int.Parse(ddl_localidad.SelectedValue);
            clienteNuevo.Saldo = float.Parse(txt_saldo.Text);

            if (IdCliente.HasValue)
            {
                clienteNuevo.IdCliente = IdCliente.Value;
                try
                {
                    DAO_Cliente.Actualizar(clienteNuevo);
                }
                catch (SqlException) { resultadoOperacion = "Ha surgido un error durante la actualización"; }
            }
            else
            {
                try
                {
                    DAO_Cliente.Insertar(clienteNuevo);
                }
                catch (SqlException) { resultadoOperacion = "Ha ocurrido un error durante la inserción"; }
            }
            //bloqueamos y limpiamos botones e inputs, y cargamos grilla
            cargarGrilla();
            Limpiar();
            bloquearCampos(true);
            btn_guardar.Enabled = false;
            btn_modificar.Enabled = false;
            btn_eliminar.Enabled = false;
            gv_grillaClientes.SelectedIndex = -1;
            if (resultadoOperacion == string.Empty)
            {
                resultadoOperacion = "¡La operación se ejecutó exitosamente!";
                lblMensajes.CssClass = "label label-success";
            }
            else
                lblMensajes.CssClass = "label label-danger";
            lblMensajes.Text = resultadoOperacion;
        }
    }

    protected void dg_grillaClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        //guardamos el id del cliente seleccionado
        int idCliente = int.Parse(gv_grillaClientes.SelectedDataKey.Value.ToString());
        IdCliente = idCliente;
        Cliente cliente = DAO_Cliente.ObtenerPorID(idCliente);
        txt_apellido.Text = cliente.Apellido;
        txt_nombre.Text = cliente.Nombre;
        txt_razonSocial.Text = cliente.RazonSocial;
        ddl_tipoDoc.SelectedValue = cliente.TipoDoc.ToString();
        txt_doc.Text = cliente.NumeroDoc.ToString();
        txt_direccion.Text = cliente.Direccion;
        txt_email.Text = cliente.Email;
        txt_cuit.Text = cliente.Cuit.ToString();
        txt_numeroTel.Text = cliente.Telefono.ToString();
        if (cliente.Sexo == "Masculino")
            rbt_sexoMasc.Checked = true;
        else
            rbt_sexoFem.Checked = false;
        ddl_provincia.SelectedValue = DAO_Provincia.obtenerPorLocalidad(int.Parse(cliente.Localidad.ToString())).ToString();
        cargarLocalidades();
        ddl_localidad.SelectedValue = cliente.Localidad.ToString();
        txt_saldo.Text = cliente.Saldo.ToString();
        //Bloqueamos los campos para edicion
        bloquearCampos(true);
        btn_guardar.Enabled = false;
        btn_modificar.Enabled = true;
        btn_eliminar.Enabled = true;
    }

    protected int? IdCliente
    {
        get
        {
            if (ViewState["IdCliente"] != null)
                return (int)ViewState["IdCliente"];
            else
            {
                return null;
            }
        }
        set { ViewState["IdCliente"] = value; }
    }

    private void Limpiar()
    {
        txt_nombre.Text = "";
        txt_apellido.Text = "";
        txt_cuit.Text = "";
        txt_direccion.Text = "";
        txt_doc.Text = "";
        txt_email.Text = "";
        txt_numeroTel.Text = "";
        txt_razonSocial.Text = "";
        txt_saldo.Text = "";
        ddl_localidad.SelectedIndex = 0;
        ddl_provincia.SelectedIndex = 0;
        ddl_tipoDoc.SelectedIndex = 0;
        rbt_sexoFem.Checked = false;
        rbt_sexoMasc.Checked = true;
        lblMensajes.Text = "";
    }

    private void bloquearCampos(bool x)
    {
        txt_nombre.Enabled = !x;
        txt_apellido.Enabled = !x;
        txt_cuit.Enabled = !x;
        txt_direccion.Enabled = !x;
        txt_doc.Enabled = !x;
        txt_email.Enabled = !x;
        txt_numeroTel.Enabled = !x;
        txt_razonSocial.Enabled = !x;
        txt_saldo.Enabled = !x;
        ddl_localidad.Enabled = !x;
        ddl_provincia.Enabled = !x;
        ddl_tipoDoc.Enabled = !x;
        rbt_sexoFem.Enabled = !x;
        rbt_sexoMasc.Enabled = !x;
    }
    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        bloquearCampos(false);
        btn_modificar.Enabled = false;
        btn_guardar.Enabled = true;
        btn_eliminar.Enabled = true;
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        IdCliente = null;
        bloquearCampos(false);
        btn_modificar.Enabled = false;
        btn_guardar.Enabled = true;
        btn_eliminar.Enabled = false;
        cargarGrilla();
        ddl_localidad.Items.Clear();
        cargarProvincias();
        cargarTipoDoc();
        Limpiar();
        gv_grillaClientes.SelectedIndex = -1;
    }

    protected void btn_eliminar_Click(object sender, EventArgs e)
    {
        string resultadoOperacion = "";
        if (IdCliente.HasValue)
        {
            try
            {
                DAO_Cliente.Eliminar(IdCliente.Value);
            }
            catch (SqlException) { resultadoOperacion = "Ha ocurrido un error durante el borrado"; }
        }
        bloquearCampos(true);
        btn_modificar.Enabled = false;
        btn_guardar.Enabled = false;
        btn_eliminar.Enabled = false;
        cargarGrilla();
        Limpiar();
        if (resultadoOperacion == string.Empty)
        {
            resultadoOperacion = "¡La operación se ejecutó exitosamente!";
            lblMensajes.CssClass = "label label-success";
        }
        else
            lblMensajes.CssClass = "label label-danger";
        lblMensajes.Text = resultadoOperacion;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gv_grillaClientes.DataSource = (from cli in DAO_Cliente.ObtenerTodos(txtBuscar.Text) orderby cli.Apellido, cli.Nombre select cli);
        gv_grillaClientes.DataKeyNames = new string[] { "idCliente" };
        gv_grillaClientes.DataBind();
    }
}
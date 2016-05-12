using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
using Entidades;

public partial class Inicio_WF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTipoDoc();
            cargarProvincias();
            cargarGrilla();
        }
    }

    private void cargarGrilla()
    {
        dg_grillaClientes.DataSource = (from cli in DAO_Cliente.ObtenerTodos() orderby cli.Apellido, cli.Nombre select cli);
        dg_grillaClientes.DataKeyField = "idCliente";
        dg_grillaClientes.DataBind();
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
        Cliente clienteNuevo = new Cliente();
        string mensajesError = string.Empty;
        clienteNuevo.Apellido = txt_apellido.Text;
        clienteNuevo.Nombre = txt_nombre.Text;
        clienteNuevo.RazonSocial = txt_razonSocial.Text;
        clienteNuevo.FechaAlta = DateTime.Now;
        clienteNuevo.Email = txt_email.Text;
        TipoDoc tipoDoc = new TipoDoc()
        {
            IdTipoDoc = int.Parse(ddl_tipoDoc.SelectedItem.Value),
            Nombre = ddl_tipoDoc.SelectedItem.Text
        };
        clienteNuevo.TipoDoc = tipoDoc;
        int nroDocumento;
        if (int.TryParse(txt_doc.Text, out nroDocumento))
            clienteNuevo.NumeroDoc = nroDocumento;
        else
            mensajesError += "El numero de documento no es valido";
        clienteNuevo.Direccion = txt_direccion.Text;
        clienteNuevo.Cuit = int.Parse(txt_cuit.Text);
        clienteNuevo.Telefono = txt_caracteristicaTel.Text.ToString() + txt_numeroTel.Text.ToString();
        if (rbt_sexoMasc.Checked)
            clienteNuevo.Sexo = "Masculino";
        else
            clienteNuevo.Sexo = "Femenino";
        Localidad localidad = new Localidad()
        {
            IdLocalidad = int.Parse(ddl_localidad.SelectedValue),
            Nombre = ddl_localidad.SelectedItem.Text
        };
        clienteNuevo.Localidad = localidad;
        clienteNuevo.Saldo = float.Parse(txt_saldo.Text);

        DAO_Cliente.Insertar(clienteNuevo);

    }

    protected void dg_grillaClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        //int idCliente = dg_grillaClientes.sele
        Cliente cliente = DAO_Cliente.ObtenerPorID(idCliente);
        txt_apellido.Text = cliente.Apellido;
        txt_nombre.Text = cliente.Nombre;
    }

    private void Limpiar()
    {
        txt_nombre.Text = "";
        txt_apellido.Text = "";
        txt_caracteristicaTel.Text = "";
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
        rbt_sexoMasc.Checked = false;
    }

}
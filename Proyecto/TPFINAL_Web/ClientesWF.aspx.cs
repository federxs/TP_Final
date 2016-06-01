﻿using System;
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
        Page.Title = "Clientes";
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
            Cliente clienteNuevo = new Cliente();
            string mensajesError = string.Empty;
            clienteNuevo.Apellido = txt_apellido.Text;
            clienteNuevo.Nombre = txt_nombre.Text;
            clienteNuevo.RazonSocial = txt_razonSocial.Text;
            clienteNuevo.FechaAlta = DateTime.Now;
            clienteNuevo.Email = txt_email.Text;
            clienteNuevo.TipoDoc = int.Parse(ddl_tipoDoc.SelectedItem.Value);
            int nroDocumento;
            if (int.TryParse(txt_doc.Text, out nroDocumento))
                clienteNuevo.NumeroDoc = nroDocumento;
            else
                mensajesError += "El numero de documento no es valido";
            clienteNuevo.Direccion = txt_direccion.Text;
            clienteNuevo.Cuit = int.Parse(txt_cuit.Text);
            clienteNuevo.Telefono = long.Parse(txt_numeroTel.Text.Trim().ToString());
            if (rbt_sexoMasc.Checked)
                clienteNuevo.Sexo = "Masculino";
            else
                clienteNuevo.Sexo = "Femenino";
            clienteNuevo.Localidad = int.Parse(ddl_localidad.SelectedValue);
            clienteNuevo.Saldo = float.Parse(txt_saldo.Text);

            if (IdCliente.HasValue)
                DAO_Cliente.Actualizar(clienteNuevo);
            else
                DAO_Cliente.Insertar(clienteNuevo);
        }
    }

    protected void dg_grillaClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        //guardamos el id del cliente seleccionado
        int idCliente = int.Parse(gv_grillaClientes.SelectedDataKey.Value.ToString());
        IdCliente = idCliente;
        Cliente cliente = DAO_Cliente.ObtenerPorID(idCliente);
        string script = "alert(\"Hello!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
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
    }

    protected int? IdCliente
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
        rbt_sexoMasc.Checked = false;
    }

}
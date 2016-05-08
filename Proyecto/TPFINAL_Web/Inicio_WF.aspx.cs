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
        }
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
}
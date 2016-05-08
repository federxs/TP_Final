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
        }
    }

    private void cargarTipoDoc()
    {
        List<TipoDoc> listaTipoDoc = DAOs.DAO_TipoDoc.ObtenerTodos();
        ddl_tipoDoc.DataSource = listaTipoDoc;
        ddl_tipoDoc.DataTextField = "Nombre";
        ddl_tipoDoc.DataValueField = "IdTipoDoc";
        ddl_tipoDoc.DataBind();
        ddl_tipoDoc.SelectedValue = "1";
    }

    private void cargarProvincias()
    {
        List<Provincia> listaProvincias = DAOs.DAO_Provincia.ObtenerTodos();
        ddl_provincia.DataSource = listaProvincias;
        ddl_provincia.DataTextField = "Nombre";
        ddl_provincia.DataValueField = "idProvincia";
        ddl_provincia.DataBind();
    }

}
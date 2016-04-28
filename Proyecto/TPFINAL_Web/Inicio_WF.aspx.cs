using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio_WF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCombo();
        }
    }

    private void cargarCombo()
    {
        cmb_tipoDoc.Items.Add(new ListItem("DNI", "1"));
        cmb_tipoDoc.Items.Add(new ListItem("LE", "2"));
        cmb_tipoDoc.Items.Add(new ListItem("LC", "3"));
    }
}
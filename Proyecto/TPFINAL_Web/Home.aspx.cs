﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Home";
        if (Session["Usuario"] != null)
        {
            txtBienvenida.Text = "Bienvenido " + Convert.ToString(Session["Usuario"]) + "!";
            Response.AddHeader("REFRESH", "3;URL=ABMClientesWF.aspx");
        }
        else
            Response.Redirect("LoginWF.aspx");
    }
}
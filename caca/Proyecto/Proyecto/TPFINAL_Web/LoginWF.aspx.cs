using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
using Entidades;

public partial class LoginWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Login";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidarUsuario())
        {
            Session["Usuario"] = txtUsuario.Text;
            Response.Redirect("Home.aspx");
        }
        else
            Session["Usuario"] = string.Empty;
    }

    private bool ValidarUsuario()
    {
        bool resultado = false;
        Usuario usuario = DAO_Usuario.Obtener(txtUsuario.Text, txtClave.Text);
        if (usuario != null)
        {
            List<Rol> roles = DAO_Usuario.ObtenerRoles(usuario.IdUsuario);
            Session["Roles"] = roles;
            resultado = true;
        }
        return resultado;
    }
}
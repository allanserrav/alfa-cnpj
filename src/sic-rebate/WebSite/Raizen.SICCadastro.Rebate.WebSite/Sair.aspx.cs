using System;
using System.Web;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Sair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = new HttpCookie("CookieLogon", null);
            userCookie.HttpOnly = true;
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userCookie);

            HttpCookie perfilCookie = new HttpCookie("CookiePerfilRebate", null);
            perfilCookie.HttpOnly = true;
            perfilCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(perfilCookie);
            Response.Redirect("Login.aspx");
        }
    }
}
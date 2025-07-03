using Raizen.SICCadastro.Rebate.SAL.UserSystem;
using Raizen.SICCadastro.Rebate.Util;
using System;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.CurrentExecutionFilePath.ToUpper().Contains(".ASPX") && !Request.CurrentExecutionFilePath.ToUpper().Contains("LOGIN.ASPX"))
            {
                if (Request.Cookies.Count > 0)
                {
                    if (this.ExisteCookie())
                    {
                        if (string.IsNullOrEmpty(Request.Cookies["CookieLogon"].Value))
                            Response.Redirect("Login.aspx");
                    }
                    else
                        Response.Redirect("Login.aspx");
                }
                else
                    Response.Redirect("Login.aspx");

                //Validar cookie Rebate 
                if (Request.Cookies["CookiePerfilRebate"] == null)
                {
                    string perfil = null;
                    XmlNode strNode = null;
                    using (wsUserSystem servico = new wsUserSystem())
                    {
                        servico.Url = ConfigurationManager.AppSettings["WebServiceUserSystem"].ToString();
                        strNode = servico.GetUserPermissions(ConstantesRebate.SiglaSIC, Request.Cookies["CookieLogon"].Value.Trim());
                    }

                    if (strNode.OuterXml.ToUpper().ToString().Contains("<SUCCESS>FALSE</SUCCESS>"))
                        Response.Redirect("Login.aspx");

                    perfil = this.BuscarNomePerfil(strNode.OuterXml.ToString());
                    if (string.IsNullOrEmpty(perfil))
                        Response.Redirect("Login.aspx");

                    CriaCookie("CookiePerfilRebate", valor: perfil);
                }
            }

            if (Request.CurrentExecutionFilePath.ToUpper().Contains("LOGIN.ASPX") &&
                Request.Cookies.Count > 0 &&
                this.ExisteCookie() &&
                !string.IsNullOrEmpty(Request.Cookies["CookieLogon"].Value))
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool ExisteCookie()
        {
            HttpCookieCollection userCookie = Request.Cookies;
            System.Collections.IEnumerator e = userCookie.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Equals("CookieLogon"))
                {
                    return (true);
                }
            }
            return (false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private string BuscarNomePerfil(string xml)
        {
            XmlDocument doc = null;
            XmlNamespaceManager ns = null;
            XPathNavigator nav = null;
            try
            {
                doc = new XmlDocument();
                doc.LoadXml(xml);
                ns = new XmlNamespaceManager(doc.NameTable);
                nav = doc.CreateNavigator();

                return nav.SelectSingleNode("/usersystem/profiles/profile", ns).Value.ToString();
            }
            finally { if (doc != null) { doc = null; } if (ns != null) { ns = null; } }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        private void CriaCookie(string nome, string valor = null)
        {
            HttpCookie userCookie = null;
            try
            {
                userCookie = new HttpCookie(nome, valor);
                userCookie.HttpOnly = true;
                userCookie.Expires = DateTime.Now.AddMinutes(20); // Code scanning alerts #3 - pediu para tirar, então fixou em 5 sem usar o input da configuração. Colocado 20 a pedidos do negócio no Sic Cadastro, então colocamos aqui também
                Response.Cookies.Add(userCookie);
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Error("Erro ao criar o cookie", ex);
                throw;
            }
        }
    }
}
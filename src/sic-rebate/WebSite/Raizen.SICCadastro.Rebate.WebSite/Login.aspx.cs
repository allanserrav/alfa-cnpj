using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Configuration;
using Raizen.SICCadastro.Rebate.SAL.UserSystem;
using System.Web.Security;
using Raizen.SICCadastro.Rebate.Util;


namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "ShowMessage('" + error + "');", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            MessageControl message = null;
            string[] perfis = null;
            XmlNode strNode = null;

            try
            {
                using (wsUserSystem servico = new wsUserSystem())
                {
                    servico.Url = ConfigurationManager.AppSettings["WebServiceUserSystem"].ToString();
                    message = servico.LoginInApplication(ConstantesRebate.SiglaSIC, txtUsuario.Text, txtSenha.Text);
                }

                if (message.success)
                {
                    CriaCookie("CookieLogon", valor: new string[] { txtUsuario.Text });

                    using (wsUserSystem servico = new wsUserSystem())
                    {
                        servico.Url = ConfigurationManager.AppSettings["WebServiceUserSystem"].ToString();
                        strNode = servico.GetUserPermissions(ConstantesRebate.SiglaSIC, txtUsuario.Text);
                    }

                    perfis = this.BuscarNomePerfil(strNode.OuterXml.ToString()).ToArray();
                    CriaCookie("CookiePerfilRebate", valor: perfis);

                    FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);
                }
                else
                {
                    this.ShowAlertMessage("Usuário ou senha invalidos! Tente novamente");
                    this.CriaCookie("CookieLogon");
                    this.CriaCookie("CookiePerfilRebate");
                }
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                this.ShowAlertMessage("Ocorreu erro na tentativa de efetuar o login! Contate o Administrador");
            }
        }

        /// <summary>
        /// BuscarNomePerfil
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private IEnumerable<string> BuscarNomePerfil(string xml)
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

                var profiles = nav.Select("/usersystem/profiles/profile");
                var prof = profiles.OfType<XPathNavigator>().Select(e => e.Value);

                return prof;
            }
            finally { if (doc != null) { doc = null; } if (ns != null) { ns = null; } }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        private void CriaCookie(string nome, string[] valor = null)
        {
            HttpCookie userCookie = null;
            try
            {
                userCookie = new HttpCookie(nome, String.Join("|", valor));
                userCookie.HttpOnly = true;
                Response.Cookies.Add(userCookie);
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Error("Erro ao criar cookie", ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool ExisteCookie()
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
    }
}
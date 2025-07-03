using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.WebSite.Controls;
using System.Web.UI.HtmlControls;
using Raizen.SICCadastro.Rebate.SAL.UserSystem;
using System.Configuration;
using Raizen.SICCadastro.Rebate.Util;
using System.Net;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Site : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ucHeader ctrlUcHeader = null;
            Label lblNome = null;
            ucMainMenu ctrlMainMenu = null;
            PlaceHolder phlMenu = null;

            HtmlGenericControl strHtm = new HtmlGenericControl("div");
            ctrlUcHeader = (ucHeader)FindControl("header");
            lblNome = (Label)ctrlUcHeader.FindControl("lblNome");
            ctrlMainMenu = (ucMainMenu)FindControl("cMenu");

            phlMenu = (PlaceHolder)ctrlMainMenu.FindControl("phlMenu");

            if (this.ExisteCookie())
            {
                string cookieValue = WebUtility.HtmlEncode(Request.Cookies["CookieLogon"].Value.ToString());
                lblNome.Text = string.Format("Bem vindo, {0}. ", string.IsNullOrEmpty(cookieValue) ? "Visitante" : cookieValue);
                strHtm.InnerHtml = BuscarMenu(ConstantesRebate.SiglaSIC, cookieValue);
                phlMenu.Controls.Add(strHtm);
            }
            else
                lblNome.Text = string.Format("Bem vindo, Visitante");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sigla"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private string BuscarMenu(string Sigla, string usuario)
        {
            if (usuario != string.Empty)
            {
                using (wsUserSystem servico = new wsUserSystem())
                {
                    servico.Url = ConfigurationManager.AppSettings["WebServiceUserSystem"].ToString();
                    return servico.GetMenuByApplication(Sigla, usuario);
                }
            }
            else
                return string.Empty;
        }
    }
}
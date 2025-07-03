using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Raizen.SICCadastro.Rebate.Util
{
    public class Util
    {
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]

        /// <summary>
        /// Popula de forma genérica um DropDownList
        /// </summary>
        /// <typeparam name="T">Parâmetro genérico</typeparam>
        /// <param name="dataValue">Indica o campo da tabela que irá popular o valor do DropDownList</param>
        /// <param name="dataText">Indica o campo da tabela que irá popular o texto do DropDownList</param>
        /// <param name="ddl">Nome do DropDownList a ser populado</param>
        /// <param name="source">lista genérica utilizada para popular o DropDownList</param>
        public static void PopulaCombo(string dataValue, string dataText, DropDownList ddl, System.Collections.Generic.Dictionary<int, string> source, bool enabled = true, bool addNaoListado = false, string selectedText = "", string selectedValue = "")
        {
            ddl.Enabled = enabled;
            ddl.DataValueField = dataValue;
            ddl.DataTextField = dataText;

            if (source == null)
                ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataSource = source;
            ddl.DataBind();

            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("SELECIONE UMA OPÇÃO", "0"));
            if (addNaoListado)
                ddl.Items.Insert(1, new System.Web.UI.WebControls.ListItem("NÃO LISTADO", "-1"));

            if (!string.IsNullOrEmpty(selectedText))
            {
                ddl.SelectedItem.Text = selectedText.ToUpper();
            }
            if (!string.IsNullOrEmpty(selectedValue))
            {
                ddl.SelectedValue = selectedValue;
            }
        }

        /// <summary>
        /// Popula de forma genérica um DropDownList
        /// </summary>
        /// <typeparam name="T">Parâmetro genérico</typeparam>
        /// <param name="dataValue">Indica o campo da tabela que irá popular o valor do DropDownList</param>
        /// <param name="dataText">Indica o campo da tabela que irá popular o texto do DropDownList</param>
        /// <param name="ddl">Nome do DropDownList a ser populado</param>
        /// <param name="source">lista genérica utilizada para popular o DropDownList</param>
        public static void PopulaCombo(string dataValue, string dataText, DropDownList ddl, System.Collections.Generic.Dictionary<string, string> source, bool enabled = true, bool addNaoListado = false, string selectedText = "", string selectedValue = "")
        {
            ddl.Enabled = enabled;
            ddl.DataValueField = dataValue;
            ddl.DataTextField = dataText;

            if (source == null)
                ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataSource = source;
            ddl.DataBind();

            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("SELECIONE UMA OPÇÃO", "0"));
            if (addNaoListado)
                ddl.Items.Insert(1, new System.Web.UI.WebControls.ListItem("NÃO LISTADO", "-1"));

            if (!string.IsNullOrEmpty(selectedText))
            {
                ddl.SelectedItem.Text = selectedText.ToUpper();
            }
            if (!string.IsNullOrEmpty(selectedValue))
            {
                ddl.SelectedValue = selectedValue;
            }
        }

        /// <summary>
        /// Popula de forma genérica um DropDownList
        /// </summary>
        /// <typeparam name="T">Parâmetro genérico</typeparam>
        /// <param name="dataValue">Indica o campo da tabela que irá popular o valor do DropDownList</param>
        /// <param name="dataText">Indica o campo da tabela que irá popular o texto do DropDownList</param>
        /// <param name="ddl">Nome do DropDownList a ser populado</param>
        /// <param name="source">lista genérica utilizada para popular o DropDownList</param>
        public static void PopulaCombo<T>(string dataValue, string dataText, DropDownList ddl, IEnumerable<T> source)
        {
            PopulaCombo<T>(dataValue, dataText, ddl, source, "SELECIONE UMA OPÇÃO");
        }

        public static void PopulaCombo<T>(string dataValue, string dataText, DropDownList ddl, IEnumerable<T> source, string texto, string selectedValue = "")
        {
            ddl.DataValueField = dataValue;
            ddl.DataTextField = dataText;
            ddl.DataSource = source;
            try
            {
                ddl.DataBind();

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    ddl.SelectedValue = selectedValue;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(texto, "0"));
        }

        public static void ShowMessageList(string mensagem)
        {
            ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, HttpContext.Current.Handler.GetType(), "util_msg", "ShowMessageLista('" + mensagem + "');", true);
        }

        public static void ShowMessage(string mensagem)
        {
            ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, HttpContext.Current.Handler.GetType(), "util_msg", "ShowMessage('" + mensagem + "');", true);
        }

        public static void ShowMessage(string mensagem, string urlRedirecionar)
        {
            ScriptManager.RegisterStartupScript(HttpContext.Current.Handler as Page, HttpContext.Current.Handler.GetType(), "util_msg", "ShowMessageWithRedirect('" + mensagem + "', '" + urlRedirecionar + "');", true);
        }

        public static void ExecutarDownloadArquivo(byte[] arrayBytes, string nomeArquivo)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + nomeArquivo);
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.BinaryWrite(arrayBytes);
            HttpContext.Current.Response.End();
        }

        public static string LoginUsuario()
        {
            if (HttpContext.Current.Request.Cookies["CookieLogon"] != null)
                return HttpContext.Current.Request.Cookies["CookieLogon"].Value;

            return string.Empty;
        }
    }
}
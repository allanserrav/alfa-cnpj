using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Erro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadError(Server.GetLastError());
            }
        }

        private void LoadError(Exception objError)
        {
            if (objError != null)
            {
                StringBuilder lasterror = new StringBuilder();

                if (objError.Message != null)
                {
                    lasterror.AppendLine("Mensagem:");
                    lasterror.AppendLine(objError.Message);
                    lasterror.AppendLine();
                }

                if (objError.InnerException != null)
                {
                    lasterror.AppendLine("InnerException:");
                    lasterror.AppendLine(objError.InnerException.ToString());
                    lasterror.AppendLine();
                }

                if (objError.Source != null)
                {
                    lasterror.AppendLine("Source:");
                    lasterror.AppendLine(objError.Source);
                    lasterror.AppendLine();
                }

                if (objError.StackTrace != null)
                {
                    lasterror.AppendLine("StackTrace:");
                    lasterror.AppendLine(objError.StackTrace);
                    lasterror.AppendLine();
                }
                lasterror.AppendLine("Pagina: ");
                lasterror.AppendLine(Request.Url.AbsoluteUri);
                txtErro.Text = "Ocorreu um erro. Por favor entre em contato com o suporte.";
                COSAN.Framework.Util.LogError.Debug(lasterror.ToString());

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.WebSite.Controls
{
    public partial class ucPaginacaoRodape : System.Web.UI.UserControl
    {
        #region Eventos
        
        /// <summary>
        /// Evendo que é chamado quando a paginação deve informar algum comando.
        /// </summary>
        public event Action<TipoComandoPaginacao, int> Comando;

        #endregion

        #region Inicializador

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Eventos dos controles

        protected void ddlPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PageIndex = int.Parse(ddlPagina.SelectedValue) - 1;
            OnComando(TipoComandoPaginacao.PaginaSelecionada, this.PageIndex);
        }

        protected void imgPrimeiraPagina_Command(object sender, CommandEventArgs e)
        {
            this.PageIndex = 0;
            OnComando(TipoComandoPaginacao.Primeiro, 0);
        }

        protected void imgAnteriorPagina_Command(object sender, CommandEventArgs e)
        {
            if (TemPaginaAnterior)
                this.PageIndex--;

            OnComando(TipoComandoPaginacao.Anterior, this.PageIndex);
        }

        protected void imgProximaPagina_Command(object sender, CommandEventArgs e)
        {
            if (TemProximaPagina)
                this.PageIndex++;

            OnComando(TipoComandoPaginacao.Proximo, this.PageIndex);
        }

        protected void imgUltimaPagina_Command(object sender, CommandEventArgs e)
        {
            OnComando(TipoComandoPaginacao.Ultimo, this.TotalPaginas - 1);
        }

        #endregion

        #region Metodos privados

        private void OnComando(TipoComandoPaginacao tipoComandoPaginacao, int paginaAtual)
        {
            if (Comando != null)
            {
                Comando(tipoComandoPaginacao, paginaAtual);
            }
        }

        #endregion

        #region Metodos publicos
        
        public void Carregar(int totalPaginas, int pageIndex)
        {
            this.TotalPaginas = totalPaginas;
            this.PageIndex = pageIndex;

            ddlPagina.Items.Clear();
            for (int i = 1; i <= totalPaginas; i++)
            {
                var item = new ListItem(i.ToString());
                item.Selected = ((i - 1) == pageIndex);

                ddlPagina.Items.Add(item);
            }

            lblTotalPagina.Text = totalPaginas.ToString();
            imgPrimeiraPagina.Enabled = this.TemPaginaAnterior;
            imgAnteriorPagina.Enabled = this.TemPaginaAnterior;
            imgUltimaPagina.Enabled = this.TemProximaPagina;
            imgProximaPagina.Enabled = this.TemProximaPagina;
        }

        #endregion

        #region Propriedades

        private int TotalPaginas
        {
            get
            {
                return (int)ViewState["ucPaginacaoRodape_TotalPaginas"];
            }
            set
            {
                ViewState["ucPaginacaoRodape_TotalPaginas"] = value;
            }
        }

        private int PageIndex
        {
            get
            {
                return (int)ViewState["ucPaginacaoRodape_PageIndex"];
            }
            set
            {
                ViewState["ucPaginacaoRodape_PageIndex"] = value;
            }
        }

        public bool TemPaginaAnterior
        {
            get
            {
                return this.PageIndex > 0;
            }
        }

        public bool TemProximaPagina
        {
            get
            {
                return this.PageIndex < (this.TotalPaginas - 1);
            }
        }

        #endregion
    }
}
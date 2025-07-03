using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Util;
using System.Data;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using COSAN.Framework.Util;
using System.Text;
using Raizen.SICCadastro.Rebate.Util.Relatorio;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class logintegracao : System.Web.UI.Page
    {
        const string expressaoOrdenacaoValor = "DsAcaoSic";
        const string chaveDirecaoOrdenacaoGrid = "ordenacaoGrid";

        #region Propriedades

        /// <summary>
        /// Lista de Cálculo Rebate
        /// </summary>
        private IList<LogIntegracaoSic> ListaLogIntegracaoGrid
        {
            get
            {
                if (ViewState["ListaLogIntegracaoGrid"] == null)
                    ViewState["ListaLogIntegracaoGrid"] = new List<LogIntegracaoSic>();

                return ViewState["ListaLogIntegracaoGrid"] as IList<LogIntegracaoSic>;
            }
            set
            {
                ViewState["ListaLogIntegracaoGrid"] = value;
            }
        }

        /// <summary>
        /// Controle de ordenação do relatório
        /// </summary>
        private SortDirection OrdenacaoGrid
        {
            get
            {
                if (ViewState[chaveDirecaoOrdenacaoGrid] == null)
                    ViewState[chaveDirecaoOrdenacaoGrid] = SortDirection.Ascending;
                return (SortDirection)ViewState[chaveDirecaoOrdenacaoGrid];
            }
            set { ViewState[chaveDirecaoOrdenacaoGrid] = value; }
        }
        #endregion

        #region Eventos [Page]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                InicializarTela();
        }
        #endregion

        #region Eventos [Controles]
        /// <summary>
        /// grvResultado_RowCreated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvResultado_RowCreated(object sender, GridViewRowEventArgs e)
        {
           
        }

        /// <summary>
        /// grvResultado_PageIndexChanging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e) { }

        /// <summary>
        /// grvResultado_DataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvResultado_DataBound(object sender, EventArgs e)
        {
            #region Paginação
            //Custom Paging
            GridViewRow grvResultadoRow = grvResultado.BottomPagerRow;
            if (grvResultadoRow == null) return;

            //Get your Controls from the GridView, in this case 
            //I use a DropDown Control for Paging
            DropDownList ddCurrentPage = (DropDownList)grvResultadoRow.Cells[0].FindControl("ddCurrentPage");
            Label lblTotalPage = (Label)grvResultadoRow.Cells[0].FindControl("lblTotalPage");

            if (ddCurrentPage != null)
            {
                //Populate Pager
                for (int i = 0; i < grvResultado.PageCount; i++)
                {
                    int iPageNumber = i + 1;
                    ListItem myListItem = new ListItem(iPageNumber.ToString());

                    if (i == grvResultado.PageIndex)
                        myListItem.Selected = true;

                    ddCurrentPage.Items.Add(myListItem);
                }
            }

            // Populate the Page Count
            if (lblTotalPage != null)
                lblTotalPage.Text = grvResultado.PageCount.ToString();
            #endregion
        }

        /// <summary>
        /// grvResultado_RowDataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

        }

        //Change to a different page when the DropDown Page is changed
        protected void ddCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Paginate("ddcurrentpage");
        }

        //Images for |<, <<, >>, and >|
        protected void imgPageFirst_Command(object sender, CommandEventArgs e)
        {
            Paginate("first");
        }
        protected void imgPagePrevious_Command(object sender, CommandEventArgs e)
        {
            Paginate("prev");
        }
        protected void imgPageNext_Command(object sender, CommandEventArgs e)
        {
            Paginate("next");
        }
        protected void imgPageLast_Command(object sender, CommandEventArgs e)
        {
            Paginate("last");
        }

        /// <summary>
        /// Paginação
        /// </summary>
        /// <param name="command"></param>
        protected void Paginate(string command)
        {
            int iCurrentIndex = grvResultado.PageIndex;

            switch (command.ToLower())
            {
                case "first":
                    grvResultado.PageIndex = 0;
                    break;
                case "prev":
                    if (grvResultado.PageIndex != 0)
                        grvResultado.PageIndex = iCurrentIndex - 1;
                    break;
                case "next":
                    grvResultado.PageIndex = iCurrentIndex + 1;
                    break;
                case "last":
                    grvResultado.PageIndex = grvResultado.PageCount;
                    break;
                case "ddcurrentpage":
                    GridViewRow grvResultadoRow = grvResultado.BottomPagerRow;
                    DropDownList ddCurrentPage = (DropDownList)grvResultadoRow.Cells[0].FindControl("ddCurrentPage");
                    grvResultado.PageIndex = ddCurrentPage.SelectedIndex;
                    break;
            }

            carregarGrid();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chkHeaderAprovado", "javascript:HeaderClickSupport();", true);
        }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarlogIntegracao();
        }

        /// <summary>
        /// Botão de exportação dos dados do relatório para Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida que a data inicial seja menor ou igual a data final
                if (this.ListaLogIntegracaoGrid.Count == 0)
                {
                    ShowAlertMessage(Mensagens.ErroGerarExcel);
                    return;
                }

                //Conteúdo do Response
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                Response.Charset = string.Empty;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "LogIngegracao_" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                //Exporta 0
                Response.Write(CriarTabela(this.ListaLogIntegracaoGrid));
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            Response.End();
        }

        protected void grvResultado_Sorting(object sender, GridViewSortEventArgs e)
        {
            switch (e.SortExpression)
            {
                case expressaoOrdenacaoValor:
                    switch (OrdenacaoGrid)
                    {
                        case SortDirection.Ascending:
                            this.ListaLogIntegracaoGrid = this.ListaLogIntegracaoGrid.OrderByDescending(r => r.DtAcaoSic).ToList();
                            OrdenacaoGrid = SortDirection.Descending;
                            break;
                        case SortDirection.Descending:
                            this.ListaLogIntegracaoGrid = this.ListaLogIntegracaoGrid.OrderBy(r => r.DtAcaoSic).ToList();
                            OrdenacaoGrid = SortDirection.Ascending;
                            break;
                    }
                    break;

            }

            carregarGrid();

            //Coloca a busca na primeira página do grid
            grvResultado.PageIndex = 0;
            grvResultado.DataBind();
        }
        #endregion Eventos

        #region Métodos Privados
        /// <summary>
        /// Carrega o Grid
        /// </summary>
        private void carregarGrid()
        {
            var logIntegracao = Factory.CreateFactoryInstance().CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO");

            FiltroLogIntegracaoSic filtro = new FiltroLogIntegracaoSic();
            //Periodo
            if (!string.IsNullOrEmpty(txtPeriodoIni.Text) && !string.IsNullOrEmpty(txtPeriodoFim.Text))
            {
                string[] dataIni = txtPeriodoIni.Text.Split('/');
                string[] dataFim = txtPeriodoFim.Text.Split('/');
                filtro.DataPeriodoIni = new DateTime(Convert.ToInt16(dataIni[2]), Convert.ToInt16(dataIni[1]), Convert.ToInt16(dataIni[0]));
                filtro.DataPeriodoFim = new DateTime(Convert.ToInt16(dataFim[2]), Convert.ToInt16(dataFim[1]), Convert.ToInt16(dataFim[0]));
            }
            
            grvResultado.DataSource = Factory.CreateFactoryInstance().CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO").SelecionarFiltro(filtro);
            grvResultado.DataBind();
        }

        /// <summary>
        /// Exibe erros
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        /// <summary>
        /// Busca bonificações
        /// </summary>
        private void BuscarlogIntegracao()
        {
            try
            {
                //Valida que a Data digitada é válida
                DateTime tempDate;
                if (txtPeriodoIni.Text.Length > 0 && !DateTime.TryParse(txtPeriodoIni.Text, out tempDate))
                {
                    txtPeriodoIni.Focus();
                    ShowAlertMessage(Mensagens.AlertaPeriodoValido);
                    return;
                }

                if (txtPeriodoFim.Text.Length > 0 && !DateTime.TryParse(txtPeriodoFim.Text, out tempDate))
                {
                    txtPeriodoFim.Focus();
                    ShowAlertMessage(Mensagens.AlertaPeriodoValido);
                    return;
                }

                FiltroLogIntegracaoSic filtro = new FiltroLogIntegracaoSic();

                //Periodo
                if (!string.IsNullOrEmpty(txtPeriodoIni.Text) && !string.IsNullOrEmpty(txtPeriodoFim.Text))
                {
                    string[] dataIni = txtPeriodoIni.Text.Split('/');
                    string[] dataFim = txtPeriodoFim.Text.Split('/');
                    filtro.DataPeriodoIni = new DateTime(Convert.ToInt16(dataIni[2]), Convert.ToInt16(dataIni[1]), Convert.ToInt16(dataIni[0]));
                    filtro.DataPeriodoFim = new DateTime(Convert.ToInt16(dataFim[2]), Convert.ToInt16(dataFim[1]), Convert.ToInt16(dataFim[0]));
                }

                this.ListaLogIntegracaoGrid = 
                    Factory.CreateFactoryInstance().CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO").SelecionarFiltro(filtro);

                //Ordena
                this.ListaLogIntegracaoGrid = this.ListaLogIntegracaoGrid.OrderByDescending(b => b.DtAcaoSic).ToList();

                carregarGrid();

                //Coloca a busca na primeira página do grid
                grvResultado.PageIndex = 0;
                grvResultado.DataBind();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Inicializa a tela
        /// </summary>
        private void InicializarTela()
        {
            txtPeriodoIni.Text = string.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString().PadLeft(2, '0'),
                RebateUtil.GetPeriodoAtual().Month.ToString().PadLeft(2, '0'),
                RebateUtil.GetPeriodoAtual().Year.ToString());
            txtPeriodoFim.Text = string.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString().PadLeft(2, '0'),
                RebateUtil.GetPeriodoAtual().Month.ToString().PadLeft(2, '0'),
            RebateUtil.GetPeriodoAtual().Year.ToString());

            BuscarlogIntegracao();
            carregarGrid();
        }

        /// <summary>
        /// Verifica se é Gestor
        /// </summary>
        /// <returns></returns>
        string[] Permissao()
        {
            //recuperando um cookie através da chave
            HttpCookie cookie = Request.Cookies["CookiePerfilRebate"];

            //caso ele não tenha expirado e não seja nulo
            if (cookie != null)
            {
                //recuperando o valor do cookie
                return cookie.Value.Split('|');
            }

            return null;
        }

        /// <summary>
        /// REcupera o login do cookie
        /// </summary>
        /// <returns></returns>
        string RecuperarLoginCookie()
        {
            //recuperando um cookie através da chave
            HttpCookie cookie = Request.Cookies["CookieLogon"];

            //caso ele não tenha expirado e não seja nulo
            if (cookie != null)
                return cookie.Value;

            return string.Empty;
        }

        /// <summary>
        /// Monta o HTML para exportação Excel
        /// </summary>
        /// <param name="lstlogIntegracao">Coleção de dados do relatório</param>
        /// <returns>String com HTML da planilha</returns>
        private string CriarTabela(IList<LogIntegracaoSic> lstlogIntegracao)
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            //CABEÇALHO
            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Data da ação"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Ação"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Página"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "360px"), "Método"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Usuário"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (LogIntegracaoSic logIntegracao in lstlogIntegracao)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, logIntegracao.DtAcaoSic.HasValue ? logIntegracao.DtAcaoSic.Value.ToString("dd/MM/yyyy") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, logIntegracao.DsAcaoSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, logIntegracao.NmPaginaSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, logIntegracao.NmMetodoSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, logIntegracao.NmUsuarioSic));

                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }
        #endregion
    }
}
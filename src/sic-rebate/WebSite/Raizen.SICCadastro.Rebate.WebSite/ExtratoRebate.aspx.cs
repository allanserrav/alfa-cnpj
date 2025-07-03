using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.BLL;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using System.Web.UI.HtmlControls;
using System.Text;
using Raizen.SICCadastro.Rebate.Util;
using Raizen.SICCadastro.Rebate.Util.Relatorio;
using System.IO;
using COSAN.Framework.Util;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class ExtratoRebate : System.Web.UI.Page
    {
        #region Propriedades
        /// <summary>
        /// ISaldoRebateSicBLO
        /// </summary>
        private ISaldoRebateSicBLO _SaldoRebateSicBLOService;
        private ISaldoRebateSicBLO SaldoRebateSicBLOService
        {
            get
            {
                if (_SaldoRebateSicBLOService == null)
                    _SaldoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO");

                return _SaldoRebateSicBLOService;
            }
        }

        /// <summary>
        /// IRebateSicBLO
        /// </summary>
        private IRebateSicBLO _IRebateSicBLOService;
        private IRebateSicBLO RebateSicBLOService
        {
            get
            {
                if (_IRebateSicBLOService == null)
                    _IRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");

                return _IRebateSicBLOService;
            }
        }

        /// <summary>
        /// ITiporebateSicBLO
        /// </summary>
        private ITiporebateSicBLO _TiporebateSicBLOService { get; set; }
        private ITiporebateSicBLO TiporebateSicBLOService
        {
            get
            {
                if (_TiporebateSicBLOService == null)
                    _TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");

                return _TiporebateSicBLOService;
            }
        }

        /// <summary>
        /// Lista de Extrato
        /// </summary>
        private IList<SaldoRebateSic> ListaExtrato
        {
            get
            {
                if (ViewState["ListaExtrato"] == null)
                    ViewState["ListaExtrato"] = new List<SaldoRebateSic>();

                return ViewState["ListaExtrato"] as IList<SaldoRebateSic>;
            }
            set
            {
                ViewState["ListaExtrato"] = value;
            }
        }

        /// <summary>
        ///Armazena lista de tipos de rebate
        /// </summary>        
        private IList<TiporebateSic> ListaTipoRebateSic
        {
            get
            {
                if (ViewState["ListaTipoRebateSic"] == null)
                    ViewState["ListaTipoRebateSic"] = TiporebateSicBLOService.Selecionar();

                return ViewState["ListaTipoRebateSic"] as IList<TiporebateSic>;
            }
            set
            {
                ViewState["ListaTipoRebateSic"] = value;
            }
        }

        #endregion

        #region Eventos [Page]
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarGridExtrato();
        }
        #endregion

        #region Eventos [Controles]

        /// <summary>
        /// btnOK_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e) { }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida se as datas não estão em branco
                if (string.IsNullOrEmpty(txtIBM.Text) || string.IsNullOrEmpty(txtDataInicial.Text) || string.IsNullOrEmpty(txtDataFinal.Text))
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaExtrato);
                    return;
                }

                //Valida que a data inicial seja menor ou igual a data final
                if (Convert.ToDateTime(txtDataInicial.Text) > Convert.ToDateTime(txtDataFinal.Text))
                {
                    ShowAlertMessage(Mensagens.AlertaDataInicialMaiorDataFinal);
                    return;
                }

                //Prepara as datas para a busca por periodo
                DateTime dataDe = Convert.ToDateTime(txtDataInicial.Text);
                DateTime dataAte = Convert.ToDateTime(txtDataFinal.Text).AddDays(1).AddMilliseconds(-1);

                //Busca Rebate
                RebateSic rebate = RebateSicBLOService.SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = txtIBM.Text.Trim() });
                if (rebate.NrSeqRebateSic == null)
                {
                    ShowAlertMessage(Mensagens.ErroConsultaIBM);
                    return;
                }

                //Realiza a busca dos lancamentos no periodo
                this.ListaExtrato = SaldoRebateSicBLOService.SelecionarPeriodo(new SaldoRebateSic
                {
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                }, dataDe, dataAte);

                //Bind
                CarregarGridExtrato();
                if (this.ListaExtrato.Count > 20)
                    ShowAlertMessage(Mensagens.AlertaExibicaoPrimeiros);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida que a data inicial seja menor ou igual a data final
                if (this.ListaExtrato.Count == 0)
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "ExtratoRebate_" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                //Exporta 0
                Response.Write(CriarTabela());
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            Response.End();
        }

        #endregion

        #region Métodos Privados
        /// <summary>
        /// Exibe erros
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        /// <summary>
        /// Carrega Grid
        /// </summary>
        /// <param name="saldos"></param>
        private void CarregarGridExtrato()
        {
            grvExtrato.DataSource = this.ListaExtrato
                .OrderByDescending(e => e.NrSeqSaldoRebateSic).ToList()
                .Take(20).ToList()
                .OrderBy(e2 => e2.NrSeqSaldoRebateSic).ToList();
            grvExtrato.DataBind();
        }

        /// <summary>
        /// Gera tabela HTML
        /// </summary>
        /// <returns></returns>
        private string CriarTabela()
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Data Lançamento"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Valor Lançamento"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Saldo"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "600px"), "Observação"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (SaldoRebateSic item in this.ListaExtrato)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.DtLancamentoSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "180px"), string.Empty, item.VlLancamentoSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "180px"), string.Empty, item.VlSaldoAtualSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "600px"), string.Empty, item.DsObsComplementoSic));
                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }
        #endregion
    }
}
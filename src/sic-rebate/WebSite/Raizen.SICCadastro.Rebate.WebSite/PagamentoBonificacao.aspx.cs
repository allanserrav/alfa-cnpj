using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Raizen.SICCadastro.Rebate.Util.Relatorio;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class PagamentoBonificacao : System.Web.UI.Page
    {
        #region Propriedades
        /// <summary>
        /// Lista de Cálculo Faixa Historico Rebate
        /// </summary>
        private IList<ViewCalculoFaixaHistoricoRebate> ListaCalculoFaixa
        {
            get
            {
                if (ViewState["CalculoFaixaHistorico"] == null)
                    ViewState["CalculoFaixaHistorico"] = new List<ViewCalculoFaixaHistoricoRebate>();

                return ViewState["CalculoFaixaHistorico"] as IList<ViewCalculoFaixaHistoricoRebate>;
            }
            set
            {
                ViewState["CalculoFaixaHistorico"] = value;
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

        /// <summary>
        /// 
        /// </summary>
        private IViewGaClienteRebateSicBLO _ViewGAClienteRebateSICBLOService { get; set; }
        private IViewGaClienteRebateSicBLO ViewGAClienteRebateSICBLOService
        {
            get
            {
                if (_ViewGAClienteRebateSICBLOService == null)
                    _ViewGAClienteRebateSICBLOService = Factory.CreateFactoryInstance().CreateInstance<IViewGaClienteRebateSicBLO>("ViewGaClienteRebateSicBLO");

                return _ViewGAClienteRebateSICBLOService;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IViewGtClienteRebateSicBLO _ViewGtClienteRebateSICBLOService { get; set; }
        private IViewGtClienteRebateSicBLO ViewGtClienteRebateSICBLOService
        {
            get
            {
                if (_ViewGtClienteRebateSICBLOService == null)
                    _ViewGtClienteRebateSICBLOService = Factory.CreateFactoryInstance().CreateInstance<IViewGtClienteRebateSicBLO>("ViewGtClienteRebateSicBLO");

                return _ViewGtClienteRebateSICBLOService;
            }
        }

        /// <summary>
        /// Armazena Lista de GA
        /// </summary>
        private IList<ViewGaClienteRebateSic> ListaGaFranquiaSic
        {
            get
            {
                if (ViewState["ListaGaFranquiaSic"] == null)
                    ViewState["ListaGaFranquiaSic"] = ViewGAClienteRebateSICBLOService.Selecionar();

                return ViewState["ListaGaFranquiaSic"] as IList<ViewGaClienteRebateSic>;
            }
            set
            {
                ViewState["ListaGaFranquiaSic"] = value;
            }
        }

        /// <summary>
        /// Armazena Lista de Gt
        /// </summary>
        private IList<ViewGtClienteRebateSic> ListaGtFranquiaSic
        {
            get
            {
                if (ViewState["ListaGtRebateSic"] == null)
                    ViewState["ListaGtRebateSic"] = ViewGtClienteRebateSICBLOService.Selecionar();

                return ViewState["ListaGtRebateSic"] as IList<ViewGtClienteRebateSic>;
            }
            set
            {
                ViewState["ListaGtRebateSic"] = value;
            }
        }

        #endregion

        #region Eventos [Page]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindGA();
                this.BindGT();
            }
        }
        #endregion

        #region Eventos [Controles]

        protected void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PagamentoBonificacao.aspx", false);
        }

        protected void btnGerarExcel_Click(object sender, EventArgs e)
        {
            ViewCalculoFaixaHistoricoRebate CalculoFaixaHistorico = new ViewCalculoFaixaHistoricoRebate();
            List<ViewCalculoFaixaHistoricoRebate> ListaCalculoFaixa = new List<ViewCalculoFaixaHistoricoRebate>();
            List<ViewCalculoFaixaHistoricoRebate> ListaCalculoFaixaFull = new List<ViewCalculoFaixaHistoricoRebate>();
            try
            {
                //Periodo
                if (!string.IsNullOrEmpty(txtPeriodo.Text))
                {
                    string[] data = txtPeriodo.Text.Split('/');
                    CalculoFaixaHistorico.DtPeriodoSic = new DateTime(Convert.ToInt16(data[1]), Convert.ToInt16(data[0]), 1);
                    CalculoFaixaHistorico.DtPeriodoVolume = CalculoFaixaHistorico.DtPeriodoSic.Value.AddMonths(-1);
                }
                //IBM
                if (!string.IsNullOrEmpty(txtIBM.Text))
                    CalculoFaixaHistorico.NrIbmClienteSic = txtIBM.Text;
                //GA
                if (ddlGA.SelectedItem.Value != "0")
                    CalculoFaixaHistorico.NmGalojaClienteSic = ddlGA.SelectedItem.Text;

                //Tipo Rebate
                List<int> lstTiposRebate = new List<int>();
                if (chkFaixaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_FAIXA_VOLUME)).NrSeqTiporebateSic.Value);
                if (chkMediaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME)).NrSeqTiporebateSic.Value);
                if (chkSomaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME)).NrSeqTiporebateSic.Value);
                if(chkEscalonado.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_ESCALONADO)).NrSeqTiporebateSic.Value);

                //Realiza a busca dos lancamentos no periodo e suas faixas Cadastradas                                
                ListaCalculoFaixaFull = Factory.CreateFactoryInstance().CreateInstance<IViewCalculoFaixaHistoricoRebateBLO>("ViewCalculoFaixaHistoricoRebateBLO").Selecionar(
                    CalculoFaixaHistorico).ToList();

                if (ListaCalculoFaixaFull != null && ListaCalculoFaixaFull.Count != 0)
                {
                    foreach (int item in lstTiposRebate)
                    {
                        ListaCalculoFaixa.AddRange(ListaCalculoFaixaFull.FindAll(x => x.NrSeqTiporebateSic.Value == item));
                    }

                    //Status
                    if (ddlSituacao.SelectedValue == "1")
                        ListaCalculoFaixa = (from l in ListaCalculoFaixa
                                             where l.NrSeqStatusCalculoRebateSic == (int)StatusCalculoRebate.AptoPagamento ||
                                                   l.NrSeqStatusCalculoRebateSic == (int)StatusCalculoRebate.InformacoesInconsistentes ||
                                                   l.NrSeqStatusCalculoRebateSic == (int)StatusCalculoRebate.NaoAtingiuVolumeMinimo
                                             select l).ToList();
                    else if (ddlSituacao.SelectedValue != "0")
                        ListaCalculoFaixa = (from l in ListaCalculoFaixa
                                             where l.NrSeqStatusCalculoRebateSic == int.Parse(ddlSituacao.SelectedItem.Value)
                                             select l).ToList();
                    if (ddlGA.SelectedValue != "0")
                        ListaCalculoFaixa = (from l in ListaCalculoFaixa
                                             where l.NmGalojaClienteSic.Contains(ddlGA.SelectedItem.Text.Replace(" ", ""))
                                             select l).ToList();
                    if (!string.IsNullOrEmpty(lstGT.SelectedValue))
                        ListaCalculoFaixa = (from l in ListaCalculoFaixa
                                             where l.NmGtlojaClienteSic.Trim().Contains(lstGT.SelectedItem.Text.Trim())
                                             select l).ToList();
                    //Filtra o Canal
                    if (ddlCanal.SelectedValue != "0")
                        ListaCalculoFaixa = ListaCalculoFaixa.Where(b => b.NmCanalClienteSic.ToUpper().Trim().Equals(ddlCanal.SelectedValue.ToUpper().Trim())).ToList();

                    if (ListaCalculoFaixa.Count > 0)
                    {
                        //Conteúdo do Response
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                        Response.Charset = string.Empty;
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "PagamentoRebate_" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                        //Exporta 
                        string tabela = CriarTabela(ListaCalculoFaixa);
                        Response.Write(tabela);
                    }
                    else
                        ShowAlertMessage(Mensagens.AlertaFiltroPagamentoBonificacaoVazio);
                }
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            if (ListaCalculoFaixa != null && ListaCalculoFaixa.Count != 0)
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
        /// Gera tabela HTML
        /// </summary>
        /// <returns></returns>
        private string CriarTabela(List<ViewCalculoFaixaHistoricoRebate> ListaCalculoFaixa)
        {
            var rebates = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Selecionar();

            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";
            //string colspan = "colspan=5";

            StringBuilder linhas = new StringBuilder();
            StringBuilder linhasInternas = new StringBuilder();
            StringBuilder cabecalho = new StringBuilder();
            StringBuilder cabecalhoInterno = new StringBuilder();
            StringBuilder totalUltimalinha = new StringBuilder();
            //string IBM = "0";
            #region OLD
            //decimal? TotalBonificacaoSomado = 0;
            //decimal? TotalBonificacaoCalculado = 0;
            //decimal? TotalVolumeCompradoSomado = 0;
            //bool Aditivo = false;

            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "60px"), "EMP")); //1
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "CEGR"));//2
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "IBM"));//3
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Pagador"));//4
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Fornecedor"));//5
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "Razão Social"));//6
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Data Assinatura"));//7
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Fim da Cond. Atual"));//8
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Valor Debito"));//9
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Canal"));//10
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "GT"));//11
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "Situação"));//12
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "Tipo/Período"));//13

            ////cabecalhoInterno.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "60px"), string.Empty));//1
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Categoria"));//2
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Vol. Contr. Periodo"));//3
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Vol. Max."));//4
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Vol. Min."));//5
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "Vol. Comprado"));//6
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Vl. Bonificação"));//7
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "% Minimo"));//8
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "% Maximo"));//9
            //cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Bonificação Unit."));//10
            ////cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), string.Empty));//11
            ////cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), string.Empty));//12
            ////cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), string.Empty));//13 
            #endregion

            var categorias = ListaCalculoFaixa
                .Select(r => r.NmCategoriaSic)
                .Distinct()
                .ToList();

            cabecalho.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH + "text-align:center;", "660px"), "colspan=\"5\"", "Dados Cliente"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH + "text-align:center;", "480px"), "colspan=\"3\"", "Pagamento"));
            foreach (var categoria in categorias) cabecalho.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH + "text-align:center;", "180px"), "colspan=\"2\"", categoria));
            cabecalho.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH + "text-align:center;", "900px"), "colspan=\"3\"", "Dados de Venda"));

            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            var cabecalho2 = new StringBuilder();
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "60px"), string.Empty, "Empresa"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "80px"), string.Empty, "IBM"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "300px"), string.Empty, "Razão Social"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "150px"), string.Empty, "Tipo Rebate"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "70px"), string.Empty, "Período<br />Cálculo"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "80px"), string.Empty, "Bonificação<br/>Total"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "200px"), string.Empty, "Data<br/>Pagto."));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "200px"), string.Empty, "Obs."));
            foreach (var categoria in categorias)
            {
                cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "80px"), string.Empty, "Vol.<br/>Consumido"));
                cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "100px"), string.Empty, "Bonificação"));
            }
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "300px"), string.Empty, "Consultor"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "300px"), string.Empty, "Gerente"));
            cabecalho2.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTH, "300px"), string.Empty, "Diretor"));

            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho2.ToString()));

            var calculosAgrupados = ListaCalculoFaixa
                .GroupBy(r => r.NrSeqRebateSic);

            foreach (var calculoAgrupado in calculosAgrupados)
            {
                var rebateSic = rebates.SingleOrDefault(r => r.NrSeqRebateSic == calculoAgrupado.First().NrSeqRebateSic);

                var colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "60px"), string.Empty, calculoAgrupado.First().NmEmpresaSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "80px") + TabelaHTML.FormatoTexto, string.Empty, calculoAgrupado.First().NrIbmClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "300px"), string.Empty, calculoAgrupado.First().NmRazsociallojaFranquiaSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "150px"), string.Empty, calculoAgrupado.First().NmTiporebateSic ));

                var periodicidadePagto = string.Empty;
                if (rebateSic != null)
                {
                    bool cosan = calculoAgrupado.First().NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
                    bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
                    periodicidadePagto = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? "Mensal" : "Trimestral";
                }

                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + "border-right:1px solid #CCC;", "70px"), string.Empty, periodicidadePagto));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "80px") + TabelaHTML.FormatoMoeda, string.Empty, calculoAgrupado.First().VlBonificacaoTotalSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, calculoAgrupado.First().NmStatusCalculoRebateSic + (calculoAgrupado.First().NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago) ? " " + calculoAgrupado.First().DtPagamentoSic.Value.ToString("dd/MM/yyyy") : string.Empty)));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + "border-right:1px solid #CCC;", "200px"), string.Empty, string.Empty));

                foreach (var categoria in categorias)
                {
                    var volumeCategoria = calculoAgrupado
                        .Where(r => r.NmCategoriaSic == categoria)
                        .Sum(r => r.VlVolumeCompradoSic ?? 0);
                    var bonificacaoCategoria = calculoAgrupado
                        .Where(r => r.NmCategoriaSic == categoria)
                        .Sum(r => r.VlBonificacaoCalculadoSic ?? 0);

                    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "80px") + TabelaHTML.FormatoMoeda, string.Empty, volumeCategoria));
                    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + "border-right:1px solid #CCC;", "100px") + TabelaHTML.FormatoMoeda, string.Empty, bonificacaoCategoria));
                }

                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "300px"), string.Empty, calculoAgrupado.First().NmGtlojaClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "300px"), string.Empty, string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "300px"), string.Empty, string.Empty));

                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            #region OLD
            //foreach (ViewCalculoFaixaHistoricoRebate item in ListaCalculoFaixa)
            //{
            //    StringBuilder colunas = new StringBuilder();
            //    StringBuilder colunasInternas = new StringBuilder();
            //    StringBuilder totalInterno = new StringBuilder();

            //    #region OLD
            //    //if (IBM != item.NrIbmClienteSic)
            //    //{
            //    //if (IBM != "0")
            //    //{
            //    //    totalInterno.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "460px"), colspan, "<b>Total:</b>"));

            //    //    //Trata Aditivo
            //    //    if (Aditivo)
            //    //    {
            //    //        totalInterno.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, string.Empty));
            //    //        totalInterno.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalBonificacaoSomado + "</b>"));
            //    //    }
            //    //    else
            //    //    {
            //    //        totalInterno.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalVolumeCompradoSomado + "</b>"));
            //    //        totalInterno.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalBonificacaoSomado + "</b>"));
            //    //    }

            //    //    linhasInternas.AppendLine(string.Format(TabelaHTML.TR, styleTR, totalInterno.ToString()));

            //    //    TotalBonificacaoSomado = 0;
            //    //    TotalVolumeCompradoSomado = 0;
            //    //    linhas.AppendLine(linhasInternas.ToString());
            //    //    linhasInternas.Remove(0, linhasInternas.Length);
            //    //    linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, string.Empty));
            //    //    linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));
            //    //}

            //    //IBM = item.NrIbmClienteSic; 
            //    #endregion

            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "60px"), string.Empty, item.NmEmpresaSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NrCegrpostoClienteSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrIbmClienteSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrCodigopagadorRebateSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrCodigofornecedorRebateSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmRazsociallojaFranquiaSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoData, string.Empty, item.DtAssinaturacontratoRebateSic.ToString()));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoData, string.Empty, item.DtFimvigenciaRebateSic.ToString()));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlDebitoSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmCanalClienteSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmGtlojaClienteSic));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmStatusCalculoRebateSic + (item.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago) ? " " + item.DtPagamentoSic.Value.ToString("dd/MM/yyyy") : string.Empty)));
            //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Concat(item.StAditivoSic.Value ? "Aditivo " : "Bonificação ", txtPeriodo.Text)));

            //        //linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            //        //linhasInternas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalhoInterno.ToString()));

            //        if (!item.StAditivoSic.Value)
            //        {
            //            //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "60px"), string.Empty, string.Empty));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmCategoriaSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeContratadoSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeMaximoSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeMinimoSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeCompradoSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlBonificacaoCalculadoSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlPercminimoRebateSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlPercmaximoRebateSic));
            //            colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlBonificacaoRebateSic));
            //            //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));
            //            //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));
            //            //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));

            //            //linhasInternas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunasInternas.ToString()));
            //        }

            //        linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));

            //    #region OLD
            //    //}
            //    //else
            //    //{
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "60px"), string.Empty, item.NmEmpresaSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NrCegrpostoClienteSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrIbmClienteSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrCodigopagadorRebateSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoTexto, string.Empty, item.NrCodigofornecedorRebateSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmRazsociallojaFranquiaSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoData, string.Empty, item.DtAssinaturacontratoRebateSic.ToString()));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoData, string.Empty, item.DtFimvigenciaRebateSic.ToString()));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlDebitoSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmCanalClienteSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmGtlojaClienteSic));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmStatusCalculoRebateSic + (item.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago) ? " " + item.DtPagamentoSic.Value.ToString("dd/MM/yyyy") : string.Empty)));
            //    //    colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Concat(item.StAditivoSic.Value ? "Aditivo " : "Bonificação ", txtPeriodo.Text)));


            //    //    if (!item.StAditivoSic.Value)
            //    //    {
            //    //        //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "60px"), string.Empty, string.Empty));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmCategoriaSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeContratadoSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeMaximoSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeMinimoSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlVolumeCompradoSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlBonificacaoCalculadoSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlPercminimoRebateSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlPercmaximoRebateSic));
            //    //        colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px") + TabelaHTML.FormatoMoeda, string.Empty, item.VlBonificacaoRebateSic));
            //    //        //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));
            //    //        //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));
            //    //        //colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, string.Empty));

            //    //        //linhasInternas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunasInternas.ToString()));
            //    //    }

            //    //    linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            //    //}

            //    //TotalBonificacaoSomado = TotalBonificacaoSomado + item.VlBonificacaoCalculadoSic;
            //    //TotalVolumeCompradoSomado = TotalVolumeCompradoSomado + item.VlVolumeCompradoSic;
            //    //TotalBonificacaoCalculado = item.VlBonificacaoTotalSic;
            //    //Aditivo = item.StAditivoSic.Value; 
            //    #endregion
            //} 
            #endregion

            #region OLD
            //totalUltimalinha.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "460px"), colspan, "<b>Total:<\b>"));

            ////Verifica se é aditivo
            //if (Aditivo)
            //{
            //    // Insere ultima linha e totalizador                
            //    totalUltimalinha.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, string.Empty));
            //    totalUltimalinha.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalBonificacaoCalculado + "</b>"));
            //}
            //else
            //{
            //    // Insere ultima linha e totalizador
            //    totalUltimalinha.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalVolumeCompradoSomado + "</b>"));
            //    totalUltimalinha.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoMoeda, "100px"), string.Empty, "<b>" + TotalBonificacaoSomado + "</b>"));
            //}

            //linhasInternas.AppendLine(string.Format(TabelaHTML.TR, styleTR, totalUltimalinha.ToString()));
            //linhas.AppendLine(linhasInternas.ToString()); 
            #endregion

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }

        /// <summary>
        /// Carrega o Grid
        /// </summary>
        private void BindGA()
        {
            ListItem selecione = new ListItem { Text = "SELECIONE", Value = "0", Selected = true };
            List<ViewGaClienteRebateSic> ListaGaRebateSic = new List<ViewGaClienteRebateSic>();
            ListaGaRebateSic = Factory.CreateFactoryInstance().CreateInstance<IViewGaClienteRebateSicBLO>("ViewGaClienteRebateSicBLO").Selecionar().ToList();
            ddlGA.DataSource = ListaGaRebateSic.OrderBy(x => x.NmGalojaClienteSic);
            ddlGA.DataTextField = "NmGalojaClienteSic";
            ddlGA.DataBind();
            ddlGA.Items.Insert(0, selecione);
        }

        /// <summary>
        /// Carrega o Grid
        /// </summary>
        private void BindGT()
        {
            lstGT.DataSource = ListaGtFranquiaSic.OrderBy(x => x.NmGtlojaClienteSic);
            lstGT.DataTextField = "NmGtlojaClienteSic";
            lstGT.DataValueField = "NmGtlojaClienteSic";
            lstGT.DataBind();
        }

        #endregion

    }
}
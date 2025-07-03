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
    public partial class CalculoRebate : System.Web.UI.Page
    {
        const string expressaoOrdenacaoValor = "ValorBonificacao";
        const string chaveDirecaoOrdenacaoGrid = "ordenacaoGrid";

        #region Propriedades
        /// <summary>
        /// ICalculoRebateSicBLO
        /// </summary>
        private ICalculoRebateSicBLO _CalculoRebateSicBLOService;
        private ICalculoRebateSicBLO CalculoRebateSicBLOService
        {
            get
            {
                if (_CalculoRebateSicBLOService == null)
                    _CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");

                return _CalculoRebateSicBLOService;
            }
        }

        /// <summary>
        /// ICalculoRebateSicBLO
        /// </summary>
        private ICalculoRebateFaixaSicBLO _CalculoRebateFaixaSicBLOService;
        private ICalculoRebateFaixaSicBLO CalculoRebateFaixaSicBLOService
        {
            get
            {
                if (_CalculoRebateFaixaSicBLOService == null)
                    _CalculoRebateFaixaSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO");

                return _CalculoRebateFaixaSicBLOService;
            }
        }

        /// <summary>
        /// ICalculoBonificacaoRebateBLO
        /// </summary>
        private ICalculoBonificacaoRebateBLO _CalculoBonificacaoRebateBLOService;
        private ICalculoBonificacaoRebateBLO CalculoBonificacaoRebateBLOService
        {
            get
            {
                if (_CalculoBonificacaoRebateBLOService == null)
                    _CalculoBonificacaoRebateBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");

                return _CalculoBonificacaoRebateBLOService;
            }
        }

        /// <summary>
        /// Retorna Instancia de StatusCalculoRebateHistoricoSicBLO
        /// </summary>
        private IStatusCalculoRebateHistoricoSicBLO _StatusCalculoRebateHistoricoSicBLOService { get; set; }
        private IStatusCalculoRebateHistoricoSicBLO StatusCalculoRebateHistoricoSicBLOService
        {
            get
            {
                if (_StatusCalculoRebateHistoricoSicBLOService == null)
                    _StatusCalculoRebateHistoricoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicBLO>("StatusCalculoRebateHistoricoSicBLO");

                return _StatusCalculoRebateHistoricoSicBLOService;
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
        /// ITiporebateSicBLO
        /// </summary>
        private IFaixarebateSicBLO _FaixarebateSicBLO { get; set; }
        private IFaixarebateSicBLO FaixarebateSicBLOService
        {
            get
            {
                if (_FaixarebateSicBLO == null)
                    _FaixarebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicBLO>("FaixarebateSicBLO");

                return _FaixarebateSicBLO;
            }
        }

        /// <summary>
        /// Lista de Cálculo Rebate
        /// </summary>
        private IList<BonificacaoGrid> ListaBonificacaoGrid
        {
            get
            {
                if (ViewState["ListaBonificacaoGrid"] == null)
                    ViewState["ListaBonificacaoGrid"] = new List<BonificacaoGrid>();

                return ViewState["ListaBonificacaoGrid"] as IList<BonificacaoGrid>;
            }
            set
            {
                ViewState["ListaBonificacaoGrid"] = value;
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
        /// Indica se a busca solicitada foi pelo calculo retroativo
        /// </summary>        
        private Boolean? FiltroBuscaCalculoRetroativo
        {
            get
            {
                return ViewState["FiltroBuscaCalculoRetroativo"] as Boolean?;
            }
            set
            {
                ViewState["FiltroBuscaCalculoRetroativo"] = value;
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
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal ||
                    e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chkAprovado = (CheckBox)e.Row.Cells[1].FindControl("chkAprovado");
                CheckBox chkHeaderAprovado = (CheckBox)this.grvResultado.HeaderRow.FindControl("chkHeaderAprovado");
                chkAprovado.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkHeaderAprovado.ClientID);
            }
        }

        /// <summary>
        /// grvDetalhe_RowCreated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvDetalhe_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal ||
                    e.Row.RowState == DataControlRowState.Alternate))
            {
                if (e.Row.Cells[0].Text.Equals("TOTAIS:"))
                    e.Row.BackColor = System.Drawing.Color.LightGray;
            }
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
        /// grvResultado_DataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (this.FiltroBuscaCalculoRetroativo.HasValue && this.FiltroBuscaCalculoRetroativo.Value)
            {
                if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[12].Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.Contains("Acerto"))
                {
                    e.Row.Cells[7].Text = string.Empty;
                    e.Row.Cells[8].Text = string.Empty;
                }
            }
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
            GetLinhasSelecionadas();
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
        /// btnOutrasOpcoes_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOutrasOpcoes_Click(object sender, EventArgs e)
        {
            //Confirmar                        
            int codigoCalculoRebate = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            lblMensagemOK.Text = string.Concat(Mensagens.ConfirmarOutrasOperacoes, Environment.NewLine, Mensagens.AlertaPerdaSelecao);
            btnOK.CommandArgument = string.Concat(ConstantesRebate.OUTRAS_OPCOES, "#", codigoCalculoRebate);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnDetalhe_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                int totalMesesProporcional = 3;
                divProporcional.Visible = false;
                lblProporcional.Text = string.Empty;
                int CodigoCalculoRebate = Convert.ToInt32(((ImageButton)sender).CommandArgument);
                BonificacaoGrid bonificacao = this.ListaBonificacaoGrid.First(b => b.CodigoCalculoRebate == CodigoCalculoRebate);
                lblIbmCliente.Text = bonificacao.CodigoIBM;
                lblCliente.Text = bonificacao.NomeCliente;
                lblTipoContrato.Text = bonificacao.DescricaoTipoRebate;
                lblFrequenciaPagto.Text = bonificacao.PeriodicidadePagamento;
                bonificacao.ValorBonificacao = (bonificacao.ValorBonificacao == null ? 0 : bonificacao.ValorBonificacao);
                lblValorTotal.Text = bonificacao.ValorBonificacao.Value.ToString("N2");
                lblPeriodo.Text = bonificacao.PeriodoCalculo;

                //CONTROLE VOLUME
                if (bonificacao.VolumeConsumido.HasValue || bonificacao.VolumeLimite.HasValue)
                {
                    lblVolumeLimite.Text = "";
                    lblVolumeComprado.Text = "";
                }

                //Busca Detalhes
                IList<BonificacaoGridDetalhe> listaOriginal = CalculoRebateFaixaSicBLOService
                    .SelecionarBonificacaoDetalhe(CodigoCalculoRebate, bonificacao.DataPeriodoCalculo);

                //Busca Detalhes quando contrato termina antes do ultimo mês do período - Correção Ago/2013
                if (listaOriginal.Count == 0 && bonificacao.PeriodicidadePagamento.Equals("Trimestral")
                    && !bonificacao.TipoBonificacao.Equals("Aditivo"))
                {
                    listaOriginal = CalculoRebateFaixaSicBLOService
                        .SelecionarBonificacaoDetalhe(CodigoCalculoRebate, bonificacao.DataPeriodoCalculo.AddMonths(-1));

                    totalMesesProporcional--;

                    if (listaOriginal.Count == 0)
                    {
                        listaOriginal = CalculoRebateFaixaSicBLOService
                            .SelecionarBonificacaoDetalhe(CodigoCalculoRebate, bonificacao.DataPeriodoCalculo.AddMonths(-2));

                        totalMesesProporcional--;
                    }
                }

                //Preparar Lista
                List<int> grupos = listaOriginal.Select(l => l.SeqGrupo.Value).Distinct().ToList();
                List<BonificacaoGridDetalhe> listaAgrupada = new List<BonificacaoGridDetalhe>();

                //Visibilidade
                var aditivo = bonificacao.Aditivo == true;
                if (!aditivo)
                {

                    //Bind
                    if (bonificacao.DescricaoTipoRebate.ToUpperInvariant().Contains(Util.ConstantesRebate.TIPO_REBATE_ESCALONADO))
                    {
                        //Agrupa as faixas
                        foreach (int seq in grupos)
                        {
                            List<BonificacaoGridDetalhe> listaGrupo = listaOriginal.Where(b => b.SeqGrupo.Value == seq).ToList();

                            if (listaGrupo == null || listaGrupo.Count == 0)
                                continue;

                            BonificacaoGridDetalhe bonificacaoDet = new BonificacaoGridDetalhe();
                            bonificacaoDet.BonificacaoUnitaria = listaGrupo.First().BonificacaoUnitaria;
                            bonificacaoDet.NomeCategoria = string.Join(" / ", listaGrupo.Select(b => b.NomeCategoria).ToArray());
                            bonificacaoDet.PercentualMáximo = listaGrupo.First().PercentualMáximo;
                            bonificacaoDet.PercentualMinimo = listaGrupo.First().PercentualMinimo;
                            bonificacaoDet.VolumeContratado = listaGrupo.First().VolumeContratado * (bonificacao.Mensal ? 1 : totalMesesProporcional);
                            bonificacaoDet.ValorBonificacaoCategoria = listaGrupo.First().ValorBonificacaoCategoria;
                            bonificacaoDet.VolumeCompradoPeriodo = listaGrupo.First().VolumeCompradoPeriodo;
                            bonificacaoDet.VolumeMaximo = listaGrupo.First().VolumeMaximo;
                            bonificacaoDet.VolumeMinimo = listaGrupo.First().VolumeMinimo;
                            listaAgrupada.Add(bonificacaoDet);
                        }

                        grvDetalheEscalonado.DataSource = listaAgrupada;
                        grvDetalheEscalonado.DataBind();
                        grvDetalheEscalonado.Visible = true;
                        grvDetalhe.Visible = false;
                    }
                    else
                    {
                        //Agrupa as faixas
                        foreach (int seq in grupos)
                        {
                            List<BonificacaoGridDetalhe> listaGrupo = listaOriginal.Where(b => b.SeqGrupo.Value == seq).ToList();

                            if (listaGrupo == null || listaGrupo.Count == 0)
                                continue;

                            BonificacaoGridDetalhe bonificacaoDet = new BonificacaoGridDetalhe();
                            bonificacaoDet.BonificacaoUnitaria = listaGrupo.First().BonificacaoUnitaria;
                            bonificacaoDet.NomeCategoria = string.Join(" / ", listaGrupo.Select(b => b.NomeCategoria).ToArray());
                            bonificacaoDet.PercentualMáximo = listaGrupo.First().PercentualMáximo;
                            bonificacaoDet.PercentualMinimo = listaGrupo.First().PercentualMinimo;
                            bonificacaoDet.VolumeContratado = listaGrupo.First().VolumeContratado * (bonificacao.Mensal ? 1 : totalMesesProporcional);
                            bonificacaoDet.ValorBonificacaoCategoria = listaGrupo.Sum(b => b.ValorBonificacaoCategoria);
                            bonificacaoDet.VolumeCompradoPeriodo = listaGrupo.Sum(b => b.VolumeCompradoPeriodo);
                            bonificacaoDet.VolumeMaximo = listaGrupo.First().VolumeMaximo;
                            bonificacaoDet.VolumeMinimo = listaGrupo.First().VolumeMinimo;
                            listaAgrupada.Add(bonificacaoDet);
                        }

                        grvDetalhe.DataSource = listaAgrupada;
                        grvDetalhe.DataBind();
                        grvDetalhe.Visible = true;
                        grvDetalheEscalonado.Visible = false;
                    }
                    lblInfo.Visible = false;
                }
                else
                {
                    grvDetalhe.Visible = grvDetalheEscalonado.Visible = false;
                    lblInfo.Visible = true;
                    lblInfo.Text = Mensagens.AlertaGridDetalheAditivo;
                }


                //PAGAMENTO PROPORCIONAL PARA O GUARDA-CHUVA
                var listaPagamentoProporcional = Factory
                    .CreateFactoryInstance()
                    .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                    .Selecionar(new CalculoRebateProporcionalSic { NrSeqCalculoRebateSic = bonificacao.CodigoCalculoRebate })
                    .ToList();


                if (listaPagamentoProporcional.Count > 0)
                {
                    //RECUPERA O CONTRATO REBATE DO CALCULO
                    var rebateSic = Factory
                        .CreateFactoryInstance()
                        .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                        .SelecionarPrimeiro(new RebateSic { NrSeqRebateSic = bonificacao.CodigoRebate });

                    var colecaoIbmCodigoFornecedor = new List<IBMFornecedor>();
                    if (rebateSic != null) colecaoIbmCodigoFornecedor.Add(new IBMFornecedor
                    {
                        IBM = rebateSic.NrIbmRebateSic,
                        CodigoFornecedor = rebateSic.NrCodigofornecedorRebateSic
                    });
                    //RECUPERA O LISTA DE MATRIZFILIAL
                    colecaoIbmCodigoFornecedor.AddRange(Factory
                        .CreateFactoryInstance()
                        .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                        .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebateSic.NrSeqRebateSic })
                        .Select(r => new IBMFornecedor
                        {
                            IBM = r.NrIbmFilialSic,
                            CodigoFornecedor = r.NrCdfornecedorFilialSic
                        }));

                    var listaPagamentoProporcionalGrid = new List<BonificacaoProporcionalGrid>();
                    foreach (var pagamentoProporcional in listaPagamentoProporcional)
                    {
                        var ibmCodigoFornecedor = colecaoIbmCodigoFornecedor.Single(r => r.IBM == pagamentoProporcional.NrIbmClienteSic);
                        listaPagamentoProporcionalGrid.Add(new BonificacaoProporcionalGrid
                        {
                            NrCodigoFornecedorRebateSic = ibmCodigoFornecedor.CodigoFornecedor,
                            NrIbmClienteSic = ibmCodigoFornecedor.IBM,
                            VlValorBonificacaoProporcionalSic = pagamentoProporcional.VlValorBonificacaoProporcionalSic.Value,
                            VlVolumeCalculadoSic = pagamentoProporcional.VlVolumeCalculadoSic.Value
                        });
                    }

                    pnlPagamentoProporcional.Visible = true;
                    grvPagamentoProporcional.DataSource = listaPagamentoProporcionalGrid;
                    grvPagamentoProporcional.DataBind();
                }
                else
                {
                    pnlPagamentoProporcional.Visible = false;
                }

                var encerradoPorVolume = false;
                //O CONTRATO TEM CONTROLE POR VOLUME?
                var controlaVolume = false;
                var rebate = Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                    .SelecionarPrimeiro(new RebateSic
                    {
                        NrSeqRebateSic = bonificacao.CodigoRebate
                    });
                if (rebate != null && rebate.StControlevolume.HasValue) controlaVolume = rebate.StControlevolume.Value;
                if (controlaVolume)
                {
                    //QUAL VOLUME?
                    decimal? volumeLimite;
                    volumeLimite = rebate.VlVolumelimiteRebateSic ?? rebate.VlVolumecontratadoRebateSic;
                    //JA ATINGIU O VOLUME?
                    var volumeComprado = Factory
                        .CreateFactoryInstance()
                        .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                        .SelecionarVolumeComprado(rebate, bonificacao.DataPeriodoCalculo.AddDays(-1D));
                    //ATINGIU O VOLUME?
                    if (volumeLimite < volumeComprado) encerradoPorVolume = true;
                }

                if (totalMesesProporcional < 3 || encerradoPorVolume)
                {
                    divProporcional.Visible = true;
                    lblProporcional.Text = string.Format("Cálculo proporcional ao fim do contrato");
                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowDialogDetalhe();"), true);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroConsultarDetalhe);
            }
        }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarBonificacao();
        }

        /// <summary>
        /// lnkSelecionarTodosBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSelecionarTodosBuscar_Click(object sender, EventArgs e)
        {
            foreach (BonificacaoGrid item in ListaBonificacaoGrid)
                item.Selecionado = true;

            carregarGrid();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chkHeaderAprovado", "javascript:HeaderClickSupport();", true);
        }

        /// <summary>
        /// lnkLimparSelecao_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLimparSelecao_Click(object sender, EventArgs e)
        {
            foreach (BonificacaoGrid item in ListaBonificacaoGrid)
                item.Selecionado = false;

            carregarGrid();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chkHeaderAprovado", "javascript:HeaderClickSupport();", true);
        }

        /// <summary>
        /// btnAprovar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAprovar_Click(object sender, EventArgs e)
        {
            //Validação
            List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
            if (selecionados.Count == 0)
            {
                ShowAlertMessage(Mensagens.AlertaSelecaoNula);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarAprovar));
            btnOK.CommandArgument = ConstantesRebate.APROVAR_ANALISTA;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnEnviar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //Validação
            List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
            if (selecionados.Count == 0)
            {
                ShowAlertMessage(Mensagens.AlertaSelecaoNula);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarEnviar));
            btnOK.CommandArgument = ConstantesRebate.ENVIAR_APROVACAO_GERENCIAL;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnAprovar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAprovarGerente_Click(object sender, EventArgs e)
        {
            //Validação
            List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
            if (selecionados.Count == 0)
            {
                ShowAlertMessage(Mensagens.AlertaSelecaoNula);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarAprovar));
            btnOK.CommandArgument = ConstantesRebate.APROVAR_GERENTE;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnEnviar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultarDebito_Click(object sender, EventArgs e)
        {
            //Validação
            List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
            if (selecionados.Count == 0)
            {
                ShowAlertMessage(Mensagens.AlertaSelecaoNula);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarConsultaDebito), Environment.NewLine, Mensagens.AlertaPerdaSelecao);
            btnOK.CommandArgument = ConstantesRebate.CONSULTA_DEBITO;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnReprovarGerente_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReprovar_Click(object sender, EventArgs e)
        {
            //Validação
            List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
            if (selecionados.Count == 0)
            {
                ShowAlertMessage(Mensagens.AlertaSelecaoNula);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarReprovar));
            btnOK.CommandArgument = ConstantesRebate.REPROVAR_GERENTE;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// btnOK_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            string[] argumentos = (((Button)sender).CommandArgument).Split('#');

            switch (argumentos[0])
            {
                case (ConstantesRebate.APROVAR_ANALISTA):
                    AprovarAnalista();
                    break;
                case (ConstantesRebate.ENVIAR_APROVACAO_GERENCIAL):
                    EnviarGerente();
                    break;
                case (ConstantesRebate.APROVAR_GERENTE):
                    AprovarGerente();
                    break;
                case (ConstantesRebate.REPROVAR_GERENTE):
                    ReprovarGerente();
                    break;
                case (ConstantesRebate.CONSULTA_DEBITO):
                    ConsultarDebitos();
                    break;
                case (ConstantesRebate.OUTRAS_OPCOES):
                    RedirecionarOutrasOpções(argumentos[1]);
                    break;
                default:
                    ExecutarPaginacao(argumentos[0]);
                    break;
            }
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
                if (this.ListaBonificacaoGrid.Count == 0)
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
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "CalculoRebate_" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                //Exporta 0
                Response.Write(CriarTabela(this.ListaBonificacaoGrid));
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
                            this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.OrderByDescending(r => r.ValorBonificacao).ToList();
                            OrdenacaoGrid = SortDirection.Descending;
                            break;
                        case SortDirection.Descending:
                            this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.OrderBy(r => r.ValorBonificacao).ToList();
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
            grvResultado.DataSource = this.ListaBonificacaoGrid;
            grvResultado.DataBind();

            if (this.ListaBonificacaoGrid.Count > 0)
            {
                decimal totalMoeda = ListaBonificacaoGrid.Sum(b => b.ValorBonificacao) ?? 0;
                lblTotalMoeda.Text = ListaBonificacaoGrid.Sum(b => b.ValorBonificacao).Value.ToString("N2");
                lblTotal.Text = ListaBonificacaoGrid.Count.ToString();
                this.divHeader.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chkHeaderAprovado", "javascript:HeaderClickSupport();", true);
            }
            else
            {
                this.divHeader.Visible = false;
            }
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
        /// Redireciona para a tela de outras opções
        /// </summary>
        /// <param name="sender"></param>
        private void RedirecionarOutrasOpções(string codigo)
        {
            string url = string.Empty;

            try
            {
                int codigoCalculo = Convert.ToInt32(codigo);
                BonificacaoGrid bonificacao = this.ListaBonificacaoGrid.FirstOrDefault(c => c.CodigoCalculoRebate == codigoCalculo);
                int codigoRebate = bonificacao.CodigoRebate.Value;
                Context.Items["IBM"] = bonificacao.CodigoIBM;
                Context.Items["RazaoSocial"] = bonificacao.NomeCliente;
                Context.Items["TipoContrato"] = bonificacao.DescricaoTipoRebate;
                Context.Items["FrequenciaPagto"] = bonificacao.PeriodicidadePagamento;
                Context.Items["StatusCliente"] = bonificacao.CodigoStatus;
                Context.Items["UrlVoltar"] = Request.UrlReferrer.AbsoluteUri;
                url = string.Format("~/DetalheClienteRebate.aspx?NrRebate={0}&NrCalculo={1}", codigoRebate, codigoCalculo == codigoRebate ? 0 : codigoCalculo);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            Server.Transfer(url);
        }

        /// <summary>
        /// Busca bonificações
        /// </summary>
        private void BuscarBonificacao()
        {
            try
            {
                // Valida se checado a aprovação massiva então a informação do período é obrigatório.
                if (chkAprovacaoMassiva.Checked && txtPeriodo.Text.Length <= 0)
                {
                    txtPeriodo.Focus();
                    ShowAlertMessage(Mensagens.AlertaPeriodoValido);
                    return;
                }
                
                //Valida que a Data digitada é válida
                DateTime tempDate;
                if (txtPeriodo.Text.Length > 0 && !DateTime.TryParse(txtPeriodo.Text, out tempDate))
                {
                    txtPeriodo.Focus();
                    ShowAlertMessage(Mensagens.AlertaPeriodoValido);
                    return;
                }

                FiltroBonificacaoGrid filtro = new FiltroBonificacaoGrid();

                //Periodo
                if (!string.IsNullOrEmpty(txtPeriodo.Text))
                {
                    string[] data = txtPeriodo.Text.Split('/');
                    filtro.DataPeriodo = new DateTime(Convert.ToInt16(data[1]), Convert.ToInt16(data[0]), 1);
                }

                //IBM
                filtro.CodigoIBM = txtIBM.Text;

                //Tipo Rebate
                List<string> lstTiposRebate = new List<string>();
                if (chkFaixaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_FAIXA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkMediaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkSomaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkEscalonado.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.FirstOrDefault(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_ESCALONADO)).NrSeqTiporebateSic.ToString());

                //Situação
                string situacao = ddlSituacao.SelectedValue;
                if (situacao != ConstantesRebate.DDL_SELECIONE)
                {
                    switch (situacao)
                    {
                        case ConstantesRebate.DDL_PENDENTE_PAGAMENTO:
                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.AptoPagamento), ",",
                                Convert.ToInt16(StatusCalculoRebate.InformacoesInconsistentes), ",",
                                Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo));
                            break;
                        case ConstantesRebate.DDL_APROVADO_ANALISTA:
                            filtro.AprovadoAnalista = true;
                            break;
                        case ConstantesRebate.DDL_ENVIADO_APROVACAO_GERENCIAL:
                            filtro.EnviadoGestor = true;
                            break;
                        case ConstantesRebate.DDL_ENVIADO_PAGAMENTO:
                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento));
                            break;
                        case ConstantesRebate.DDL_PAGO:
                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.Pago));
                            break;
                        case ConstantesRebate.DDL_CANCELADO:
                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.Cancelado));
                            break;
                        case ConstantesRebate.DDL_CALCULO_RETROATIVO_PENDENTE:
                            filtro.CalculoRetroativo = true;
                            break;
                        case ConstantesRebate.DDL_PENDENTE_DEBITO:
                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.PendenteDebito));
                            break;
                    }
                }

                //Verifica se o tipo foi informado                
                if (lstTiposRebate.Count == 0)
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaTipoRebate);
                    return;
                }
                else
                    filtro.ListaTipoRebate = string.Join(",", lstTiposRebate.Select(r => r).ToArray());

                //Aprovação Massiva
                filtro.AprovacaoMassiva = chkAprovacaoMassiva.Checked;

                //Verifica se os filtros foram informados
                if (!filtro.FiltroInformado)
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaSemFiltros);
                    return;
                }

                //Verifica qual busca deve executar
                if ((!filtro.AprovacaoMassiva.Value) && filtro.CalculoRetroativo.HasValue && filtro.CalculoRetroativo.Value)
                {
                    this.FiltroBuscaCalculoRetroativo = true;
                    this.ListaBonificacaoGrid = CalculoRebateSicBLOService.SelecionarRebatesSemCalculo(filtro);
                }
                else if (!filtro.CalculoRetroativo.HasValue)
                {
                    this.FiltroBuscaCalculoRetroativo = false;
                    this.ListaBonificacaoGrid = CalculoRebateSicBLOService.SelecionarBonificacao(filtro);
                }
                else
                {
                    this.ListaBonificacaoGrid.Clear();
                }

                //Ordena
                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.OrderBy(b => b.CodigoIBM).ToList();

                //Filtra o Canal
                if (ddlCanal.SelectedValue != "0")
                    this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => b.NomeCanal.ToUpper().Trim().Equals(ddlCanal.SelectedValue.ToUpper().Trim())).ToList();

                //Marca os Cálculos Apto Pagamento
                foreach (BonificacaoGrid item in ListaBonificacaoGrid)
                {
                    if ((!filtro.AprovacaoMassiva.Value) &&
                        (item.CodigoStatus == Convert.ToInt16(StatusCalculoRebate.AptoPagamento) && 
                        (item.AprovadoAnalista.HasValue && !item.AprovadoAnalista.Value)))
                        item.Selecionado = true;
                }

                //Marca todos os itens
                if ((filtro.AprovadoAnalista.HasValue && filtro.AprovadoAnalista.Value) ||
                    (filtro.EnviadoGestor.HasValue && filtro.EnviadoGestor.Value) ||
                    (filtro.CalculoRetroativo.HasValue && filtro.CalculoRetroativo.Value))
                    this.ListaBonificacaoGrid.ToList().ForEach(b => b.Selecionado = true);

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
        /// Devolve as linhas selecionadas
        /// </summary>
        /// <returns></returns>
        private List<BonificacaoGrid> GetLinhasSelecionadas()
        {
            List<BonificacaoGrid> selecionados = new List<BonificacaoGrid>();

            //Recupera linhas selecionadas no grid view
            foreach (GridViewRow row in grvResultado.Rows)
            {
                string codigo = grvResultado.DataKeys[row.RowIndex].Value.ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = (CheckBox)row.FindControl("chkAprovado");

                    if (this.ListaBonificacaoGrid.Count == 0)
                        continue;

                    this.ListaBonificacaoGrid.First(b => b.CodigoCalculoRebate.ToString().Equals(codigo)).Selecionado = check.Checked;

                    if (check.Checked)
                        selecionados.Add(this.ListaBonificacaoGrid.First(b => b.CodigoCalculoRebate.ToString().Equals(codigo)));
                }
            }

            //Adiciona os itens que já estavam selecionados em outras páginas
            foreach (BonificacaoGrid item in ListaBonificacaoGrid)
            {
                BonificacaoGrid selecionado = selecionados.FirstOrDefault(s => s.CodigoCalculoRebate == item.CodigoCalculoRebate);
                if (selecionado == null && item.Selecionado)
                    selecionados.Add(item);
            }

            return selecionados;
        }

        /// <summary>
        /// Inicializa a tela
        /// </summary>
        private void InicializarTela()
        {
            bool gestor = this.Permissao().Any(_ => _ == ConstantesRebate.SICCadastroAvancado);
            bool isConsulta = this.Permissao().Any(_ => _ == ConstantesRebate.SICConsulta);

            //Verifica se é Gestor
            if (gestor)
            {
                ddlSituacao.SelectedValue = ConstantesRebate.DDL_ENVIADO_APROVACAO_GERENCIAL;
                tdAnalista.Visible = false;
                BuscarBonificacao();
            }
            else //Senão é Analista
            {
                tdGerente.Visible = false;
                txtPeriodo.Text = string.Format("{0}/{1}", RebateUtil.GetPeriodoAtual().Month.ToString().PadLeft(2, '0'),
                    RebateUtil.GetPeriodoAtual().Year.ToString());
                ddlSituacao.SelectedValue = ConstantesRebate.DDL_PENDENTE_PAGAMENTO;
                BuscarBonificacao();
            }
            //E se for perfil consulta esconde alguns botões
            if (isConsulta)
            {
                tdCalculo.Visible = false;
                tdAnalista.Visible = false;
                tdGerente.Visible = false;
                tdExportar.Visible = true;
            }

            carregarGrid();
        }

        /// <summary>
        /// Aprovar Gerente
        /// </summary>
        /// <param name="selecionados"></param>
        private void EnviarGerente()
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
                List<CalculoRebateSic> listCalculo = CarregarCalculoRebate(selecionados);

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (!listCalculo.TrueForAll(c => c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Cancelado)
                   && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Pago)
                   && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }

                //Se algum item selecionado não foi aprovado pelo analista, não deixa enviar a lista
                if (!listCalculo.TrueForAll(c => c.StAprovadoAnalistaSic.HasValue && c.StAprovadoAnalistaSic.Value))
                {
                    ShowAlertMessage(Mensagens.AlertaSelecaoEnviarSemAprovar);
                    return;
                }

                //Se algum item selecionado já foi enviado pelo analista, não deixa executar a ação novamente
                if (listCalculo.FirstOrDefault(c => c.StEnviadoAprovacaoGerenteSic.HasValue && c.StEnviadoAprovacaoGerenteSic.Value) != null)
                {
                    ShowAlertMessage(Mensagens.AlertaReenviarGerente);
                    return;
                }

                //Salva no Banco os rebates aprovados
                foreach (CalculoRebateSic calculo in listCalculo)
                {
                    calculo.StEnviadoAprovacaoGerenteSic = true;
                    calculo.DtEnviadoAprovacaoGerenteSic = RebateUtil.GetDataAtual();
                    this.CalculoRebateSicBLOService.Atualizar(calculo);
                }

                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => !b.Selecionado).ToList();
                carregarGrid();

                //Envio de e-mail!
                string login = RecuperarLoginCookie();
                AgendarEmail(ConstantesRebate.ENVIAR_APROVACAO_GERENCIAL, login);

            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Aprovar Gerente
        /// </summary>
        /// <param name="selecionados"></param>
        private void AprovarGerente()
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
                List<CalculoRebateSic> listCalculo = CarregarCalculoRebate(selecionados);

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (!listCalculo.TrueForAll(c => c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Cancelado)
                   && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Pago)
                   && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }

                //Se algum item selecionado não foi  enviado pelo analista, não deixa prosseguir
                if (!listCalculo.TrueForAll(c => c.StEnviadoAprovacaoGerenteSic.HasValue && c.StEnviadoAprovacaoGerenteSic.Value))
                {
                    ShowAlertMessage(Mensagens.AlertaAprovarGerenteSemEnviar);
                    return;
                }

                //Se algum item selecionado já foi enviado pelo analista, não deixa executar a ação novamente
                if (listCalculo.FirstOrDefault(c => c.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago)) != null)
                {
                    ShowAlertMessage(Mensagens.AlertaReaprovarGerente);
                    return;
                }

                //Salva no Banco os rebates aprovados
                foreach (CalculoRebateSic calculo in listCalculo)
                {
                    //Atualiza Calculo
                    calculo.StAprovadoGerenteSic = true;
                    calculo.DtAprovadoGerenteSic = RebateUtil.GetDataAtual();
                    calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento);
                    this.CalculoRebateSicBLOService.Atualizar(calculo);

                    //Insere Historico
                    StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic();
                    historico.NrSeqCalculoRebateSic = calculo.NrSeqCalculoRebateSic;
                    historico.DtAlteracaoSic = RebateUtil.GetDataAtual();
                    historico.NmLoginSic = ConstantesRebate.USUARIO_SERVICO;
                    historico.NrSeqStatusCalculoRebateSic = calculo.NrSeqStatusCalculoRebateSic;
                    historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_ENVIADO_PAGAMENTO,
                        calculo.NrSeqRebateSic, calculo.DtPeriodoSic.Value.ToShortDateString(),
                        calculo.VlBonificacaoTotalSic.Value.ToString("N2"));
                    StatusCalculoRebateHistoricoSicBLOService.Incluir(historico);
                }

                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => !b.Selecionado).ToList();
                carregarGrid();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Reprovar Gerente
        /// </summary>
        /// <param name="selecionados"></param>
        private void ReprovarGerente()
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
                List<CalculoRebateSic> listCalculo = CarregarCalculoRebate(selecionados);

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (!listCalculo.TrueForAll(c => c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Cancelado)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Pago)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }

                //Se algum item selecionado não  foi  enviado pelo analista, não deixa prosseguir
                if (!listCalculo.TrueForAll(c => c.StEnviadoAprovacaoGerenteSic.HasValue && c.StEnviadoAprovacaoGerenteSic.Value))
                {
                    ShowAlertMessage(Mensagens.AlertaReprovarGerenteSemEnviar);
                    return;
                }

                //Salva no Banco os rebates aprovados
                foreach (CalculoRebateSic calculo in listCalculo)
                {
                    calculo.StEnviadoAprovacaoGerenteSic = false;
                    this.CalculoRebateSicBLOService.Atualizar(calculo);
                }

                //Envio de e-mail!
                string login = RecuperarLoginCookie();
                AgendarEmail(ConstantesRebate.REPROVAR_GERENTE, login);

                //Carregar Grid
                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => !b.Selecionado).ToList();
                carregarGrid();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Aprovar Analista
        /// </summary>
        /// <param name="selecionados"></param>
        private void AprovarAnalista()
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
                List<CalculoRebateSic> listCalculo = CarregarCalculoRebate(selecionados);

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (!listCalculo.TrueForAll(c => c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Cancelado)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Pago)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }

                //Se algum item selecionado já foi aprovado pelo analista, não deixa prosseguir
                if (listCalculo.FirstOrDefault(c => c.StAprovadoAnalistaSic.HasValue && c.StAprovadoAnalistaSic.Value) != null)
                {
                    ShowAlertMessage(Mensagens.AlertaReaprovarAnalista);
                    return;
                }

                //Salva no Banco os rebates aprovados
                foreach (CalculoRebateSic calculo in listCalculo)
                {
                    if (calculo.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.AptoPagamento))
                    {
                        calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.VerificandoDebitos);
                        calculo.StAprovadoAnalistaSic = true;
                        calculo.DtAprovadoAnalistaSic = RebateUtil.GetDataAtual();
                    }
                    else
                    {
                        calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AptoPagamento);
                        calculo.StAprovadoAnalistaSic = true;
                        calculo.DtAprovadoAnalistaSic = RebateUtil.GetDataAtual();
                    }
                    this.CalculoRebateSicBLOService.Atualizar(calculo);
                }

                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => !b.Selecionado).ToList();
                carregarGrid();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Busca os cálculos originarios da bonificação
        /// </summary>
        private List<CalculoRebateSic> CarregarCalculoRebate(List<BonificacaoGrid> selecionados)
        {
            List<CalculoRebateSic> listCalculo = new List<CalculoRebateSic>();

            //Aprova todas as linhas marcadas                    
            foreach (BonificacaoGrid s in selecionados)
                listCalculo.Add(this.CalculoRebateSicBLOService.SelecionarPrimeiro(new CalculoRebateSic { NrSeqCalculoRebateSic = s.CodigoCalculoRebate }));

            return listCalculo;
        }

        /// <summary>
        /// Pagina o Grid
        /// </summary>
        /// <param name="argumento"></param>
        /// <param name="selecionados"></param>
        private void ExecutarPaginacao(string argumento)
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();
                if (selecionados != null && selecionados.Count > 0)
                    Paginate(argumento);

                carregarGrid();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// ConsultarDebitos
        /// </summary>
        /// <param name="selecionados"></param>
        private void ConsultarDebitos()
        {
            try
            {
                List<BonificacaoGrid> selecionados = GetLinhasSelecionadas();

                //Distinct nos valores repetidos...
                selecionados = selecionados.Distinct(new ComparaBonificacaoGridPorCodigoRebate()).ToList();

                //Transforma selecionados em cáluclos rebate
                List<CalculoRebateSic> listCalculo = (from s in selecionados
                                                      select new CalculoRebateSic
                                                      {
                                                          NrSeqCalculoRebateSic = s.CodigoCalculoRebate,
                                                          NrSeqRebateSic = s.CodigoRebate,
                                                          NrSeqStatusCalculoRebateSic = s.CodigoStatus
                                                      }).ToList();

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (!listCalculo.TrueForAll(c => c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Cancelado)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.Pago)
                    && c.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }

                //Processa os débitos para os cliente selecionados
                CalculoBonificacaoRebateBLOService.ProcessarDebitos(listCalculo);

                //Refazer a busca
                BuscarBonificacao();
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Agenda o envio de e-mail
        /// </summary>
        /// <param name="acao"></param>
        /// <param name="login"></param>
        private void AgendarEmail(string acao, string login = null)
        {
            try
            {
                bool gestor = this.Permissao().Any(_=>_ == ConstantesRebate.SICCadastroAvancado);
                string perfil = string.Empty;

                //Consulta Mensagem do Email a enviar
                MensagemSic mensagemSic = new MensagemSic { NmMensagemSic = acao.Trim().ToUpper() };
                List<MensagemSic> lstMensagem = (List<MensagemSic>)Factory.CreateFactoryInstance().CreateInstance<IMensagemSicBLO>("MensagemSicBLO").Selecionar(mensagemSic);

                //Monta QueryString que identifica o perfil
                switch (acao)
                {
                    case ConstantesRebate.ENVIAR_APROVACAO_GERENCIAL:
                        perfil = "&pfl=" + ConstantesRebate.GESTOR;
                        break;
                    case ConstantesRebate.REPROVAR_GERENTE:
                        perfil = "&pfl=" + ConstantesRebate.ANALISTA;
                        break;
                    default:
                        break;
                }

                //Pega a url completa e monta a url direta ao resultado
                string[] url = Request.Url.AbsoluteUri.Split('/');
                StringBuilder strLink = new StringBuilder().AppendFormat("{0}//{1}/Rebate/login.aspx?ReturnUrl=CalculoRebate.aspx{2}", url[0], url[2], perfil);

                //Preenche os dados do agendamento
                AgendamentoMensagemSic agendamento = new AgendamentoMensagemSic();
                agendamento.DtAgendamentoMensagemSic = DateTime.Now;
                agendamento.StAgengamentoMensagemSic = true;
                agendamento.NrSeqMensagemSic = lstMensagem[0].NrSeqMensagemSic;

                if (gestor)
                {
                    agendamento.NmGrupodeAgengamentoMensagemSic = ConstantesRebate.GrupoGestao;
                    agendamento.NmGrupoparaAgendamentoMensagemSic = ConstantesRebate.GrupoOperacoes;
                }
                else
                {
                    agendamento.NmGrupodeAgengamentoMensagemSic = ConstantesRebate.GrupoOperacoes;
                    agendamento.NmGrupoparaAgendamentoMensagemSic = ConstantesRebate.GrupoGestao;
                }

                agendamento.NmUserSolicitacaoSic = login;
                agendamento.NmLinkAgendamentoMensagemSic = strLink.ToString();

                //Inclui o agendamento para o envio do email
                Factory.CreateFactoryInstance().CreateInstance<IAgendamentoMensagemSicBLO>("AgendamentoMensagemSicBLO").Incluir(agendamento);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
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
        /// <param name="lstBonificacao">Coleção de dados do relatório</param>
        /// <returns>String com HTML da planilha</returns>
        private string CriarTabela(IList<BonificacaoGrid> lstBonificacao)
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            //CABEÇALHO
            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "IBM"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Fornecedor"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "360px"), "Cliente"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Calculo"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Bonificação"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Bonif. Ant."));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Diferença"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Débito"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Dt. Pagto."));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "180px"), "Status"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (BonificacaoGrid bonificacao in lstBonificacao)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.CodigoIBM));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.CodigoIBMFornecedor));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.NomeCliente));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.TipoBonificacao));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.ValorBonificacao.HasValue ? bonificacao.ValorBonificacao.Value.ToString("N") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.ValorBonificacaoAnterior.HasValue && (bonificacao.Acerto.HasValue && !bonificacao.Acerto.Value) ? bonificacao.ValorBonificacaoAnterior.Value.ToString("N") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.PercentualDiferencaBonificacao.HasValue && (bonificacao.Acerto.HasValue && !bonificacao.Acerto.Value) ? bonificacao.PercentualDiferencaBonificacao.Value.ToString("P0") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.ValorDebito.HasValue ? bonificacao.ValorDebito.Value.ToString("N") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.DataPagamento.HasValue ? bonificacao.DataPagamento.Value.ToString("dd/MM/yyyy") : string.Empty));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, bonificacao.DescricaoStatus));

                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }
        #endregion
    }
}
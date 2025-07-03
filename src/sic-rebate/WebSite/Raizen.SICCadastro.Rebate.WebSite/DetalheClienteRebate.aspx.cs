using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using Raizen.SICCadastro.Rebate.Util;
using COSAN.Framework.Util;
using System.Text;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class DetalheClienteRebate : System.Web.UI.Page
    {
        #region Propriedades

        private CalculoRebateSic CalculoRebateSic
        {
            get
            {
                if (ViewState["CalculoRebateSic"] == null)
                    ViewState["CalculoRebateSic"] = new CalculoRebateSic();

                return ViewState["CalculoRebateSic"] as CalculoRebateSic;
            }
            set
            {
                ViewState["CalculoRebateSic"] = value;
            }
        }

        #endregion Propriedades

        #region Metodos Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarTela();
            }
        }

        #endregion Metodos Page

        #region Metodos Controles

        /// <summary>
        /// Consultar Extrato por Periodo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida se as datas não estão em branco
                if (string.IsNullOrEmpty(txtDataInicial.Text) || string.IsNullOrEmpty(txtDataFinal.Text))
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaPeriodo);
                    return;
                }
                //Valida que seja uma data válida
                DateTime tempDate;
                if (!DateTime.TryParse(txtDataInicial.Text, out tempDate) || !DateTime.TryParse(txtDataFinal.Text, out tempDate))
                {
                    ShowAlertMessage(Mensagens.AlertaPeriodoValido);
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

                //Realiza a busca dos lancamentos no periodo
                IList<SaldoRebateSic> saldos =
                    Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO")
                    .SelecionarPeriodo(new SaldoRebateSic { NrSeqRebateSic = CalculoRebateSic.NrSeqRebateSic }, dataDe, dataAte);

                CarregarGridExtrato(saldos);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// Calcular Aditivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCalcularAditivo_Click(object sender, EventArgs e)
        {
            //Validação
            if (txtDataAditivo.Text == string.Empty)
            {
                ShowAlertMessage(Mensagens.AlertaInformePeriodoCalculoAditivo);
                return;
            }

            //Valida período seja data válida
            DateTime tempDate;
            if (!DateTime.TryParse(txtDataAditivo.Text, out tempDate))
            {
                ShowAlertMessage(Mensagens.AlertaPeriodoValido);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarAditivo));
            btnOK.CommandArgument = ConstantesRebate.ADITIVO_REBATE;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// Pagamento Manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagtoManual_Click(object sender, EventArgs e)
        {
            //Cálculo Retroativo
            if (this.CalculoRebateSic.NrSeqCalculoRebateSic == null || this.CalculoRebateSic.NrSeqCalculoRebateSic == 0)
            {
                ShowAlertMessage(Mensagens.AlertaCalculoPagamentoManual);
                return;
            }

            //Valida se a observação foi preenchida            
            if (string.IsNullOrEmpty(txtObsPagto.Text.Trim()))
            {
                ShowAlertMessage(Mensagens.AlertaObservacaoPagtoManual);
                return;
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarPagamentoManual));
            btnOK.CommandArgument = ConstantesRebate.PAGTO_MANUAL;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// Altera o status do cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlterarStatus_Click(object sender, EventArgs e)
        {
            //Deve selecionar um status
            if (ddlStatusRebate.SelectedValue == "0")
            {
                ShowAlertMessage(Mensagens.AlertaSelecionarStatus);
                return;
            }

            int codStatus = Convert.ToInt16(ddlStatusRebate.SelectedValue);

            //Informações Inconsistentes
            if (codStatus == Convert.ToInt16(StatusCalculoRebate.InformacoesInconsistentes))
            {
                //Validação
                //Se o status atual já é Informações Inconsistentes
                if (ddlStatusRebate.Attributes["StatusAtual"] == Convert.ToInt16(StatusCalculoRebate.InformacoesInconsistentes).ToString())
                {
                    ShowAlertMessage(Mensagens.AlertaStatusInformacoesInconsistentes);
                    return;
                }

                //Se o status atual não é pago, não pode alterar
                if (ddlStatusRebate.Attributes["StatusAtual"] != Convert.ToInt16(StatusCalculoRebate.Pago).ToString())
                {
                    ShowAlertMessage(Mensagens.AlertaStatusPago);
                    return;
                }
            }

            //Cancelado
            if (codStatus == Convert.ToInt16(StatusCalculoRebate.Cancelado))
            {
                //Se o status atual já é Informações Inconsistentes
                if (ddlStatusRebate.Attributes["StatusAtual"] == Convert.ToInt16(StatusCalculoRebate.Cancelado).ToString()
                    || ddlStatusRebate.Attributes["StatusAtual"] == Convert.ToInt16(StatusCalculoRebate.Pago).ToString()
                    || ddlStatusRebate.Attributes["StatusAtual"] == Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento).ToString())
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    return;
                }
            }

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.AlteracaoStatus));
            btnOK.CommandArgument = ConstantesRebate.ALTERAR_STATUS;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// Recalculo de Bonificação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            string periodo = PeriodoRecalculoBonificacao();

            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, string.Format(Mensagens.ConfirmarRecalculo, periodo)));
            btnOK.CommandArgument = ConstantesRebate.RECALCULO_REBATE;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// Calcuo Retroativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRetroativo_Click_Antigo(object sender, EventArgs e)
        {
            //Confirmar                        
            lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarRetroativo));
            btnOK.CommandArgument = ConstantesRebate.CALCULO_RETROATIVO;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument, string.Format("javascript:ShowMessageOK();"), true);
        }

        /// <summary>
        /// Cálculo Retroativo e Exibição do Log Detalhado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRetroativo_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter a confirmação do usuário
                lblMensagemOK.Text = string.Concat(string.Format(Mensagens.ConfirmarDialog, Mensagens.ConfirmarRetroativo));
                btnOK.CommandArgument = ConstantesRebate.CALCULO_RETROATIVO;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), btnOK.CommandArgument,
                    "javascript:ShowMessageOK();", true);
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro no cálculo retroativo: {ex.Message}\nStackTrace: {ex.StackTrace}");
                ShowAlertMessage($"Erro ao iniciar cálculo retroativo: {ex.Message}");
            }
        }

        /// <summary>
        /// btnOK_Click - Manipula ações com base no CommandArgument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            string[] argumentos = (((Button)sender).CommandArgument).Split('#');

            switch (argumentos[0])
            {
                case (ConstantesRebate.ADITIVO_REBATE):
                    CalcularAditivo();
                    break;

                case (ConstantesRebate.RECALCULO_REBATE):
                    RecalcularBonificacao();
                    break;

                case (ConstantesRebate.CALCULO_RETROATIVO):
                    CalcularRetroativo();
                    break;

                case (ConstantesRebate.ALTERAR_STATUS):
                    AlterarStatus();
                    break;

                case (ConstantesRebate.PAGTO_MANUAL):
                    PagarManualmente();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Calcular Retroativo
        /// </summary>
        private void CalcularRetroativo()
        {
            try
            {
                var usuario = Request.Cookies["CookieLogon"]?.Value ?? "Sistema";
                DateTime inicioExecucao = DateTime.Now;
                try
                {
                    // Obtém os parâmetros necessários

                    var rebateSic = new RebateSic { NrSeqRebateSic = Convert.ToInt32(Request.QueryString["NrRebate"]) };
                    var urlReferrer = Request.UrlReferrer?.AbsoluteUri;


                    // Executa o cálculo retroativo
                    var calculoBLO = Factory.CreateFactoryInstance()
                        .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
                    calculoBLO.CalcularRetroativo(rebateSic, urlReferrer, usuario);

                    //Atualiza a tela
                    ConsultarExtratoSaldo();

                    ShowAlertMessage(Mensagens.MsgRetroativoSucesso);

                    try
                    {
                        MostrarLogsRebateRetroativo(usuario, inicioExecucao);
                    }
                    catch (Exception ex02)
                    {
                        LogError.Debug(string.Format("Erro {0}: {1}", ex02.Message, ex02.StackTrace));
                    }
                }
                catch (Exception ex)
                {
                    // LogError.Debug($"Erro no cálculo retroativo: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    // ShowAlertMessage($"Erro ao calcular retroativo: {ex.Message}");
                    LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                    ShowAlertMessage(string.Concat(Mensagens.ErroCalculoRetroativo, ": ", ex.Message));

                    try
                    {
                        MostrarLogsRebateRetroativo(usuario, inicioExecucao);
                    }
                    catch (Exception ex02)
                    {
                        LogError.Debug(string.Format("Erro {0}: {1}", ex02.Message, ex02.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroGenerico, ": ", ex.Message));
            }
        }

        private void MostrarLogsRebateRetroativo(string usuario, DateTime inicioExecucao)
        {
            // Busca os logs gerados na mesma data/hora para o usuário logado
            var logRebateBLO = new BLL.LogRebateRetroativoBLO();
            IList<Model.LogRebateRetroativo> logs = logRebateBLO.SelecionarPorUsuarioEData(usuario, inicioExecucao);

            // Formata os logs em HTML
            string logFormatado = FormatLogsHtml(logs);

            // Exibe os logs no modal
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowLogDetalhado",
                $"javascript:ShowLogDetalhado('{logFormatado.Replace("\n", "").Replace("\r", "").Replace("'", "\\'")}');", true);
        }

        /// <summary>
        /// Formata a lista de logs em HTML para exibição no modal.
        /// </summary>
        private string FormatLogsHtml(IList<Model.LogRebateRetroativo> logs)
        {
            if (logs == null || logs.Count == 0)
                return "<p>Nenhum log encontrado.</p>";

            StringBuilder sb = new StringBuilder();
            sb.Append("<div style='font-family:monospace; font-size:12px;'>");

            foreach (var log in logs)
            {
                sb.Append("<div style='margin-bottom:10px; border-bottom:1px solid #ccc; padding:5px;'>");
                sb.Append($"<strong>Usuário:</strong> {log.CdLogUsuarioRebateRetroativo}<br/>");
                sb.Append($"<strong>Data/Hora:</strong> {log.DtLogDatetimeRebateRetroativo:dd/MM/yyyy HH:mm:ss}<br/>");
                sb.Append($"<strong>Detalhes:</strong><br/> {log.XmlLogDetalheRebateRetroativo.Replace("\n", "<br/>")}");
                sb.Append("</div>");
            }

            sb.Append("</div>");
            return sb.ToString();
        }






        /// <summary>
        /// btnOK_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click_Antigo(object sender, EventArgs e)
        {
            string[] argumentos = (((Button)sender).CommandArgument).Split('#');

            switch (argumentos[0])
            {
                case (ConstantesRebate.ADITIVO_REBATE):
                    CalcularAditivo();
                    break;
                case (ConstantesRebate.RECALCULO_REBATE):
                    RecalcularBonificacao();
                    break;
                case (ConstantesRebate.CALCULO_RETROATIVO):
                    CalcularRetroativo();
                    break;
                case (ConstantesRebate.ALTERAR_STATUS):
                    AlterarStatus();
                    break;
                case (ConstantesRebate.PAGTO_MANUAL):
                    PagarManualmente();
                    break;
                default:
                    break;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            //Volta a tela anterior
            Response.Redirect("~/CalculoRebate.aspx");
        }

        #endregion Metodos Controles

        #region Metodos Private

        /// <summary>
        /// Preenche tela inicial
        /// </summary>
        private void InicializarTela()
        {
            try
            {
                #region Atributos de Cálculo e Rebate
                //Nr Rebate
                int nrSeqRebateSic = 0;
                if (!int.TryParse(Request.QueryString["NrRebate"], out nrSeqRebateSic))
                {
                    ShowAlertMessage(Mensagens.AlertaNumeroRebate);
                    return;
                }
                CalculoRebateSic.NrSeqRebateSic = nrSeqRebateSic;

                //Nr Calculo
                int nrSeqCalculoRebateSic = 0;
                if (!int.TryParse(Request.QueryString["NrCalculo"], out nrSeqCalculoRebateSic))
                {
                    ShowAlertMessage(Mensagens.AlertaNumeroCalculoRebate);
                    return;
                }
                CalculoRebateSic.NrSeqCalculoRebateSic = nrSeqCalculoRebateSic;
                #endregion

                #region Dados Contexto

                //Dados Cliente
                lblIbmCliente.Text = Context.Items["IBM"].ToString() ?? string.Empty;
                lblCliente.Text = Context.Items["RazaoSocial"].ToString() ?? string.Empty;
                lblTipoContrato.Text = Context.Items["TipoContrato"].ToString() ?? string.Empty;
                lblFrequenciaPagto.Text = Context.Items["FrequenciaPagto"].ToString() ?? string.Empty;

                //Armazena e trata status atual
                string nrStatusInfInconsistente = Convert.ToInt16(StatusCalculoRebate.InformacoesInconsistentes).ToString(); //Cód. Status de Inf. Inconsistentes
                string statusAtual = string.Empty;
                if (Context.Items["StatusCliente"] != null)
                    statusAtual = Context.Items["StatusCliente"].ToString() ?? "0"; //Status recebido via contexto                
                ddlStatusRebate.Attributes.Add("StatusAtual", statusAtual); //Adiciona o status nos atributos da combo

                //Caso o status atual seja informações inconsistentes, desabilita a combo
                if (statusAtual.Equals(nrStatusInfInconsistente))
                    ddlStatusRebate.SelectedValue = nrStatusInfInconsistente;

                //Limpando o contexto
                Context.Items.Clear();

                #endregion Dados Contexto

                #region Ações Complementares
                //Recupera o cálculo e coplementa as informações faltantes para o pagamento manual
                if (nrSeqCalculoRebateSic > 0)
                {
                    ICalculoRebateSicBLO CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
                    this.CalculoRebateSic = CalculoRebateSicBLOService.SelecionarPrimeiro(CalculoRebateSic);
                    chkPagtoManual.Checked = this.CalculoRebateSic.StPagtoManualSic.HasValue && this.CalculoRebateSic.StPagtoManualSic.Value;
                    txtObsPagto.Text = this.CalculoRebateSic.DsObsPagtoSic ?? string.Empty;
                }

                string periodo = PeriodoRecalculoBonificacao();
                lblPeriodo.Text = (periodo == string.Empty ? "--/----" : periodo);
                ConsultarExtratoSaldo();
                #endregion

                #region permissionamento

                bool isConsulta = this.Permissao().Any(_ => _ == ConstantesRebate.SICConsulta);

                if (isConsulta)
                {
                    btnRow1.Visible = false;
                    btnRow2.Visible = false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroConsultarDetalheCliente, ": ", ex.Message));
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
        /// COnsulta Extrato
        /// </summary>
        private void ConsultarExtratoSaldo()
        {
            try
            {
                //Seleciona os lançamentos em ordem decrescente e pega os 5 primeiros da lista
                IList<SaldoRebateSic> saldos =
                    Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO")
                    .Selecionar(new SaldoRebateSic { NrSeqRebateSic = CalculoRebateSic.NrSeqRebateSic }, 5, "NR_SEQ_SALDO_REBATE_SIC DESC");

                //Inverte a ordem para crescente para exibir como extrato - ordem crescente dos lançamentos
                saldos = saldos.OrderBy(d => d.NrSeqSaldoRebateSic).ToList();

                CarregarGridExtrato(saldos);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroConsultarDetalheCliente, ": ", ex.Message));
            }
        }

        /// <summary>
        /// Carrega Grid
        /// </summary>
        /// <param name="saldos"></param>
        private void CarregarGridExtrato(IList<SaldoRebateSic> saldos)
        {
            grvExtrato.DataSource = saldos;
            grvExtrato.DataBind();
        }

        /// <summary>
        /// Calcular Aditivo
        /// </summary>
        private void CalcularAditivo()
        {
            try
            {
                //Periodo
                DateTime dtAditivo = DateTime.MinValue;
                if (!string.IsNullOrEmpty(txtDataAditivo.Text))
                {
                    string[] data = txtDataAditivo.Text.Split('/');
                    dtAditivo = new DateTime(Convert.ToInt16(data[1]), Convert.ToInt16(data[0]), 1);
                }

                ICalculoBonificacaoRebateBLO CalculoBonificacaoRebateBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");

                //Chamada ao método de Cálculo Retroativo que realiza o processo 
                CalculoBonificacaoRebateBLOService.CalcularAditivo(new RebateSic { NrSeqRebateSic = CalculoRebateSic.NrSeqRebateSic }, dtAditivo, Request.UrlReferrer.AbsoluteUri, Request.Cookies["CookieLogon"].Value != null ? Request.Cookies["CookieLogon"].Value.ToString() : null);

                //Atualiza a tela
                ConsultarExtratoSaldo();

                ShowAlertMessage(Mensagens.MsgSucessoAditivo);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroAditivo, ": ", ex.Message));
            }
        }

        /// <summary>
        /// Alterar Status
        /// </summary>
        private void AlterarStatus()
        {
            try
            {
                //Cancelado
                bool cancelar = (Convert.ToInt16(ddlStatusRebate.SelectedValue) == Convert.ToInt16(StatusCalculoRebate.Cancelado));

                //Cria objeto BLO
                ICalculoRebateSicBLO CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");

                //Preenche o objeto do Calculo Rebate
                CalculoRebateSic calculo = CalculoRebateSicBLOService.SelecionarPrimeiro(new CalculoRebateSic { NrSeqCalculoRebateSic = CalculoRebateSic.NrSeqCalculoRebateSic });

                //Atualiza dados do status e flags e datas de aprovação
                calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(ddlStatusRebate.SelectedValue);

                if (!cancelar)
                {
                    calculo.StAprovadoAnalistaSic = false;
                    calculo.DtAprovadoAnalistaSic = null;
                    calculo.StEnviadoAprovacaoGerenteSic = false;
                    calculo.DtEnviadoAprovacaoGerenteSic = null;
                    calculo.StAprovadoGerenteSic = false;
                    calculo.DtAprovadoGerenteSic = null;
                    calculo.DtPagamentoSic = null;
                }

                CalculoRebateSicBLOService.Atualizar(calculo);

                //Altera atributo de status armazenado da combo
                ddlStatusRebate.Attributes["StatusAtual"] = calculo.NrSeqStatusCalculoRebateSic.ToString();

                #region Atualiza Saldo

                ISaldoRebateSicBLO SaldoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO");

                //Busca o último saldo
                SaldoRebateSic saldo = SaldoRebateSicBLOService.SelecionarUltimo(new SaldoRebateSic { NrSeqRebateSic = calculo.NrSeqRebateSic });
                decimal saldoAtual = saldo.VlSaldoAtualSic ?? 0;
                //Cria nova entrada de Saldo
                SaldoRebateSic saldoAtualizado = new SaldoRebateSic
                {
                    NrSeqRebateSic = calculo.NrSeqRebateSic,
                    VlSaldoAtualSic = cancelar ? (saldoAtual - calculo.VlBonificacaoTotalSic) : (saldoAtual + calculo.VlBonificacaoTotalSic),
                    VlLancamentoSic = cancelar ? (-1) * calculo.VlBonificacaoTotalSic : calculo.VlBonificacaoTotalSic,
                    DtLancamentoSic = RebateUtil.GetDataAtual(),
                    DsObsComplementoSic = cancelar ? string.Format(ConstantesRebate.DS_EXTRATO_CANCELADO, calculo.DtPeriodoSic.Value.ToString("MM/yyyy")) :
                                                     string.Format(ConstantesRebate.DS_EXTRATO_INFORMACOES_INCONSISTENTES, calculo.DtPeriodoSic.Value.ToString("MM/yyyy"))
                };
                //Insere registro com saldo atualizado
                SaldoRebateSicBLOService.Incluir(saldoAtualizado);

                #endregion Atualiza Saldo

                #region Insere Historico do Status

                StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic
                {
                    NrSeqCalculoRebateSic = calculo.NrSeqCalculoRebateSic,
                    DtAlteracaoSic = RebateUtil.GetDataAtual(),
                    NmLoginSic = ConstantesRebate.USUARIO_SERVICO,
                    NrSeqStatusCalculoRebateSic = calculo.NrSeqStatusCalculoRebateSic,
                    DsObservacaoSic = cancelar ? string.Format(ConstantesRebate.DS_HISTORICO_GENERICO, ConstantesRebate.DS_HISTORICO_CANCELADO,
                                                    calculo.NrSeqRebateSic,
                                                    calculo.DtPeriodoSic.Value.ToString("MM/yyyy"),
                                                    calculo.VlBonificacaoTotalSic.Value.ToString("N2")) :
                                                 string.Format(ConstantesRebate.DS_HISTORICO_INFORMACOES_INCONSISTENTES,
                                                    calculo.NrSeqRebateSic,
                                                    calculo.DtPeriodoSic.Value.ToString("MM/yyyy"),
                                                    calculo.VlBonificacaoTotalSic.Value.ToString("N2"))
                };

                Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicBLO>("StatusCalculoRebateHistoricoSicBLO").Incluir(historico);

                #endregion Insere Historico

                #region Atualiza Tela

                ConsultarExtratoSaldo();

                #endregion Atualiza Tela

                ShowAlertMessage(Mensagens.MsgStatusSucesso);

            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroAlteracaoStatus, ": ", ex.Message));
            }
        }


        /// <summary>
        /// Pagamento Manual
        /// </summary>
        private void PagarManualmente()
        {
            try
            {
                //Preenche o objeto do Calculo Rebate
                ICalculoRebateSicBLO CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
                CalculoRebateSic calculo = CalculoRebateSicBLOService.SelecionarPrimeiro(new CalculoRebateSic { NrSeqCalculoRebateSic = this.CalculoRebateSic.NrSeqCalculoRebateSic });

                //Se algum item selecionado foi cancelado, pago, enviado pagto, não deixa prosseguir                
                if (calculo.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Cancelado)
                    || calculo.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago)
                    || calculo.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento))
                {
                    ShowAlertMessage(Mensagens.AlertaBonificacaoCanceladaPagaEnviada);
                    chkPagtoManual.Checked = this.CalculoRebateSic.StPagtoManualSic.HasValue && this.CalculoRebateSic.StPagtoManualSic.Value;
                    txtObsPagto.Text = this.CalculoRebateSic.DsObsPagtoSic ?? string.Empty;
                    return;
                }

                //Pagar Manualmente
                calculo.StPagtoManualSic = chkPagtoManual.Checked;
                calculo.DsObsPagtoSic = txtObsPagto.Text.Trim();
                CalculoRebateSicBLOService.Atualizar(calculo);
                ShowAlertMessage(Mensagens.MsgSucessoPagtoManual);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroPagamentoManual, ": ", ex.Message));
            }
        }

        /// <summary>
        /// Calcular Retroativo
        /// </summary>
        private void CalcularRetroativo_Antigo()
        {
            try
            {
                ICalculoBonificacaoRebateBLO CalculoBonificacaoRebateBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");

                //Chamada ao método de Cálculo Retroativo que realiza o processo 
                CalculoBonificacaoRebateBLOService.CalcularRetroativo(new RebateSic { NrSeqRebateSic = CalculoRebateSic.NrSeqRebateSic }, Request.UrlReferrer.AbsoluteUri, Request.Cookies["CookieLogon"].Value != null ? Request.Cookies["CookieLogon"].Value.ToString() : null);

                //Atualiza a tela
                ConsultarExtratoSaldo();

                ShowAlertMessage(Mensagens.MsgRetroativoSucesso);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroCalculoRetroativo, ": ", ex.Message));
            }
        }

        /// <summary>
        /// Informa Periodo do Recalculo 
        /// </summary>
        private string PeriodoRecalculoBonificacao()
        {
            string periodo = string.Empty;

            try
            {
                ICalculoRebateSicBLO CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
                CalculoRebateSic calculoRebateSic = CalculoRebateSicBLOService.SelecionarUltimo(new CalculoRebateSic { NrSeqRebateSic = this.CalculoRebateSic.NrSeqRebateSic });

                if (calculoRebateSic.NrSeqCalculoRebateSic == null || calculoRebateSic.NrSeqCalculoRebateSic == 0)
                    return string.Empty;

                DateTime dataPeriodo = calculoRebateSic.DtPeriodoSic.Value;
                periodo = dataPeriodo.ToString("MM/yyyy");
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroPeriodoRecalculo);
            }

            return periodo;
        }

        /// <summary>
        /// Recalcular Última Bonificação 
        /// </summary>
        private void RecalcularBonificacao()
        {
            try
            {
                ICalculoBonificacaoRebateBLO CalculoBonificacaoRebateBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
                //Chamada ao método de Recálculo que realiza o processo 
                CalculoBonificacaoRebateBLOService.RecalcularUltimoPeriodo(new RebateSic { NrSeqRebateSic = CalculoRebateSic.NrSeqRebateSic }, Request.UrlReferrer.AbsoluteUri, Request.Cookies["CookieLogon"].Value != null ? Request.Cookies["CookieLogon"].Value.ToString() : null);

                //Atualiza a tela
                ConsultarExtratoSaldo();

                ShowAlertMessage(Mensagens.MsgRecalculoSucesso);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(string.Concat(Mensagens.ErroRecalcular, ": ", ex.Message));
            }
        }

        /// <summary>
        /// Exibe erros
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }


        #endregion Metodos Private
    }
}
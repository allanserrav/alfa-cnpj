using COSAN.Framework.Factory;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.SAL;
using Raizen.SICCadastro.Rebate.SAL.wsConsultarDebitos;
using Raizen.SICCadastro.Rebate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Lógica de Processamento para os cálculos
    /// </summary>
    public class CalculoBonificacaoRebateBLO : ICalculoBonificacaoRebateBLO
    {
        #region Constantes

        private const string URL_SAP_CREDITO = "URL_SAP_CREDITO";
        private const string USUARIO_SAP_CREDITO = "USUARIO_SAP_CREDITO";
        private const string SENHA_SAP_CREDITO = "SENHA_SAP_CREDITO";
        private const string URL_SAP_DEBITO = "URL_SAP_DEBITO";
        private const string USUARIO_SAP_DEBITO = "USUARIO_SAP_DEBITO";
        private const string SENHA_SAP_DEBITO = "SENHA_SAP_DEBITO";

        #endregion Constantes

        #region Variaveis Privadas

        /// <summary>
        ///Armazena lista de tipos de rebate
        /// </summary>
        private IList<TiporebateSic> ListTipoRebateSic { get; set; }

        /// <summary>
        ///Armazena lista de status
        /// </summary>
        private IList<StatusSic> ListTipoStatusSic { get; set; }

        /// <summary>
        ///Armazena lista de rebates
        /// </summary>
        private IList<RebateSic> ListRebateSic { get; set; }

        /// <summary>
        ///Armazena os produtos x categorias
        /// </summary>
        private IList<FaixarebateSic> ListFaixaRebateSic { get; set; }

        /// <summary>
        /// Retorna Instancia de RebateSicBLO
        /// </summary>
        private IRebateSicBLO RebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de IClienteSicBLO
        /// </summary>
        private IClienteSicBLO ClienteSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de IClientestatusSicBLO
        /// </summary>
        private IClientestatusSicBLO ClientestatusSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de FaixaRebateSicBLO
        /// </summary>
        private IFaixarebateSicBLO FaixaRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de ProdutoSicBLO
        /// </summary>
        private IVolumeMensalFaixaRebateSicBLO VolumeMensalFaixaRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de DebitoRebateSicBLO
        /// </summary>
        private IDebitoRebateSicBLO DebitoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de TipoRebateSicBLO
        /// </summary>
        private ITiporebateSicBLO TiporebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia IStatusSicBLO
        /// </summary>
        private IStatusSicBLO StatusSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de SaldoRebateSicBLO
        /// </summary>
        private ISaldoRebateSicBLO SaldoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de SaldoRebateSicBLO
        /// </summary>
        private ICalculoRebateSicBLO CalculoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de CalculoRebateFaixaSicBLO
        /// </summary>
        private ICalculoRebateFaixaSicBLO CalculoRebateFaixaSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de VolumeCalculoRebateFaixaSicBLO
        /// </summary>
        private IVolumeCalculoRebateFaixaSicBLO VolumeCalculoRebateFaixaSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de StatusCalculoRebateHistoricoSicBLO
        /// </summary>
        private IStatusCalculoRebateHistoricoSicBLO StatusCalculoRebateHistoricoSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de BuscaDadosRebateBLO
        /// </summary>
        private IBuscaVolumeRebateBLO BuscaVolumeRebateBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de RebateSicDAO
        /// </summary>
        private IRebateSicDAO RebateSicDAO { get; set; }

        /// <summary>
        /// Retorna Instancia de DadosCalculoRebateSicBLO
        /// </summary>
        private IDadosCalculoRebateSicBLO DadosCalculoRebateSicBLO { get; set; }

        /// <summary>
        /// Retorna Instancia DadosCalculoFaixaRebateSicBLO
        /// </summary>
        private IDadosCalculoFaixaRebateSicBLO DadosCalculoFaixaRebateSicBLO { get; set; }

        #endregion Variaveis Privadas

        #region Construtor

        /// <summary>
        /// Construtor Default
        /// </summary>
        public CalculoBonificacaoRebateBLO()
        {
            this.RebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
            this.FaixaRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicBLO>("FaixarebateSicBLO");
            this.VolumeMensalFaixaRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IVolumeMensalFaixaRebateSicBLO>("VolumeMensalFaixaRebateSicBLO");
            this.DebitoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IDebitoRebateSicBLO>("DebitoRebateSicBLO");
            this.TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");
            this.SaldoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO");
            this.CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
            this.CalculoRebateFaixaSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO");
            this.VolumeCalculoRebateFaixaSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IVolumeCalculoRebateFaixaSicBLO>("VolumeCalculoRebateFaixaSicBLO");
            this.StatusCalculoRebateHistoricoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicBLO>("StatusCalculoRebateHistoricoSicBLO");
            this.BuscaVolumeRebateBLOService = Factory.CreateFactoryInstance().CreateInstance<IBuscaVolumeRebateBLO>("BuscaVolumeRebateBLO");
            this.StatusSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IStatusSicBLO>("StatusSicBLO");
            this.ClienteSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IClienteSicBLO>("ClienteSicBLO");
            this.ClientestatusSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IClientestatusSicBLO>("ClientestatusSicBLO");
            this.RebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IRebateSicDAO>("RebateSicDAO");
            this.ListTipoRebateSic = this.TiporebateSicBLOService.Selecionar();
            this.ListTipoStatusSic = this.StatusSicBLOService.Selecionar();
        }

        #endregion Construtor

        #region Metodos Publicos

        #region Métodos Processamento Serviço

        /// <summary>
        /// Executar o cálculo/inserção para os rebates do periodo atual
        /// </summary>
        public void ProcessarServico()
        {
            var mensagem = string.Empty;

            Console.WriteLine("     > CalculoBonificacaoRebate > ProcessarServico  ");
            Console.WriteLine("");

          //Inicialização das listas Globais
        this.ListRebateSic = this.RebateSicBLOService.SelecionarVigentes();
#if DEBUG
            //Seleciona rebate específico do cliente informado
            this.ListRebateSic = this.ListRebateSic.Where(r => r.NrIbmRebateSic == "0001023031").ToList();
            //this.ListRebateSic = this.ListRebateSic.Where(r => r.NrIbmRebateSic == "0001020717").ToList();


            
#endif

            //#if DEBUG
            //            //Seleciona rebate específico do cliente informado
            //            this.ListRebateSic = this.ListRebateSic.Where(r => r.NrSeqClienteSic == 948).ToList();
            //#endif

            Console.WriteLine("     > ProcessarServico - ListRebateSic");
            Console.WriteLine("");

            this.ListRebateSic = FiltrarVigentes(this.ListRebateSic,/* DateTime.Now*/null, out mensagem);

            Console.WriteLine("     > ProcessarServico - ListFaixaRebateSic");
            Console.WriteLine("");

            this.ListFaixaRebateSic = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesListaRebate(this.ListRebateSic);

            Console.WriteLine("     > ProcessarServico - Inicialização das listas Globais");
            Console.WriteLine("");

            //Expurgar pedidos
            CancelarBonificacaoCosan();

            Console.WriteLine("     > ProcessarServico - Expurgar pedidos");
            Console.WriteLine("");

            //Processar Chamar Busca Dados
            IList<VolumeRbc> volumesSelecionados;
            BuscaVolumeRebateBLOService.ProcessarServico(this.ListRebateSic, this.ListFaixaRebateSic, out volumesSelecionados, "sic.raizen.com/Rebate", "SICRebate_Vigencia Volume");

            Console.WriteLine(">>>> Processado Chamada de Busca Dados ");
            Console.WriteLine("");

            //Datas Utilizadas para cálculo
            DateTime dataAtual = RebateUtil.GetDataAtual();
            DateTime dataInicioPeriodoTrimestral = RebateUtil.GetInicioPeriodoTrimestral(dataAtual);
            DateTime dataInicioPeriodoMensal = RebateUtil.GetInicioPeriodoMensal(dataAtual);
            DateTime dataFimPeriodo = RebateUtil.GetFimPeriodo(dataAtual);

            Console.WriteLine("     > ProcessarServico - Datas Utilizadas para cálculo");
            Console.WriteLine("");

            //Recupera as faixas
            List<FaixarebateSic> listFaixaRebateSic = this.ListFaixaRebateSic.ToList();

            Console.WriteLine("     > ProcessarServico - Recupera as faixas");
            Console.WriteLine("");

            //Buscar os volumes do período pelas faixas rebate
            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();

            Console.WriteLine("     > ProcessarServico - Buscar os volumes do período pelas faixas rebate");
            Console.WriteLine("");

            //Recupera tipo rebate cosan
            TiporebateSic tipoRebateCosan = ListTipoRebateSic.Single(t => t.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME));

            Console.WriteLine("     > ProcessarServico - Recupera tipo rebate cosan");
            Console.WriteLine("");

            //Recupera os rebates
            int[] mesesGrupo = RebateUtil.GetListaMesesGrupoTrimestral(RebateUtil.GetDataAtual().Month);

            Console.WriteLine("     > ProcessarServico - Recupera os rebates ");
            Console.WriteLine("");

            //Armazena mensal
            IList<RebateSic> listRebateSicMensal = this.ListRebateSic.Where(r => r.NrSeqTiporebateSic != tipoRebateCosan.NrSeqTiporebateSic && !r.StCalculoRebateSic.Value).ToList();

            Console.WriteLine("     > ProcessarServico - Armazena mensal ");
            Console.WriteLine("");

            //Recupera os Volumes Mensais
            List<FaixarebateSic> listFaixaRebateSicMensal = this.ListFaixaRebateSic.Where(f => listRebateSicMensal.Select(r => r.NrSeqRebateSic).ToList().Contains(f.NrSeqRebateSic)).ToList();
            if (listFaixaRebateSicMensal.Count > 0)
                listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                    dataInicioPeriodoMensal, dataFimPeriodo, listFaixaRebateSicMensal).ToList());

            Console.WriteLine("     > ProcessarServico - Recupera os Volumes Mensais ");
            Console.WriteLine("");

            //Armazena trimestral
            IList<RebateSic> listRebateSicTrimestral = this.ListRebateSic.Where(r =>
            {
                return
                    (r.NrSeqTiporebateSic == tipoRebateCosan.NrSeqTiporebateSic && !r.StCalculoRebateSic.Value) ||
                    (r.StCalculoRebateSic.Value && mesesGrupo.Contains(r.DtIniciovigenciaRebateSic.Value.Month));
            }).ToList();

            Console.WriteLine("     > ProcessarServico - Armazena trimestral ");
            Console.WriteLine("");

            //Recupera os Volumes trimestrais
            List<FaixarebateSic> listFaixaRebateSicTrimestral = this.ListFaixaRebateSic.Where(f => listRebateSicTrimestral.Select(r => r.NrSeqRebateSic).ToList().Contains(f.NrSeqRebateSic)).ToList();
            if (listFaixaRebateSicTrimestral.Count > 0)
                listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                    dataInicioPeriodoTrimestral, dataFimPeriodo, listFaixaRebateSicTrimestral).ToList());

            Console.WriteLine("     > ProcessarServico - Recupera os Volumes trimestrais ");
            Console.WriteLine("");

            //Armazena trimestral e mensal
            List<RebateSic> listRebateSicTotal = new List<RebateSic>();
            listRebateSicTotal.AddRange(listRebateSicMensal);
            listRebateSicTotal.AddRange(listRebateSicTrimestral);

            Console.WriteLine("     > ProcessarServico - Armazena trimestral e mensal ");
            Console.WriteLine("");

            //Lista de rebates que serao calculados pela primeira vez

            //Prepara listas para inserção
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
            List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
            List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();
            List<RebateSic> listRebateSicPrimeiroCalculo = new List<RebateSic>();
            List<DadosCalculoRebateSic> listDadosCalculoRebateSic = new List<DadosCalculoRebateSic>();

            //Calcular Rebate
            foreach (RebateSic rebateSic in listRebateSicTotal)
            {
                try
                {
                    Calcular(rebateSic, listFaixaRebateSic, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, RebateUtil.GetPeriodoAtual(), false, volumesSelecionados as List<VolumeRbc>);

                    //Verifica se nao esta marcado que possui calculo
                    if (rebateSic.StPossuiCalculoRebateSic == null || rebateSic.StPossuiCalculoRebateSic == false)
                    {
                        rebateSic.StPossuiCalculoRebateSic = true;
                        listRebateSicPrimeiroCalculo.Add(rebateSic);
                    }

                    // Daddos Calculo Rebate
                    List<FaixarebateSic> listFaixas = listFaixaRebateSic.Where(f => f.NrSeqRebateSic == rebateSic.NrSeqRebateSic).ToList();

                    listDadosCalculoRebateSic.Add(this.DadosCalculoRebate(rebateSic, listFaixas, RebateUtil.GetPeriodoAtual()));
                }
                catch (Exception ex)
                {
                    LogError.Debug(string.Format("Erro no cálculo do rebate: {0}. {1}\n{2}", rebateSic.NrIbmRebateSic, ex.Message, ex.StackTrace));
                    throw;
                }
            }

            Console.WriteLine("     > ProcessarServico - Calcular Rebate ");
            Console.WriteLine("");

            //Preparando listas para inserção
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
            IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, false);

            Console.WriteLine("     > ProcessarServico - Preparando listas para inserção ");
            Console.WriteLine("");

            //Bloco de Inserção ...............................................................
            CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                listVolumeCalculoRebateFaixaSic,
                listCalculoRebateFaixaSic,
                listCalculoRebateProporcionalSic,
                listCalculoRebateSic,
                listStatusCalculoRebateHistoricoSic,
                listSaldoRebateSic,
                listRebateSicPrimeiroCalculo);

            Console.WriteLine("     > ProcessarServico - Bloco de Inserção ");
            Console.WriteLine("");

            // Dados Calculo Rebate
            IDadosCalculoRebateSicDAO dadosCalculoRebateDAO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoRebateSicDAO>("DadosCalculoRebateSicDAO");
            foreach (var dadosCalculoRebateSic in listDadosCalculoRebateSic)
                dadosCalculoRebateDAO.Incluir(dadosCalculoRebateSic);

            Console.WriteLine("     > ProcessarServico - Dados Calculo Rebate ");
            Console.WriteLine("");

            //Processar / Inserir Débitos
            ProcessarDebitos(listCalculoRebateSic);
        }

        #endregion Métodos Processamento Serviço

        #region Métodos Processamento Débitos

        /// <summary>
        /// Busca Débitos
        /// </summary>
        /// <param name="listRebateSicTotal"></param>
        /// <param name="listCalculoRebateSicInterna"></param>
        /// <param name="listStatusCalculoRebateHistoricoSic"></param>
        /// <returns></returns>
        public void ProcessarDebitos(List<CalculoRebateSic> listCalculoRebateSic)
        {
            //Busca novamente os cálculos
            List<CalculoRebateSic> listCalculoRebateSicInterna = new List<CalculoRebateSic>();
            foreach (CalculoRebateSic calculoRebate in listCalculoRebateSic)
                listCalculoRebateSicInterna.Add(CalculoRebateSicBLOService.SelecionarPrimeiro(
                    new CalculoRebateSic { NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic }));

            Console.WriteLine("     > ProcessarDebitos > ProcessarServico - Dados Calculo Rebate ");
            Console.WriteLine("");

            //Tratamento de débitos
            if (listCalculoRebateSicInterna.Count > 0)
            {
                var proxy = new wsConsultaDebitosSoapClient();
                Console.WriteLine("     > ProcessarDebitos > ProcessarServico - Tratamento de débitos ");
                Console.WriteLine("");
                //Percorre lista de calculos
                foreach (CalculoRebateSic calculoRebate in listCalculoRebateSicInterna)
                {
                    //Valida se o calculo foi cancelado ou pago, se sim não consulta os débitos
                    if (calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Cancelado) ||
                        calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento) ||
                        calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago) ||
                        calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo)) // //RSIC-103
                        continue;

                    //Verifica se existe débito em todos os pagadores do controlador
                    var rebate = BuscaRebate(calculoRebate);
                    var debitoRbc = proxy.ObterListaDebitosPorIbmControlador(RebateUtil.FormatarIBM(rebate.NrCodigopagadorRebateSic)).ToList();
                    DebitoRebateSic debitoValidacao = SelecionarDebitoRbcPorIBM(debitoRbc, rebate);

                    //Prepara Historico
                    StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic();
                    historico.NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic;
                    historico.DtAlteracaoSic = RebateUtil.GetDataAtual();
                    historico.NmLoginSic = ConstantesRebate.USUARIO_SERVICO;

                    //Não Possui débitos atualmente
                    if (debitoValidacao == null)
                    {
                        //Inserir registro de débito com valor 0
                        debitoValidacao = new DebitoRebateSic
                        {
                            DtConsultaSic = RebateUtil.GetDataAtual(),
                            NrSeqRebateSic = calculoRebate.NrSeqRebateSic,
                            VlDebitoSic = 0
                        };
                        DebitoRebateSicBLOService.Incluir(debitoValidacao);

                        //Verificar se possuia débitos
                        if (calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.PendenteDebito))
                        {
                            //Buscando o último status
                            IList<StatusCalculoRebateHistoricoSic> listaStatus = StatusCalculoRebateHistoricoSicBLOService.Selecionar(
                                new StatusCalculoRebateHistoricoSic { NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic });
                            listaStatus = listaStatus.Where(ls => ls.NrSeqStatusCalculoRebateSic != Convert.ToInt16(StatusCalculoRebate.PendenteDebito)).ToList()
                                .OrderByDescending(ss => ss.NrSeqStatusCalculoRebateHistoricoSic).ToList();

                            //Status
                            int NrSeqStatusCalculoRebateSic = listaStatus.First().NrSeqStatusCalculoRebateSic.Value;

                            //Possuia débitos e não possui mais... Voltar para último status
                            calculoRebate.NrSeqStatusCalculoRebateSic = NrSeqStatusCalculoRebateSic;
                            historico.NrSeqStatusCalculoRebateSic = NrSeqStatusCalculoRebateSic;
                            historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_GENERICO,
                                ConstantesRebate.DS_HISTORICO_SEM_DEBITO,
                                calculoRebate.NrSeqRebateSic,
                                calculoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"),
                                calculoRebate.VlBonificacaoTotalSic.Value.ToString("N2"));
                        }
                        else //Não possuia débitos, nada a fazer
                            continue;
                    }
                    else //Possui Débitos
                    {
                        //Inserir novo registro de débitos
                        DebitoRebateSicBLOService.Incluir(debitoValidacao);

                        //Possui débitos, nada a fazer
                        if (calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.PendenteDebito))
                            continue;
                        else
                        {
                            //Não possuia débitos
                            calculoRebate.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.PendenteDebito);
                            historico.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.PendenteDebito);
                            historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_PENDENTE_DEBITO,
                                debitoValidacao.NrSeqRebateSic, calculoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"),
                                calculoRebate.VlBonificacaoTotalSic.Value.ToString("N2"));
                        }
                    }

                    //Verificar Débitos da Cadeia do Controlador  - CDI
                    VerificarDebitosCadeiaControlador(calculoRebate, historico);

                    //Inseri histórico
                    StatusCalculoRebateHistoricoSicBLOService.Incluir(historico);

                    //Atualizar Status do cálculo
                    CalculoRebateSicBLOService.Atualizar(calculoRebate);
                }

                Console.WriteLine("     > ProcessarDebitos > ProcessarServico - Percorre lista de calculos ");
                Console.WriteLine("");
            }
        }

        public void RevalidarPendenteDebito()
        {
            IList<CalculoRebateSic> listCalculoRebateSicVerificandoDebitos = CalculoRebateSicBLOService.Selecionar(new CalculoRebateSic { NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.VerificandoDebitos) });
            RevalidarPendenteDebito(listCalculoRebateSicVerificandoDebitos, Convert.ToInt16(StatusCalculoRebate.VerificandoDebitos));
            IList<CalculoRebateSic> listCalculoRebateSicPendenteDebito = CalculoRebateSicBLOService.Selecionar(new CalculoRebateSic { NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.PendenteDebito) });
            RevalidarPendenteDebito(listCalculoRebateSicPendenteDebito, Convert.ToInt16(StatusCalculoRebate.PendenteDebito));
        }

        private void RevalidarPendenteDebito(IList<CalculoRebateSic> listCalculoRebateSic, Int16 NrSeqStatusCalculoRebateSic)
        {
            foreach (CalculoRebateSic calculoRebate in listCalculoRebateSic)
            {
                //Prepara Historico
                StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic();
                historico.NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic;
                historico.DtAlteracaoSic = RebateUtil.GetDataAtual();
                historico.NmLoginSic = ConstantesRebate.USUARIO_SERVICO;

                //Verificar Débitos da Cadeia do Controlador  - CDI
                VerificarRevalidarDebitosCadeiaControlador(calculoRebate, historico);

                if (calculoRebate.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.PendenteDebito))
                {
                    historico.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.PendenteDebito);
                    historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_PENDENTE_DEBITO,
                        calculoRebate.NrSeqRebateSic, calculoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"),
                        calculoRebate.VlBonificacaoTotalSic.Value.ToString("N2"));
                }
                else
                {
                    calculoRebate.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AptoPagamento);
                    if (NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.VerificandoDebitos))
                    {
                        calculoRebate.StAprovadoAnalistaSic = true;
                        calculoRebate.DtAprovadoAnalistaSic = RebateUtil.GetDataAtual();
                    }
                    historico.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AptoPagamento);
                    historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_APTO_PAGAMENTO,
                        calculoRebate.NrSeqRebateSic, calculoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"),
                        calculoRebate.VlBonificacaoTotalSic.Value.ToString("N2"));
                }

                //Inseri histórico
                StatusCalculoRebateHistoricoSicBLOService.Incluir(historico);

                //Atualizar Status do cálculo
                CalculoRebateSicBLOService.Atualizar(calculoRebate);
            }
        }

        private void VerificarDebitosCadeiaControlador(CalculoRebateSic calculoRebate, StatusCalculoRebateHistoricoSic historico)
        {
            string ibm = this.RebateSicDAO.ObterIbmPeloRebate(calculoRebate.NrSeqRebateSic.Value);
            string ibmControlador = this.ObterIbmControladorSAP(ibm);

            if (IsDebitoPendenteControladorRebate(ibmControlador))
            {
                calculoRebate.NrSeqStatusCalculoRebateSic = (int?)StatusCalculoRebate.PendenteDebito;
            }
        }

        private void VerificarRevalidarDebitosCadeiaControlador(CalculoRebateSic calculoRebate, StatusCalculoRebateHistoricoSic historico)
        {
            string ibm = this.RebateSicDAO.ObterIbmPeloRebate(calculoRebate.NrSeqRebateSic.Value);
            string ibmControlador = this.ObterIbmControladorSAP(ibm);

            if (IsDebitoPendenteControladorRebate(ibmControlador))
            {
                calculoRebate.NrSeqStatusCalculoRebateSic = (int?)StatusCalculoRebate.PendenteDebito;
            }
            else
            {
                calculoRebate.NrSeqStatusCalculoRebateSic = (int?)StatusCalculoRebate.AptoPagamento;
            }
        }

        /// <summary>
        /// ObterIbmControladorSAP
        /// </summary>
        /// <param name="ibm"></param>
        /// <returns></returns>
        private string ObterIbmControladorSAP(string ibm)
        {
            try
            {
                var service = new CreditoService();
                return service.ObterIbmControlador(ibm);
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// IsDebitoPendenteControladorRebate
        /// </summary>
        /// <param name="ibmControlador"></param>
        /// <returns></returns>
        private bool IsDebitoPendenteControladorRebate(string ibmControlador)
        {
            try
            {
                AtualizaDocContabilService service = new AtualizaDocContabilService();
                return service.IsCadeiaTemDebito(ibmControlador);
            }
            catch
            {
                return false;
            }
        }

        private RebateSic BuscaRebate(CalculoRebateSic calculoRebate)
        {
            RebateSic rebate = null;
            //Tenta buscar na lista local
            if (this.ListRebateSic != null && this.ListRebateSic.Count > 0)
                rebate = this.ListRebateSic.FirstOrDefault(r => r.NrSeqRebateSic == calculoRebate.NrSeqRebateSic);

            //Senão encontrou busca na base
            if (rebate == null || rebate.NrSeqRebateSic == 0)
                rebate = RebateSicBLOService.Selecionar(new RebateSic { NrSeqRebateSic = calculoRebate.NrSeqRebateSic }).First();
            return rebate;
        }

        #endregion Métodos Processamento Débitos

        #region Métodos Calcular Rebate

        /// <summary>
        /// Calcula a bonificação de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        public void RecalcularUltimoPeriodo(RebateSic rebateSic, string url = null, string login = null)
        {
            //Busca o rebate
            rebateSic = RebateSicBLOService.Selecionar(rebateSic).First();

            //SE É RECALCULO, ENTENDE-SE QUE O PERÍODO ATUAL NÃO FOI PAGO, DESSA FORMA,
            //É NECESSÁRIO VALIDAR O VOLUME ATÉ O PERÍODO ANTERIOR
            //DESCOBRINDO O PERÍODO ANTERIOR
            //Buscar último cálculo
            CalculoRebateSic calculoRebateSic = CalculoRebateSicBLOService.SelecionarUltimo(
                new CalculoRebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    StAditivoSic = false
                });
            //Classifica tipo
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
            //Verifica se é trimestral ou mensal
            int periodicidadePagto = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;

            var mensagem = string.Empty;
            if (!ValidarVigencia(rebateSic, calculoRebateSic.DtPeriodoSic.Value.AddMonths(periodicidadePagto * -1), out mensagem))
                throw new Exception(string.Format("Não é possível recalcular, {0}", mensagem));

            ////Verificar se o cliente já foi aceito
            //if (!VerificarClienteAceito(rebateSic.NrSeqClienteSic.Value))
            //    throw new Exception("O cliente não está com status aceito.");

            if (calculoRebateSic.NrSeqCalculoRebateSic == null || calculoRebateSic.NrSeqCalculoRebateSic == 0)
                throw new Exception("Não existe nenhuma bonificação calculada para o rebate informado."); //Calculo não existe

            //Verifica se já foi pago, se sim não pode excluir
            if (calculoRebateSic.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago))
                throw new Exception("A bonificação já foi paga, não é possível recalcular."); //Calculo pago

            //Verifica se já foi enviado para pagamento, se sim não pode excluir
            if (calculoRebateSic.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento))
                throw new Exception("A bonificação já foi enviada para pagamento, não é possível recalcular."); //Calculo Enviado Pagamento

            //Verifica se já foi cancelado, se sim não pode excluir
            if (calculoRebateSic.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Cancelado))
                throw new Exception("A bonificação foi cancelada, não é possível recalcular."); //Calculo Cancelado

            //Datas Utilizadas para cálculo
            DateTime dataFimPeriodo = RebateUtil.GetFimPeriodoMensal(RebateUtil.GetFimPeriodo(calculoRebateSic.DtPeriodoSic.Value));

            //Para o tipo Cosan, não deve calcular o último período
            if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().AddMonths(-1).Month)
                throw new Exception("Para este tipo de rebate, não é possível efetuar o recálculo.");

            //Formata data Inicio
            DateTime dataInicioPeriodo = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ?
                RebateUtil.GetInicioPeriodoMensal(calculoRebateSic.DtPeriodoSic.Value) :
                RebateUtil.GetInicioPeriodoTrimestral(calculoRebateSic.DtPeriodoSic.Value);

            //Apagar Cálculo do último período se existir
            CalculoRebateSicBLOService.ExcluirCalculoUltimoPeriodo(rebateSic, calculoRebateSic.DtPeriodoSic.Value, dataInicioPeriodo, dataFimPeriodo);

            //Recupera os Volumes
            if (cosan && !rebateSic.StCalculoRebateSic.Value)
                dataInicioPeriodo = dataInicioPeriodo.AddMonths(-2);

            IList<VolumeRbc> volumesSelecionados;
            //Buscar os volumes do último período
            List<RebateSic> listRebate = new List<RebateSic>();
            listRebate.Add(rebateSic);
            List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesListaRebate(listRebate).ToList();
            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, dataInicioPeriodo, dataFimPeriodo, true, out volumesSelecionados, url, login).ToList();
            VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas, true);

            //Calcular os volumes
            //Buscar os volumes do período pelas faixas rebate
            listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();

            listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                dataInicioPeriodo, dataFimPeriodo, listFaixas).ToList());

            //Prepara listas para inserção
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
            List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
            List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

            //Calcular Rebate
            Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, calculoRebateSic.DtPeriodoSic.Value, false, volumesSelecionados as List<VolumeRbc>);

            //Preparando listas para inserção
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
            IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, false);

            //Bloco de Inserção ...............................................................
            CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                listVolumeCalculoRebateFaixaSic,
                listCalculoRebateFaixaSic,
                listCalculoRebateProporcionalSic,
                listCalculoRebateSic,
                listStatusCalculoRebateHistoricoSic,
                listSaldoRebateSic);

            //Processar / Inserir Débitos
            ProcessarDebitos(listCalculoRebateSic);
        }

        /// <summary>
        /// Executa o calculo retroativo de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        public void CalcularRetroativoAntigo(RebateSic rebateSic, string url = null, string login = null)
        {
            //Busca o rebate
            rebateSic = RebateSicBLOService.Selecionar(rebateSic).First();

            //Datas Utilizadas para cálculo
            DateTime dataAtual = RebateUtil.GetDataAtual();
            DateTime dataInicioPeriodo = new DateTime(rebateSic.DtIniciovigenciaRebateSic.Value.Year, rebateSic.DtIniciovigenciaRebateSic.Value.Month, 1);

            //O RETROATIVO CONSIDERA QUE NÃO HOUVERAM CALCULOS REBATE. DESSA FORMA DEVE CONSIDERAR APENAS
            //O QUE FOI CONSUMIDO ATÉ O INICIO DO REBATE

            var mensagem = string.Empty;
            if (!ValidarVigencia(rebateSic, dataInicioPeriodo, out mensagem, true))
                throw new Exception(string.Format("Não é possível calcular o retroativo, {0}", mensagem));

            ////Verificar se o cliente já foi aceito
            //if (!VerificarClienteAceito(rebateSic.NrSeqClienteSic.Value))
            //    throw new Exception("O cliente não está com status aceito.");

            //Verificar se possui o rebate é elegível de cálculo retroativo
            if (rebateSic.StCalculoRetroativoSic == null || !rebateSic.StCalculoRetroativoSic.Value)
                throw new Exception("Rebate não marcado como retroativo.");

            //Verificar se possui algum cálculo, se existir não deixa fazer o cálculo retroativo
            CalculoRebateSic validacao = CalculoRebateSicBLOService.SelecionarPrimeiro(new CalculoRebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic });
            if (validacao != null && validacao.NrSeqCalculoRebateSic.HasValue)
                throw new Exception("Não é possível executar o cálculo retroativo de um rebate que possua cálculos anteriores.");

            //Cria Lista rebate para utilização
            List<RebateSic> listRebate = new List<RebateSic>();
            listRebate.Add(rebateSic);

            //Verifica o tipo
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);

            //Verificar se é trimestral o mensal
            //Verifica o tipo
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
            int incremento = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;

            //Percorrer os periodos do inicio retroativo até hoje
            DateTime periodoInicialVar = dataInicioPeriodo;

            //Buscar a proxima data limite
            DateTime periodoFimVar = mensal || (cosan && incremento == 1) ? RebateUtil.GetFimPeriodoMensal(periodoInicialVar) : RebateUtil.GetFimPeriodoTrimestral(periodoInicialVar);

            //Calcula meses do inicio até o final
            DateTime periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);

            //Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e calculados dentro do intervalo atual
            if (cosan && rebateSic.DtIniciovigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().Year && rebateSic.DtIniciovigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().Month)
            {
                periodoInicialVar = periodoInicialVar.AddMonths(-1);
                periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoInicialVar);
                periodoCalculo = periodoCalculo.AddMonths(-1);
            }

            //Percorre todos os meses até periodo atual
            while (periodoCalculo <= dataAtual)
            {
                //NÃO FAZ MAIS CALCULO SE NÃO FOR MAIS VIGENTE POR VOLUME
                if (!VerificarVigenciaVolume(periodoInicialVar, rebateSic, out mensagem)) break;

                //Para o tipo Cosan, não deve calcular o último período
                if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == dataAtual.AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == dataAtual.AddMonths(-1).Month)
                    continue;

                //Verifica se deve executar o cálculo para o mês atual caso esteja após do período de calculo
                if (periodoCalculo.Year == dataAtual.Year && periodoCalculo.Month == dataAtual.Month && dataAtual.Day < GetDiaCalculo())
                {
                    //Incrementa o mês e Formata Período Bonificação
                    periodoInicialVar = periodoInicialVar.AddMonths(incremento);
                    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));
                    periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                    continue;
                }

                List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesRebate(new FaixarebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    DtIniciocalculoRebateSic = periodoInicialVar,
                    DtFimcalculoRebateSic = periodoFimVar
                }).ToList();
                if (listFaixas == null || listFaixas.Count == 0)
                    throw new Exception(string.Format("Não foram encontradas faixas vigentes para este rebate no período {0} a {1}."
                        , periodoInicialVar.ToShortDateString(), periodoFimVar.ToShortDateString()));

                //Recuperar volume de 3 meses para cosan
                DateTime periodoInicialBuscaVolume = periodoInicialVar;
                if (cosan && incremento == 1) periodoInicialBuscaVolume = periodoInicialVar.AddMonths(-2);

                IList<VolumeRbc> volumesSelecionados;
                //Buscar os volumes
                List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesSelecionados, url, login).ToList();
                VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                //Recupera os Volumes
                listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
                listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                    periodoInicialBuscaVolume, periodoFimVar, listFaixas).ToList());

                //Prepara listas do cálculo
                List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

                //Calcular Rebate
                Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, periodoCalculo, false, volumesSelecionados as List<VolumeRbc>);
                rebateSic.StPossuiCalculoRebateSic = true;

                //Preparando listas para inserção
                IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
                IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, false);

                //Bloco de Inserção ...............................................................
                CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                    listVolumeCalculoRebateFaixaSic,
                    listCalculoRebateFaixaSic,
                    listCalculoRebateProporcionalSic,
                    listCalculoRebateSic,
                    listStatusCalculoRebateHistoricoSic,
                    listSaldoRebateSic,
                   new List<RebateSic> { rebateSic });

                //Processar / Inserir Débitos
                ProcessarDebitos(listCalculoRebateSic);

                //Incrementa o mês
                periodoInicialVar = periodoInicialVar.AddMonths(incremento);
                periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

                //Formata Período Bonificação
                periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
            }

            //Tira a marcação retroativa do rebate
            rebateSic.StCalculoRetroativoSic = false;
            RebateSicBLOService.Atualizar(rebateSic);
        }

        /// <summary>
        /// Executa o cálculo retroativo de um rebate com log detalhado de cada passo.
        /// </summary>
        /// <param name="rebateSic">Rebate a ser calculado.</param>
        /// <param name="url">URL opcional.</param>
        /// <param name="login">Login do usuário opcional.</param>
        public void CalcularRetroativo(RebateSic rebateSic, string url = null, string login = null)
        {
            DateTime inicioExecucao = DateTime.Now;
            var logRebateBLL = new LogRebateRetroativoBLO();
            try
            {
                // Recuperar Rebate
                var rebateBLL = new RebateSicBLO();
                var reb = rebateBLL.SelecionarPrimeiro(rebateSic);
                if(reb != null & reb.NrIbmRebateSic != null)
                {
                    rebateSic = reb;
                }
            }
            catch (Exception ex)
            {
                // Faz nada
            }
            LogRebateRetroativo log = new LogRebateRetroativo
            {
                NrSeqAplicacaoRebateRetroativo = 1,
                NrSeqModuloRebateRetroativo = 1,
                NrSeqEntidadeRebateRetroativo = rebateSic.NrSeqRebateSic ?? 0,
                DtLogDatetimeRebateRetroativo = inicioExecucao,
                CdLogUsuarioRebateRetroativo = login ?? "Sistema",
                XmlLogDetalheRebateRetroativo = $"<LogIniciado>- Calculo retroativo iniciado - IBM:{rebateSic?.NrIbmRebateSic} -</br></br></LogIniciado>"
            };

            try
            {
                logRebateBLL.Incluir(log);

                // ----------------------------------

                int contador = 1;
                // ----------------------------------


                // Inicialização
                DateTime agora = DateTime.Now;
                //Busca o rebate
                rebateSic = RebateSicBLOService.Selecionar(rebateSic).First();
                LogEtapa(logRebateBLL, log, $"{contador} - Busca rebate", agora);
                contador++;
                //Datas Utilizadas para cálculo
                DateTime dataAtual = RebateUtil.GetDataAtual();
                DateTime dataInicioPeriodo = new DateTime(rebateSic.DtIniciovigenciaRebateSic.Value.Year, rebateSic.DtIniciovigenciaRebateSic.Value.Month, 1);

                // Validações
                agora = DateTime.Now;
                //O RETROATIVO CONSIDERA QUE NÃO HOUVERAM CALCULOS REBATE. DESSA FORMA DEVE CONSIDERAR APENAS
                //O QUE FOI CONSUMIDO ATÉ O INICIO DO REBATE
                if (!ValidarVigencia(rebateSic, dataInicioPeriodo, out var mensagem, true))
                    throw LogErro(logRebateBLL, log, $"Não é possível calcular o retroativo: {mensagem}");
                LogEtapa(logRebateBLL, log, $"{contador} - Validação da vigência", agora);
                contador++;

                // Verificações
                agora = DateTime.Now;
                //Verificar se possui o rebate é elegível de cálculo retroativo
                if (rebateSic.StCalculoRetroativoSic == null || !rebateSic.StCalculoRetroativoSic.Value)
                    throw LogErro(logRebateBLL, log, "Rebate não marcado como retroativo.");
                LogEtapa(logRebateBLL, log, $"{contador} - Verificação de retroatividade", agora);
                contador++;

                // Verifica se possui algum cálculo, se existir não deixa fazer o cálculo retroativo
                agora = DateTime.Now;
                //Verificar se possui algum cálculo, se existir não deixa fazer o cálculo retroativo
                var validacao = CalculoRebateSicBLOService.SelecionarPrimeiro(new CalculoRebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic });
                if (validacao != null && validacao.NrSeqCalculoRebateSic.HasValue)
                    throw LogErro(logRebateBLL, log, "Não é possível executar o cálculo retroativo de um rebate que possua cálculos anteriores.");
                LogEtapa(logRebateBLL, log, $"{contador} - Validação de cálculos anteriores", agora);
                contador++;

                //Cria Lista rebate para utilização
                List<RebateSic> listRebate = new List<RebateSic>();
                listRebate.Add(rebateSic);

                // Busca o tipo de rebate
                agora = DateTime.Now;
                //Verifica o tipo
                TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
                bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
                LogEtapa(logRebateBLL, log, $"{contador} - Verificação do tipo de rebate", agora);
                contador++;

                //Verificar se é trimestral o mensal
                //Verifica o tipo
                agora = DateTime.Now;
                bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
                int incremento = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;
                LogEtapa(logRebateBLL, log, $"{contador} - Verificação trimestral ou mensal", agora);
                contador++;

                //Percorrer os periodos do inicio retroativo até hoje
                agora = DateTime.Now;
                DateTime periodoInicialVar = dataInicioPeriodo;

                //Buscar a proxima data limite
                DateTime periodoFimVar = mensal || (cosan && incremento == 1) ? RebateUtil.GetFimPeriodoMensal(periodoInicialVar) : RebateUtil.GetFimPeriodoTrimestral(periodoInicialVar);

                //Calcula meses do inicio até o final
                DateTime periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                LogEtapa(logRebateBLL, log, $"{contador} - Cálculo de meses inicial e final", agora);
                contador++;

                //Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e calculados dentro do intervalo atual
                agora = DateTime.Now;
                if (cosan && rebateSic.DtIniciovigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().Year && rebateSic.DtIniciovigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().Month)
                {
                    periodoInicialVar = periodoInicialVar.AddMonths(-1);
                    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoInicialVar);
                    periodoCalculo = periodoCalculo.AddMonths(-1);
                }
                LogEtapa(logRebateBLL, log, $"{contador} - Verifica se os tipos cosan que possuem inicio de vigencia igual ao periodo atual", agora);
                contador++;

                // Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e
                // calculados dentro do intervalo atual
                while (periodoCalculo <= dataAtual)
                {
                    agora = DateTime.Now;
                    //NÃO FAZ MAIS CALCULO SE NÃO FOR MAIS VIGENTE POR VOLUME
                    if (!VerificarVigenciaVolume(periodoInicialVar, rebateSic, out mensagem)) break;

                    //Para o tipo Cosan, não deve calcular o último período
                    if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == dataAtual.AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == dataAtual.AddMonths(-1).Month)
                        continue;

                    //Verifica se deve executar o cálculo para o mês atual caso esteja após do período de calculo
                    if (periodoCalculo.Year == dataAtual.Year && periodoCalculo.Month == dataAtual.Month && dataAtual.Day < GetDiaCalculo())
                    {
                        //Incrementa o mês e Formata Período Bonificação
                        periodoInicialVar = periodoInicialVar.AddMonths(incremento);
                        periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));
                        periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                        continue;
                    }

                    List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesRebate(new FaixarebateSic
                    {
                        NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                        DtIniciocalculoRebateSic = periodoInicialVar,
                        DtFimcalculoRebateSic = periodoFimVar
                    }).ToList();
                    if (listFaixas == null || listFaixas.Count == 0)
                        throw LogErro(logRebateBLL, log, string.Format("Não foram encontradas faixas vigentes para este rebate no período {0} a {1}."
                            , periodoInicialVar.ToShortDateString(), periodoFimVar.ToShortDateString()));

                    //Recuperar volume de 3 meses para cosan
                    DateTime periodoInicialBuscaVolume = periodoInicialVar;
                    if (cosan && incremento == 1) periodoInicialBuscaVolume = periodoInicialVar.AddMonths(-2);

                    IList<VolumeRbc> volumesSelecionados;
                    //Buscar os volumes
                    List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesSelecionados, url, login).ToList();
                    VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                    //Recupera os Volumes
                    listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
                    listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                        periodoInicialBuscaVolume, periodoFimVar, listFaixas).ToList());

                    //Prepara listas do cálculo
                    List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                    List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                    List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                    List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

                    //Calcular Rebate
                    Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, periodoCalculo, false, volumesSelecionados as List<VolumeRbc>);
                    rebateSic.StPossuiCalculoRebateSic = true;

                    //Preparando listas para inserção
                    IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
                    IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, false);

                    //Bloco de Inserção ...............................................................
                    CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                        listVolumeCalculoRebateFaixaSic,
                        listCalculoRebateFaixaSic,
                        listCalculoRebateProporcionalSic,
                        listCalculoRebateSic,
                        listStatusCalculoRebateHistoricoSic,
                        listSaldoRebateSic,
                       new List<RebateSic> { rebateSic });

                    //Processar / Inserir Débitos
                    ProcessarDebitos(listCalculoRebateSic);

                    //Incrementa o mês
                    periodoInicialVar = periodoInicialVar.AddMonths(incremento);
                    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

                    //Formata Período Bonificação
                    periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);

                    //------------------------------------- Finalizar Loop -------------------------------------    


                    LogEtapa(logRebateBLL, log, $"{contador} - Processamento do período {periodoInicialVar} a {periodoFimVar}", agora);

                    contador++;
                }

                // Atualiza rebate
                //Tira a marcação retroativa do rebate
                agora = DateTime.Now;
                rebateSic.StCalculoRetroativoSic = false;
                RebateSicBLOService.Atualizar(rebateSic);
                LogEtapa(logRebateBLL, log, $"{contador} - Atualização do rebate", agora);

                contador++;

                // Finaliza log com tempo total
                log.XmlLogDetalheRebateRetroativo += $"<TotalExecucao>{(DateTime.Now - inicioExecucao).TotalSeconds} segundos</TotalExecucao>";
                logRebateBLL.Atualizar(log);
            }
            catch (Exception ex)
            {
                log.XmlLogDetalheRebateRetroativo += $"<Erro>{ex.Message}</br></Erro>";
                logRebateBLL.Atualizar(log);
                throw;
            }
        }

        /// <summary>
        /// Loga uma etapa da execução.
        /// </summary>
        private void LogEtapa(LogRebateRetroativoBLO logRebateBLL, LogRebateRetroativo log, string descricao, DateTime agora)
        {
            log.XmlLogDetalheRebateRetroativo += $"<Etapa><Descricao>| {descricao} |</Descricao><Inicio> [{agora}]-</Inicio><Fim>-[{DateTime.Now}] </br></Fim></Etapa>";
            logRebateBLL.Atualizar(log);
        }

        /// <summary>
        /// Loga um erro e lança uma exceção com a mensagem.
        /// </summary>
        private Exception LogErro(LogRebateRetroativoBLO logRebateBLL, LogRebateRetroativo log, string mensagemErro)
        {
            log.XmlLogDetalheRebateRetroativo += $"<Erro>|| {mensagemErro} ||</br></Erro>";
            logRebateBLL.Atualizar(log);
            return new Exception(mensagemErro);
        }



        /// <summary>
        /// Executa o cálculo aditivo
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="dataInicioAditivo"></param>
        public void CalcularAditivo(RebateSic rebateSic, DateTime dataInicioAditivo, string url = null, string login = null)
        {
            //Busca o rebate
            rebateSic = RebateSicBLOService.Selecionar(rebateSic).First();
            var mensagem = string.Empty;
            if (!ValidarVigencia(rebateSic, dataInicioAditivo, out mensagem, true))
                throw new Exception(string.Format("Não é possível calcular o aditivo, {0}", mensagem));

            ////Verificar se o cliente já foi aceito
            //if (!VerificarClienteAceito(rebateSic.NrSeqClienteSic.Value))
            //    throw new Exception("O cliente não está com status aceito.");

            //Cria Lista rebate para utilização
            List<RebateSic> listRebate = new List<RebateSic>();
            listRebate.Add(rebateSic);

            ////Verificar se possui o rebate é elegível de cálculo aditivo
            //if (dataInicioAditivo > rebateSic.DtFimvigenciaRebateSic)
            //    throw new Exception("Não é possível calcular o aditivo, a data informada é posterior a data de término do contrato.");

            ////Verificar se possui o rebate é elegível de cálculo aditivo
            //if (dataInicioAditivo < rebateSic.DtIniciovigenciaRebateSic)
            //    throw new Exception("Não é possível calcular o aditivo, a data informada é anterior a data de inicio do contrato.");

            //Verifica o tipo
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);

            //Buscar data de inicio do grupo considerando o inicio do aditivo
            DateTime dataAtual = RebateUtil.GetDataAtual();
            DateTime dataInicioPeriodo = RebateUtil.GetInicioPeriodoAditivo(rebateSic.DtIniciovigenciaRebateSic.Value, dataInicioAditivo);

            //Verificar se é trimestral o mensal
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
            int incremento = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;

            //Recuperar data de inicio correta para cosan
            if (cosan || mensal)
                dataInicioPeriodo = new DateTime(dataInicioAditivo.AddMonths(0).Year, dataInicioAditivo.AddMonths(0).Month, 1);

            //Busca de faixas
            List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasAditivo(rebateSic, dataInicioPeriodo).ToList();
            if (listFaixas == null || listFaixas.Count == 0)
                throw new Exception("Não foram encontradas faixas vigentes para o rebate.");

            //Percorrer os periodos do inicio retroativo até hoje
            DateTime periodoInicialVar = mensal || (cosan && incremento == 1) ? RebateUtil.GetInicioPeriodoMensal(dataInicioPeriodo) : RebateUtil.GetInicioPeriodoTrimestral(dataInicioPeriodo);
            //VALIDAÇÃO PARA INÍCIO DO PERÍODO
            //O PERÍODO INICIAL NUNCA PODE SER ANTERIOR A DATA DE INICIO DO CONTRATO REBATE
            //ISSO PODE CRIAR UM PROBLEMA NO CASO DE REBATE MENSAL ONDE NÃO DEVE GERAR BONIFICAÇÃO NO MÊS DE INÍCIO DA VIGÊNCIA.
            //O VOLUME DO MÊS DE INÍCIO DEVE SER CONTABILIZADO NO MÊS SEGUINTE
            if (rebateSic.DtIniciovigenciaRebateSic.HasValue &&
                periodoInicialVar < rebateSic.DtIniciovigenciaRebateSic.Value)
                periodoInicialVar = rebateSic.DtIniciovigenciaRebateSic.Value;

            //Buscar a proxima data limite
            DateTime periodoFimVar = mensal || (cosan && incremento == 1) ? RebateUtil.GetFimPeriodoMensal(periodoInicialVar) : RebateUtil.GetFimPeriodoTrimestral(periodoInicialVar);

            //Calcula meses do inicio até o final
            DateTime periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);

            //Percorre todos os meses até periodo atual
            while (periodoCalculo <= dataAtual)
            {
                #region ...

                //Busca de faixas
                //MUDADO PARA CÁ.
                //DEVE FAZER A BUSCA DA FAIXA PARA CADA PERÍODO INFORMADO, CONSIDERANDO QUE PARA CADA
                //PERÍODO PODE HAVER UMA FAIXA VIGENTE DIFERENTE
                //FAIXAS DEVEM SER VIGENTES AO MENOS EM PERIODO -1D (FIM DO MÊS ANTERIOR, CASO DE FINAL DE CONTRATO)
                //List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasAditivo(rebateSic, periodoCalculo.AddDays(-1D)).ToList();
                //if (listFaixas == null || listFaixas.Count == 0)
                //    throw new Exception("Não foram encontradas faixas vigentes para o rebate.");

                #endregion ...

                //NÃO FAZ MAIS CALCULO SE NÃO FOR MAIS VIGENTE POR VOLUME
                if (!VerificarVigenciaVolume(periodoInicialVar, rebateSic, out mensagem)) break;

                //Para o tipo Cosan, não deve calcular o último período
                if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == dataAtual.AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == dataAtual.AddMonths(-1).Month)
                    continue;

                //Verifica se deve executar o cálculo para o mês atual caso esteja após do período de calculo
                if (periodoCalculo.Year == dataAtual.Year && periodoCalculo.Month == dataAtual.Month && dataAtual.Day < GetDiaCalculo())
                {
                    //Incrementa o mês
                    IncrementaMesAditivo(incremento, ref periodoInicialVar, ref periodoFimVar, ref periodoCalculo);
                    continue;
                }

                //Recuperar volume de 3 meses para cosan
                DateTime periodoInicialBuscaVolume = periodoInicialVar;
                if (cosan && incremento == 1) periodoInicialBuscaVolume = periodoInicialVar.AddMonths(-2);

                IList<VolumeRbc> volumesSelecionados = new List<VolumeRbc>();
                //Buscar os volumes
                List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesSelecionados, url, login).ToList();
                //Inclui os volumes - OBS: Se ja existir volume para o periodo inserido anteriormente, não insere o novo volume
                VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                #region OLD : Murilo Beltrame 28/07/2014 : O primeiro calculo deve olhar apenas o cenário atual

                ////Recupera os Volumes
                //List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSicAnterior = VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodoAditivo(periodoInicialBuscaVolume, periodoFimVar, rebateSic).ToList();

                ////CORRECAO - Insercao e busca de quando muda o volume (guarda-chuva) - Paulo 11/09/2013
                ////Atualiza os volumes atuais sobre os dados selecionados do BD
                //foreach (VolumeMensalFaixaRebateSic volumeMensalAnterior in listVolumeMensalFaixaRebateSicAnterior)
                //{
                //    volumeMensalAnterior.VlVolumeCompradoSic = listVolumeMensalFaixaRebateSic.Where(v => v.NrSeqCategoriaSic == volumeMensalAnterior.NrSeqCategoriaSic &&
                //                                                                                        v.NrSeqRebateSic == volumeMensalAnterior.NrSeqRebateSic &&
                //                                                                                        v.DtPeriodoSic == volumeMensalAnterior.DtPeriodoSic)
                //                                                                                        .FirstOrDefault().VlVolumeCompradoSic;
                //}
                ////Apos atualizar volumes, atribui valor atualizado a lista que irá trabalhar
                //listVolumeMensalFaixaRebateSic = listVolumeMensalFaixaRebateSicAnterior;

                #endregion OLD : Murilo Beltrame 28/07/2014 : O primeiro calculo deve olhar apenas o cenário atual

                //Valida Volumes
                if (listVolumeMensalFaixaRebateSic.Count == 0)
                {
                    LogError.Debug(string.Format("Aditivo do rebate {0} sem volume consumido para o perído {1}, cálculo não será efetuado.", rebateSic.NrIbmRebateSic, periodoCalculo.ToString("MM/yyyy")));
                    IncrementaMesAditivo(incremento, ref periodoInicialVar, ref periodoFimVar, ref periodoCalculo);
                    continue;
                }

                //Prepara listas do cálculo
                List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

                //Calcular Rebate
                Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, periodoCalculo, true, volumesSelecionados as List<VolumeRbc>);

                //Antes de inserir, acertar o valor do aditivo
                var listaCalculoOriginal = CalculoRebateSicBLOService.Selecionar(new CalculoRebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    DtPeriodoSic = periodoCalculo,
                    StAditivoSic = false
                });
                //BUSCA CALCULO ORIGINAL QUE NÃO TENHA SIDO CANCELADO
                CalculoRebateSic calculoOriginal = listaCalculoOriginal
                    .OrderByDescending(r => r.DtPeriodoSic)
                    .FirstOrDefault(r => r.NrSeqStatusCalculoRebateSic != 7); //TODO : MUDAR PARA CONSTANTE
                if (calculoOriginal == null) calculoOriginal = new CalculoRebateSic();

                if (calculoOriginal.NrSeqCalculoRebateSic == null)
                {
                    calculoOriginal.VlBonificacaoTotalSic = 0;
                }
                else
                {
                    //Calcular valor aditivo
                    //Verificar se a faixa comprende todo período...
                    int diferencaMesesFaixa = incremento;

                    #region OLD : Murilo Beltrame 28/07/2014 : Deve buscar aditivo somente quando a data de busca de volume for maior que o inicio do período

                    //if (dataInicioAditivo >= periodoInicialBuscaVolume)

                    #endregion OLD : Murilo Beltrame 28/07/2014 : Deve buscar aditivo somente quando a data de busca de volume for maior que o inicio do período

                    if (dataInicioAditivo > periodoInicialBuscaVolume)
                    {
                        diferencaMesesFaixa = RebateUtil.GetDiferencaMeses(periodoInicialBuscaVolume, periodoFimVar);

                        //Cálculo proporcional
                        if (diferencaMesesFaixa < incremento && incremento > 1)
                        {
                            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaAditivo = new List<VolumeCalculoRebateFaixaSic>();
                            List<CalculoRebateFaixaSic> listCalculoRebateFaixaAditivo = new List<CalculoRebateFaixaSic>();
                            List<CalculoRebateProporcionalSic> listCalculoRebateProporcional = new List<CalculoRebateProporcionalSic>();
                            List<CalculoRebateSic> listCalculoRebateAditivo = new List<CalculoRebateSic>();

                            //Buscar faixas antigas com datas atuais
                            List<FaixarebateSic> listFaixasHistorico = this.FaixaRebateSicBLOService.SelecionarFaixasHistorico(calculoOriginal.NrSeqCalculoRebateSic.Value).ToList();
                            listFaixasHistorico.ForEach(a => a.DtIniciocalculoRebateSic = listFaixas.First().DtIniciocalculoRebateSic);

                            //RECUPERAR O VOLUME HISTÓRICO
                            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSicAnterior = VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodoAditivo(periodoInicialBuscaVolume, periodoFimVar, rebateSic).ToList();

                            //Recalcular Rebate Proporcional Aditivo
                            Calcular(rebateSic, listFaixasHistorico, listVolumeMensalFaixaRebateSicAnterior, listVolumeCalculoRebateFaixaAditivo,
                                listCalculoRebateFaixaAditivo, listCalculoRebateProporcional, listCalculoRebateAditivo, periodoCalculo, true, volumesSelecionados as List<VolumeRbc>);

                            //Recupera valor do cálculo proporcional
                            foreach (CalculoRebateSic calculo in listCalculoRebateAditivo)
                                calculoOriginal.VlBonificacaoTotalSic = calculo.VlBonificacaoTotalSic;

                            //Caso não consiga calcular, considera proporcional simples
                            if (listCalculoRebateAditivo.Count == 0)
                                calculoOriginal.VlBonificacaoTotalSic = (calculoOriginal.VlBonificacaoTotalSic.Value / incremento) * diferencaMesesFaixa;
                        }
                    }
                }

                decimal valorAditivo = 0;
                foreach (CalculoRebateSic calculo in listCalculoRebateSic)
                {
                    valorAditivo = calculo.VlBonificacaoTotalSic.Value - calculoOriginal.VlBonificacaoTotalSic.Value;
                    calculo.VlBonificacaoTotalSic = valorAditivo;
                    foreach (var calculoProporcional in listCalculoRebateProporcionalSic)
                        calculoProporcional.VlValorBonificacaoProporcionalSic = valorAditivo * calculoProporcional.VlProporcaoSic;
                }

                //Validar aditivo
                if (valorAditivo <= 0)
                {
                    LogError.Debug(string.Format("Aditivo do rebate {0} com valor valor negativo ou nulo para o perído {1}, cálculo não será considerado.", rebateSic.NrIbmRebateSic, periodoCalculo.ToString("MM/yyyy")));
                    IncrementaMesAditivo(incremento, ref periodoInicialVar, ref periodoFimVar, ref periodoCalculo);
                    continue;
                }

                //Zera a bonificação das faixas por se tratar de aditivo
                foreach (CalculoRebateFaixaSic calculoFaixa in listCalculoRebateFaixaSic)
                    calculoFaixa.VlBonificacaoCalculadoSic = 0;

                //Preparando listas para inserção
                IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, true);
                IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, true);

                //Bloco de Inserção ...............................................................
                CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                    listVolumeCalculoRebateFaixaSic,
                    listCalculoRebateFaixaSic,
                    listCalculoRebateProporcionalSic,
                    listCalculoRebateSic,
                    listStatusCalculoRebateHistoricoSic,
                    listSaldoRebateSic);

                //Processar / Inserir Débitos
                ProcessarDebitos(listCalculoRebateSic);

                //Incrementa o mês
                IncrementaMesAditivo(incremento, ref periodoInicialVar, ref periodoFimVar, ref periodoCalculo);
            }
        }

        /// <summary>
        /// Executa o cálculo acerto de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        public List<AcertoCalculoRebateSic> CalcularAcerto(RebateSic rebateSic, string url = null, string login = null)
        {
            //Preparando listas para saldo de acerto
            List<AcertoCalculoRebateSic> listAcertoCalculoRebateSic = new List<AcertoCalculoRebateSic>();

            //Busca o rebate
            rebateSic = RebateSicBLOService.Selecionar(new RebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic }).First();

            //Busca dados do calculo rebate
            this.DadosCalculoRebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoRebateSicBLO>("DadosCalculoRebateSicBLO");
            DadosCalculoRebateSic dadosCalculoRebateSic = this.DadosCalculoRebateSicBLO.SelecionarUltimo(
            new DadosCalculoRebateSic
            {
                NrIbmClienteSic = rebateSic.NrIbmRebateSic
            });

            //Verificar se o cliente já foi aceito
            if (!VerificarClienteAceito(rebateSic.NrSeqClienteSic.Value))
                throw new Exception("IBM não está com o status aceito.");

            //Verificar se possui cálculo, se existir faz o cálculo de acerto
            CalculoRebateSic validacao = CalculoRebateSicBLOService.SelecionarUltimo(new CalculoRebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic });
            if (validacao != null && !validacao.NrSeqCalculoRebateSic.HasValue)
                throw new Exception("Não é possível executar o acerto de cálculo de um rebate sem cálculos.");

            if (dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic == null)
                throw new Exception("Não é possível executar o acerto de cálculo de um rebate sem dados de cálculos.");
            else
                rebateSic.StCalculoRebateSic = dadosCalculoRebateSic.StCalculoRebateSic;

            //Datas Utilizadas para cálculo
            DateTime dataAtual = dadosCalculoRebateSic.DtPeriodoSic.Value;
            DateTime dataInicioPeriodo = new DateTime(rebateSic.DtIniciovigenciaRebateSic.Value.Year, rebateSic.DtIniciovigenciaRebateSic.Value.Month, 1);

            //Cria Lista rebate para utilização
            List<RebateSic> listRebate = new List<RebateSic>();
            listRebate.Add(rebateSic);

            //Verifica o tipo
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);

            //Verificar se é trimestral o mensal
            //Verifica o tipo
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;
            int incremento = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;
            int incrementoProporcional = incremento;

            //Percorrer os periodos do inicio retroativo até hoje
            DateTime periodoInicialVar = dataInicioPeriodo;

            //Buscar a proxima data limite
            DateTime periodoFimVar = mensal || (cosan && incremento == 1) ? RebateUtil.GetFimPeriodoMensal(periodoInicialVar) : RebateUtil.GetFimPeriodoTrimestral(periodoInicialVar);
            var peridoFimVarInicial = periodoFimVar;
            //Calcula meses do inicio até o final
            DateTime periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);

            bool trimestreProporcional = false;
            if (periodoCalculo > dataAtual)
            {
                periodoCalculo = dataAtual;
                trimestreProporcional = true;
            }

            //Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e calculados dentro do intervalo atual
            if (cosan && rebateSic.DtIniciovigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().Year && rebateSic.DtIniciovigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().Month)
            {
                periodoInicialVar = periodoInicialVar.AddMonths(-1);
                periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoInicialVar);
                periodoCalculo = periodoCalculo.AddMonths(-1);
            }

            AcertoCalculoRebateSic acertoCalculoRebateSic = new AcertoCalculoRebateSic();
            acertoCalculoRebateSic.VlBonificacaoTotalSic = 0;
            acertoCalculoRebateSic.VlAcertoBonificacaoTotalSic = 0;
            acertoCalculoRebateSic.VlSaldoAcertoBonificacaoSic = 0;

            //Percorre todos os meses até periodo atual
            while (periodoCalculo <= dataAtual)
            {
                // Busca calculo original
                CalculoRebateSic calculoRebateSic = CalculoRebateSicBLOService.SelecionarUltimo(
                new CalculoRebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    DtPeriodoSic = periodoCalculo
                });

                // Trimestral Proporcional

                if (rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value)
                {
                    // Verifica se achou o calculo original
                    if (calculoRebateSic.NrSeqCalculoRebateSic == null)
                    {
                        while (calculoRebateSic.NrSeqCalculoRebateSic == null)
                        {
                            periodoCalculo = periodoCalculo.AddMonths(-1);
                            calculoRebateSic = CalculoRebateSicBLOService.SelecionarUltimo(
                            new CalculoRebateSic
                            {
                                NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                                DtPeriodoSic = periodoCalculo
                            });
                            periodoFimVar = periodoFimVar.AddMonths(-1);
                            incrementoProporcional -= 1;
                            trimestreProporcional = true;
                        }
                    }
                }

                if (calculoRebateSic.NrSeqCalculoRebateSic != null && calculoRebateSic.NrSeqStatusCalculoRebateSic == Convert.ToInt16(StatusCalculoRebate.Pago))
                {
                    acertoCalculoRebateSic.DtPeriodoSic = calculoRebateSic.DtPeriodoSic;
                    acertoCalculoRebateSic.NrSeqRebateSic = calculoRebateSic.NrSeqRebateSic;
                    acertoCalculoRebateSic.StCalculoRebateSic = dadosCalculoRebateSic.StCalculoRebateSic;
                }
                else
                {
                    //Incrementa o mês
                    periodoInicialVar = periodoInicialVar.AddMonths(incrementoProporcional < incremento ? incrementoProporcional : incremento);
                    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

                    //Formata Período Bonificação
                    periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                    continue;
                }

                if (rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value && calculoRebateSic.NrSeqCalculoRebateSic == null)
                {
                    //Incrementa o mês
                    periodoInicialVar = periodoInicialVar.AddMonths(incrementoProporcional < incremento ? incrementoProporcional : incremento);
                    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

                    //Formata Período Bonificação
                    periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                    continue;
                }

                //Para o tipo Cosan, não deve calcular o último período
                if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == dataAtual.AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == dataAtual.AddMonths(-1).Month)
                    continue;

                //Verifica se deve executar o cálculo para o mês atual caso esteja após do período de calculo
                //if (periodoCalculo.Year == dataAtual.Year && periodoCalculo.Month == dataAtual.Month && dataAtual.Day < GetDiaCalculo())
                //{
                //    //Incrementa o mês e Formata Período Bonificação
                //    periodoInicialVar = periodoInicialVar.AddMonths(incremento);
                //    periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));
                //    periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
                //    continue;
                //}

                List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesRebate(new FaixarebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    DtIniciocalculoRebateSic = periodoInicialVar,
                    DtFimcalculoRebateSic = periodoFimVar
                }).ToList();
                if (listFaixas == null || listFaixas.Count == 0)
                    throw new Exception(string.Format("Não foram encontradas faixas vigentes para este rebate no período {0} a {1}."
                        , periodoInicialVar.ToShortDateString(), periodoFimVar.ToShortDateString()));

                //Recuperar volume de 3 meses para cosan
                DateTime periodoInicialBuscaVolume = periodoInicialVar;
                if (cosan && incremento == 1) periodoInicialBuscaVolume = periodoInicialVar.AddMonths(-2);

                IList<VolumeRbc> volumesSelecionados;
                //Buscar os volumes
                List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesSelecionados, url, login).ToList();
                VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                //Recupera os Volumes
                listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
                listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                    periodoInicialBuscaVolume, periodoFimVar, listFaixas).ToList());

                //Prepara listas do cálculo
                List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

                if ((calculoRebateSic == null || (dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic != null && rebateSic.StCalculoRebateSic != dadosCalculoRebateSic.StCalculoRebateSic)) || (rebateSic.StCalculoRebateSic.Value && (peridoFimVarInicial > periodoFimVar)) || trimestreProporcional)
                {
                    RebateSic dadosRebateSic = RebateSicBLOService.Selecionar(new RebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic }).First();
                    // Calcular com parâmetros
                    dadosRebateSic.StCalculoRebateSic = dadosCalculoRebateSic.StCalculoRebateSic;
                    dadosRebateSic.NrSeqTiporebateSic = dadosCalculoRebateSic.NrSeqTipoRebate;

                    List<RebateSic> listDadosRebate = new List<RebateSic>();
                    listDadosRebate.Add(rebateSic);

                    List<FaixarebateSic> listDadosFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesRebate(new FaixarebateSic
                    {
                        NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                        DtIniciocalculoRebateSic = periodoInicialVar,
                        DtFimcalculoRebateSic = periodoFimVar
                    }).ToList();

                    this.DadosCalculoFaixaRebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoFaixaRebateSicBLO>("DadosCalculoFaixaRebateSicBLO");
                    IList<DadosCalculoRebateFaixaSic> listDadosCalculoRebateFaixaSic = this.DadosCalculoFaixaRebateSicBLO.Selecionar(new DadosCalculoRebateFaixaSic { NrSeqDadosCalculoRebateSic = dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic });
                    List<FaixarebateSic> listDadosFaixasc = new List<FaixarebateSic>();
                    foreach (var dadoFaixa in listDadosFaixas)
                    {
                        DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic = listDadosCalculoRebateFaixaSic.Where(w => w.NrSeqCategoriaSic.Equals(dadoFaixa.NrSeqCategoriaSic)).FirstOrDefault();
                        dadoFaixa.VlVolumemensalRebateSic = dadosCalculoRebateFaixaSic.VlVolumeMensalRebateSic;
                        dadoFaixa.VlPercminimoRebateSic = dadosCalculoRebateFaixaSic.VlPercMinimoRebateSic;
                        dadoFaixa.VlPercmaximoRebateSic = dadosCalculoRebateFaixaSic.VlPercMaximoRebateSic;
                        dadoFaixa.VlBonificacaoRebateSic = dadosCalculoRebateFaixaSic.VlBonificacaoRebateSic;
                        listDadosFaixasc.Add(dadoFaixa);
                    }

                    IList<VolumeRbc> volumesDadosSelecionados;
                    //Buscar os volumes
                    List<VolumeMensalFaixaRebateSic> listVolumeDadosMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listDadosRebate, listDadosFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesDadosSelecionados, url, login).ToList();
                    VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                    //Recupera os Volumes
                    listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
                    listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                        periodoInicialBuscaVolume, periodoFimVar, listFaixas).ToList());

                    //Prepara listas do cálculo
                    List<VolumeCalculoRebateFaixaSic> listVolumeDadosCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                    List<CalculoRebateFaixaSic> listCalculoDadosRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                    List<CalculoRebateProporcionalSic> listCalculoDadosRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                    List<CalculoRebateSic> listCalculoDadosRebateSic = new List<CalculoRebateSic>();

                    //Calcular Retroativo Proposrcional do Rebate
                    Calcular(rebateSic, listDadosFaixasc, listVolumeMensalFaixaRebateSic, listVolumeDadosCalculoRebateFaixaSic, listCalculoDadosRebateFaixaSic, listCalculoDadosRebateProporcionalSic, listCalculoDadosRebateSic, periodoCalculo, true, volumesDadosSelecionados as List<VolumeRbc>, true);
                    calculoRebateSic = listCalculoDadosRebateSic.FirstOrDefault();
                }

                //Calcular Acerto Rebate
                Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, periodoCalculo, false, volumesSelecionados as List<VolumeRbc>, true);
                rebateSic.StPossuiCalculoRebateSic = true;

                acertoCalculoRebateSic.VlBonificacaoTotalSic += calculoRebateSic.VlBonificacaoTotalSic;
                acertoCalculoRebateSic.VlAcertoBonificacaoTotalSic += listCalculoRebateSic.First().VlBonificacaoTotalSic;
                acertoCalculoRebateSic.DtIniciocalculoRebateSic = periodoInicialVar;
                acertoCalculoRebateSic.DtFimcalculoRebateSic = periodoFimVar;
                if (acertoCalculoRebateSic.DtPeriodoSic.Equals(listCalculoRebateSic.FirstOrDefault().DtPeriodoSic))
                {
                    acertoCalculoRebateSic.VlSaldoAcertoBonificacaoSic = acertoCalculoRebateSic.VlAcertoBonificacaoTotalSic - acertoCalculoRebateSic.VlBonificacaoTotalSic;
                    listAcertoCalculoRebateSic.Add(acertoCalculoRebateSic);
                    acertoCalculoRebateSic = new AcertoCalculoRebateSic();
                    acertoCalculoRebateSic.VlBonificacaoTotalSic = 0;
                    acertoCalculoRebateSic.VlAcertoBonificacaoTotalSic = 0;
                    acertoCalculoRebateSic.VlSaldoAcertoBonificacaoSic = 0;
                }

                IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
                IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoRebateSic, false);

                //Incrementa o mês
                periodoInicialVar = periodoInicialVar.AddMonths(incrementoProporcional < incremento ? incrementoProporcional : incremento);
                periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

                //Formata Período Bonificação
                periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
            }
            return listAcertoCalculoRebateSic;
        }

        public void LancarAcertos(List<AcertoCalculoRebateSic> listAcertoCalculoRebateSic, string url = null, string login = null)
        {
            foreach (var acerto in listAcertoCalculoRebateSic)
            {
                DateTime periodoInicialVar = acerto.DtIniciocalculoRebateSic.Value;
                DateTime periodoFimVar = acerto.DtFimcalculoRebateSic.Value;
                DateTime periodoCalculo = acerto.DtPeriodoSic.Value;

                //Busca o rebate
                RebateSic rebateSic = RebateSicBLOService.Selecionar(new RebateSic { NrSeqRebateSic = acerto.NrSeqRebateSic }).First();

                //Busca dados do calculo rebate
                this.DadosCalculoRebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoRebateSicBLO>("DadosCalculoRebateSicBLO");
                DadosCalculoRebateSic dadosCalculoRebateSic = this.DadosCalculoRebateSicBLO.SelecionarPrimeiro(
                new DadosCalculoRebateSic
                {
                    NrIbmClienteSic = rebateSic.NrIbmRebateSic
                });

                rebateSic.StCalculoRebateSic = dadosCalculoRebateSic.StCalculoRebateSic;

                //Cria Lista rebate para utilização
                List<RebateSic> listRebate = new List<RebateSic>();
                listRebate.Add(rebateSic);

                List<FaixarebateSic> listFaixas = this.FaixaRebateSicBLOService.SelecionarFaixasVigentesRebate(new FaixarebateSic
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    DtIniciocalculoRebateSic = periodoInicialVar,
                    DtFimcalculoRebateSic = periodoFimVar
                }).ToList();
                if (listFaixas == null || listFaixas.Count == 0)
                    throw new Exception(string.Format("Não foram encontradas faixas vigentes para este rebate no período {0} a {1}."
                        , periodoInicialVar.ToShortDateString(), periodoFimVar.ToShortDateString()));

                //Recuperar volume de 3 meses para cosan
                DateTime periodoInicialBuscaVolume = periodoInicialVar;

                IList<VolumeRbc> volumesSelecionados;
                //Buscar os volumes
                List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = BuscaVolumeRebateBLOService.SelecionarVolumesListaRebate(listRebate, listFaixas, periodoInicialBuscaVolume, periodoFimVar, false, out volumesSelecionados, url, login).ToList();
                VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), listFaixas);

                //Recupera os Volumes
                listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
                listVolumeMensalFaixaRebateSic.AddRange(VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodo(
                    periodoInicialBuscaVolume, periodoFimVar, listFaixas).ToList());

                //Prepara listas do cálculo
                List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
                List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
                List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
                List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();

                //Calcular Acerto Rebate
                Calcular(rebateSic, listFaixas, listVolumeMensalFaixaRebateSic, listVolumeCalculoRebateFaixaSic, listCalculoRebateFaixaSic, listCalculoRebateProporcionalSic, listCalculoRebateSic, periodoCalculo, false, volumesSelecionados as List<VolumeRbc>, true);

                IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = AplicarStatusAptoPagamento(listCalculoRebateSic, false);
                VerificarDebitosCadeiaControlador(listCalculoRebateSic.FirstOrDefault(), new StatusCalculoRebateHistoricoSic());

                List<CalculoRebateSic> listCalculoAcertoRebateSic = new List<CalculoRebateSic>();
                foreach (var calculo in listCalculoRebateSic)
                {
                    calculo.StAditivoSic = false;
                    calculo.StAcertoSic = true;
                    calculo.VlBonificacaoTotalSic = acerto.VlSaldoAcertoBonificacaoSic;
                    if (calculo.VlBonificacaoTotalSic < 0)
                        calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AcertoBloqueado);
                    listCalculoAcertoRebateSic.Add(calculo);
                }

                IList<SaldoRebateSic> listSaldoRebateSic = CreditarBonificacao(listCalculoAcertoRebateSic, false);

                //Bloco de Inserção ...............................................................
                CalculoRebateSicBLOService.IncluirCalculoBonificacaoLista(
                    listVolumeCalculoRebateFaixaSic,
                    listCalculoRebateFaixaSic,
                    listCalculoRebateProporcionalSic,
                    listCalculoAcertoRebateSic,
                    listStatusCalculoRebateHistoricoSic,
                    listSaldoRebateSic,
                   new List<RebateSic> { rebateSic });
            }
        }

        #endregion Métodos Calcular Rebate

        #endregion Metodos Publicos

        /// <summary>
        /// Recupera os débito de um cliente rebate
        /// </summary>
        /// <param name="listDebitoRbc">Lista de débitos RBC</param>
        /// <param name="rebate">Rebate</param>
        /// <returns>DebitoRebateSic</returns>
        private DebitoRebateSic SelecionarDebitoRbcPorIBM(IList<SAL.wsConsultarDebitos.DebitoRbc> listDebitoRbc, RebateSic rebate)
        {
            DebitoRebateSic debitoRebateSic = null;

            //Validação
            if (listDebitoRbc == null || listDebitoRbc.Count == 0)
                return debitoRebateSic;

            //Recupera os débitos do cliente e exclui os débitos que não bloqueiam pagamentos
            //Por numero de pagador
            List<SAL.wsConsultarDebitos.DebitoRbc> listDebitoRbcIBM = listDebitoRbc.Where(d =>
                //RebateUtil.FormatarIBM(d.NrClientePagador) == RebateUtil.FormatarIBM(rebate.NrCodigopagadorRebateSic)
                (d.VlMontante > 0 || d.VlMontante > ConstantesRebate.VALOR_MAXIMO_MONTANTE_DEBITO)
                && d.DiasVencidos > ConstantesRebate.DIAS_MAXIMO_ATRASO_DEBITO).ToList();

            //Se existirem débitos retorna o registro, considera apenas se o montante for maior que zero
            if (listDebitoRbcIBM != null && listDebitoRbcIBM.Count > 0 && listDebitoRbcIBM.Sum(v => v.VlMontante) > 0)
            {
                debitoRebateSic = new DebitoRebateSic
                {
                    DtConsultaSic = RebateUtil.GetDataAtual(),
                    NrSeqRebateSic = rebate.NrSeqRebateSic,
                    VlDebitoSic = listDebitoRbcIBM.Sum(v => v.VlMontante)
                };
            }

            return debitoRebateSic;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="listCalculoRebateSic"></param>
        /// <returns></returns>
        private static IList<StatusCalculoRebateHistoricoSic> AplicarStatusAptoPagamento(List<CalculoRebateSic> listCalculoRebateSic, bool aditivo)
        {
            //Inserir Status Apto Pagamento
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = new List<StatusCalculoRebateHistoricoSic>();
            foreach (CalculoRebateSic calculo in listCalculoRebateSic)
            {
                StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic
                {
                    NrSeqCalculoRebateSic = calculo.NrSeqCalculoRebateSic, //Identificação Provisória M
                    DtAlteracaoSic = RebateUtil.GetDataAtual(),
                    NmLoginSic = ConstantesRebate.USUARIO_SERVICO
                };

                if (calculo.VlBonificacaoTotalSic == 0) //Inserir Status Não Atingiu Volume Mínimo
                {
                    calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo);
                    historico.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo);
                    historico.DsObservacaoSic = string.Concat(string.Format(ConstantesRebate.DS_NAO_ATINGIU_LIMITE_MINIMO,
                        calculo.NrSeqRebateSic, calculo.DtPeriodoSic.Value.ToString("MM/yyyy")), aditivo ? " (Aditivo)" : string.Empty);
                }
                else //Inserir Status Apto Pagamento
                {
                    calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AptoPagamento);
                    historico.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.AptoPagamento);
                    historico.DsObservacaoSic = string.Concat(string.Format(ConstantesRebate.DS_HISTORICO_APTO_PAGAMENTO,
                        calculo.NrSeqRebateSic, calculo.DtPeriodoSic.Value.ToString("MM/yyyy"),
                        calculo.VlBonificacaoTotalSic.Value.ToString("N2")), aditivo ? " (Aditivo)" : string.Empty);
                }

                listStatusCalculoRebateHistoricoSic.Add(historico);
            }

            return listStatusCalculoRebateHistoricoSic;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="listCalculoRebateSic"></param>
        /// <returns></returns>
        private IList<SaldoRebateSic> CreditarBonificacao(List<CalculoRebateSic> listCalculoRebateSic, bool aditivo)
        {
            //Creditar Bonificação
            IList<SaldoRebateSic> listSaldoRebateSic = new List<SaldoRebateSic>();
            foreach (CalculoRebateSic calculo in listCalculoRebateSic.Where(c => c.VlBonificacaoTotalSic > 0).ToList())
            {
                //Busca o último saldo
                SaldoRebateSic saldo = SaldoRebateSicBLOService.SelecionarUltimo(new SaldoRebateSic { NrSeqRebateSic = calculo.NrSeqRebateSic });
                decimal saldoAtual = saldo.VlSaldoAtualSic ?? 0;

                listSaldoRebateSic.Add(new SaldoRebateSic
                {
                    NrSeqRebateSic = calculo.NrSeqRebateSic,
                    VlSaldoAtualSic = (saldoAtual + calculo.VlBonificacaoTotalSic),
                    VlLancamentoSic = calculo.VlBonificacaoTotalSic,
                    DtLancamentoSic = RebateUtil.GetDataAtual(),
                    DsObsComplementoSic = string.Concat(string.Format(
                        ConstantesRebate.DS_EXTRATO_APTO_PAGAMENTO, calculo.DtPeriodoSic.Value.ToString("MM/yyyy")), aditivo ? " (Aditivo)" : string.Empty),
                });
            }
            return listSaldoRebateSic;
        }

        /// <summary>
        /// Cria Lista de Volumes Mensais x Calculo Rebate FAixa
        /// </summary>
        /// <param name="faixa"></param>
        /// <param name="listVolumes"></param>
        /// <returns></returns>
        private List<VolumeCalculoRebateFaixaSic> CriarListaVolumeCalculoRebateFaixaSic(FaixarebateSic faixa, List<VolumeMensalFaixaRebateSic> listVolumes, RebateSic rebateSic)
        {
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();

            //Percorre lista de volumes
            foreach (VolumeMensalFaixaRebateSic volume in listVolumes)
            {
                //Prepara relacionamento NxN
                VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic = new VolumeCalculoRebateFaixaSic();
                volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = faixa.NrSeqFaixarebateSic; //Identificação Provisória N
                volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic = volume.NrSeqVolumeMensalFaixaRebateSic;
                volumeCalculoRebateFaixaSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic;

                //Adiciona registro NxN a lista
                listVolumeCalculoRebateFaixaSic.Add(volumeCalculoRebateFaixaSic);
            }

            return listVolumeCalculoRebateFaixaSic;
        }

        /// <summary>
        /// Calcula Rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="listFaixaRebateSicInterna"></param>
        /// <param name="listVolumeMensalFaixaRebateSic"></param>
        /// <param name="listVolumeCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateSic"></param>
        private void Calcular(
            RebateSic rebateSic,
            List<FaixarebateSic> listFaixaRebateSicInterna,
            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic,
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic,
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            List<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic,
            DateTime dataPeriodo,
            bool aditivo,
            List<VolumeRbc> volumesSelecionados,
            bool acerto = false)
        {
            //Classifica tipo
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;

            //Verifica se é trimestral ou mensal
            int periodicidadePagto = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;

            //Datas
            DateTime dtInicio = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetInicioPeriodoMensal(dataPeriodo) : RebateUtil.GetInicioPeriodoTrimestral(dataPeriodo);
            DateTime dtFim = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetFimPeriodoMensal(dtInicio) : RebateUtil.GetFimPeriodoTrimestral(dtInicio);
            int diferencaMesesPeriodo = RebateUtil.GetDiferencaMeses(dtInicio, dtFim);

            #region Validação

            if (!acerto) // Não validar quando for Cálculo de Acerto do Período
            {
                //Valida se existe cálculo para o rebateneste período
                CalculoRebateSic validacaoRebate = CalculoRebateSicBLOService.SelecionarPrimeiro(
                    new CalculoRebateSic
                    {
                        NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                        DtPeriodoSic = dataPeriodo,
                        StAditivoSic = false
                    });
            
                //Valida e loga
                //Se existirem aditivos no periodo, deixa inserir o cálculo
                if (validacaoRebate.NrSeqCalculoRebateSic != null && validacaoRebate.NrSeqCalculoRebateSic.Value > 0 && !aditivo)
                {
                    LogError.Debug(string.Format("Não é possível efetuar o cálculo: Periodo {0}, NrSeqRebateSic {1}. Este cálculo já foi efetuado!",
                      validacaoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"), validacaoRebate.NrSeqRebateSic));
                    Console.WriteLine(string.Format("Não é possível efetuar o cálculo: Periodo {0}, NrSeqRebateSic {1}. Este cálculo já foi efetuado!",
                      validacaoRebate.DtPeriodoSic.Value.ToString("MM/yyyy"), validacaoRebate.NrSeqRebateSic));
                    Console.WriteLine("");
                    return;
                }
            }

            #endregion Validação

            //Recupera informaçoes do rebate
            List<FaixarebateSic> listFaixas = listFaixaRebateSicInterna.Where(f => f.NrSeqRebateSic == rebateSic.NrSeqRebateSic).ToList();

            //Consistir validação
            if (listFaixas == null || listFaixas.Count == 0)
                return;

            //Lista de faixas calculadas por rebate
            List<CalculoRebateFaixaSic> listCalculoFaixas = new List<CalculoRebateFaixaSic>();

            //Valor Total de Bonificação
            decimal valorBonificacaoTotal = 0;

            //Seleciona o tipo do rebate

            #region REBATE GLOBAL COSAN

            if (tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME))
            {
                //Para o tipo Cosan, não deve calcular o último período
                if (rebateSic.DtFimvigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().AddMonths(-1).Month)
                    return;

                //Distinct nas faixas
                decimal volumeContratado = listFaixas.First().VlVolumemensalRebateSic.Value * periodicidadePagto;

                //Distinct nos volumes
                List<VolumeMensalFaixaRebateSic> volumesCosan = FiltrarVolumeCategoriaPeriodo(listVolumeMensalFaixaRebateSic.Where(x => x.NrSeqRebateSic == rebateSic.NrSeqRebateSic).ToList());

                decimal volumeConsumido = volumesCosan.Sum(v => v.VlVolumeCompradoSic.Value) / 3;//Média trimestral

                //Busca Faixas de consumo
                decimal faixaPercentual = (volumeConsumido * 100) / volumeContratado;
                List<FaixarebateSic> faixasRebateCosan = listFaixas.Where(f => faixaPercentual >= f.VlPercminimoRebateSic.Value &&
                    faixaPercentual <= f.VlPercmaximoRebateSic.Value).ToList();

                //Calcula bonificação total do contrato (os valores das faixas tem q ser iguais! Regra do tipo de rebate)
                if (faixasRebateCosan.Count > 0)
                    valorBonificacaoTotal = faixasRebateCosan.First().VlBonificacaoRebateSic.Value * (faixasRebateCosan.First().VlRecebebonusRebateSic.Value / 100);
                else
                    valorBonificacaoTotal = 0;

                //Percorre a lista de faixas do rebate
                foreach (FaixarebateSic faixa in faixasRebateCosan)
                {
                    //Verificar se a faixa comprende todo período...
                    DateTime dtInicioFaixa = faixa.DtIniciocalculoRebateSic.Value > dtInicio ? faixa.DtIniciocalculoRebateSic.Value : dtInicio;
                    DateTime dtFimFaixa = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetFimPeriodoMensal(dtInicio) : RebateUtil.GetFimPeriodoTrimestral(dtInicio);
                    dtFimFaixa = faixa.DtFimcalculoRebateSic.Value < dtFimFaixa ? faixa.DtFimcalculoRebateSic.Value : dtFimFaixa;

                    //Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e calculados dentro do intervalo atual
                    if (rebateSic.DtIniciovigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().Year && rebateSic.DtIniciovigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().Month)
                        dtInicioFaixa = dtInicio;

                    //Calculo proporcional
                    int diferencaMesesFaixa = RebateUtil.GetDiferencaMeses(dtInicioFaixa, dtFimFaixa);
                    if (diferencaMesesFaixa < 0) continue; //GERA ERRO NA DIVISÂO NA SEQUENCIA DO CODIGO
                    if (diferencaMesesFaixa < diferencaMesesPeriodo)
                        periodicidadePagto = diferencaMesesFaixa + 1;

                    //Recupera os volumes da faixa
                    List<VolumeMensalFaixaRebateSic> listVolumes = (from v in volumesCosan
                                                                    join f in listFaixaRebateSicInterna on v.NrSeqFaixarebateSic equals f.NrSeqFaixarebateSic
                                                                    where f.NrSeqCategoriaSic == faixa.NrSeqCategoriaSic
                                                                    select v).Distinct().ToList();

                    //Prenche informações de agrupamento do cálculo
                    CalculoRebateFaixaSic calculoRebateFaixaSic = new CalculoRebateFaixaSic();
                    calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = faixa.NrSeqFaixarebateSic; //Identificação Provisória N
                    calculoRebateFaixaSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic; //Identificação Provisória M
                    calculoRebateFaixaSic.VlVolumeCalculadoSic = 0;

                    //Cria lista de VolumeMensal x CalculoRebatFaixa
                    listVolumeCalculoRebateFaixaSic.AddRange(CriarListaVolumeCalculoRebateFaixaSic(faixa, listVolumes,rebateSic));

                    //Média
                    calculoRebateFaixaSic.VlVolumeCalculadoSic = listVolumes.Sum(v => v.VlVolumeCompradoSic ?? 0) / 3;
                    calculoRebateFaixaSic.VlVolumeContratadoSic = volumeContratado;

                    //Cálcula os limites mínimo e máximo da bonificação
                    calculoRebateFaixaSic.VlVolumeMaximoSic = (volumeContratado / periodicidadePagto) * (faixa.VlPercmaximoRebateSic / 100);
                    calculoRebateFaixaSic.VlVolumeMinimoSic = (volumeContratado / periodicidadePagto) * (faixa.VlPercminimoRebateSic / 100);
                    calculoRebateFaixaSic.VlBonificacaoCalculadoSic = volumeConsumido == 0 ? 0 : ((calculoRebateFaixaSic.VlVolumeCalculadoSic * valorBonificacaoTotal) / volumeConsumido);

                    if (calculoRebateFaixaSic.VlVolumeMaximoSic.HasValue && calculoRebateFaixaSic.VlVolumeMaximoSic.Value >= 100000000)
                        calculoRebateFaixaSic.VlVolumeMaximoSic = Decimal.Parse("99999999,999");

                    //Adiciona cálculo faixa a lista
                    listCalculoFaixas.Add(calculoRebateFaixaSic);
                }
            }

            #endregion REBATE GLOBAL COSAN

            #region REBATE GLOBAL RAÍZEN, REBATE FASEADO

            else if (tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME) ||
                     tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_FAIXA_VOLUME))
            {
                //Indica se é global soma
                bool globalSoma = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME);

                //Prepara lista de grupo x volume
                Dictionary<int, decimal> dictGrupoVolume = new Dictionary<int, decimal>();

                List<int> listGrupos = (from f in listFaixas select f.NrSeqGrupoSic.Value).Distinct().ToList();

                //Recupera os volumes da faixa
                foreach (int grupo in listGrupos)
                {
                    //Recupera faixas do grupo
                    List<FaixarebateSic> listFaixasGrupo = listFaixas.Where(f => f.NrSeqGrupoSic == grupo).ToList();

                    //Recupera volume por grupo
                    foreach (FaixarebateSic faixa in listFaixasGrupo)
                    {
                        List<VolumeMensalFaixaRebateSic> listVolumes = listVolumeMensalFaixaRebateSic.Where(
                            v => v.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic).ToList();

                        if (aditivo)
                        {
                            DateTime dtInicioFaixa = faixa.DtIniciocalculoRebateSic.Value > dtInicio ? faixa.DtIniciocalculoRebateSic.Value : dtInicio;
                            DateTime dtFimFaixa = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetFimPeriodoMensal(dtInicioFaixa) : RebateUtil.GetFimPeriodoTrimestral(dtInicioFaixa);
                            dtFimFaixa = faixa.DtFimcalculoRebateSic.Value < dtFimFaixa ? faixa.DtFimcalculoRebateSic.Value : dtFimFaixa;

                            listVolumes = listVolumeMensalFaixaRebateSic.Where(v =>
                            v.NrSeqCategoriaSic == faixa.NrSeqCategoriaSic &&
                            v.DtPeriodoSic.Value >= dtInicioFaixa && v.DtPeriodoSic.Value <= dtFimFaixa).ToList();
                        }

                        decimal volume = listVolumes.Sum(v => v.VlVolumeCompradoSic).Value;

                        if (dictGrupoVolume.ContainsKey(grupo))
                            dictGrupoVolume[grupo] += volume;
                        else
                            dictGrupoVolume.Add(grupo, volume);
                    }
                }

                //Percorre a lista de faixas do rebate
                foreach (FaixarebateSic faixa in listFaixas)
                {
                    //Verificar se a faixa comprende todo período...
                    DateTime dtInicioFaixa = faixa.DtIniciocalculoRebateSic.Value > dtInicio ? faixa.DtIniciocalculoRebateSic.Value : dtInicio;
                    DateTime dtFimFaixa = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetFimPeriodoMensal(dtInicioFaixa) : RebateUtil.GetFimPeriodoTrimestral(dtInicioFaixa);
                    dtFimFaixa = faixa.DtFimcalculoRebateSic.Value < dtFimFaixa ? faixa.DtFimcalculoRebateSic.Value : dtFimFaixa;

                    //Calculo proporcional
                    int diferencaMesesFaixa = RebateUtil.GetDiferencaMeses(dtInicioFaixa, dtFimFaixa);
                    if (diferencaMesesFaixa < diferencaMesesPeriodo) periodicidadePagto = diferencaMesesFaixa + 1;
                    if (periodicidadePagto < 0) continue; //Evita periodo negativo, consequentemente evita calculo errado (negativo)

                    //Recupera os volumes da faixa
                    List<VolumeMensalFaixaRebateSic> listVolumes = listVolumeMensalFaixaRebateSic.Where(
                        v => v.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic).ToList();

                    if (aditivo)
                    {
                        listVolumes = listVolumeMensalFaixaRebateSic.Where(v =>
                            v.NrSeqCategoriaSic == faixa.NrSeqCategoriaSic &&
                            v.DtPeriodoSic.Value >= dtInicioFaixa && v.DtPeriodoSic.Value <= dtFimFaixa).ToList();
                    }

                    //Prenche informações de agrupamento do cálculo
                    CalculoRebateFaixaSic calculoRebateFaixaSic = new CalculoRebateFaixaSic();
                    calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = faixa.NrSeqFaixarebateSic; //Identificação Provisória N
                    calculoRebateFaixaSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic; //Identificação Provisória M
                    calculoRebateFaixaSic.VlVolumeCalculadoSic = 0;

                    //Cria lista de VolumeMensal x CalculoRebatFaixa
                    listVolumeCalculoRebateFaixaSic.AddRange(CriarListaVolumeCalculoRebateFaixaSic(faixa, listVolumes, rebateSic));

                    //Soma o volume consumido na faixa
                    calculoRebateFaixaSic.VlVolumeCalculadoSic = listVolumes.Sum(volume => volume.VlVolumeCompradoSic ?? 0);
                    calculoRebateFaixaSic.VlVolumeContratadoSic = faixa.VlVolumemensalRebateSic * periodicidadePagto;

                    //Cálcula os limites mínimo e máximo da bonificação
                    calculoRebateFaixaSic.VlVolumeMaximoSic = (faixa.VlVolumemensalRebateSic * periodicidadePagto * faixa.VlPercmaximoRebateSic) / 100;
                    calculoRebateFaixaSic.VlVolumeMinimoSic = (faixa.VlVolumemensalRebateSic * periodicidadePagto * faixa.VlPercminimoRebateSic) / 100;

                    if (calculoRebateFaixaSic.VlVolumeMaximoSic.HasValue && calculoRebateFaixaSic.VlVolumeMaximoSic.Value >= 100000000)
                        calculoRebateFaixaSic.VlVolumeMaximoSic = Decimal.Parse("99999999,999");

                    //Se volume comprado for maior ou igual ao mínimo
                    if (dictGrupoVolume[faixa.NrSeqGrupoSic.Value] >= calculoRebateFaixaSic.VlVolumeMinimoSic)
                    {
                        //Se volume comprado maior ou igual ao máximo
                        if (dictGrupoVolume[faixa.NrSeqGrupoSic.Value] >= calculoRebateFaixaSic.VlVolumeMaximoSic)
                            calculoRebateFaixaSic.VlBonificacaoCalculadoSic = calculoRebateFaixaSic.VlVolumeMaximoSic * faixa.VlBonificacaoRebateSic;
                        else //Volume comprado está entre o mínimo e o máximo
                            calculoRebateFaixaSic.VlBonificacaoCalculadoSic = calculoRebateFaixaSic.VlVolumeCalculadoSic * faixa.VlBonificacaoRebateSic;
                    }
                    else //Não atingiu o valor mínimo para bonificação
                        calculoRebateFaixaSic.VlBonificacaoCalculadoSic = 0;

                    //Somatoria do total
                    valorBonificacaoTotal += calculoRebateFaixaSic.VlBonificacaoCalculadoSic.Value; //Soma bonificação

                    //Adiciona cálculo faixa a lista
                    listCalculoFaixas.Add(calculoRebateFaixaSic);
                }

                //Caso seja global soma, encontra os valores proporcionais para as faixas x grupos
                if (globalSoma)
                {
                    foreach (var grupo in dictGrupoVolume)
                    {
                        List<FaixarebateSic> faixasGrupo = listFaixas.Where(f => f.NrSeqGrupoSic == grupo.Key).ToList();
                        if (faixasGrupo != null && faixasGrupo.Count > 1)
                        {
                            List<CalculoRebateFaixaSic> calculosFaixa = listCalculoFaixas.Where(
                                vcf => listFaixas.Select(lf => lf.NrSeqFaixarebateSic).ToArray().Contains(vcf.NrSeqCalculoRebateFaixaSic)).ToList();

                            decimal volumeMaxGrupo = calculosFaixa.First().VlVolumeMaximoSic ?? 0;
                            decimal valorBonificacaoTotalGrupo = listCalculoFaixas.Sum(b => b.VlBonificacaoCalculadoSic ?? 0) / faixasGrupo.Count;
                            if (grupo.Value > 0 && grupo.Value >= volumeMaxGrupo)
                                foreach (CalculoRebateFaixaSic calcFaixa in listCalculoFaixas)
                                    calcFaixa.VlBonificacaoCalculadoSic = (calcFaixa.VlVolumeCalculadoSic / grupo.Value) * valorBonificacaoTotalGrupo;
                        }
                    }

                    //Recalcula Total
                    valorBonificacaoTotal = listCalculoFaixas.Sum(b => b.VlBonificacaoCalculadoSic ?? 0);
                }
            }

            #endregion REBATE GLOBAL RAÍZEN, REBATE FASEADO

            #region REBATE ESCALONADO

            else if (tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_ESCALONADO))
            {
                //CONSIDERANDO QUE OS VOLUMES JÁ POSSUAM A FAIXA CORRETA ONDE
                //O MÉTODO RESPONSÁVEL POR ESSA ASSOCIAÇÃO É: BLL.BuscaVolumeRebateBLO.FormatarListaVolumesGlobalMedia
                //E QUE O CÁLCULO DO REBATE ESCALONADO RECEBE APENAS O CONJUNTO DE VolumeMensalFaixaRebateSic QUE POSSUAM VALOR
                //E QUE O CONJUNTO DE VolumeMensalFaixaRebateSic POSSUI UM MEMBRO PARA CADA MÊS DO PERÍODO DE PAGAMENTO

                //ENCONTRA O GRUPO DA FAIXA
                List<int> listGrupos = (from f in listFaixas select f.NrSeqGrupoSic.Value).Distinct().ToList();

                foreach (int grupo in listGrupos)
                {
                    //ENCONTRA TODAS AS FAIXAS PARA O GRUPO
                    var listFaixasGrupo = listFaixas
                        .Where(f => f.NrSeqGrupoSic == grupo);
                    listFaixasGrupo = listFaixasGrupo.OrderByDescending(r => r.VlVolumemensalRebateSic).ToList();

                    //DEFININDO AS CATEGORIAS PERTENCENTES AO GRUPO
                    var categoriasGrupo = listFaixasGrupo.Select(r => r.NrSeqCategoriaSic).Distinct();
                    //DEFININDO O VOLUME DO GRUPO COM BASE EM TODOS OS VOLUMES DISTINTOS DE TODAS AS CATEGORIAS DO GRUPO
                    var volumesDistintos = listVolumeMensalFaixaRebateSic
                        .Where(r => categoriasGrupo.Any(ir => r.NrSeqCategoriaSic == ir) && r.NrSeqRebateSic == rebateSic.NrSeqRebateSic)
                        .Select(r => new
                        {
                            Periodo = r.DtPeriodoSic,
                            Categoria = r.NrSeqCategoriaSic,
                            Volume = r.VlVolumeCompradoSic
                        })
                        .Distinct();
                    var volume = volumesDistintos.Sum(r => r.Volume);
                    //AGRUPANDO AS FAIXAS POR CATEGORIA PARA SELECIONAR POR CATEGORIA OS VOLUMES
                    var listaFaixasGrupoAgrupado = listFaixasGrupo
                       .GroupBy(r => r.NrSeqCategoriaSic);
                    //DEFINE A FAIXA PARA CADA VOLUME
                    var faixa = new FaixarebateSic();
                    var aptoPagamento = true;
                    var volumesFaixa = new List<VolumeMensalFaixaRebateSic>();
                    foreach (var faixaGrupo in listaFaixasGrupoAgrupado)
                    {
                        //SELECIONA A FAIXA DE BONIFICAÇÃO PARA A CATEGORIA A VOLUME DEFINIDOS
                        faixa = faixaGrupo.FirstOrDefault(ir =>
                        {
                            return
                                (ir.VlVolumemensalRebateSic * periodicidadePagto) <= volume &&
                                faixaGrupo.Key == ir.NrSeqCategoriaSic; //KEY É NrSeqCategoriaSic DADO PELO AGRUPAMENTO
                        });
                        //SE NÃO ATINGIR O VOLUME, NÃO VAI HAVER FAIXA. GRAVA DA MESMA FORMA COM A ÚLTIMA FAIXA DO GRUPO.
                        //A DECISÃO SOBRE A BONIFICAÇÃO É DE CARGO DO CÁLCULO
                        if (faixa == null)
                        {
                            faixa = faixaGrupo.Last(r => r.NrSeqCategoriaSic == faixaGrupo.Key);
                            aptoPagamento = false;
                        }
                        var volumesSelecionadosParaFaixa = listVolumeMensalFaixaRebateSic
                            .Where(r => r.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic)
                            .ToList();

                        volumesFaixa.AddRange(volumesSelecionadosParaFaixa);

                        //Cria lista de VolumeMensal x CalculoRebatFaixa
                        listVolumeCalculoRebateFaixaSic.AddRange(
                            CriarListaVolumeCalculoRebateFaixaSic(
                                faixa,
                                volumesSelecionadosParaFaixa,rebateSic));
                    }

                    #region OLD

                    ////ENCONTRA TODAS AS FAIXAS PARA O GRUPO
                    //List<FaixarebateSic> listFaixasGrupo = listFaixas
                    //    .Where(f => f.NrSeqGrupoSic == grupo)
                    //    .ToList();

                    //var volumesFaixa = listVolumeMensalFaixaRebateSic
                    //    .Where(r => listFaixasGrupo.Any(ir => ir.NrSeqFaixarebateSic == r.NrSeqFaixarebateSic))
                    //    .ToList();

                    //var listaFaixasGrupoAgrupado = listFaixasGrupo
                    //   .GroupBy(r => r.NrSeqCategoriaSic);

                    ////DEFINE O VOLUME TOTAL DO GRUPO
                    ////List<VolumeMensalFaixaRebateSic> volumesFaixa = new List<VolumeMensalFaixaRebateSic>();
                    ////foreach (var faixaGrupo in listaFaixasGrupoAgrupado)
                    ////{
                    ////    var faixa = faixaGrupo.First();
                    ////    volumesFaixa.AddRange(listVolumeMensalFaixaRebateSic
                    ////        .Where(r => r.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic));
                    ////}
                    //var volume = volumesFaixa.Sum(r => r.VlVolumeCompradoSic ?? 0);

                    //DO GRUPO, SELECIONA A FAIXA COM VOLUME IMEDIATAMENTE INFERIOR AO VOLUME PARA PAGAMENTO DA BONIFICAÇÃO
                    //listFaixasGrupo = listFaixasGrupo.OrderByDescending(r => r.VlVolumemensalRebateSic).ToList();
                    //var faixaBonificacao = listFaixasGrupo.FirstOrDefault(r => r.VlVolumemensalRebateSic <= volume);

                    #endregion OLD

                    var volumeAjustado = volume;
                    if (faixa != null &&
                        faixa.VlPercmaximoRebateSic.HasValue &&
                        faixa.VlPercmaximoRebateSic.Value > 0 &&
                        faixa.VlPercmaximoRebateSic.Value * periodicidadePagto < volume)
                        volumeAjustado = faixa.VlPercmaximoRebateSic.Value * periodicidadePagto;

                    //Prenche informações de agrupamento do cálculo
                    CalculoRebateFaixaSic calculoRebateFaixaSic = new CalculoRebateFaixaSic();
                    calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = faixa.NrSeqFaixarebateSic; //Identificação Provisória N
                    calculoRebateFaixaSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic; //Identificação Provisória M
                    //Média
                    calculoRebateFaixaSic.VlVolumeCalculadoSic = volume ?? 0M;
                    calculoRebateFaixaSic.VlVolumeContratadoSic = faixa.VlVolumemensalRebateSic * periodicidadePagto ?? 0M;
                    //Cálcula os limites mínimo e máximo da bonificação
                    calculoRebateFaixaSic.VlVolumeMinimoSic = faixa.VlVolumemensalRebateSic * periodicidadePagto ?? 0M;
                    calculoRebateFaixaSic.VlVolumeMaximoSic = faixa.VlPercmaximoRebateSic * periodicidadePagto ?? 0M; //O VOLUME MÁXIMO ESTA NESSA PROPRIEDADE
                    calculoRebateFaixaSic.VlBonificacaoCalculadoSic = aptoPagamento ? volumeAjustado * faixa.VlBonificacaoRebateSic : 0M;
                    //Adiciona cálculo faixa a lista
                    listCalculoFaixas.Add(calculoRebateFaixaSic);
                    //CORRIGINDO PARA O ID DA FAIXA
                    //listVolumeCalculoRebateFaixaSic.ForEach(r =>
                    //{
                    //    r.NrSeqCalculoRebateFaixaSic = calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic;
                    //});

                    #region OLD

                    //if (faixaBonificacao != null)
                    //{
                    //    //AJUSTANDO VOLUME
                    //    var volumeAjustado = volume;
                    //    if (faixaBonificacao.VlPercmaximoRebateSic.HasValue &&
                    //        faixaBonificacao.VlPercmaximoRebateSic.Value > 0 &&
                    //        faixaBonificacao.VlPercmaximoRebateSic < volume)
                    //        volumeAjustado = faixaBonificacao.VlPercmaximoRebateSic.Value;

                    //    //Prenche informações de agrupamento do cálculo
                    //    CalculoRebateFaixaSic calculoRebateFaixaSic = new CalculoRebateFaixaSic();
                    //    calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = faixaBonificacao.NrSeqFaixarebateSic; //Identificação Provisória N
                    //    calculoRebateFaixaSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic; //Identificação Provisória M
                    //    //Média
                    //    calculoRebateFaixaSic.VlVolumeCalculadoSic = volume;
                    //    calculoRebateFaixaSic.VlVolumeContratadoSic = faixaBonificacao.VlVolumemensalRebateSic;
                    //    //Cálcula os limites mínimo e máximo da bonificação
                    //    calculoRebateFaixaSic.VlVolumeMinimoSic = faixaBonificacao.VlVolumemensalRebateSic;
                    //    calculoRebateFaixaSic.VlVolumeMaximoSic = faixaBonificacao.VlPercmaximoRebateSic; //O VOLUME MÁXIMO ESTA NESSA PROPRIEDADE
                    //    calculoRebateFaixaSic.VlBonificacaoCalculadoSic = volumeAjustado * faixaBonificacao.VlBonificacaoRebateSic;
                    //    //Adiciona cálculo faixa a lista
                    //    listCalculoFaixas.Add(calculoRebateFaixaSic);

                    //    //Cria lista de VolumeMensal x CalculoRebatFaixa
                    //    listVolumeCalculoRebateFaixaSic.AddRange(CriarListaVolumeCalculoRebateFaixaSic(faixaBonificacao, volumesFaixa));
                    //}

                    #endregion OLD
                }
            }

            #endregion REBATE ESCALONADO

            //Preenche cálculo
            CalculoRebateSic calculoRebateSic = new CalculoRebateSic();
            calculoRebateSic.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic; //Identificação Provisória M
            calculoRebateSic.NrSeqRebateSic = rebateSic.NrSeqRebateSic;
            calculoRebateSic.DtPeriodoSic = dataPeriodo;
            calculoRebateSic.VlBonificacaoTotalSic = listCalculoFaixas.Sum(b => b.VlBonificacaoCalculadoSic ?? 0);
            calculoRebateSic.VlVolumeTotal = listCalculoFaixas.Sum(cf => cf.VlVolumeCalculadoSic);
            calculoRebateSic.StAprovadoAnalistaSic = false;
            calculoRebateSic.StEnviadoAprovacaoGerenteSic = false;
            calculoRebateSic.StAprovadoGerenteSic = false;
            calculoRebateSic.StAditivoSic = aditivo;
            //VALOR TOTAL NA VULNERABILIDADE PARA ACOMPANHAMENTO
            if (rebateSic.StControlevolume == true) calculoRebateSic.VlVolumeConsumidoSic = rebateSic.VlVolumeCompradoRebateSic;

            //RSIC-103
            if (calculoRebateSic.VlBonificacaoTotalSic == 0) //Inserir Status Não Atingiu Volume Mínimo
                calculoRebateSic.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo);

            //Adiciona cálculo a lista
            listCalculoRebateSic.Add(calculoRebateSic);

            //Adiciona cálculo faixa a lista
            listCalculoRebateFaixaSic.AddRange(listCalculoFaixas);

            //CALCULO PROPORCIONAL
            //SÓ FAZ O CALCULO PARA QUEM TEM FILIAIS NO GUARDA-CHUVA E
            //O PAGAMENTO PROPORCIONAL É HABILIDATDO
            if (rebateSic.StMatrizRebateSic == true &&
                rebateSic.StPagamentoProporcional == true)
            {
                //SELECIONA O OBJETO PARA CALCULO PROPORCIONAL COM BASE NA LISTA NO GUARDA-CHUVA
                var listaProporcoes = new MatrizfilialrebateSicBLO()
                    .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebateSic.NrSeqRebateSic })
                    .Select(r => new CalculoRebateProporcionalSic
                    {
                        //NrCodigoFornecedorRebateSic = r.NrCdfornecedorFilialSic,
                        NrIbmClienteSic = r.NrIbmFilialSic,
                        NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic
                    })
                    .ToList();
                //ADICIONA O 'PAI' DO GUARDA-CHUVA PARA TER PROPORÇÃO TAMBÉM
                listaProporcoes.Add(new CalculoRebateProporcionalSic
                {
                    //NrCodigoFornecedorRebateSic = rebateSic.NrCodigofornecedorRebateSic,
                    NrIbmClienteSic = rebateSic.NrIbmRebateSic,
                    NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic
                });

                //DEFINE O VOLUME PROPORCIONAL PARA CADA EMPRESA
                var volumeTotal = calculoRebateSic.VlVolumeTotal ?? 0M;
                if (volumeTotal > 0M)
                {
                    //DEFINE PARA CADA IBM A PROPORÇÃO DE VALOR
                    foreach (var calculoProporcional in listaProporcoes)
                    {
                        var cliente = new ClienteSicBLO()
                            .SelecionarPrimeiro(new ClienteSic { NrIbmClienteSic = calculoProporcional.NrIbmClienteSic });

                        var volumesSelecionadosIBM = volumesSelecionados
                            .Where(r => r.NrIbmRebateRbc == calculoProporcional.NrIbmClienteSic);
                        var volumeIBM = volumesSelecionadosIBM.Sum(r => r.VlVolumeCompradoRbc ?? 0);
                        var volumePercentualIBM = volumeIBM / volumeTotal;
                        calculoProporcional.VlVolumeCalculadoSic = volumeIBM;
                        calculoProporcional.VlProporcaoSic = volumePercentualIBM;
                        calculoProporcional.VlValorBonificacaoProporcionalSic = calculoRebateSic.VlBonificacaoTotalSic * volumePercentualIBM;
                        calculoProporcional.NrSeqClienteSic = cliente.NrSeqClienteSic;

                        //TODO : ADICIONAR NA COLEÇÃO DE RETORNO
                        listCalculoRebateProporcionalSic.Add(calculoProporcional);
                    }

                    #region OLD : Murilo 29/07/2014 : Já faz o calculo na iteração anterior

                    ////CRIANDO CALCULOS PROPORCIONAIS
                    //foreach (var proporcaoIBM in proporcoes)
                    //{
                    //    var cliente = new ClienteSicBLO()
                    //        .SelecionarPrimeiro(new ClienteSic { NrIbmClienteSic = proporcaoIBM.Key });
                    //    #region OLD : Murilo 29/07/2014 : Deve incluir na tabela de calculo proporcional
                    //    //var calculoProporcional = RebateUtil.Clonar(calculoRebateSic);
                    //    ////AJUSTANDO REFERENCIAS E VALORES PROPORCIONAIS
                    //    //calculoProporcional.NrSeqCalculoRebateSic = rebateSic.NrSeqRebateSic + (-1); //TEMPORARIO(PK)
                    //    //calculoProporcional.VlVolumeTotal = calculoRebateSic.VlVolumeTotal * proporcaoIBM.Value;
                    //    //calculoProporcional.VlBonificacaoTotalSic = calculoRebateSic.VlBonificacaoTotalSic * proporcaoIBM.Value;

                    //    //foreach (var calculoFaixa in listCalculoFaixas)
                    //    //{
                    //    //    var calculoFaixaProporcional = RebateUtil.Clonar(calculoFaixa);
                    //    //    //AJUSTANDO REFERÊNCIA
                    //    //    //NÃO DEVE AJUSTAR VALOR DADO QUE É APENAS INFORMATIVO.
                    //    //    calculoFaixaProporcional.NrSeqCalculoRebateSic = calculoProporcional.NrSeqCalculoRebateSic;
                    //    //    //ADICIONA FAIXA DE CALCULO NA COLEÇÃO DE RETORNO
                    //    //    listCalculoRebateFaixaSic.Add(calculoFaixaProporcional);
                    //    //}

                    //    ////ADICIONA CALCULO NA COLEÇÃO DE RETORNO
                    //    //listCalculoRebateSic.Add(calculoProporcional);
                    //    #endregion
                    //    var calculoProporcional = new CalculoRebateProporcionalSic{
                    //        NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic,
                    //        NrSeqClienteSic = cliente.NrSeqClienteSic,
                    //        NrIbmClienteSic = proporcaoIBM.Key,
                    //        NrCodigoFornecedorRebateSic = "",
                    //        VlProporcaoSic = proporcaoIBM.Value,
                    //        VlValorBonificacaoProporcionalSic = calculoRebateSic.VlBonificacaoTotalSic* proporcaoIBM.Value
                    //    };
                    //}

                    #endregion OLD : Murilo 29/07/2014 : Já faz o calculo na iteração anterior

                    #region OLD : Murilo 29/07/2014 : Não é necessário fazer o ajuste dado que a proporção do pai também é armazenado na tabela de proporções

                    ////AJUSTANDO O VALOR DO CALCULO PARA MATRIZ
                    //var proporcaoMatriz = (1M - proporcoes.Sum(r => r.Value));
                    //calculoRebateSic.VlVolumeTotal = calculoRebateSic.VlVolumeTotal * proporcaoMatriz;
                    //calculoRebateSic.VlBonificacaoTotalSic = calculoRebateSic.VlBonificacaoTotalSic * proporcaoMatriz;

                    #endregion OLD : Murilo 29/07/2014 : Não é necessário fazer o ajuste dado que a proporção do pai também é armazenado na tabela de proporções
                }
            }
        }

        private List<VolumeMensalFaixaRebateSic> FiltrarVolumeCategoriaPeriodo(List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic)
        {
            var lstVolumeMensal = new List<VolumeMensalFaixaRebateSic>();
            var result = from l in listVolumeMensalFaixaRebateSic
                         group l by new { l.NrSeqRebateSic, l.DtPeriodoSic, l.NrSeqCategoriaSic, l.VlVolumeCompradoSic } into grp
                         select new
                         {
                             grp.Key.NrSeqRebateSic,
                             grp.Key.DtPeriodoSic,
                             grp.Key.NrSeqCategoriaSic,
                             grp.Key.VlVolumeCompradoSic,
                             NrSeqFaixarebateSic = grp.Max(f => f.NrSeqFaixarebateSic),
                             NrSeqVolumeMensalFaixaRebateSic = grp.Max(f => f.NrSeqVolumeMensalFaixaRebateSic),
                             NrSeqFaixaRebateHistoricoSic = grp.Max(f => f.NrSeqFaixaRebateHistoricoSic),
                             StVolumeEncontrado = true
                         };

            foreach (var item in result)
            {
                lstVolumeMensal.Add(listVolumeMensalFaixaRebateSic.First(x => x.NrSeqVolumeMensalFaixaRebateSic == item.NrSeqVolumeMensalFaixaRebateSic));
            }
            return lstVolumeMensal;
        }

        /// <summary>
        /// Cancela as bonificações do periodo anterior para o tipo cosan, que estava pendente débito
        /// </summary>
        private void CancelarBonificacaoCosan()
        {
            //Buscar todos os Média Volume (Cosan) do período anterior com estado Pendente Débito
            TiporebateSic tipoRebateCosan = ListTipoRebateSic.Single(t => t.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME));
            List<RebateSic> listRebateCosan = this.ListRebateSic.Where(r => r.NrSeqTiporebateSic == tipoRebateCosan.NrSeqTiporebateSic).ToList();
            DateTime dtPeriodoAnterior = RebateUtil.GetPeriodoAtual().AddMonths(-1);

            //Percorre lista de rebates
            foreach (RebateSic rebateSic in listRebateCosan)
            {
                IList<CalculoRebateSic> listCalculoCancelar = CalculoRebateSicBLOService.Selecionar(new CalculoRebateSic
                {
                    DtPeriodoSic = dtPeriodoAnterior,
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                    NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.PendenteDebito)
                });

                //Percorre calculo
                foreach (CalculoRebateSic calculo in listCalculoCancelar)
                {
                    //Mudar estado para cancelado
                    calculo.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.Cancelado);
                    CalculoRebateSicBLOService.Atualizar(calculo);

                    //Inserir histórico cancelado
                    StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic();
                    historico.NrSeqCalculoRebateSic = calculo.NrSeqCalculoRebateSic;
                    historico.DtAlteracaoSic = RebateUtil.GetDataAtual();
                    historico.NmLoginSic = ConstantesRebate.USUARIO_SERVICO;
                    historico.NrSeqStatusCalculoRebateSic = calculo.NrSeqStatusCalculoRebateSic;
                    historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_GENERICO,
                        ConstantesRebate.DS_HISTORICO_CANCELADO, calculo.NrSeqRebateSic,
                        calculo.DtPeriodoSic.Value.ToString("MM/yyyy"), calculo.VlBonificacaoTotalSic.Value.ToString("N2"));
                    StatusCalculoRebateHistoricoSicBLOService.Incluir(historico);

                    //Subtrair bonificação do saldo (Extrato) - Busca o último saldo
                    SaldoRebateSic saldo = SaldoRebateSicBLOService.SelecionarUltimo(new SaldoRebateSic { NrSeqRebateSic = calculo.NrSeqRebateSic });
                    decimal saldoAtual = saldo.VlSaldoAtualSic ?? 0;

                    //Cria nova entrada de Saldo
                    SaldoRebateSic saldoAtualizado = new SaldoRebateSic
                    {
                        NrSeqRebateSic = calculo.NrSeqRebateSic,
                        VlSaldoAtualSic = (saldoAtual - calculo.VlBonificacaoTotalSic),
                        VlLancamentoSic = (-1) * calculo.VlBonificacaoTotalSic,
                        DtLancamentoSic = RebateUtil.GetDataAtual(),
                        DsObsComplementoSic = string.Format(ConstantesRebate.DS_EXTRATO_CANCELADO, calculo.DtPeriodoSic.Value.ToString("MM/yyyy")),
                    };

                    //Insere registro com saldo atualizado
                    SaldoRebateSicBLOService.Incluir(saldoAtualizado);
                }
            }
        }

        /// <summary>
        /// Incrementa o mes do aditivo e contadores de data
        /// </summary>
        /// <param name="incremento"></param>
        /// <param name="periodoInicialVar"></param>
        /// <param name="periodoFimVar"></param>
        /// <param name="periodoCalculo"></param>
        private static void IncrementaMesAditivo(int incremento, ref DateTime periodoInicialVar, ref DateTime periodoFimVar, ref DateTime periodoCalculo)
        {
            //Incrementa o mês
            periodoInicialVar = periodoInicialVar.AddMonths(incremento);
            periodoFimVar = RebateUtil.GetFimPeriodoMensal(periodoFimVar.AddMonths(incremento));

            //Formata Período Bonificação
            periodoCalculo = new DateTime(periodoFimVar.AddMonths(1).Year, periodoFimVar.AddMonths(1).Month, 1);
        }

        /// <summary>
        /// Verifica se um cliente possui status aceito
        /// </summary>
        /// <param name="NrSeqCliente"></param>
        /// <returns></returns>
        private bool VerificarClienteAceito(int NrSeqCliente)
        {
            IList<ClientestatusSic> status = ClientestatusSicBLOService.Selecionar(new ClientestatusSic { NrSeqClienteSic = NrSeqCliente });
            if (status == null || status.Count == 0)
                return false;

            StatusSic aceito = this.ListTipoStatusSic.First(s => s.NmStatusSic.Trim().ToUpper().Equals(ConstantesRebate.STATUS_CLIENTE_ACEITO));
            status = status.OrderByDescending(st => st.NrSeqClientestausSic).ToList();
            if (status.First().NrSeqStatusSic == aceito.NrSeqStatusSic)
                return true;

            return false;
        }

        /// <summary>
        /// Retorna o dia programado para executar o cálculo
        /// </summary>
        /// <returns></returns>
        private int GetDiaCalculo()
        {
            //Recuperar data atual para verificar se deve executar o serviço de cálculo
            IPeriodoProcessamentoSicBLO periodoProcessamentoSicBLO = Factory.CreateFactoryInstance().CreateInstance<IPeriodoProcessamentoSicBLO>("PeriodoProcessamentoSicBLO");
            IList<PeriodoProcessamentoSic> periodos = periodoProcessamentoSicBLO.Selecionar();
            periodos = periodos.Where(p => p.NrSeqTiporebateSic.HasValue).ToList();
            int? diaCalculo = periodos.Min(p => p.NrDiaInicioCalculoSic);
            return diaCalculo.Value;
        }

        /// <summary>
        /// Filtra a coleção informada para conter apenas contratos rebate vigentes.
        /// </summary>
        /// <param name="listaRebate">Lista com rebates a ser filtrado</param>
        /// <param name="now">Data para validação do período de vigencia (Data do processamento ou de Recalculo/Aditivo). Nulo para não validar período de vigência.</param>
        /// <param name="mensagem">Mensagem de inconformidade quando for o caso. Vazio se nenhum problema for encontrado.</param>
        /// <returns>Coleção contendo apenas contratos vigentes</returns>
        private IList<RebateSic> FiltrarVigentes(IList<RebateSic> listaRebate, DateTime? now, out string mensagem)
        {
            List<RebateSic> r = new List<RebateSic>();
            var mensagemDeRetorno = new StringBuilder();
            foreach (var rebate in listaRebate)
            {
                var mensagemInterna = string.Empty;
                if (ValidarVigencia(rebate, now, out mensagemInterna)) r.Add(rebate);
                else
                {
                    mensagemDeRetorno.AppendFormat("{0} não é vigente. {1}", rebate.NrIbmRebateSic, mensagemInterna);
                    mensagemDeRetorno.AppendLine();
                }
            }
            mensagem = mensagemDeRetorno.ToString();

            return r.Count > 0 ? r : null;
        }

        /// <summary>
        /// Definie se o contrato é vigente conforme aceitação, período de vigencia e controle de volume quando for o caso.
        /// </summary>
        /// <param name="rebate">Contrato Rebate.</param>
        /// <param name="now">Data para validação do período de vigencia. Nulo para não validar período de vigência.</param>
        /// <param name="mensagem">Mensagem de inconformidade quando for o caso. Vazio se nenhum problema for encontrado.</param>
        /// <returns>Verdadeiro se o contrato for vigente. Falso caso não seja vigente. Verificar a mensagem para descrição da recusa.</returns>
        private bool ValidarVigencia(RebateSic rebate, DateTime? now, out string mensagem, bool isAditivo = false)
        {
            mensagem = string.Empty;

            if (!VerificarClienteAceito(rebate.NrSeqClienteSic.Value))
            {
                mensagem = "O cliente não está com status aceito.";
                return false;
            }
            else if (now.HasValue &&
                rebate.DtFimvigenciaRebateSic.HasValue &&
                now > rebate.DtFimvigenciaRebateSic)
            {
                mensagem = "A data informada é posterior a data de término do contrato.";
                return false;
            }
            else if (now.HasValue &&
                rebate.DtIniciovigenciaRebateSic.HasValue &&
                now < rebate.DtIniciovigenciaRebateSic)
            {
                mensagem = "A data informada é anterior a data de inicio do contrato.";
                return false;
            }

            if (string.IsNullOrEmpty(mensagem))
            {
                var mensagemVigenciaVolume = string.Empty;
                var valido = VerificarVigenciaVolume(now, rebate, out mensagemVigenciaVolume, isAditivo);
                if (!string.IsNullOrEmpty(mensagemVigenciaVolume)) mensagem += mensagemVigenciaVolume;
                if (!valido) return false;
            }

            return string.IsNullOrEmpty(mensagem); //VERDADEIRO SE NÃO HOUVER MENSAGEM. FALSO SE HOUVER MENSAGEM.
        }

        private bool VerificarVigenciaVolume(DateTime? now, RebateSic rebate, out string mensagem, bool isAditivo = false)
        {
            var retorno = true;
            var mensagemInterna = string.Empty;
            if (rebate.StControlevolume == true)
            {
                //DEFININDO O VOLUME LIMITE
                var volumeLimite = 0M;
                if (rebate.VlVolumelimiteRebateSic.HasValue) volumeLimite = rebate.VlVolumelimiteRebateSic.Value;
                else if (rebate.VlVolumecontratadoRebateSic.HasValue) volumeLimite = rebate.VlVolumecontratadoRebateSic.Value;

                //SE HÁ VOLUME LIMITE
                if (volumeLimite > 0M)
                {
                    DateTime dataPesquisa;
                    if (now.HasValue)
                        dataPesquisa = now.Value;
                    else
                    {
                        var _agora = DateTime.Now;
                        dataPesquisa = new DateTime(_agora.Year, _agora.Month, 1);
                    }

                    dataPesquisa = isAditivo ? dataPesquisa.AddMonths(-1).AddDays(-1) : dataPesquisa.AddDays(-1D);

                    var volumeComprado = new RebateSicBLO()
                        //.SelecionarVolumeComprado(rebate, now.HasValue ? now.Value : DateTime.Now);
                        .SelecionarVolumeComprado(rebate, dataPesquisa);

                    if (volumeComprado >= volumeLimite)
                    {
                        mensagemInterna += "O contrato atingiu o volume máximo calculado.";
                        retorno = false;
                    }

                    rebate.VlVolumeCompradoRebateSic = volumeComprado;
                }
            }
            mensagem = mensagemInterna;
            return retorno;
        }

        private DadosCalculoRebateSic DadosCalculoRebate(RebateSic rebateSic, List<FaixarebateSic> listFaixarebateSic, DateTime DtPerido)
        {
            DadosCalculoRebateSic dadosRebate = new DadosCalculoRebateSic();
            dadosRebate.NrSeqClienteSic = rebateSic.NrSeqClienteSic.Value;
            dadosRebate.NrIbmClienteSic = rebateSic.NrIbmRebateSic;
            dadosRebate.DtPeriodoSic = DtPerido;
            dadosRebate.NrSeqTipoRebate = rebateSic.NrSeqTiporebateSic.Value;
            dadosRebate.StCalculoRebateSic = rebateSic.StCalculoRebateSic.Value;
            List<DadosCalculoRebateFaixaSic> listDadosCalculoRebateFaixaSic = new List<DadosCalculoRebateFaixaSic>();
            foreach (var faixaRebateSic in listFaixarebateSic)
            {
                DadosCalculoRebateFaixaSic dadosFaixa = new DadosCalculoRebateFaixaSic();
                dadosFaixa.NrSeqCategoriaSic = faixaRebateSic.NrSeqCategoriaSic.Value;
                dadosFaixa.VlVolumeMensalRebateSic = faixaRebateSic.VlVolumemensalRebateSic.HasValue ? faixaRebateSic.VlVolumemensalRebateSic.Value : 0;
                dadosFaixa.VlPercMinimoRebateSic = faixaRebateSic.VlPercminimoRebateSic.HasValue ? faixaRebateSic.VlPercminimoRebateSic.Value : 0;
                dadosFaixa.VlPercMaximoRebateSic = faixaRebateSic.VlPercmaximoRebateSic.HasValue ? faixaRebateSic.VlPercmaximoRebateSic.Value : 0;
                dadosFaixa.VlBonificacaoRebateSic = faixaRebateSic.VlBonificacaoRebateSic.HasValue ? faixaRebateSic.VlBonificacaoRebateSic.Value : 0;
                listDadosCalculoRebateFaixaSic.Add(dadosFaixa);
            }
            dadosRebate.Faixas = listDadosCalculoRebateFaixaSic;
            return dadosRebate;
        }
    }
}
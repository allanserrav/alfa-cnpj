using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Util;
using System.Diagnostics;
using Raizen.SICCadastro.Rebate.Util;
using Raizen.SICCadastro.Rebate.BLL;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Lógica de Processamento para a busca de dados
    /// </summary>
    public class BuscaVolumeRebateBLO : IBuscaVolumeRebateBLO
    {
        #region Variaveis Privadas

        /// <summary>
        ///Armazena lista de tipos de rebate
        /// </summary>        
        private IList<TiporebateSic> ListTipoRebateSic { get; set; }

        /// <summary>
        ///Armazena os produtos x categorias
        /// </summary>
        private Dictionary<int, IList<ProdutoSic>> DictCategoria { get; set; }

        /// <summary>
        ///Armazena os produtos x categorias
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
        /// Retorna Instancia de FaixaRebateSicBLO
        /// </summary>
        private IFaixarebateSicBLO FaixaRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de CategoriaSicBLOService
        /// </summary>
        private ICategoriaSicBLO CategoriaSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de ProdutoSicBLO
        /// </summary>
        private IProdutoSicBLO ProdutoSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de ProdutoSicBLO
        /// </summary>        
        private IVolumeMensalFaixaRebateSicBLO VolumeMensalFaixaRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de TipoRebateSicBLO
        /// </summary>
        private ITiporebateSicBLO TiporebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de SaldoRebateSicBLO
        /// </summary>
        private ICalculoRebateSicBLO CalculoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de MatrizfilialrebateSicBLO
        /// </summary>
        private IMatrizfilialrebateSicBLO MatrizfilialrebateSicBLOService { get; set; }

        /// <summary>
        /// Armazena os rebates e suas filiais
        /// </summary>
        private Dictionary<int, List<string>> DictMatrizFilial { get; set; }

        #endregion Private Variables

        #region Construtor
        /// <summary>
        /// Construtor Default
        /// </summary>
        public BuscaVolumeRebateBLO()
        {
            this.RebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
            this.FaixaRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicBLO>("FaixarebateSicBLO");
            this.CategoriaSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICategoriaSicBLO>("CategoriaSicBLO");
            this.ProdutoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IProdutoSicBLO>("ProdutoSicBLO");
            this.VolumeMensalFaixaRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IVolumeMensalFaixaRebateSicBLO>("VolumeMensalFaixaRebateSicBLO");
            this.TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");
            this.CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
            this.MatrizfilialrebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO");

            this.ListTipoRebateSic = this.TiporebateSicBLOService.Selecionar();
            this.DictCategoria = this.SelecionarCategoriasProdutosRebate();
        }

        #endregion

        #region Metodos Publicos

        #region Métodos Processamento

        /// <summary>
        /// Executar a busca/inserção de dados
        /// </summary>
        /// <param name="listRebateSic">Lista de rebates</param>
        /// <param name="listFaixaRebateSic">Lista de Faixas Rebate</param>
        public void ProcessarServico(
            IList<RebateSic> listRebate, 
            IList<FaixarebateSic> listFaixaRebate,
            out IList<VolumeRbc> volumesSelecionados,
            string url = null,
            string login = null)
        {
            #region Inicialização
            this.ListRebateSic = listRebate;
            this.ListFaixaRebateSic = listFaixaRebate;

            //Variáveis locais
            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();

            Console.WriteLine("     > ProcessarServico - > Variáveis locais");
            Console.WriteLine("");

            //Datas Utilizadas para cálculo
            DateTime dataAtual = RebateUtil.GetDataAtual();
            DateTime dataInicioPeriodoMensal = RebateUtil.GetInicioPeriodoMensal(dataAtual);
            DateTime dataInicioPeriodoTrimestral = RebateUtil.GetInicioPeriodoTrimestral(dataAtual);
            DateTime dataFimPeriodo = RebateUtil.GetFimPeriodoMensal(RebateUtil.GetFimPeriodo(dataAtual));
            #endregion

            #region Fluxo 1 --- Fluxo Padrão de busca
            #region Log Inicio
            Console.WriteLine(">>>> Iniciando Fluxo 1...");
            Console.WriteLine("");
            Stopwatch sw = null;
            sw = new Stopwatch();
            sw.Start();
            #endregion

            //Selecionar os clientes rebate com contratos que possuem inicio da vigência dentro do grupo mensal e vigência maior que 90 dias                       
            //Recupera meses do grupo atual
            int[] mesesGrupo = RebateUtil.GetListaMesesGrupoTrimestral(dataAtual.Month);

            //Recupera tipo rebate cosan
            TiporebateSic tipoRebateCosan = ListTipoRebateSic.Single(t => t.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME));

            Console.WriteLine(">>>> tipo rebate cosan recuperado");
            Console.WriteLine("");

            IList<VolumeRbc> volumesSelecionadosTrimestrais = new List<VolumeRbc>();
            //Recupera Contratos Trimestrais do grupo atual + contratos trimestrais Cosan e busca o volume
            IList<RebateSic> listRebateTrimestral = this.ListRebateSic.Where(r => (r.NrSeqTiporebateSic == tipoRebateCosan.NrSeqTiporebateSic) ||
                (r.StCalculoRebateSic.Value && mesesGrupo.Contains(r.DtIniciovigenciaRebateSic.Value.Month))).ToList();
            if (listRebateTrimestral != null && listRebateTrimestral.Count > 0)
                listVolumeMensalFaixaRebateSic.AddRange(SelecionarVolumesListaRebate(listRebateTrimestral, null, dataInicioPeriodoTrimestral, dataFimPeriodo, false, out volumesSelecionadosTrimestrais, url, login).ToList());

            Console.WriteLine(">>>> Recuperado Contratos Trimestrais do grupo atual + contratos trimestrais Cosan e busca o volume");
            Console.WriteLine("");

            IList<VolumeRbc> volumesSelecionadosMensais = new List<VolumeRbc>();
            //Recupera Contratos Mensais e busca o volume
            IList<RebateSic> listRebateMensal = this.ListRebateSic.Where(r => r.NrSeqTiporebateSic != tipoRebateCosan.NrSeqTiporebateSic && !r.StCalculoRebateSic.Value).ToList();
            if (listRebateMensal != null && listRebateMensal.Count > 0)
                listVolumeMensalFaixaRebateSic.AddRange(SelecionarVolumesListaRebate(listRebateMensal, null, dataInicioPeriodoMensal, dataFimPeriodo, false, out volumesSelecionadosMensais, url, login).ToList());

            Console.WriteLine(">>>> Recupera Contratos Mensais e busca o volume");
            Console.WriteLine("");

            volumesSelecionados = new List<VolumeRbc>();
            (volumesSelecionados as List<VolumeRbc>).AddRange(volumesSelecionadosTrimestrais);
            (volumesSelecionados as List<VolumeRbc>).AddRange(volumesSelecionadosMensais);

            #region Log Fim
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string tempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(string.Format(">>>> Finalizando Fluxo 1: {0}", tempo));
            Console.WriteLine("");
            #endregion
            #endregion

            #region Fluxo 2--- Fluxo de Inserção

            #region Log Inicio
            Console.WriteLine(">>>> Iniciando Fluxo 2...");
            Console.WriteLine("");
            Stopwatch swFluxo3 = null;
            swFluxo3 = new Stopwatch();
            swFluxo3.Start();
            #endregion

            //Inclui a lista de volumes na base SIC
            IncluirListaVolumeMensalFaixaRebateSic(listVolumeMensalFaixaRebateSic);

            #region Log Fim
            swFluxo3.Stop();
            TimeSpan tsFluxo3 = swFluxo3.Elapsed;
            tempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsFluxo3.Hours, tsFluxo3.Minutes, tsFluxo3.Seconds, tsFluxo3.Milliseconds / 10);
            Console.WriteLine(string.Format(">>>> Finalizando Fluxo 2: {0}", tempo));
            Console.WriteLine("");
            #endregion

            #endregion
        }
        #endregion

        #region Métodos Selecionar Volume
        /// <summary>
        /// Busca os volumes de uma lista rebate e suas faixas
        /// </summary>
        /// <param name="listRebateSic">Lista rebate</param>                
        /// <param name="dataInicioPeriodo">Inicio Período</param>
        /// <param name="dataFimPeriodo">Fim Período</param>
        public IList<VolumeMensalFaixaRebateSic> SelecionarVolumesListaRebate(
            IList<RebateSic> listRebateSic,
            List<FaixarebateSic> listFaixaRebateSic,
            DateTime dataInicioPeriodo,
            DateTime dataFimPeriodo,
            bool recalculo,
            out IList<VolumeRbc> volumesSelecionados,
            string url = null,
            string login = null)
        {
            volumesSelecionados = new List<VolumeRbc>();
            //Variáveis
            List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
            List<RebateSic> listRebateSicComGC = new List<RebateSic>(); //GC = Guarda-chuva

            //Para os clientes Guarda-Chuva, incluir os filhos para a busca de volumes            
            this.DictMatrizFilial = new Dictionary<int, List<string>>();
            foreach (RebateSic rebateSic in listRebateSic)
            {
                if (!rebateSic.StMatrizRebateSic.HasValue || !rebateSic.StMatrizRebateSic.Value) continue;
                IList<MatrizfilialrebateSic> listMatrizFilial = MatrizfilialrebateSicBLOService.Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebateSic.NrSeqRebateSic });

                if (listMatrizFilial == null || listMatrizFilial.Count == 0) continue;

                List<string> listFiliais = new List<string>(); //guarda-chuva
                foreach (MatrizfilialrebateSic filial in listMatrizFilial)
                {
                    listRebateSicComGC.Add(new RebateSic { NrSeqRebateSic = filial.NrSeqRebatematrizSic, NrIbmRebateSic = filial.NrIbmFilialSic });
                    listFiliais.Add(filial.NrIbmFilialSic);
                }

                if (!DictMatrizFilial.ContainsKey(rebateSic.NrSeqRebateSic.Value))
                    DictMatrizFilial.Add(rebateSic.NrSeqRebateSic.Value, listFiliais);
            }
            Console.WriteLine(">>>> (SelecionarVolumesListaRebate) Para os clientes Guarda-Chuva, incluido os filhos para a busca de volumes   ");
            Console.WriteLine("");

            //Recuperar o volume para todos os clientes encontrados
            listRebateSicComGC.AddRange(listRebateSic);
            List<VolumeRbc> listVolumeRbc = VolumeMensalFaixaRebateSicBLOService
                .SelecionarVolumeRbc(dataInicioPeriodo, dataFimPeriodo, listRebateSicComGC)
                .ToList();

            Console.WriteLine(">>>> (SelecionarVolumesListaRebate) Recuperado o volume para todos os clientes encontrados  ");
            Console.WriteLine("");

            //Selecionar as faixas rebate dos clientes encontrados
            if (listFaixaRebateSic == null || listFaixaRebateSic.Count == 0)
                listFaixaRebateSic = this.ListFaixaRebateSic.ToList();

            Console.WriteLine(">>>> (SelecionarVolumesListaRebate) Selecionado as faixas rebate dos clientes encontrados  ");
            Console.WriteLine("");

            //TRAZENDO SÓ O VOLUME ATÉ O LIMITE
            foreach (RebateSic rebate in listRebateSic)
            {
                //SE É CONTROLADO POR VOLUME
                if (rebate != null && rebate.StControlevolume == true)
                {
                    var limite = rebate.VlVolumelimiteRebateSic ?? rebate.VlVolumecontratadoRebateSic;
                    if (limite.HasValue && limite.Value > 0M)
                    {
                        //BUSCA OS GUARDA-CHUVAS
                        //List<string> ibmsgc = null;
                        List<string> ibmsGuardaChuva = new List<string>();
                        ibmsGuardaChuva.Add(rebate.NrIbmRebateSic);
                        if (DictMatrizFilial.ContainsKey(rebate.NrSeqRebateSic.Value))
                            ibmsGuardaChuva.AddRange(DictMatrizFilial[rebate.NrSeqRebateSic.Value]);
                        //TRAZ OS VOLUMES CALCULADOS APENAS PARA PRODUTOS CONSIDERADOS NA FAIXA
                        //PARA TAL, É NECESSÁRIO CONSIDERAR QUAIS SÃO OS PRODUTOS ENVOLVIDOS OBSERVANDO SUA CATEGORIA E
                        //RELACIONANDO ESSAS CATEGORIAS ÀS FAIXAS VIGENTES DO CONTRATO REBATE OBSERVADO
                        var faixas = listFaixaRebateSic
                            .Where(r=>r.NrSeqRebateSic == rebate.NrSeqRebateSic)
                            .ToList();
                        var categoriasDasFaixas = new CategoriaSicBLO()
                            .Selecionar()
                            .Where(r => faixas.Any(rr => rr.NrSeqCategoriaSic == r.NrSeqCategoriaSic))
                            .ToList();
                        var produtos = new ProdutoSicBLO()
                            .Selecionar()
                            .Where(r => categoriasDasFaixas.Any(rr => rr.NrSeqCategoriaSic == r.NrSeqCategoriaSic))
                            .ToList();
                        var volumes = listVolumeRbc
                            .Where(r =>
                            {
                                var pertenceAIBMSDoContrato = ibmsGuardaChuva.Contains(r.NrIbmRebateRbc);
                                var deProdutosDasFaixas = produtos.Any(rr => rr.CdSapProdutoSic == r.CdProdutoRbc);
                                return pertenceAIBMSDoContrato && deProdutosDasFaixas;
                            })
                            .ToList();
                        //TRAZ VOLUMES COMPRADOS
                        var volumeComprado = new RebateSicBLO()
                            .SelecionarVolumeComprado(rebate, dataInicioPeriodo.AddDays(-1D));
                        #region OLD : Mudança de escopo
                        //var volumeComprado = 0M;
                        //foreach (var ibm in ibmsGuardaChuva)
                        //{
                        //    //TUDO O QUE FOI COMPRADO ANTES DO PERIODO DO CALCULO
                        //    volumeComprado += Factory
                        //        .CreateFactoryInstance()
                        //        .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                        //        .SelecionarVolumeComprado(ibm, rebate.DtIniciovigenciaRebateSic.Value, dataInicioPeriodo);
                        //} 
                        #endregion

                        //SE É VALIDO
                        if (volumeComprado > limite.Value) //JA COMPROU TUDO O QUE O REBATE PAGA
                        {
                            //return listVolumeMensalFaixaRebateSic;
                            foreach (var volume in volumes)
                                listVolumeRbc.Remove(volume);
                        }
                        else if (volumeComprado + volumes.Sum(r => r.VlVolumeCompradoRbc ?? 0) > limite.Value) //A SOMA DO COMPRADO COM O CALCULADO ULTRAPASSA O LIMITE
                        {
                            #region OLD
                            //ORDENA POR DATA
                            //volumes = volumes.OrderBy(r => r.DtPeriodoRbc).ToList();
                            ////FILTRO
                            //var listaVolumeLimitadaRBC = new List<VolumeRbc>();
                            //foreach (var volumeRBC in volumes)
                            //{
                            //    if (volumeRBC.VlVolumeCompradoRbc.HasValue &&
                            //        volumeComprado + listaVolumeLimitadaRBC.Sum(r => r.VlVolumeCompradoRbc ?? 0) + volumeRBC.VlVolumeCompradoRbc.Value > limite.Value) break;
                            //    listaVolumeLimitadaRBC.Add(volumeRBC);
                            //} 
                            #endregion
                            //ENCONTRANDO A PROPORÇÃO A SER PAGA
                            var valorPropocional = limite.Value - volumeComprado;
                            var valorTotal = volumes.Sum(r => r.VlVolumeCompradoRbc);
                            var percentual = valorPropocional / valorTotal;
                            //AJUSTANDO O VOLUME COMPRADO PARA A PROPORÇÃO E
                            //DEVOLVENDO PARA A COLEÇÃO ORIGINAL
                            foreach (var volume in volumes)
                            {
                                listVolumeRbc.Remove(volume);
                                listVolumeRbc.Add(new VolumeRbc
                                {
                                    CdProdutoRbc = volume.CdProdutoRbc,
                                    DtPeriodoRbcTexto = volume.DtPeriodoRbcTexto,
                                    NmProdutoRbc = volume.NmProdutoRbc,
                                    NrIbmRebateRbc = volume.NrIbmRebateRbc,
                                    VlVolumeCompradoRbc = volume.VlVolumeCompradoRbc * percentual
                                });
                            }
                            #region OLD
                            //listVolumeRbc.AddRange(listaVolumeLimitadaRBC); 
                            #endregion
                            //ENVIANDO MENSAGEM DE EMAIL QUANDO ATINGIR O LIMITE DE VOLUME
                            var mensagem = Factory
                                .CreateFactoryInstance()
                                .CreateInstance<IMensagemSicBLO>("MensagemSicBLO")
                                .SelecionarPrimeiro(new MensagemSic { NmMensagemSic = "AVISO_LIMITE_VOLUME_REBATE" });
                            if (mensagem != null)
                            {
                                var landingPage = string.Empty;
                                if (!string.IsNullOrEmpty(url))
                                {
                                    var link = url.Split('/');
                                    if (link != null && link.Count() >= 3)
                                        landingPage = string.Format("{0}//{1}/Cadastro/login.aspx?ReturnUrl=ClienteAlteracao.aspx?ibmCliente={2}",
                                            link[0],
                                            link[2],
                                            rebate.NrIbmRebateSic);
                                }
                                var cliente = Factory.CreateFactoryInstance().CreateInstance<IClienteSicBLO>("ClienteSicBLO").SelecionarPrimeiro(new ClienteSic { NrSeqClienteSic = rebate.NrSeqClienteSic });
                                var parameters = string.Format("|{0}|{1}|{2}", rebate.NrIbmRebateSic, cliente.NmRazsociallojaFranquiaSic, limite.Value.ToString("N2"));
                                var agendamento = new AgendamentoMensagemSic
                                {
                                    DtAgendamentoMensagemSic = DateTime.Now.Date.AddHours(23D),
                                    NrSeqMensagemSic = mensagem.NrSeqMensagemSic,
                                    NmUserSolicitacaoSic = login,
                                    NmGrupodeAgengamentoMensagemSic = "SicCadastroOperacoes@cosan.rede",
                                    NmGrupoparaAgendamentoMensagemSic = "SicCadastroOperacoes@cosan.rede",
                                    NmLinkAgendamentoMensagemSic = !string.IsNullOrEmpty(landingPage) ? landingPage + parameters : string.Empty,
                                    StAgengamentoMensagemSic = true
                                };
                                try
                                {
                                    Factory
                                        .CreateFactoryInstance()
                                        .CreateInstance<IAgendamentoMensagemSicBLO>("AgendamentoMensagemSicBLO")
                                        .Incluir(agendamento);
                                }
                                catch (Exception ex) { LogError.Debug("Não foi possível agendar o envio de mensagem:" + ex.StackTrace); }
                            }
                            else LogError.Debug("Não foi possível selecinar uma mensagem com nome 'AVISO_LIMITE_VOLUME_REBATE'. Agendamento de envio de e-mail foi abortado.");
                        }
                    }
                }
            }
            Console.WriteLine(">>>> (SelecionarVolumesListaRebate) percorreu -> TRAZENDO SÓ O VOLUME ATÉ O LIMITE ");
            Console.WriteLine("");

            //Percorre todos os contratos rebates da base
            foreach (RebateSic rebateSic in listRebateSic)
            {
                //Recupera tipo rebate cosan
                TiporebateSic tipoRebateCosan = ListTipoRebateSic.Single(t => t.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME));
                bool cosan = rebateSic.NrSeqTiporebateSic == tipoRebateCosan.NrSeqTiporebateSic;

                //Para o tipo Cosan, não deve calcular o último período
                if (cosan && rebateSic.DtFimvigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().AddMonths(-1).Year && rebateSic.DtFimvigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().AddMonths(-1).Month)
                    continue;

                //Lista Interna
                List<VolumeMensalFaixaRebateSic> listVolumeInterna = new List<VolumeMensalFaixaRebateSic>();

                //Recupera as faixas do contrato rebate
                List<FaixarebateSic> faixasRebate = listFaixaRebateSic.Where(f => f.NrSeqRebateSic == rebateSic.NrSeqRebateSic).ToList();

                //Busca os volumes percorrendo as faixas do Rebate
                foreach (FaixarebateSic faixa in faixasRebate)
                {
                    DateTime dtFim = (faixa.DtFimcalculoRebateSic.Value < dataFimPeriodo) ? faixa.DtFimcalculoRebateSic.Value : dataFimPeriodo;
                    DateTime dtInicio = (faixa.DtIniciocalculoRebateSic > dataInicioPeriodo) ? faixa.DtIniciocalculoRebateSic.Value : dataInicioPeriodo;

                    //Os tipos cosan que possuem inicio de vigencia igual ao periodo atual devem ser considereados e calculados dentro do intervalo atual
                    if (cosan && rebateSic.DtIniciovigenciaRebateSic.Value.Year == RebateUtil.GetDataAtual().Year && rebateSic.DtIniciovigenciaRebateSic.Value.Month == RebateUtil.GetDataAtual().Month)
                        dtInicio = dataInicioPeriodo;

                    IList<VolumeRbc> volumesSelecionadosFaixa = new List<VolumeRbc>();
                    listVolumeInterna.AddRange(SelecionarVolumesRebate(listVolumeRbc, rebateSic, faixa, dataInicioPeriodo, dtFim, out volumesSelecionadosFaixa).ToList());
                    (volumesSelecionados as List<VolumeRbc>).AddRange(volumesSelecionadosFaixa);
                }

                //Tratar Tipo Media Volume
                listVolumeInterna = FormatarListaVolumesGlobalMedia(rebateSic, listVolumeInterna, faixasRebate, dataInicioPeriodo, dataFimPeriodo, recalculo);

                //Adiciona na lisa de retorno
                listVolumeMensalFaixaRebateSic.AddRange(listVolumeInterna);
            }
            Console.WriteLine(">>>> (SelecionarVolumesListaRebate) Percorre todos os contratos rebates da base ");
            Console.WriteLine("");

            volumesSelecionados = volumesSelecionados
                .Distinct()
                .ToList();

            return listVolumeMensalFaixaRebateSic;
        }

        #endregion

        #endregion Metodos Publicos

        #region Metodos Privados
        /// <summary>
        /// Carrega lista de categorias x produtos
        /// </summary>
        /// <param name="listCategoriaSic"></param>
        /// <param name="dictCategoria"></param>
        private Dictionary<int, IList<ProdutoSic>> SelecionarCategoriasProdutosRebate()
        {
            IList<CategoriaSic> listCategoriaSic;
            Dictionary<int, IList<ProdutoSic>> dictCategoria;

            //Busca de Categorias
            listCategoriaSic = CategoriaSicBLOService.Selecionar(
                new CategoriaSic
                {
                    StCategoriaRebateSic = true
                });

            if (listCategoriaSic == null || listCategoriaSic.Count == 0)
                throw new Exception("Nenhuma categoria Rebate encontrada na base.");

            //Busca de Produtos
            dictCategoria = new Dictionary<int, IList<ProdutoSic>>();
            foreach (var item in listCategoriaSic)
            {
                //Para cada faixa encontrada, recuperar a categoria
                int idCategoria = Convert.ToInt32(item.NrSeqCategoriaSic);
                if (dictCategoria.ContainsKey(idCategoria))
                    continue;

                //Recuperar os produtos da categoria
                IList<ProdutoSic> listProdutoSic = ProdutoSicBLOService.Selecionar(new ProdutoSic
                {
                    NrSeqCategoriaSic = idCategoria
                });

                if (listProdutoSic == null || listProdutoSic.Count == 0)
                    throw new Exception(string.Format("Nenhum produto encontrado para a Categoria {0}.", idCategoria));

                dictCategoria.Add(idCategoria, listProdutoSic);
            }

            return dictCategoria;
        }

        /// <summary>
        /// Seleciona o volume na lista glogal buscando por IBM x Categoria
        /// </summary>
        private List<VolumeRbc> SelecionarVolumePorIBMCategoria(IList<VolumeRbc> listVolumeRbc, RebateSic rebateSic, FaixarebateSic faixa, DateTime dataInicio, DateTime dataFim)
        {
            //Recupera os produtos para a categoria da faixa
            IList<ProdutoSic> produtos = this.DictCategoria[faixa.NrSeqCategoriaSic.Value];

            //Lista de IBMs, para caso de rebate guarda-chuva
            List<string> IBMs = new List<string>();
            IBMs.Add(rebateSic.NrIbmRebateSic);
            if (this.DictMatrizFilial.ContainsKey(rebateSic.NrSeqRebateSic.Value))
                IBMs.AddRange(this.DictMatrizFilial[rebateSic.NrSeqRebateSic.Value]);

            //Recupera o volume comprado pelo IBM do contrato rebate para os produtos da categoria da faixa atual
            List<VolumeRbc> volumesFaixa = (from v in listVolumeRbc
                                            join p in produtos on v.CdProdutoRbc equals p.CdSapProdutoSic
                                            where IBMs.Contains(v.NrIbmRebateRbc) &&
                                                  v.DtPeriodoRbc >= dataInicio && v.DtPeriodoRbc <= dataFim
                                            select v).Distinct().ToList();

            return volumesFaixa;
        }

        /// <summary>
        /// Busca os volumes de um rebate e suas faixas (utiliza a lista volumes RBC enviada)
        /// </summary>
        /// <param name="listVolumeRbc">Lista de volumes RBC (Oracle)</param>        
        /// <param name="dataInicioPeriodo">inicio periodo</param>
        /// <param name="dataFimPeriodo">fim período</param>
        /// <param name="rebateSic">Rebate</param>
        /// <param name="faixa">Faixa</param>
        /// <returns></returns>
        private IList<VolumeMensalFaixaRebateSic> SelecionarVolumesRebate(
            IList<VolumeRbc> listVolumeRbc, 
            RebateSic rebateSic, 
            FaixarebateSic faixa, 
            DateTime dataInicioPeriodo, 
            DateTime dataFimPeriodo, 
            out IList<VolumeRbc> volumesSelecionados)
        {
            //Variáveis
            volumesSelecionados = new List<VolumeRbc>();
            IList<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();

            //Periodo de referencia (importação é mensal)            
            DateTime dataInicioVar = dataInicioPeriodo;
            DateTime datafimVar = RebateUtil.GetFimPeriodoMensal(dataInicioVar);
            int meses = RebateUtil.GetDiferencaMeses(dataInicioPeriodo, dataFimPeriodo);

            //Percorre todos os meses do periodo atual
            for (int i = 0; i <= meses; i++)
            {
                //Formata datas   
                if (i == meses)
                    datafimVar = dataFimPeriodo;

                //Instancia o volume comprado
                IList<VolumeRbc> volumesSelecionadosMeses = new List<VolumeRbc>();
                VolumeMensalFaixaRebateSic volumeCompradoRebateSic = CriarVolumeMensalFaixaRebateSic(listVolumeRbc, rebateSic, faixa, dataInicioVar, datafimVar, out volumesSelecionadosMeses);
                (volumesSelecionados as List<VolumeRbc>).AddRange(volumesSelecionadosMeses);

                //Adiciona volume a lista para persistência
                listVolumeMensalFaixaRebateSic.Add(volumeCompradoRebateSic);

                //Incrementa os meses
                dataInicioVar = new DateTime(dataInicioVar.AddMonths(1).Year, dataInicioVar.AddMonths(1).Month, 1);
                datafimVar = RebateUtil.GetFimPeriodoMensal(datafimVar.AddMonths(1));
            }

            return listVolumeMensalFaixaRebateSic;
        }

        /// <summary>
        /// Cria uma instância de VolumeMensalFaixaRebateSic
        /// </summary>
        /// <param name="listVolumeRbc">Lista d Volumes RBC</param>
        /// <param name="rebateSic">Rebate</param>
        /// <param name="faixa">Faixa</param>
        /// <param name="periodo">Periodo</param>
        /// <returns>VolumeMensalFaixaRebateSic</returns>
        private VolumeMensalFaixaRebateSic CriarVolumeMensalFaixaRebateSic(
            IList<VolumeRbc> listVolumeRbc, 
            RebateSic rebateSic, 
            FaixarebateSic faixa, 
            DateTime dataInicio, 
            DateTime dataFim,
            out IList<VolumeRbc> volumesSelecionados)
        {
            //Inicializa volume
            VolumeMensalFaixaRebateSic volumeCompradoRebateSic = new VolumeMensalFaixaRebateSic();
            volumeCompradoRebateSic.DtPeriodoSic = new DateTime(dataInicio.Year, dataInicio.Month, 1);
            volumeCompradoRebateSic.NrSeqFaixarebateSic = faixa.NrSeqFaixarebateSic;
            volumeCompradoRebateSic.NrSeqRebateSic = rebateSic.NrSeqRebateSic;
            volumeCompradoRebateSic.StVolumeEncontrado = false;
            volumeCompradoRebateSic.VlVolumeCompradoSic = 0;
            volumeCompradoRebateSic.NrSeqCategoriaSic = faixa.NrSeqCategoriaSic;
            volumeCompradoRebateSic.DtGravacaoSic = RebateUtil.GetDataAtual();
            //CUSTOM PROP PARA VINCULAR AO IBM
            volumeCompradoRebateSic.NrIbmRebateSic = rebateSic.NrIbmRebateSic;

            //Busca o volume dentro da faixa, considerando IBM, Categoria e periodo                            
            List<VolumeRbc> volumesFaixa = SelecionarVolumePorIBMCategoria(listVolumeRbc, rebateSic, faixa, dataInicio, dataFim);
            volumesSelecionados = volumesFaixa;
            //Verifica se encontrou os volumes
            if (volumesFaixa != null && volumesFaixa.Count > 0)
            {
                volumeCompradoRebateSic.StVolumeEncontrado = true;
                volumeCompradoRebateSic.VlVolumeCompradoSic = volumesFaixa.Sum(v => v.VlVolumeCompradoRbc);
            }
            return volumeCompradoRebateSic;
        }

        /// <summary>
        /// Insere uma lista de volumes na base SIC
        /// </summary>
        /// <param name="listVolumeMensalFaixaRebateSic">Lista de volumes</param>        
        private void IncluirListaVolumeMensalFaixaRebateSic(IList<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic)
        {
            //Inserção dos dados de volume no Base SIC
            VolumeMensalFaixaRebateSicBLOService.Incluir(listVolumeMensalFaixaRebateSic.ToList(), this.ListFaixaRebateSic.ToList());
        }

        /// <summary>
        /// Prepara lista para os tipos global média volume
        /// </summary>
        /// <param name="tipoRebateCosan"></param>
        /// <param name="rebateSic"></param>
        /// <param name="listVolumeInterna"></param>
        /// <param name="faixasRebate"></param>
        /// <returns></returns>
        private List<VolumeMensalFaixaRebateSic> FormatarListaVolumesGlobalMedia(RebateSic rebateSic, List<VolumeMensalFaixaRebateSic> listVolumeInterna, List<FaixarebateSic> faixasRebate, DateTime dtInicio, DateTime dtFim, bool recalculo)
        {
            //Recupera tipo rebate cosan
            //TiporebateSic tipoRebateCosan = ListTipoRebateSic.Single(t => t.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME));
            TiporebateSic tipoRebate = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);

            bool cosan = tipoRebate.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;

            //Verifica se é trimestral ou mensal  
            int periodicidadePagto = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? 1 : 3;


            //Trata Global Cosan (Tabela Prêmio)               
            //if (rebateSic.NrSeqTiporebateSic == tipoRebateCosan.NrSeqTiporebateSic && faixasRebate.Count > 0)
            #region REBATE COSAN
            if (tipoRebate.NmTiporebateSic.Trim().ToUpperInvariant().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME) &&
                    faixasRebate.Count > 0)
            {
                //Trimestral
                //int periodicidadePagto = (rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value) ? 3 : 1;

                //Volume contratado               
                decimal volumeContratado = faixasRebate.First().VlVolumemensalRebateSic.Value * periodicidadePagto;

                //Distinct nos volumes
                List<VolumeMensalFaixaRebateSic> volumesCosan = listVolumeInterna.Where(v =>
                    faixasRebate.Distinct(new ComparaFaixaRebatePorCategoria())
                    .Select(f => f.NrSeqFaixarebateSic.Value).ToList().Contains(v.NrSeqFaixarebateSic.Value)).ToList();
                decimal volumeConsumido = volumesCosan.Sum(v => v.VlVolumeCompradoSic.Value) / 3; //Média trimestral

                //Tratando casos de recalculo - Buscar todos os volumes da base para o periodo
                if (recalculo)
                {
                    IList<VolumeMensalFaixaRebateSic> volumesRecalculo =
                        VolumeMensalFaixaRebateSicBLOService.SelecionarVolumeMensalFaixaPeriodoAditivo(dtInicio.AddMonths(-2), dtFim, rebateSic);
                    if (volumesRecalculo != null && volumesRecalculo.Count > 0)
                        volumeConsumido += (volumesRecalculo.Sum(v => v.VlVolumeCompradoSic.Value) / 3);
                }

                //Busca Faixas de consumo
                decimal faixaPercentual = (volumeConsumido * 100) / volumeContratado;
                List<FaixarebateSic> faixasRebateCosan = faixasRebate.Where(f => faixaPercentual >= f.VlPercminimoRebateSic.Value &&
                    faixaPercentual <= f.VlPercmaximoRebateSic.Value).ToList();

                //Para o caso de o cliente ter consumido além do máximo cadastrado, considera o máximo da ultima faixa
                if (faixasRebateCosan.Count == 0)
                {
                    decimal percentualLimiteMin = faixasRebate.Max(f => f.VlPercminimoRebateSic).Value;
                    decimal percentualLimiteMax = faixasRebate.Max(f => f.VlPercmaximoRebateSic).Value;

                    if (faixaPercentual >= percentualLimiteMax)
                        faixasRebateCosan = faixasRebate.Where(f => percentualLimiteMin == f.VlPercminimoRebateSic.Value &&
                            percentualLimiteMax == f.VlPercmaximoRebateSic.Value).ToList();
                }

                //Recupera as faixas para o percentual consumido
                listVolumeInterna = listVolumeInterna.Where(v =>
                    faixasRebateCosan.Select(f => f.NrSeqFaixarebateSic.Value).ToList().Contains(v.NrSeqFaixarebateSic.Value)).ToList();

                //Verificar volumees ja inseridos por rebate/Categoria/Produto
                var lstVolumesInseridos = VolumeMensalFaixaRebateSicBLOService.Selecionar(new VolumeMensalFaixaRebateSic()
                {
                    NrSeqRebateSic = rebateSic.NrSeqRebateSic
                }).Where(f=> f.DtPeriodoSic >= dtInicio.AddMonths(-2) && f.DtPeriodoSic <= dtFim );
                //Remover da lista de volumes, as categorias ja inseridas no periodo
                listVolumeInterna = RemoverVolumesJaInseridos(listVolumeInterna, lstVolumesInseridos);
            } 
            #endregion
            #region REBATE ESCALONADO
            else if (
                    tipoRebate.NmTiporebateSic.Trim().ToUpperInvariant().Contains(ConstantesRebate.TIPO_REBATE_ESCALONADO) &&
                    faixasRebate.Count > 0)
            {
                var tempVolumesMensalFaixa = new List<VolumeMensalFaixaRebateSic>();
                //ENCONTRA O GRUPO DA FAIXA
                List<int> listGrupos = (from f in faixasRebate select f.NrSeqGrupoSic.Value).Distinct().ToList();

                foreach (int grupo in listGrupos)
                {
                    //ENCONTRA TODAS AS FAIXAS PARA O GRUPO
                    var listFaixasGrupo = faixasRebate
                        .Where(f => f.NrSeqGrupoSic == grupo);
                    listFaixasGrupo = listFaixasGrupo.OrderByDescending(r => r.VlVolumemensalRebateSic).ToList();

                    //DEFININDO AS CATEGORIAS PERTENCENTES AO GRUPO
                    var categoriasGrupo = listFaixasGrupo.Select(r => r.NrSeqCategoriaSic).Distinct();
                    //DEFININDO O VOLUME DO GRUPO COM BASE EM TODOS OS VOLUMES DISTINTOS DE TODAS AS CATEGORIAS DO GRUPO
                    var volumesDistintos = listVolumeInterna
                        .Where(r => categoriasGrupo.Any(ir => r.NrSeqCategoriaSic == ir))
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
                    List<VolumeMensalFaixaRebateSic> volumesFaixa = new List<VolumeMensalFaixaRebateSic>();
                    foreach (var faixaGrupo in listaFaixasGrupoAgrupado)
                    {
                        //SELECIONA A FAIXA DE BONIFICAÇÃO PARA A CATEGORIA A VOLUME DEFINIDOS
                        var faixa = faixaGrupo.FirstOrDefault(ir =>
                        {
                            return
                                (ir.VlVolumemensalRebateSic * periodicidadePagto) <= volume &&
                                faixaGrupo.Key == ir.NrSeqCategoriaSic; //KEY É NrSeqCategoriaSic DADO PELO AGRUPAMENTO
                        });
                        volumesFaixa.AddRange(listVolumeInterna
                            .Where(r =>
                            {
                                return
                                    (faixa != null && r.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic) ||
                                    //SE NÃO ATINGIR O VOLUME, NÃO VAI HAVER FAIXA. GRAVA DA MESMA FORMA COM A ÚLTIMA FAIXA DO GRUPO.
                                    //A DECISÃO SOBRE A BONIFICAÇÃO É DE CARGO DO CÁLCULO
                                    (faixa == null && r.NrSeqFaixarebateSic == faixaGrupo.Last().NrSeqFaixarebateSic);
                            }));
            }

                    tempVolumesMensalFaixa.AddRange(volumesFaixa);

                    #region OLD
                    //var listaFaixasGrupoAgrupado = listFaixasGrupo
                    //   .GroupBy(r => r.NrSeqCategoriaSic);

                    ////DEFINE O VOLUME TOTAL DO GRUPO
                    //List<VolumeMensalFaixaRebateSic> volumesFaixa = new List<VolumeMensalFaixaRebateSic>();
                    //foreach (var faixaGrupo in listaFaixasGrupoAgrupado)
                    //{
                    //    var faixa = faixaGrupo.First();
                    //    volumesFaixa.AddRange(listVolumeInterna
                    //        .Where(r => r.NrSeqFaixarebateSic == faixa.NrSeqFaixarebateSic));
                    //} 
                    //var volume = volumesFaixa.Sum(r => r.VlVolumeCompradoSic ?? 0);
                    ////DO GRUPO, SELECIONA A FAIXA COM VOLUME IMEDIATAMENTE INFERIOR AO VOLUME PARA PAGAMENTO DA BONIFICAÇÃO
                    //listFaixasGrupo = listFaixasGrupo.OrderByDescending(r => r.VlVolumemensalRebateSic).ToList();
                    ////PARA CADA VOLUME TENTA SELECIONAR A FAIXA QUE CORRESPONDE AO MONTANTE CONTRATAO E A CATEGORIA DE PRODUTOS
                    //volumesFaixa.ForEach(r =>
                    //{
                    //    var faixaBonificacao = listFaixasGrupo.FirstOrDefault(ir => ir.VlVolumemensalRebateSic <= volume && r.NrSeqCategoriaSic == ir.NrSeqCategoriaSic);
                    //    if (faixaBonificacao != null)
                    //    {
                    //        r.NrSeqFaixarebateSic = faixaBonificacao.NrSeqFaixarebateSic;
                    //        tempVolumesMensalFaixa.Add(r);
                    //    }
                    //}); 
                    #endregion
                }

                listVolumeInterna = tempVolumesMensalFaixa;

                #region OLD
                //listVolumeInterna = listVolumeInterna.Where(r =>
                //{
                //    //PEGA A FAIXA DEFINIDA
                //    var faixa = faixasRebate.Single(f => f.NrSeqFaixarebateSic == r.NrSeqFaixarebateSic);
                //    //PEGA TODAS AS FAIXAS DO GRUPO
                //    var faixasGrupo = faixasRebate.Where(f => f.NrSeqGrupoSic == faixa.NrSeqGrupoSic);
                //    //DO GRUPO, SELECIONA A FAIXA COM VOLUME IMEDIATAMENTE INFERIOR AO VOLUME PARA PAGAMENTO DA BONIFICAÇÃO
                //    faixasGrupo = faixasGrupo.OrderByDescending(ir => ir.VlVolumemensalRebateSic).ToList();
                //    var faixaBonificacao = faixasGrupo.FirstOrDefault(ir => ir.VlVolumemensalRebateSic <= r.VlVolumeCompradoSic);
                //    if (faixaBonificacao == null ||
                //        faixaBonificacao.NrSeqFaixarebateSic == null ||
                //        faixaBonificacao.NrSeqFaixarebateSic.Value <= 0)
                //    {
                //        faixaBonificacao = faixasRebate.OrderBy(ir => ir.VlVolumemensalRebateSic).First();
                //    }

                //    //RETORNANDO
                //    return 
                //        r.StVolumeEncontrado == true && 
                //        faixaBonificacao.NrSeqFaixarebateSic == r.NrSeqFaixarebateSic;
                //}).ToList(); 
                #endregion
            } 
            #endregion

            return listVolumeInterna;
        }

        private List<VolumeMensalFaixaRebateSic> RemoverVolumesJaInseridos(List<VolumeMensalFaixaRebateSic> listVolumeInterna, IEnumerable<VolumeMensalFaixaRebateSic> lstVolumesInseridos)
        {
            return listVolumeInterna.Where(x => !lstVolumesInseridos.Any(v =>     v.NrSeqRebateSic == x.NrSeqRebateSic &&
                                                                                  v.DtPeriodoSic == x.DtPeriodoSic &&
                                                                                  v.NrSeqCategoriaSic == x.NrSeqCategoriaSic
                                                                                  )).ToList(); 

                         
        }
        #endregion
    }
}
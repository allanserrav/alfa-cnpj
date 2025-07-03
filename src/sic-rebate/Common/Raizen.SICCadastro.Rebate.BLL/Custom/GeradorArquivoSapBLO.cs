using COSAN.Framework.Factory;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.Util;
using Raizen.SICCadastro.Rebate.Util.Arquivo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.BLL
{
    public class GeradorArquivoSapBLO : IGeradorArquivoSapBLO
    {
        #region Variaveis Privadas

        /// <summary>
        /// Retorna Instancia de CalculoRebateSicBLO
        /// </summary>
        private ICalculoRebateSicBLO CalculoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de RebateSicBLO
        /// </summary>
        private IRebateSicBLO RebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de ClienteSicBLO
        /// </summary>
        private IClienteSicBLO ClienteSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de ClienteSicBLO
        /// </summary>
        private IDadosArquivoRebateSicBLO DadosArquivoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de PeriodoProcessamentoSicBLO
        /// </summary>
        private IPeriodoProcessamentoSicBLO PeriodoProcessamentoSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de SaldoRebateSicBLO
        /// </summary>
        private ISaldoRebateSicBLO SaldoRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de StatusCalculoRebateHistoricoSicBLO
        /// </summary>
        private IStatusCalculoRebateHistoricoSicBLO StatusCalculoRebateHistoricoSicBLOService { get; set; }

        /// <summary>
        /// Armazena os dados de dia de vencimento de cada tipo rebate - Usado antes de definir pagamento para proximo dia seguinte
        /// </summary>
        //private IList<PeriodoProcessamentoSic> PeriodosVencimentos { get; set; }

        #endregion Variaveis Privadas

        #region Constutor

        public GeradorArquivoSapBLO()
        {
            this.CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");
            this.RebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
            this.ClienteSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IClienteSicBLO>("ClienteSicBLO");
            this.DadosArquivoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IDadosArquivoRebateSicBLO>("DadosArquivoRebateSicBLO");
            this.PeriodoProcessamentoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IPeriodoProcessamentoSicBLO>("PeriodoProcessamentoSicBLO");
            this.SaldoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicBLO>("SaldoRebateSicBLO");
            this.StatusCalculoRebateHistoricoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicBLO>("StatusCalculoRebateHistoricoSicBLO");

            //Dados dia do vencimento - Usado antes de definir pagamento para proximo dia seguinte
            //this.PeriodosVencimentos = PeriodoProcessamentoSicBLOService.Selecionar().Where(d => d.NrSeqTiporebateSic != null).ToList();
        }

        #endregion Constutor

        #region Struct

        //struct DadosBonificacaoRebate
        //{
        //    public CalculoRebateProporcionalSic CalculoRebateProporcionalSic { get; set; }
        //    public CalculoRebateSic CalculoRebateSic { get; set; }
        //    //public RebateSic RebateSic { get; set; }
        //    public IBMFornecedor IBMFornecedor { get; set; }
        //    public ClienteSic ClienteSic { get; set; }
        //    public bool PagamentoManual { get; set; }
        //}

        /*struct IBMFornecedor
        {
            public string IBM { get; set; }
            public string CodigoFornecedor { get; set; }
        }*/

        #endregion Struct

        #region Metodos Publicos

        public void ProcessarServico(string localArquivo)
        {
            //Buscar Rebates a pagar ( todos com status Enviado a pagamento)
            IList<CalculoRebateSic> listaRebates = CalculoRebateSicBLOService.Selecionar(new CalculoRebateSic { NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento) });

            IList<DadosBonificacaoRebate> clientesSBOP = new List<DadosBonificacaoRebate>();
            IList<DadosBonificacaoRebate> clientesSABB = new List<DadosBonificacaoRebate>();
            IList<DadosBonificacaoRebate> clientesMIME = new List<DadosBonificacaoRebate>();
            IList<DadosBonificacaoRebate> clientesSIMA = new List<DadosBonificacaoRebate>();


            //CRIAR UMA LISTA DE PAGAMENTOS PROPORCIONAIS
            var listaPagamentosProporcionais = SelecionarPagamentosProporcionais(listaRebates);
            if (listaPagamentosProporcionais == null) return;

            //Separando clientes por empresa
            foreach (CalculoRebateProporcionalSic calculoRebateProporcional in listaPagamentosProporcionais)
            {
                //BUSCA DADOS DE CONTRATO REBATE COM BASE NO CALCULO
                CalculoRebateSic calculoSic = listaRebates.SingleOrDefault(r => r.NrSeqCalculoRebateSic == calculoRebateProporcional.NrSeqCalculoRebateSic);
                var colecaoIbmCodigoFornecedor = new List<IBMFornecedor>();
                //RECUPERA O CONTRATO REBATE DO CALCULO
                RebateSic rebateSic = RebateSicBLOService.SelecionarPrimeiro(new RebateSic { NrSeqRebateSic = calculoSic.NrSeqRebateSic });
                if (rebateSic == null) return;

                colecaoIbmCodigoFornecedor.Add(new IBMFornecedor
                {
                    IBM = rebateSic.NrIbmRebateSic,
                    CodigoFornecedor = rebateSic.NrCodigofornecedorRebateSic
                });
                //RECUPERA O LISTA DE MATRIZFILIAL
                colecaoIbmCodigoFornecedor.AddRange(new MatrizfilialrebateSicBLO()
                    .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebateSic.NrSeqRebateSic })
                    .Select(r => new IBMFornecedor
                    {
                        IBM = r.NrIbmFilialSic,
                        CodigoFornecedor = r.NrCdfornecedorFilialSic
                    }));
                //ENCONTRA O IBM+CODIGO FORNECEDOR DO PAGAMENTO
                var ibmCodFornecedor = colecaoIbmCodigoFornecedor.SingleOrDefault(r => r.IBM == calculoRebateProporcional.NrIbmClienteSic);

                //BUSCA DADOS DE CLIENTE PARA CADA PORÇÃO (PROPORCIONAL) DE PAGAMENTO
                ClienteSic clienteSic = ClienteSicBLOService.SelecionarPrimeiro(new ClienteSic { NrSeqClienteSic = calculoRebateProporcional.NrSeqClienteSic });

                //Armazenando os dados consultados
                DadosBonificacaoRebate dadosBonificacao = new DadosBonificacaoRebate()
                {
                    CalculoRebateSic = calculoSic,
                    CalculoRebateProporcionalSic = calculoRebateProporcional,
                    //RebateSic = rebateSic,
                    IBMFornecedor = ibmCodFornecedor,
                    ClienteSic = clienteSic
                };

                //Separacao por empresa
                switch (clienteSic.NrSeqEmpresaSic)
                {
                    case (int)EmpresaCliente.SBOP:
                        {
                            clientesSBOP.Add(dadosBonificacao);
                        }
                        break;

                    case (int)EmpresaCliente.SABB:
                        {
                            clientesSABB.Add(dadosBonificacao);
                        }
                        break;

                    case (int)EmpresaCliente.MIME:
                        {
                            clientesMIME.Add(dadosBonificacao);
                        }
                        break;
                    case (int)EmpresaCliente.SIMA:
                        {
                            clientesSIMA.Add(dadosBonificacao);
                        }
                        break;

                    default:
                        break;
                }
            }

            if (clientesSBOP.Count > 0) GerarArquivo(clientesSBOP, EmpresaCliente.SBOP, localArquivo);
            if (clientesSABB.Count > 0) GerarArquivo(clientesSABB, EmpresaCliente.SABB, localArquivo);
            if (clientesMIME.Count > 0) GerarArquivo(clientesMIME, EmpresaCliente.MIME, localArquivo);
            if (clientesSIMA.Count > 0) GerarArquivo(clientesSIMA, EmpresaCliente.SIMA, localArquivo);
        }

        #endregion Metodos Publicos

        #region Metodos Privados

        private void GerarArquivo(IList<DadosBonificacaoRebate> dadosBonificacao, EmpresaCliente empresa, string localArquivo)
        {
            DateTime dataGeracao = DateTime.Now;

            //Dados Arquivo
            DadosArquivoRebateSic dadosArquivo = DadosArquivoRebateSicBLOService.SelecionarPrimeiro(new DadosArquivoRebateSic());

            //Criação do Arquivo
            string nomeArquivo = new StringBuilder().Append(localArquivo)
                .Append(@"\novo\RIFGCMC")
                .Append(RetornaIdEmpresa(empresa))
                .Append(".DAT").ToString();

            //Nome e local da cópia do arquivo (o local do arquivo deve ter a pasta backup)
            string nomeArquivoBackup = new StringBuilder().Append(localArquivo)
                .Append(@"\backup\RIFGCMC")
                .Append(RetornaIdEmpresa(empresa))
                .Append(".DAT").Append(dataGeracao.ToString("yyyyMMddhhmmss")).ToString();

            if (File.Exists(nomeArquivo))
            {
                LogError.Debug(string.Format("Erro: Geracao Arquivo Rebate - Arquivo ja Existe! {0}", nomeArquivo));
                return;
            }

            string nomeEmpresa = empresa.ToString();
            string numeroArquivo = string.Empty;
            switch (empresa)
            {
                case EmpresaCliente.SBOP:
                    {
                        numeroArquivo = (++dadosArquivo.NrArquivoSbopSeqSic).ToString();
                    }
                    break;

                case EmpresaCliente.SABB:
                    {
                        numeroArquivo = (++dadosArquivo.NrArquivoSaabSeqSic).ToString();
                    }
                    break;

                case EmpresaCliente.MIME:
                    {
                        numeroArquivo = (++dadosArquivo.NrArquivoMimeSeqSic).ToString();
                    }
                    break;
                case EmpresaCliente.SIMA:
                    {
                        numeroArquivo = (++dadosArquivo.NrArquivoMimeSeqSic).ToString();
                    }
                    break;

                default:
                    break;
            }

            List<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();
            List<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = new List<StatusCalculoRebateHistoricoSic>();
            List<SaldoRebateSic> listSaldoRebateSic = new List<SaldoRebateSic>();

            StreamWriter writer = new StreamWriter(nomeArquivo);

            try
            {
                //Header
                string header = new StringBuilder()
                    .Append(ConstantesArquivo.Header)                  //HEADER - fixo
                    .Append(new String(' ', 4))                        //4 espaços
                    .Append(empresa.ToString())                        //Nome da Empresa
                    .Append(ConstantesArquivo.Transacao)               //FB01 - fixo
                    .Append(new String(' ', 8))                        //8 espaços
                    .Append(ConstantesArquivo.SistemaLegado)           //GCMS - fixo
                    .Append(new String(' ', 6))                        //6 espaços
                    .Append(numeroArquivo.PadLeft(12, '0'))             //numeração sequencial do arquivo
                    .Append(dataGeracao.ToString("yyyyMMddHHmmss"))    //Data Hora da geração do arquivo
                    .ToString();

                writer.WriteLine(header);

                //Conteudo do Arquivo (Linhas)
                int totalLinhas = 0;
                decimal valorTotal = 0;

                foreach (DadosBonificacaoRebate item in dadosBonificacao)
                {
                    //if (item.CalculoRebateSic.VlBonificacaoTotalSic > 0   //Caso nao tenha atingido o volume, o valor é zero e nao é enviado no arquivo para pagto
                    if (item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic > 0   //Caso nao tenha atingido o volume, o valor é zero e nao é enviado no arquivo para pagto
                        && (item.CalculoRebateSic.StPagtoManualSic == null || !item.CalculoRebateSic.StPagtoManualSic.Value))
                    {
                        ++dadosArquivo.NrReferenciaSeqSic;
                        string linha = string.Empty;

                        //Linha G
                        linha = new StringBuilder()
                            .Append(ConstantesArquivo.FileRecordG.PadRight(10, ' '))                                    //File Record Type - Fixo: G
                            .Append(new String(' ', 10))                                                                //Control key
                            .Append(new String(' ', 4))                                                                 //Transaction code
                            .Append(dataGeracao.ToString("yyyyMMdd"))                                                   //Data do Documento
                            .Append(ConstantesArquivo.TipoDocumento)                                                    //Tipo de documento - Fixo: KR
                            .Append(empresa.ToString())                                                                 //Empresa
                            .Append(dataGeracao.ToString("yyyyMMdd"))                                                   //Data de lançamento no documento
                            .Append(new String(' ', 2))                                                                 //Mes do exercicio
                            .Append(ConstantesArquivo.ChaveMoeda.PadRight(5, ' '))                                      //Chave da moeda - Fixo: R$
                            .Append(new String(' ', 28))                                                                //Taxa de conversão, No. documento contabil, Data
                            .Append(dadosArquivo.NrReferenciaSeqSic.ToString().PadLeft(10, '0').PadRight(16, ' '))      //No. documento de referencia
                            .Append(ConstantesArquivo.TextoCabecalho.PadRight(25, ' '))                                 //Texto para cabeçalho de documento - Fixo: REBATESIC
                            .Append(new String(' ', 25))                                                                //6 campos nao utilizados no rebate
                            .ToString();

                        writer.WriteLine(linha);
                        totalLinhas++;

                        //Programa e armazena a data do pagamento para o dia seguinte à geração do arquivo
                        item.CalculoRebateSic.DtPagamentoSic = dataGeracao.AddDays(1);

                        //Linha D-Credito
                        linha = new StringBuilder()
                            .Append(ConstantesArquivo.FileRecordD.PadRight(10, ' '))                                                                //File Record Type - Fixo: D
                            .Append(new String(' ', 10))                                                                                            //Control key
                            .Append(ConstantesArquivo.LancamentoCredito.PadRight(2, ' '))                                                           //Chave de lançamento - Fixo: C
                            .Append(new String(' ', 1))                                                                                             //Código de razão especial para o item seguinte
                                                                                                                                                    //.Append(Math.Round(item.CalculoRebateSic.VlBonificacaoTotalSic.Value, 2).ToString().Replace(',', '.').PadLeft(16, '0')) //Montante em moeda de documento
                            .Append(Math.Round(item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic.Value, 2).ToString().Replace(',', '.').PadLeft(16, '0')) //Montante em moeda de documento
                            .Append(new String(' ', 150))                                                                                           //Sequencia de 17 campos nao utilizados
                            .Append(item.CalculoRebateSic.DtPagamentoSic.Value.ToString("yyyyMMdd"))                                                //Data de efetivação do pagamento
                            .Append((dadosArquivo.NrReferenciaSeqSic.ToString().PadLeft(10, '0')).PadRight(18, ' '))                                //No. atribuicao
                            .Append(new StringBuilder().AppendFormat("{0}  {1}  PERIODO:{2}",
                                    ConstantesArquivo.TextoCabecalho,
                                    item.ClienteSic.NrIbmClienteSic.ToString(),
                                    item.CalculoRebateSic.DtPeriodoSic.Value.ToString("MM/yyyy"))
                                    .ToString().PadRight(50, ' '))                                                                                  //Texto de item
                            .Append(new String(' ', 2))                                                                                             //Area de reclamacao
                            .Append(ConstantesArquivo.CondicaoPagamento)                                                                            //Condicao de pagto Fixo: 0001 (Realiza o pagamento na data definida - Data de efetivação do pagamento)
                            .Append(new String(' ', 4))                                                                                             //Sequencia de 4 campos nao utilizados
                                                                                                                                                    //.Append(item.RebateSic.NrCodigofornecedorRebateSic.ToString().PadLeft(17, '0'))                                         //Conta ou matchcode para o item seguinte (Sisac: Vendor)
                            .Append(item.IBMFornecedor.CodigoFornecedor.ToString().PadLeft(17, '0'))                                         //Conta ou matchcode para o item seguinte (Sisac: Vendor)
                            .Append(ConstantesArquivo.AccountTypeK)                                                                                 //Account Type Indicator for SAP posting key - Fixo: K
                            .Append(new String(' ', 137))                                                                                           //Sequencia de campos nao utilizados
                            .ToString();

                        writer.WriteLine(linha);
                        totalLinhas++;
                        //valorTotal += Math.Round(item.CalculoRebateSic.VlBonificacaoTotalSic.Value, 2);
                        valorTotal += Math.Round(item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic.Value, 2);

                        //Linha D-Debito
                        linha = new StringBuilder()
                            .Append(ConstantesArquivo.FileRecordD.PadRight(10, ' '))                                                                //File Record Type - Fixo: D
                            .Append(new String(' ', 10))                                                                                            //Control key
                            .Append(ConstantesArquivo.LancamentoDebito.PadRight(2, ' '))                                                            //Chave de lançamento - Fixo: D
                            .Append(new String(' ', 1))                                                                                             //Código de razão especial para o item seguinte
                                                                                                                                                    //.Append(Math.Round(item.CalculoRebateSic.VlBonificacaoTotalSic.Value, 2).ToString().Replace(',', '.').PadLeft(16, '0')) //Montante em moeda de documento
                            .Append(Math.Round(item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic.Value, 2).ToString().Replace(',', '.').PadLeft(16, '0')) //Montante em moeda de documento
                            .Append(new String(' ', 65))                                                                                            //Sequencia de 7 campos nao utilizados
                            .Append(new String('0', 12))                                                                                            //No. ordem - Verificado nos arquivos gerados pelo SISAC, sempre zero
                            .Append(new String(' ', 81))                                                                                            //Sequencia de 10 campos nao utilizados
                            .Append(ConstantesArquivo.NumeroAtribuicao.PadLeft(18, '0'))                                                            //No. Atribuicao (Sisac: CodService) Fixo: 200007971
                            .Append((new StringBuilder().AppendFormat("{0}-{1}",
                                        item.ClienteSic.NrIbmClienteSic.ToString(),
                                        //item.RebateSic.NrCodigofornecedorRebateSic.ToString())).ToString().PadRight(50, ' '))                       //Texto de item (Sisac: Vendor)
                                        item.IBMFornecedor.CodigoFornecedor.ToString())).ToString().PadRight(50, ' '))                       //Texto de item (Sisac: Vendor)
                            .Append(new String(' ', 10))                                                                                            //Sequencia de 6 campos nao utilizados
                            .Append(ConstantesArquivo.NumeroAtribuicao.PadLeft(17, '0'))                                                            //No. Atribuicao (Sisac: CodService) Fixo: 200007971 ***TODO:Confirmar se é fixo
                            .Append(ConstantesArquivo.AccountTypeS)                                                                                 //Account Type Indicator for SAP position key - Fixo: S
                            .Append(new String(' ', 100))                                                                                           //Sequencia de campos nao utilizados
                            .Append(ConstantesArquivo.CanalDistribuicao.PadRight(2, ' '))                                                           //Canal de Distribuição - Fixo: V
                            .Append(new String(' ', 35))                                                                                            //Sequencia de campos nao utilizados
                            .ToString();

                        writer.WriteLine(linha);
                        totalLinhas++;
                        //valorTotal += Math.Round(item.CalculoRebateSic.VlBonificacaoTotalSic.Value, 2);
                        valorTotal += Math.Round(item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic.Value, 2);
                    }
                    else
                    {
                        //Armazena a data da geração para pagamentos sem bonificação e manual
                        item.CalculoRebateSic.DtPagamentoSic = dataGeracao;
                    }

                    item.CalculoRebateSic.NrSeqStatusCalculoRebateSic = Convert.ToInt16(StatusCalculoRebate.Pago);

                    //Armazena CalculoRebateSic atualizado
                    listCalculoRebateSic.Add(item.CalculoRebateSic);

                    #region Insere Historico

                    StatusCalculoRebateHistoricoSic historico = new StatusCalculoRebateHistoricoSic();
                    historico.NrSeqCalculoRebateSic = item.CalculoRebateSic.NrSeqCalculoRebateSic;
                    historico.DtAlteracaoSic = dataGeracao;
                    historico.NmLoginSic = ConstantesRebate.USUARIO_SERVICO;
                    historico.NrSeqStatusCalculoRebateSic = item.CalculoRebateSic.NrSeqStatusCalculoRebateSic;
                    historico.DsObservacaoSic = string.Format(ConstantesRebate.DS_HISTORICO_PAGO,
                        item.CalculoRebateSic.NrSeqRebateSic,
                        item.CalculoRebateSic.DtPeriodoSic.Value.ToString("MM/yyyy"),
                        item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic.Value.ToString("N2"),
                        item.CalculoRebateProporcionalSic.VlProporcaoSic.Value * 100,
                        item.CalculoRebateSic.VlBonificacaoTotalSic.Value.ToString("N2"));
                    listStatusCalculoRebateHistoricoSic.Add(historico);

                    #endregion Insere Historico

                    #region Atualiza Saldo

                    //if (item.CalculoRebateSic.VlBonificacaoTotalSic > 0)   //Caso nao tenha atingido o volume, o valor é zero e nao é atualizado o saldo
                    if (item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic > 0)   //Caso nao tenha atingido o volume, o valor é zero e nao é atualizado o saldo
                    {
                        //Busca o último saldo
                        SaldoRebateSic saldo;
                        saldo = listSaldoRebateSic.Where(s => s.NrSeqRebateSic == item.CalculoRebateSic.NrSeqRebateSic).LastOrDefault();
                        if (saldo == null)
                            saldo = SaldoRebateSicBLOService.SelecionarUltimo(new SaldoRebateSic { NrSeqRebateSic = item.CalculoRebateSic.NrSeqRebateSic });
                        decimal saldoAtual = saldo.VlSaldoAtualSic ?? 0;
                        //Cria nova entrada de Saldo
                        SaldoRebateSic saldoAtualizado = new SaldoRebateSic
                        {
                            NrSeqRebateSic = item.CalculoRebateSic.NrSeqRebateSic,
                            VlSaldoAtualSic = (saldoAtual - item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic),
                            VlLancamentoSic = (-1) * item.CalculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic,
                            DtLancamentoSic = item.CalculoRebateSic.DtPagamentoSic ?? dataGeracao,
                            DsObsComplementoSic = string.Format(ConstantesRebate.DS_EXTRATO_PAGO, item.CalculoRebateSic.DtPeriodoSic.Value.ToString("MM/yyyy")),
                        };
                        //Insere registro com saldo atualizado
                        listSaldoRebateSic.Add(saldoAtualizado);
                    }

                    #endregion Atualiza Saldo
                }

                //Footer
                string footer = new StringBuilder()
                    .Append(ConstantesArquivo.Footer)                                   //FOOTER - fixo
                    .Append(new String(' ', 4))                                         //4 espaços
                    .Append(totalLinhas.ToString().PadLeft(12, '0'))                    //Total Linhas do arquivo
                    .Append(valorTotal.ToString().Replace(",", "").PadLeft(25, '0'))    //Valor total no arquivo
                    .ToString();

                writer.WriteLine(footer);
                writer.Close();

                //Realizando copia de backup do arquivo
                File.Copy(nomeArquivo, nomeArquivoBackup, false);
            }
            catch (Exception ex)
            {
                writer.Close();
                File.Delete(nomeArquivo); //Em caso de erro, apaga o arquivo gerado até o momento do erro
                LogError.Debug(string.Format("Erro: Construção do Arquivo Rebate {0}: {1}", nomeArquivo, ex.Message));
                return;
            }

            //Atualiza informações de pagamento do CalculoRebate
            CalculoRebateSicBLOService.AtualizarCalculoGeracaoArquivo(listCalculoRebateSic, listStatusCalculoRebateHistoricoSic, listSaldoRebateSic, dadosArquivo);
        }

        private IList<CalculoRebateProporcionalSic> SelecionarPagamentosProporcionais(IList<CalculoRebateSic> listaCalculoRebates)
        {
            List<CalculoRebateProporcionalSic> r = new List<CalculoRebateProporcionalSic>();
            foreach (var calculoRebate in listaCalculoRebates)
            {
                var calculosProporcionais = new CalculoRebateProporcionalSicBLO()
                    .Selecionar(new CalculoRebateProporcionalSic { NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic })
                    .ToList();
                if (calculosProporcionais != null && calculosProporcionais.Count > 0)
                    r.AddRange(calculosProporcionais);
                else
                {
                    var rebate = new RebateSicBLO().SelecionarPrimeiro(new RebateSic { NrSeqRebateSic = calculoRebate.NrSeqRebateSic });
                    r.Add(new CalculoRebateProporcionalSic
                    {
                        //NrCodigoFornecedorRebateSic = rebate.NrCodigofornecedorRebateSic,
                        NrIbmClienteSic = rebate.NrIbmRebateSic,
                        NrSeqCalculoRebateSic = calculoRebate.NrSeqCalculoRebateSic,
                        NrSeqClienteSic = rebate.NrSeqClienteSic,
                        VlProporcaoSic = 1,
                        VlValorBonificacaoProporcionalSic = calculoRebate.VlBonificacaoTotalSic
                    });
                }
            }
            return r.Count < 1 ? null : r;
        }

        #region DiaPagamento [inativo]

        /// <summary>
        /// Identifica o dia de realizacao do pagamento
        /// </summary>
        /// <param name="dadosBonificacao"></param>
        /// <returns></returns>
        //private int DiaPagamento(DadosBonificacaoRebate dadosBonificacao)
        //{
        //    //Busca o PeriodoProcessamento referente ao Tipo Rebate
        //    PeriodoProcessamentoSic periodoProcessamento = PeriodosVencimentos.FirstOrDefault(d => d.NrSeqTiporebateSic == dadosBonificacao.RebateSic.NrSeqTiporebateSic);

        //    //Caso não tenha PeriodoProcessamento cadastrado para o Tipo Rebate, sobe o erro
        //    if (periodoProcessamento == null)
        //    {
        //        throw new Exception("Erro: Geracao Arquivo Rebate - Periodo de Processamento não cadastrado! Rebate ID: " + dadosBonificacao.RebateSic.NrSeqTiporebateSic.ToString());
        //    }

        //    //Monta a data em que o pagamento deverá (ou deveria) ser realizado
        //    DateTime dataPagamento = new DateTime(
        //                                            dadosBonificacao.CalculoRebateSic.DtPeriodoSic.Value.Year,
        //                                            dadosBonificacao.CalculoRebateSic.DtPeriodoSic.Value.Month,
        //                                            periodoProcessamento.NrDiaEmissaoCobranca.Value
        //                                         );
        //    //Data da geracao do arquivo
        //    DateTime dataAtual = DateTime.Now;

        //    //Caso a data de pagamento programada seja futura, envia o dia programado, caso ja tenha passado coloca para o dia seguinte a geracao do arquivo
        //    if (dataPagamento > dataAtual)
        //        return periodoProcessamento.NrDiaEmissaoCobranca.Value;
        //    else
        //        return (dataAtual.Day + 1);
        //}

        #endregion DiaPagamento [inativo]

        #endregion Metodos Privados

        private string RetornaIdEmpresa(EmpresaCliente empresa)
        {
            switch (empresa)
            {
                case EmpresaCliente.SBOP:
                    {
                        return "D";
                    }

                case EmpresaCliente.SIMA:
                    {
                        return "4";
                    }
                default:
                    return ((int)empresa).ToString();
            }
        }


    }
}
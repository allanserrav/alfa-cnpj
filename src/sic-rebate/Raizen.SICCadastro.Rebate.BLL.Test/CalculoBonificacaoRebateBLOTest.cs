using Raizen.SICCadastro.Rebate.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
using COSAN.Framework.Factory;
using System.Linq;

namespace Raizen.SICCadastro.Rebate.BLL.Test
{
    /// <summary>
    ///This is a test class for CalculoBonificacaoRebateBLOTest and is intended
    ///to contain all CalculoBonificacaoRebateBLOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalculoBonificacaoRebateBLOTest
    {
        private const string C_IBMGLobalSoma = "0000224740";
        private const string C_IBMGlobalMedia = "0001023911";
        private const string C_IBMEscalonado = "0001022906";// sem registro na base QA
        private const string C_IBMFaixaVolume = "0001024038";
        private const string C_IBMGCA = "0001022928";// sem registro na base QA
        private const string C_IBMGCB = "0001022976";
        private const string C_IBMGCC = "0001024182";// sem registro na base QA

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        //mock reg
        // * rebate -- para recalculo do ultimo periodo
        // * tipo?
        // * faixa

        delegate bool VerificacaoAditivo(IList<CalculoRebateSic> calculosObtidos, IList<CalculoRebateFaixaSic> calculosObtidosFaixa, IList<CalculoRebateProporcionalSic> calculosObtidosProporcionais);
        delegate bool VerificacaoRecalculo(CalculoRebateSic calculoObtido, IList<CalculoRebateFaixaSic> calculosObtidosFaixa, IList<CalculoRebateProporcionalSic> calculosObtidosProporcionais);

        //INCLUSÃO DE VOLUME PELO GUARDACHUVA
        private void Incluir_GuardaChuva_Calcular_Aditivo(string ibmRebate, IList<string> ibmsGC, VerificacaoAditivo condicao)
        {
            //DATA DE INICIO DO ADITIVO
            DateTime periodo = new DateTime(2014, 1, 1, 0, 0, 0);
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            if (rebate == null) Assert.Fail("Não foi possível localiza um contrato de Rebate para o IBM " + ibmRebate + ".");
            //ARMAZENANDO OS CALCULOS ADITIVOS ORIGINAIS
            var calculosAditivosPeriodo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosPeriodo = calculosAditivosPeriodo.Where(r => r.DtPeriodoSic >= periodo).ToList();
            //ADICIONAR GUARDACHUVA PARA O REBATE IBMS NÃO PERTENCENTES AO REBATE E COM VOLUME PARA O PERIODO
            foreach (var ibm in ibmsGC)
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                    .Incluir(new MatrizfilialrebateSic
                    {
                        NrIbmFilialSic = ibm,
                        NrSeqRebatematrizSic = rebate.NrSeqRebateSic
                    });
            }
            rebate.StMatrizRebateSic = true;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER CALCULO DO ATIVIDO
            Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                .CalcularAditivo(rebate, periodo);
            //ADITIVOS OBTIDOS
            var calculosAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosObtidos = calculosAditivosObtidos.Where(r => !calculosAditivosPeriodo.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var faixasAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar();
            faixasAditivosObtidos = faixasAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var proporcoesAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar();
            proporcoesAditivosObtidos = proporcoesAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            //REMOVENDO O GUARDACHUVA
            var guardaChuvas = Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebate.NrSeqRebateSic });
            foreach (var guardaChuva in guardaChuvas)
            {
                Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Excluir(guardaChuva);
            }
            rebate.StMatrizRebateSic = false;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculosAditivosObtidos, faixasAditivosObtidos, proporcoesAditivosObtidos));
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Aditivo_GlobalSoma()
        {
            //Incluir_GuardaChuva_Calcular_Aditivo(
            //    C_IBMGLobalSoma,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //     (calculos, faixas, proporcoes) =>
            //     {
            //         return
            //             calculos.Count >= 2 && //DEVE HAVER AO MENOS 2 CALCULOS CONSIDERANDO A DATA DE ESCRITA DO TESTE (2014/08/11)
            //             calculos[0].DtPeriodoSic == new DateTime(2014, 4, 1) &&
            //             calculos[0].VlBonificacaoTotalSic == 29058.75M; //SOMADOS OS VOLUMES, O PRIMEIRO RESULTADO ESPERADO, PARA Ó PRIMEIRO TRIMESTRE, DEVE SER DE 29058.75
            //     });
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Aditivo_GlobalMedia()
        {
            //Incluir_GuardaChuva_Calcular_Aditivo(
            //    C_IBMGlobalMedia,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //     (calculos, faixas, proporcoes) =>
            //     {
            //         return calculos.Count >= 2; //DEVE HAVER AO MENOS 2 CALCULOS CONSIDERANDO A DATA DE ESCRITA DO TESTE (2014/08/11)
            //     });
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Aditivo_Escalonado()
        {
            //Incluir_GuardaChuva_Calcular_Aditivo(
            //    C_IBMEscalonado,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //     (calculos, faixas, proporcoes) =>
            //     {
            //         return 
            //             calculos.Count >= 1 && //DEVE HAVER AO MENOS 1 CALCULOS CONSIDERANDO A DATA DE ESCRITA DO TESTE (2014/08/11)
            //             calculos[0].DtPeriodoSic == new DateTime(2014,4,1,0,0,0) && 
            //             calculos[0].VlBonificacaoTotalSic == 210000M;
            //     });
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Aditivo_FaixaVolume()
        {
            //Incluir_GuardaChuva_Calcular_Aditivo(
            //    C_IBMFaixaVolume,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //      (calculos, faixas, proporcoes) =>
            //      {
            //          return
            //             calculos.Count >= 7 && //DEVE HAVER AO MENOS 7 CALCULOS CONSIDERANDO A DATA DE ESCRITA DO TESTE (2014/08/12)
            //             calculos[0].DtPeriodoSic == new DateTime(2014, 1, 1) && calculos[0].VlBonificacaoTotalSic == 30212M && //SOMADOS OS VOLUMES, O PRIMEIRO RESULTADO ESPERADO, PARA O PRIMEIRO TRIMESTRE, DEVE SER DE 30212
            //             calculos[1].DtPeriodoSic == new DateTime(2014, 2, 1) && calculos[1].VlBonificacaoTotalSic == 34060M && //SOMADOS OS VOLUMES, O SEGUNGO RESULTADO ESPERADO, PARA O SEGUNDO TRIMESTRE, DEVE SER DE 34060
            //             calculos[2].DtPeriodoSic == new DateTime(2014, 3, 1) && calculos[2].VlBonificacaoTotalSic == 34320M && //SOMADOS OS VOLUMES, O TERCEIRO RESULTADO ESPERADO, PARA O TERCEIRO TRIMESTRE, DEVE SER DE 34320
            //             calculos[3].DtPeriodoSic == new DateTime(2014, 4, 1) && calculos[3].VlBonificacaoTotalSic == 28860M && //SOMADOS OS VOLUMES, O QUARTO RESULTADO ESPERADO, PARA O QUARTO TRIMESTRE, DEVE SER DE 28860
            //             calculos[4].DtPeriodoSic == new DateTime(2014, 5, 1) && calculos[4].VlBonificacaoTotalSic == 30160M && //SOMADOS OS VOLUMES, O QUINTO RESULTADO ESPERADO, PARA O QUINTO TRIMESTRE, DEVE SER DE 30160
            //             calculos[5].DtPeriodoSic == new DateTime(2014, 6, 1) && calculos[5].VlBonificacaoTotalSic == 28080M && //SOMADOS OS VOLUMES, O SEXTO RESULTADO ESPERADO, PARA O SEXTO TRIMESTRE, DEVE SER DE 28080
            //             calculos[6].DtPeriodoSic == new DateTime(2014, 7, 1) && calculos[6].VlBonificacaoTotalSic == 33800M;    //SOMADOS OS VOLUMES, O SETIMO RESULTADO ESPERADO, PARA O SÉTIMO TRIMESTRE, DEVE SER DE 33800
            //      });
        }

        private void Incluir_GuardaChuva_Efetuar_Recalculo(string ibmRebate, IList<string> ibmsGC, VerificacaoRecalculo condicao)
        {
            //DATA DE INICIO DO ADITIVO
            DateTime periodo = new DateTime(2014, 1, 1, 0, 0, 0);
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            //ADICIONAR GUARDACHUVA PARA O REBATE IBMS NÃO PERTENCENTES AO REBATE E COM VOLUME PARA O PERIODO
            foreach (var ibm in ibmsGC)
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                    .Incluir(new MatrizfilialrebateSic
                    {
                        NrIbmFilialSic = ibm,
                        NrSeqRebatematrizSic = rebate.NrSeqRebateSic
                    });
            }
            rebate.StMatrizRebateSic = true;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER RECALCULO
            Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                .RecalcularUltimoPeriodo(rebate); //O REBATE PRECISA TER VENCIDO DENTRO DE UMA DATA CONTROLADA PARA QUE SE SAIBA QUAL O ÚLTIMO PERÍODO
            //ADITIVOS OBTIDOS
            var calculoObtido = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic { NrSeqRebateSic = rebate.NrSeqRebateSic }, 1, "NR_SEQ_CALCULO_REBATE_SIC DESC")
                .FirstOrDefault();
            var faixasCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar(new CalculoRebateFaixaSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            var proporcoesCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar(new CalculoRebateProporcionalSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            //REMOVENDO O GUARDACHUVA
            var guardaChuvas = Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebate.NrSeqRebateSic });
            foreach (var guardaChuva in guardaChuvas)
            {
                Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Excluir(guardaChuva);
            }
            rebate.StMatrizRebateSic = false;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculoObtido, faixasCalculo, proporcoesCalculo));
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Efetuar_Recalculo_GlobalSoma()
        {
            //Incluir_GuardaChuva_Efetuar_Recalculo(
            //    C_IBMGLobalSoma,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Efetuar_Recalculo_GlobalMedia()
        {
            //Incluir_GuardaChuva_Efetuar_Recalculo(
            //    C_IBMGlobalMedia,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Efetuar_Recalculo_Escalonado()
        {
            //Incluir_GuardaChuva_Efetuar_Recalculo(
            //    C_IBMEscalonado,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Incluir_GuardaChuva_Efetuar_Recalculo_FaixaVolume()
        {
            //Incluir_GuardaChuva_Efetuar_Recalculo(
            //    C_IBMFaixaVolume,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcoes) => false);
        }

        /*[TestMethod]
        public void Incluir_GuardaChuva_Calcular_Retroativo_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Retroativo_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Retroativo_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Incluir_GuardaChuva_Calcular_Retroativo_FaixaVolume() { Assert.Inconclusive(); }*/

        //PAGAMENTO PROPORCIONAL
        private void Pagamento_Proporcional_Calcular_Aditivo(string ibmRebate, IList<string> ibmsGC, VerificacaoAditivo condicao)
        {
            //DATA DE INICIO DO ADITIVO
            DateTime periodo = new DateTime(2014, 1, 1, 0, 0, 0);
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            //ARMAZENANDO OS CALCULOS ADITIVOS ORIGINAIS
            var calculosAditivosPeriodo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosPeriodo = calculosAditivosPeriodo.Where(r => r.DtPeriodoSic >= periodo).ToList();
            //ADICIONAR GUARDACHUVA PARA O REBATE IBMS NÃO PERTENCENTES AO REBATE E COM VOLUME PARA O PERIODO
            foreach (var ibm in ibmsGC)
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                    .Incluir(new MatrizfilialrebateSic
                    {
                        NrIbmFilialSic = ibm,
                        NrSeqRebatematrizSic = rebate.NrSeqRebateSic,
                        NrCdfornecedorFilialSic = ibm
                    });
            }
            rebate.StMatrizRebateSic = true;
            rebate.StPagamentoProporcional = true;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER CALCULO DO ATIVIDO
            Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                .CalcularAditivo(rebate, periodo);
            //ADITIVOS OBTIDOS
            var calculosAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosObtidos = calculosAditivosObtidos.Where(r => !calculosAditivosPeriodo.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var faixasAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar();
            faixasAditivosObtidos = faixasAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var proporcoesAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar();
            proporcoesAditivosObtidos = proporcoesAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            //REMOVENDO O GUARDACHUVA
            var guardaChuvas = Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebate.NrSeqRebateSic });
            foreach (var guardaChuva in guardaChuvas)
            {
                Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Excluir(guardaChuva);
            }
            rebate.StMatrizRebateSic = false;
            rebate.StPagamentoProporcional = false;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculosAditivosObtidos, faixasAditivosObtidos, proporcoesAditivosObtidos));
        }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Aditivo_GlobalSoma()
        {
            //Pagamento_Proporcional_Calcular_Aditivo(
            //    C_IBMGLobalSoma,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculos, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Aditivo_GlobalMedia()
        {
            //Pagamento_Proporcional_Calcular_Aditivo(
            //        C_IBMGlobalMedia,
            //        new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //        (calculos, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Aditivo_Escalonado()
        {
            //Pagamento_Proporcional_Calcular_Aditivo(
            //        C_IBMEscalonado,
            //        new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //        (calculos, faixas, proporcoes) =>
            //        {
            //            return calculos.Count >= 1 &&
            //                calculos[0].DtPeriodoSic == new DateTime(2014, 4, 1, 0, 0, 0) &&
            //                calculos[0].VlBonificacaoTotalSic == 210000M &&
            //                proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[0].NrSeqCalculoRebateSic).Count() == 4;
            //        });
        }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Aditivo_FaixaVolume()
        {
            //Pagamento_Proporcional_Calcular_Aditivo(
            //    C_IBMFaixaVolume,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculos, faixas, proporcoes) =>
            //    {
            //        return
            //           calculos.Count >= 7 && //DEVE HAVER AO MENOS 7 CALCULOS CONSIDERANDO A DATA DE ESCRITA DO TESTE (2014/08/12)
            //           calculos[0].DtPeriodoSic == new DateTime(2014, 1, 1) && calculos[0].VlBonificacaoTotalSic == 30212M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[0].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O PRIMEIRO RESULTADO ESPERADO, PARA O PRIMEIRO TRIMESTRE, DEVE SER DE 30212
            //           calculos[1].DtPeriodoSic == new DateTime(2014, 2, 1) && calculos[1].VlBonificacaoTotalSic == 34060M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[1].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O SEGUNGO RESULTADO ESPERADO, PARA O SEGUNDO TRIMESTRE, DEVE SER DE 34060
            //           calculos[2].DtPeriodoSic == new DateTime(2014, 3, 1) && calculos[2].VlBonificacaoTotalSic == 34320M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[2].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O TERCEIRO RESULTADO ESPERADO, PARA O TERCEIRO TRIMESTRE, DEVE SER DE 34320
            //           calculos[3].DtPeriodoSic == new DateTime(2014, 4, 1) && calculos[3].VlBonificacaoTotalSic == 28860M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[3].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O QUARTO RESULTADO ESPERADO, PARA O QUARTO TRIMESTRE, DEVE SER DE 28860
            //           calculos[4].DtPeriodoSic == new DateTime(2014, 5, 1) && calculos[4].VlBonificacaoTotalSic == 30160M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[4].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O QUINTO RESULTADO ESPERADO, PARA O QUINTO TRIMESTRE, DEVE SER DE 30160
            //           calculos[5].DtPeriodoSic == new DateTime(2014, 6, 1) && calculos[5].VlBonificacaoTotalSic == 28080M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[5].NrSeqCalculoRebateSic).Count() == 4 && //SOMADOS OS VOLUMES, O SEXTO RESULTADO ESPERADO, PARA O SEXTO TRIMESTRE, DEVE SER DE 28080
            //           calculos[6].DtPeriodoSic == new DateTime(2014, 7, 1) && calculos[6].VlBonificacaoTotalSic == 33800M && proporcoes.Where(r => r.NrSeqCalculoRebateSic == calculos[6].NrSeqCalculoRebateSic).Count() == 4;   //SOMADOS OS VOLUMES, O SETIMO RESULTADO ESPERADO, PARA O SÉTIMO TRIMESTRE, DEVE SER DE 33800
            //    });
        }

        private void Pagamento_Proporcional_Efetuar_Recalculo(string ibmRebate, IList<string> ibmsGC, VerificacaoRecalculo condicao)
        {
            //DATA DE INICIO DO ADITIVO
            DateTime periodo = new DateTime(2014, 1, 1, 0, 0, 0);
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            //ADICIONAR GUARDACHUVA PARA O REBATE IBMS NÃO PERTENCENTES AO REBATE E COM VOLUME PARA O PERIODO
            foreach (var ibm in ibmsGC)
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                    .Incluir(new MatrizfilialrebateSic
                    {
                        NrIbmFilialSic = ibm,
                        NrSeqRebatematrizSic = rebate.NrSeqRebateSic,
                        NrCdfornecedorFilialSic = ibm
                    });
            }
            rebate.StMatrizRebateSic = true;
            rebate.StPagamentoProporcional = true;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER RECALCULO
            Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                .RecalcularUltimoPeriodo(rebate); //O REBATE PRECISA TER VENCIDO DENTRO DE UMA DATA CONTROLADA PARA QUE SE SAIBA QUAL O ÚLTIMO PERÍODO
            //ADITIVOS OBTIDOS
            var calculoObtido = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic { NrSeqRebateSic = rebate.NrSeqRebateSic }, 1, "NR_SEQ_CALCULO_REBATE_SIC DESC")
                .FirstOrDefault();
            var faixasCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar(new CalculoRebateFaixaSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            var proporcoesCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar(new CalculoRebateProporcionalSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            //REMOVENDO O GUARDACHUVA
            var guardaChuvas = Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Selecionar(new MatrizfilialrebateSic { NrSeqRebatematrizSic = rebate.NrSeqRebateSic });
            foreach (var guardaChuva in guardaChuvas)
            {
                Factory
                .CreateFactoryInstance()
                .CreateInstance<IMatrizfilialrebateSicBLO>("MatrizfilialrebateSicBLO")
                .Excluir(guardaChuva);
            }
            rebate.StMatrizRebateSic = false;
            rebate.StPagamentoProporcional = false;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculoObtido, faixasCalculo, proporcoesCalculo));
        }
        [TestMethod]
        public void Pagamento_Proporcional_Efetuar_Recalculo_GlobalSoma()
        {
            //Pagamento_Proporcional_Efetuar_Recalculo(
            //    C_IBMGLobalSoma,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcional) => false);
        }
        [TestMethod]
        public void Pagamento_Proporcional_Efetuar_Recalculo_GlobalMedia()
        {
            //Pagamento_Proporcional_Efetuar_Recalculo(
            //    C_IBMGlobalMedia,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcional) => false);
        }
        [TestMethod]
        public void Pagamento_Proporcional_Efetuar_Recalculo_Escalonado()
        {
            //Pagamento_Proporcional_Efetuar_Recalculo(
            //    C_IBMEscalonado,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcional) => false);
        }
        [TestMethod]
        public void Pagamento_Proporcional_Efetuar_Recalculo_FaixaVolume()
        {
            //Pagamento_Proporcional_Efetuar_Recalculo(
            //    C_IBMFaixaVolume,
            //    new List<string> { C_IBMGCA, C_IBMGCB, C_IBMGCC },
            //    (calculo, faixas, proporcional) => false);
        }

        /*[TestMethod]
        public void Pagamento_Proporcional_Calcular_Retroativo_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Retroativo_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Retroativo_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Pagamento_Proporcional_Calcular_Retroativo_FaixaVolume() { Assert.Inconclusive(); }*/

        //LIMITAÇÃO POR VOLUME
        private void Vigencia_Por_Volume_Calcular_Aditivo(string ibmRebate, decimal volumeLimite, VerificacaoAditivo condicao)
        {
            //DATA DE INICIO DO ADITIVO
            DateTime periodo = new DateTime(2014, 1, 1, 0, 0, 0);
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            //ARMAZENANDO OS CALCULOS ADITIVOS ORIGINAIS
            var calculosAditivosPeriodo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosPeriodo = calculosAditivosPeriodo.Where(r => r.DtPeriodoSic >= periodo).ToList();
            //ALTERA REBATE PARA CONTROLAR VOLUME
            rebate.StControlevolume = true;
            rebate.VlVolumelimiteRebateSic = volumeLimite;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER CALCULO DO ATIVIDO
            try
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                    .CalcularAditivo(rebate, periodo);
            }
            catch { }
            //ADITIVOS OBTIDOS
            var calculosAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    StAditivoSic = true,
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                });
            calculosAditivosObtidos = calculosAditivosObtidos.Where(r => !calculosAditivosPeriodo.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var faixasAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar();
            faixasAditivosObtidos = faixasAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            var proporcoesAditivosObtidos = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar();
            proporcoesAditivosObtidos = proporcoesAditivosObtidos.Where(r => calculosAditivosObtidos.Any(ir => ir.NrSeqCalculoRebateSic == r.NrSeqCalculoRebateSic)).ToList();
            //REMOVENDO O CONTROLE DE VOLUME DO REBATE
            rebate.StControlevolume = false;
            rebate.VlVolumelimiteRebateSic = null;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculosAditivosObtidos, faixasAditivosObtidos, proporcoesAditivosObtidos));
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Para_Atingir_Volume_GlobalSoma()
        {
            //Vigencia_Por_Volume_Calcular_Aditivo(
            //    C_IBMGLobalSoma,
            //    1M,
            //    (calculos, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Para_Atingir_Volume_GlobalMedia()
        {
            //Vigencia_Por_Volume_Calcular_Aditivo(
            //    C_IBMGlobalMedia,
            //    1M,
            //    (calculos, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Para_Atingir_Volume_Escalonado()
        {
            //Vigencia_Por_Volume_Calcular_Aditivo(
            //    C_IBMEscalonado,
            //    871000M,
            //    (calculos, faixas, proporcoes) => false);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Para_Atingir_Volume_FaixaVolume()
        {
            //Vigencia_Por_Volume_Calcular_Aditivo(
            //    C_IBMFaixaVolume,
            //    1M,
            //    (calculos, faixas, proporcoes) => false);
        }

        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Atingiu_Volume_Volume_GlobalSoma()
        {
            Vigencia_Por_Volume_Calcular_Aditivo(
                C_IBMGLobalSoma,
                1M,
                (calculos, faixas, proporcoes) => calculos == null || calculos.Count <= 0);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Atingiu_Volume_Volume_GlobalMedia()
        {
            Vigencia_Por_Volume_Calcular_Aditivo(
                C_IBMGlobalMedia,
                1M,
                 (calculos, faixas, proporcoes) => calculos == null || calculos.Count <= 0);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Atingiu_Volume_Volume_Escalonado()
        {
            //Vigencia_Por_Volume_Calcular_Aditivo(
            //    C_IBMEscalonado,
            //    1M,
            //    (calculos, faixas, proporcoes) => calculos == null || calculos.Count <= 0);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Aditivo_Atingiu_Volume_Volume_FaixaVolume()
        {
            Vigencia_Por_Volume_Calcular_Aditivo(
                C_IBMFaixaVolume,
                1M,
                 (calculos, faixas, proporcoes) => calculos == null || calculos.Count <= 0);
        }

        private void Vigencia_Por_Volume_Efetuar_Recalculo(string ibmRebate, decimal volumeLimite, VerificacaoRecalculo condicao)
        {
            //IDENTIFICAR UM REBATE
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibmRebate });
            //ALTERA REBATE PARA CONTROLAR VOLUME
            rebate.StControlevolume = true;
            rebate.VlVolumelimiteRebateSic = volumeLimite;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);
            //FAZER RECALCULO
            try
            {
                Factory
                    .CreateFactoryInstance()
                    .CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                    .RecalcularUltimoPeriodo(rebate);
            }
            catch { }
            //CALCULOS
            var calculoObtido = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic { NrSeqRebateSic = rebate.NrSeqRebateSic }, 1, "NR_SEQ_CALCULO_REBATE_SIC DESC")
                .FirstOrDefault();
            var faixasCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateFaixaSicBLO>("CalculoRebateFaixaSicBLO")
                .Selecionar(new CalculoRebateFaixaSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            var proporcoesCalculo = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateProporcionalSicBLO>("CalculoRebateProporcionalSicBLO")
                .Selecionar(new CalculoRebateProporcionalSic { NrSeqCalculoRebateSic = calculoObtido.NrSeqCalculoRebateSic });
            //VOLTA O REBATE PARA O CALCULO ORIGINAL
            rebate.StControlevolume = false;
            rebate.VlVolumelimiteRebateSic = null;
            Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .Atualizar(rebate);

            Assert.IsTrue(condicao(calculoObtido, faixasCalculo, proporcoesCalculo));
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Para_Atingir_Volume_GlobalSoma()
        {
            Vigencia_Por_Volume_Efetuar_Recalculo(
                C_IBMGLobalSoma,
                1M,
                (calculo, faixas, proporcoes) => calculo != null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Para_Atingir_Volume_GlobalMedia()
        {
            Vigencia_Por_Volume_Efetuar_Recalculo(
                    C_IBMGlobalMedia,
                    1M,
                     (calculo, faixas, proporcoes) => calculo != null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Para_Atingir_Volume_Escalonado()
        {
            //Vigencia_Por_Volume_Efetuar_Recalculo(
            //    C_IBMEscalonado,
            //    1M,
            //    (calculo, faixas, proporcoes) => calculo != null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Para_Atingir_Volume_FaixaVolume()
        {
            Vigencia_Por_Volume_Efetuar_Recalculo(
                C_IBMFaixaVolume,
                1M,
                (calculo, faixas, proporcoes) => calculo != null);
        }

        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Atingiu_Volume_Volume_GlobalSoma()
        {
            //Vigencia_Por_Volume_Efetuar_Recalculo(
            //    C_IBMGLobalSoma,
            //    1M,
            //    (calculo, faixas, proporcoes) => calculo == null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Atingiu_Volume_Volume_GlobalMedia()
        {
            //Vigencia_Por_Volume_Efetuar_Recalculo(
            //        C_IBMGlobalMedia,
            //        1M,
            //         (calculo, faixas, proporcoes) => calculo == null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Atingiu_Volume_Volume_Escalonado()
        {
            //Vigencia_Por_Volume_Efetuar_Recalculo(
            //    C_IBMEscalonado,
            //    1M,
            //    (calculo, faixas, proporcoes) => calculo == null);
        }
        [TestMethod]
        public void Vigencia_Por_Volume_Efetuar_Recalculo_Atingiu_Volume_Volume_FaixaVolume()
        {
            //Vigencia_Por_Volume_Efetuar_Recalculo(
            //    C_IBMFaixaVolume,
            //    1M,
            //    (calculo, faixas, proporcoes) => calculo == null);
        }

        /*[TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Para_Atingir_Volume_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Para_Atingir_Volume_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Para_Atingir_Volume_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Para_Atingir_Volume_FaixaVolume() { Assert.Inconclusive(); }

        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Atingiu_Volume_Volume_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Atingiu_Volume_Volume_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Atingiu_Volume_Volume_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Vigencia_Por_Volume_Calcular_Retroativo_Atingiu_Volume_Volume_FaixaVolume() { Assert.Inconclusive(); }*/

        //Alteração Faixa
        /*[TestMethod]
        public void Alteracao_Faixa_Calcular_Aditivo_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Aditivo_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Aditivo_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Aditivo_FaixaVolume() { Assert.Inconclusive(); }

        [TestMethod]
        public void Alteracao_Faixa_Efetuar_Recalculo_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Efetuar_Recalculo_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Efetuar_Recalculo_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Efetuar_Recalculo_FaixaVolume() { Assert.Inconclusive(); }

        [TestMethod]
        public void Alteracao_Faixa_Calcular_Retroativo_GlobalSoma() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Retroativo_GlobalMedia() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Retroativo_Escalonado() { Assert.Inconclusive(); }
        [TestMethod]
        public void Alteracao_Faixa_Calcular_Retroativo_FaixaVolume() { Assert.Inconclusive(); }*/
    }
}
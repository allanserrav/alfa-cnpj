using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Configuration;
using COSAN.Framework.Util;
using System.Diagnostics;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<< Inicio Job >>>");
            //Formata a cultura
            CultureInfo culture = null;
            try
            {
                Console.WriteLine("<<< Cultura >>>");
                culture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no arquivo de configuração: Verifique se a chave DefaultCulture existe ou representa uma cultura inválida." + ex.Message);
                LogError.Debug("Erro no arquivo de configuração: Verifique se a chave DefaultCulture existe ou representa uma cultura inválida." + ex.Message);
                Environment.Exit(0);
            }


            //Geracao de arquivos SAP
            try
            {
                Console.WriteLine("<<< Gerar Arquivo SAP >>>");
                IGeradorArquivoSapBLO geradorArquivoSapBLO = Factory.CreateFactoryInstance().CreateInstance<IGeradorArquivoSapBLO>("GeradorArquivoSapBLO");
                geradorArquivoSapBLO.ProcessarServico(ConfigurationManager.AppSettings["DiretorioArquivos"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no processamento do Serviço de Geração de Arquivos SAP" + ex.Message);
                Console.WriteLine("");
                LogError.Debug("Erro no processamento do Serviço de Geração de Arquivos SAP" + ex.Message);            
            }



            //Processamento do Reajuste Rebate
            try
            {
                Console.WriteLine("<<< Processamento Reajuste >>>");
                IReajusteBonificacaoBLO reajusteBonificacaoBLO = Factory.CreateFactoryInstance().CreateInstance<IReajusteBonificacaoBLO>("ReajusteBonificacaoBLO");
                reajusteBonificacaoBLO.ProcessarServico();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no processamento do Serviço de reajuste do Rebate" + ex.Message);
                Console.WriteLine("");
                LogError.Debug("Erro no processamento do Serviço de reajuste do Rebate" + ex.Message);
                Environment.Exit(0);
            }



            //Processamento Busca de Dados x Cálculo
            try
            {

                #region Log Inicio
                Stopwatch sw = null;
                Console.WriteLine(">>>> Iniciando Serviço Busca de dados Rebate/Calculo Rebate...");
                Console.WriteLine("");
                sw = new Stopwatch();
                sw.Start();
                #endregion

                //Recuperar data atual para verificar se deve executar o serviço de cálculo
                IPeriodoProcessamentoSicBLO periodoProcessamentoSicBLO = Factory.CreateFactoryInstance().CreateInstance<IPeriodoProcessamentoSicBLO>("PeriodoProcessamentoSicBLO");
                IList<PeriodoProcessamentoSic> periodos = periodoProcessamentoSicBLO.Selecionar();
                periodos = periodos.Where(p => p.NrSeqTiporebateSic.HasValue).ToList();
                int? diaCalculo = periodos.Min(p => p.NrDiaInicioCalculoSic);

                //Se for teste, não considera datas da base                
                if (RebateUtil.TesteSistema())
                    diaCalculo = RebateUtil.GetDataAtual().Day;

                if (diaCalculo != null && diaCalculo == RebateUtil.GetDataAtual().Day)
                {
                    ICalculoBonificacaoRebateBLO calculoBonificacaoRebateBLO = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
                    calculoBonificacaoRebateBLO.ProcessarServico();
                }

                #region Log Fim
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                string tempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine(">> Finalizando Serviço Busca de dados Rebate/Calculo Rebate: " + tempo);
                Console.WriteLine("");
                #endregion

            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro no processamento na Busca de dados Rebate/Calculo Rebate | {0} | {1} ", ex.Message, ex.StackTrace));
                Console.WriteLine(string.Format("Erro no processamento na Busca de dados Rebate/Calculo Rebate | {0} | {1} ", ex.Message, ex.StackTrace));
                Console.WriteLine("");
                Environment.Exit(0);
            }

            // Processamento Verifica Debito Pendente
            try
            {
                #region Log Inicio
                Stopwatch sw = null;
                Console.WriteLine(">>>> Iniciando processamento Verifica Debito Pendente...");
                Console.WriteLine("");
                sw = new Stopwatch();
                sw.Start();
                #endregion

                ICalculoBonificacaoRebateBLO calculoBonificacaoRebateBLO = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
                calculoBonificacaoRebateBLO.RevalidarPendenteDebito();

                #region Log Fim
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                string tempo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine(">> Finalizando processamento Verifica Debito Pendente: " + tempo);
                Console.WriteLine("");
                #endregion

            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro no processamento Verifica Debito Pendente | {0} | {1} ", ex.Message, ex.StackTrace));
                Console.WriteLine(string.Format("Erro no processamento Verifica Debito Pendente | {0} | {1} ", ex.Message, ex.StackTrace));
                Console.WriteLine("");
                Environment.Exit(0);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace Raizen.SICCadastro.Rebate.Util
{
    /// <summary>
    /// Classe Utilitária
    /// </summary>
    public class RebateUtil
    {
        #region Metodos Publicos
        /// <summary>
        /// Recupera a lista intervalo de meses para o grupo mensal com base no mês informado
        /// </summary>
        /// <returns></returns>
        public static int[] GetListaMesesGrupoTrimestral(int mes)
        {
            int[] meses = null;


            #region switch
            switch (mes)
            {
                case 1:
                case 4:
                case 7:
                case 10:
                    meses = new int[] { 1, 4, 7, 10 }; //Azul
                    break;
                case 2:
                case 5:
                case 8:
                case 11:
                    meses = new int[] { 2, 5, 8, 11 }; //Rosa
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                    meses = new int[] { 3, 6, 9, 12 }; //Amarelo
                    break;
            }
            #endregion switch

            return meses;
        }

        /// <summary>
        /// Retorna a data máxima que deve ser considerado para a busca de volumes de clientes
        /// que foram inseridos tardiamente
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static DateTime GetFimPeriodoMaximoTrimestral(DateTime dataInicioVigencia)
        {
            int novoMes = 0;
            DateTime periodoLimite = GetDataAtual();
            int[] mesesGrupo = GetListaMesesGrupoTrimestral(dataInicioVigencia.Month);

            //Seleciona o mês limite...
            if (periodoLimite.Month == mesesGrupo.Min())
            {
                novoMes = mesesGrupo.Max();
                periodoLimite.AddYears(-1);
            }
            else if (periodoLimite.Month == mesesGrupo.Max())
                novoMes = mesesGrupo.Max();
            else
                novoMes = mesesGrupo.Where(m => m < periodoLimite.Month).ToList().Max();

            DateTime dataRetorno = new DateTime(periodoLimite.Year, novoMes, 1).AddMonths(-1);
            return new DateTime(dataRetorno.Year, dataRetorno.Month, DateTime.DaysInMonth(dataRetorno.Year, dataRetorno.Month));
        }

        /// <summary>
        /// Retorna próximo periodo do grupo trimestral
        /// </summary>
        /// <param name="dataReferencia"></param>
        /// <returns></returns>
        public static DateTime GetFimProximoPeriodoTrimestral(DateTime dataReferencia)
        {
            int proximoMes = 0;
            int anoRetorno = dataReferencia.Year;
            int[] mesesGrupo = GetListaMesesGrupoTrimestral(dataReferencia.Month);

            //Seleciona o próximo mês do grupo
            if (dataReferencia.Month == mesesGrupo.Max())
            {
                proximoMes = mesesGrupo.Min();
                anoRetorno++;
            }
            else
                proximoMes = mesesGrupo.Where(m => m > dataReferencia.Month).ToList().Min();

            DateTime dataRetorno = new DateTime(anoRetorno, proximoMes, 1).AddMonths(-1);
            return new DateTime(dataRetorno.Year, dataRetorno.Month, DateTime.DaysInMonth(dataRetorno.Year, dataRetorno.Month));
        }

        /// <summary>
        /// Retorna o periodo inicial para o calculo aditivo
        /// </summary>
        /// <param name="dataInicioVigenciaRebate"></param>
        /// <param name="dataInicioAditivo"></param>
        /// <returns></returns>
        public static DateTime GetInicioPeriodoAditivo(DateTime dataInicioVigenciaRebate, DateTime dataInicioAditivo)
        {
            int[] mesesGrupo = GetListaMesesGrupoTrimestral(dataInicioVigenciaRebate.Month);

            int mesRetorno = 0;
            int anoRetorno = dataInicioAditivo.Year;

            //Seleciona o próximo mês do grupo
            if (dataInicioAditivo.Month >= mesesGrupo.Max())
            {
                mesRetorno = mesesGrupo.Min();
                anoRetorno++;
            }   
            else
            {
                mesRetorno = mesesGrupo.Where(m => m > dataInicioAditivo.Month).ToList().Min();                
            }

            return new DateTime(anoRetorno, mesRetorno, 1);
        }

        /// <summary>
        /// Formata um código IBM para o padrão esperado na base RBC
        /// </summary>
        /// <param name="codigoIBM">Código IBM</param>
        /// <returns>Código IBM formatado</returns>
        public static string FormatarIBM(string codigoIBM)
        {
            return codigoIBM.PadLeft(10, '0');
        }

        /// <summary>
        /// Cálcula a diferença em meses entre duas datas
        /// </summary>
        /// <param name="inicio">inicio</param>
        /// <param name="fim">fim</param>
        /// <returns>dias</returns>
        public static int GetDiferencaMeses(DateTime inicio, DateTime fim)
        {
            return ((fim.Year - inicio.Year) * 12) + fim.Month - inicio.Month;
        }

        /// <summary>
        /// Cálcula a diferença em dias entre duas datas
        /// </summary>
        /// <param name="inicio">inicio</param>
        /// <param name="fim">fim</param>
        /// <returns>dias</returns>
        public static int GetDiferencaDias(DateTime inicio, DateTime fim)
        {
            return Convert.ToInt32((fim - inicio).TotalDays);
        }

        /// <summary>
        /// Retorna data atual
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDataAtual()
        {
            DateTime dataAtual = DateTime.Now;
            //Se for teste, considera a data atual com os meses retroativos do app.config
            if (TesteSistema())
            {
                dataAtual = dataAtual.AddMonths((-1) * TesteMesesRetroativo());
            }
            return dataAtual;
        }

        /// <summary>
        /// Retorna o período com base no mes atual
        /// </summary>
        /// <param name="dataAtual"></param>
        /// <returns></returns>
        public static DateTime GetPeriodoAtual()
        {
            DateTime data = new DateTime(GetDataAtual().Year, GetDataAtual().Month, 1);
            return data;
        }

        /// <summary>
        /// Retorna o fim do período
        /// </summary>
        /// <param name="dataPeriodo"></param>
        /// <returns></returns>
        public static DateTime GetFimPeriodo(DateTime dataPeriodo)
        {
            DateTime dataFimPeriodo = new DateTime(dataPeriodo.AddMonths(-1).Year, dataPeriodo.AddMonths(-1).Month, 1);
            return dataFimPeriodo;
        }

        /// <summary>
        /// Retorna o início do período trimestral
        /// </summary>
        /// <param name="dataReferencia"></param>
        /// <returns></returns>
        public static DateTime GetInicioPeriodoTrimestral(DateTime dataReferencia)
        {
            DateTime dataInicioPeriodo = new DateTime(dataReferencia.AddMonths(-3).Year, dataReferencia.AddMonths(-3).Month, 1);
            return dataInicioPeriodo;
        }

        /// <summary>
        /// Retorna o início do período trimestral
        /// </summary>
        /// <param name="dataReferencia"></param>
        /// <returns></returns>
        public static DateTime GetInicioPeriodoMensal(DateTime dataReferencia)
        {
            DateTime dataInicioPeriodo = new DateTime(dataReferencia.AddMonths(-1).Year, dataReferencia.AddMonths(-1).Month, 1);
            return dataInicioPeriodo;
        }

        /// <summary>
        /// Retorna o fim do período trimestral
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <returns></returns>
        public static DateTime GetFimPeriodoTrimestral(DateTime dataInicio)
        {
            DateTime data = dataInicio.AddMonths(2);
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }

        /// <summary>
        /// Retorna o fim do período trimestral
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <returns></returns>
        public static DateTime GetFimPeriodoMensal(DateTime dataInicio)
        {
            return new DateTime(dataInicio.Year, dataInicio.Month, DateTime.DaysInMonth(dataInicio.Year, dataInicio.Month));
        }

        /// <summary>
        /// Indica se a aplicação está em modo teste
        /// </summary>
        /// <returns></returns>
        public static bool TesteSistema()
        {
            //Se for teste, não considera datas da base
            bool testeAplicacao = false;
            bool.TryParse(ConfigurationManager.AppSettings["TesteSistema"], out testeAplicacao);
            return testeAplicacao;
        }

        /// <summary>
        /// Indica se a aplicação está em modo teste
        /// </summary>
        /// <returns></returns>
        public static int TesteMesesRetroativo()
        {
            //Se for teste, não considera datas da base
            int mesesRetroativo = 0;
            int.TryParse(ConfigurationManager.AppSettings["QtdMesesRetroativo"], out mesesRetroativo);
            return mesesRetroativo;
        }

        /// <summary>
        /// Faz uma cópia superficial do objeto.
        /// </summary>
        /// <typeparam name="T">Uma instância de objeto</typeparam>
        /// <param name="obj">Objeto a ser clonado</param>
        /// <returns>Clone do objeto</returns>
        public static T Clonar<T>(T obj) where T : new()
        {
            object o = Activator.CreateInstance<T>();
            var propriedades = obj.GetType().GetProperties();
            foreach (var propriedade in propriedades)
            {
                propriedade.SetValue(o, propriedade.GetValue(obj, null), null);
            }
            return (T)o;
        }

        public static void EscreveArquivo<T>(string path, IEnumerable<T> collection, Func<T,string> printMethod)
        {
            var lines = new List<string> { "ESCREVENDO DADOS DE  : " + collection.GetType().FullName };
            foreach (var item in collection)
            {
                lines.Add(printMethod(item));
            }

            File.WriteAllLines(path, lines.ToArray(), System.Text.Encoding.UTF8);
        }
        #endregion
    }
}

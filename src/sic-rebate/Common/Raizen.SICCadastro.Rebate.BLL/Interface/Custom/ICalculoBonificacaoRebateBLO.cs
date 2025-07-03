using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a ICalculoRebateBLO
    /// </summary>
    public interface ICalculoBonificacaoRebateBLO
    {
        #region Metodos de ICalculoRebateBLO

        #region Métodos Processamento
        /// <summary>
        /// Executar o cálculo/inserção para os rebates do periodo atual
        /// </summary>
        void ProcessarServico();

        #endregion

        #region Selecionar Débitos
        /// <summary>
        /// Busca Débitos
        /// </summary>
        /// <param name="listRebateSicTotal"></param>
        /// <param name="listCalculoRebateSic"></param>
        /// <param name="listStatusCalculoRebateHistoricoSic"></param>
        /// <returns></returns>
        void ProcessarDebitos(List<CalculoRebateSic> listCalculoRebateSic);

        #endregion

        /// <summary>
        /// Calcula a bonificação de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        void RecalcularUltimoPeriodo(RebateSic rebateSic, string url = null, string login = null);

        /// <summary>
        /// Executa o calculo retroativo de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        void CalcularRetroativo(RebateSic rebateSic, string url = null, string login = null);

        /// <summary>
        /// Executa o cálculo aditivo
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="dataInicioAditivo"></param>
        void CalcularAditivo(RebateSic rebateSic, DateTime dataInicioAditivo, string url = null, string login = null);

        void RevalidarPendenteDebito();

        /// <summary>
        /// Executa o cálculo acerto de um rebate
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="url"></param>
        /// <param name="login"></param>
        List<AcertoCalculoRebateSic> CalcularAcerto(RebateSic rebateSic, string url = null, string login = null);

        /// <summary>
        /// Executa o lançamento do cálculo de acerto de um rebate
        /// </summary>
        /// <param name="listAcertoCalculoRebateSic"></param>
        /// <param name="url"></param>
        /// <param name="login"></param>
        void LancarAcertos(List<AcertoCalculoRebateSic> listAcertoCalculoRebateSic, string url = null, string login = null);
        #endregion
    }
}

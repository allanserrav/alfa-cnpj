#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateSicDAO.cs
// Class Name	        : ICalculoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : 
//	Date of Modification    : 
//	Reason for modification : 
//	Modification Done       : 
//	Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a ICalculoRebateSicDAO
    /// </summary>
    public partial interface ICalculoRebateSicDAO
    {
        #region Metodos de ICalculoRebateSicDAO

        #region IncluirCalculoBonificacaoLista
        /// <summary>
        /// Insere na base os cálculos de bonificação para um período
        /// </summary>
        /// <param name="listVolumeCalculoRebateFaixaSic">listVolumeCalculoRebateFaixaSic</param>
        /// <param name="listCalculoRebateFaixaSic">listCalculoRebateFaixaSic</param>
        /// <param name="listCalculoRebateSic">listCalculoRebateSic</param>
        /// <param name="listStatusCalculoRebateHistoricoSic">listStatusCalculoRebateHistoricoSic</param>
        /// <param name="listSaldoRebateSic">listSaldoRebateSic</param>
        /// <param name="listDebitoRebateSic">listDebitoRebateSic</param>
        void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic, 
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic, 
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic, 
            IList<SaldoRebateSic> listSaldoRebateSic);

        void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic, 
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic, 
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic, 
            IList<SaldoRebateSic> listSaldoRebateSic,
            List<RebateSic> listRebateSicPrimeiroCalculo);

        /// <summary>
        /// Atualiza os dados do cálculo após geração dos arquivos
        /// </summary>
        /// <param name="listCalculoRebateSic">listCalculoRebateSic</param>
        /// <param name="listStatusCalculoRebateHistoricoSic">listStatusCalculoRebateHistoricoSic</param>
        /// <param name="listSaldoRebateSic">listSaldoRebateSic</param>
        /// <param name="dadosArquivoRebateSic">dadosArquivoRebateSic</param>
        void AtualizarCalculoGeracaoArquivo(IList<CalculoRebateSic> listCalculoRebateSic, IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic,
            IList<SaldoRebateSic> listSaldoRebateSic, DadosArquivoRebateSic dadosArquivoRebateSic);

        #endregion

        #region ExcluirCalculoRebatePeriodo
        /// <summary>
        /// Exclui o cálculo rebate e volumes de um periodo
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="dataPeriodoCalculo"></param>
        /// <param name="dataPeriodoVolumeInicio"></param>
        /// <param name="dataPeriodoVolumeFim"></param>
        void ExcluirCalculoPeriodo(RebateSic rebateSic, DateTime dataPeriodoCalculo, DateTime dataPeriodoVolumeInicio, DateTime dataPeriodoVolumeFim);
        #endregion

        #region SelecionarVolumeMensalFaixaPeriodo
        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        IList<BonificacaoGrid> SelecionarBonificacao(FiltroBonificacaoGrid filtro);
        #endregion

        #region SelecionarBonificacao
        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        IList<BonificacaoGrid> SelecionarRebatesSemCalculo(FiltroBonificacaoGrid filtro);
        #endregion

        #endregion ICalculoRebateSic
    }
}

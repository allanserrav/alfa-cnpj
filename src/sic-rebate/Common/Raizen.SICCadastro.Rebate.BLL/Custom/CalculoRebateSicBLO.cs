#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateSicBLO.cs
// Class Name	        : CalculoRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/08/2012
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Util;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a  CalculoRebateSicBLO
    /// </summary>
    internal partial class CalculoRebateSicBLO : ICalculoRebateSicBLO
    {
        #region Metodos Publicos

        #region Selecionar

        /// <summary>
        /// Selecionar o último registro referente aos dados de CalculoRebateSic
        /// </summary>
        /// <param name="saldoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
        /// <returns>Retorna uma instância de CalculoRebateSic</returns>
        public CalculoRebateSic SelecionarUltimo(CalculoRebateSic calculoRebateSic)
        {
            IList<CalculoRebateSic> lista = this.Selecionar(calculoRebateSic, 1, "TB_CALCULO_REBATE_SIC.NR_SEQ_CALCULO_REBATE_SIC DESC");
            if (lista.Count > 0)
                return lista[0];
            else
                return new CalculoRebateSic();
        }
        #endregion Selecionar

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
        public void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic, 
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic, 
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic, 
            IList<SaldoRebateSic> listSaldoRebateSic)
        {
            this.calculoRebateSicDAO.IncluirCalculoBonificacaoLista(
                listVolumeCalculoRebateFaixaSic, 
                listCalculoRebateFaixaSic,
                listCalculoRebateProporcionalSic,
                listCalculoRebateSic, 
                listStatusCalculoRebateHistoricoSic, 
                listSaldoRebateSic);
        }

        /// <summary>
        /// Insere na base os cálculos de bonificação para um período e atualiza rebates (primeiro calculo)
        /// </summary>
        /// <param name="listVolumeCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateSic"></param>
        /// <param name="listStatusCalculoRebateHistoricoSic"></param>
        /// <param name="listSaldoRebateSic"></param>
        /// <param name="listRebateSicPrimeiroCalculo"></param>
        public void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic, 
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic, 
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic, 
            IList<SaldoRebateSic> listSaldoRebateSic,
            List<RebateSic> listRebateSicPrimeiroCalculo)
        {
            this.calculoRebateSicDAO.IncluirCalculoBonificacaoLista(
                listVolumeCalculoRebateFaixaSic, 
                listCalculoRebateFaixaSic,
                listCalculoRebateProporcionalSic,
                listCalculoRebateSic, 
                listStatusCalculoRebateHistoricoSic, 
                listSaldoRebateSic, 
                listRebateSicPrimeiroCalculo);
        }

        /// <summary>
        /// Atualiza os dados do cálculo após geração dos arquivos
        /// </summary>
        /// <param name="listCalculoRebateSic">listCalculoRebateSic</param>
        /// <param name="listStatusCalculoRebateHistoricoSic">listStatusCalculoRebateHistoricoSic</param>
        /// <param name="listSaldoRebateSic">listSaldoRebateSic</param>
        /// <param name="dadosArquivoRebateSic">dadosArquivoRebateSic</param>
        public void AtualizarCalculoGeracaoArquivo(IList<CalculoRebateSic> listCalculoRebateSic, IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic,
            IList<SaldoRebateSic> listSaldoRebateSic, DadosArquivoRebateSic dadosArquivoRebateSic)
        {
            this.calculoRebateSicDAO.AtualizarCalculoGeracaoArquivo(listCalculoRebateSic, listStatusCalculoRebateHistoricoSic, listSaldoRebateSic, dadosArquivoRebateSic);
        }

        #endregion

        #region ExcluirCalculoRebatePeriodo
        /// <summary>
        /// Exclui o cálculo rebate e volumes de um periodo
        /// </summary>
        /// <param name="rebateSic"></param>
        public void ExcluirCalculoUltimoPeriodo(RebateSic rebateSic, DateTime dataPeriodo, DateTime dataInicio, DateTime dataFim)
        {
            //Apagar Cálculo do último período
            this.calculoRebateSicDAO.ExcluirCalculoPeriodo(rebateSic, dataPeriodo, dataInicio, dataFim);
        }
        #endregion

        #region SelecionarBonificacao
        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        public IList<BonificacaoGrid> SelecionarBonificacao(FiltroBonificacaoGrid filtro)
        {
            return this.calculoRebateSicDAO.SelecionarBonificacao(filtro);
        }
        #endregion

        #region SelecionarRetroativos
        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        public IList<BonificacaoGrid> SelecionarRebatesSemCalculo(FiltroBonificacaoGrid filtro)
        {
            return this.calculoRebateSicDAO.SelecionarRebatesSemCalculo(filtro);
        }
        #endregion

        #endregion Public Methods
    }
}


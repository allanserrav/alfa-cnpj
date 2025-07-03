using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IBuscaDadosRebateBLO
    /// </summary>
    public interface IBuscaVolumeRebateBLO
    {
        #region Metodos de IBuscaDadosRebateBLO

        #region Métodos Processamento
        /// <summary>
        /// Executar a busca/inserção de dados
        /// </summary>
        /// <param name="listRebateSic">Lista de rebates</param>
        /// <param name="listFaixaRebateSic">Lista de Faixas Rebate</param>
        void ProcessarServico(
            IList<RebateSic> listRebate, 
            IList<FaixarebateSic> listFaixaRebate,
            out IList<VolumeRbc> volumesSelecionados,
            string url = null, 
            string login = null);
        #endregion

        #region Métodos Selecionar Volume
        /// <summary>
        /// Busca os volumes de uma lista rebate e suas faixas
        /// </summary>
        /// <param name="listRebateSic">Lista rebate</param>                
        /// <param name="dataInicioPeriodo">Inicio Período</param>
        /// <param name="dataFimPeriodo">Fim Período</param>
        IList<VolumeMensalFaixaRebateSic> SelecionarVolumesListaRebate(
            IList<RebateSic> listRebateSic, 
            List<FaixarebateSic> listFaixaRebateSic,
            DateTime dataInicioPeriodo, 
            DateTime dataFimPeriodo,
            bool recalculo,
            out IList<VolumeRbc> volumesSelecionados,
            string url = null,
            string login = null);

        #endregion

        #endregion
    }
}

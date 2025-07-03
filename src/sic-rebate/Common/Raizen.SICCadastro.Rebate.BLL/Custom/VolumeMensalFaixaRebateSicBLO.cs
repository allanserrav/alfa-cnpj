using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Complemento de RebateSicBLO
    /// </summary>
    internal partial class VolumeMensalFaixaRebateSicBLO
    {
        #region Metodos Publicos
        #region Selecionar Por Grupo Mensal
        /// <summary>
        /// Seleciona em lote os dados do Volume Comprado RBC (Oracle)
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listIBM">lista de IBMs</param>
        /// <param name="listCdSapProduto">lista de códigos produto</param>
        /// <returns>Lista de VolumeRBC</returns>
        public IList<VolumeRbc> SelecionarVolumeRbc(DateTime inicio, DateTime fim, List<RebateSic> listRebateSic)
        {
            //Consistência
            if (listRebateSic == null || listRebateSic.Count == 0)
                return new List<VolumeRbc>();

            return this.volumeMensalFaixaRebateSicDAO.SelecionarVolumeRbc(
                inicio, fim, listRebateSic.Select(r => r.NrIbmRebateSic).ToList());
        }
        #endregion

        #region SelecionarVolumeMensalFaixaPeriodo
        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listFaixaRebateSic">lista de faixas rebate</param>
        /// <returns>lista de volume</returns>
        public IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodo(DateTime inicio, DateTime fim, List<FaixarebateSic> listFaixaRebateSic)
        {
            //Consistência
            if (listFaixaRebateSic == null || listFaixaRebateSic.Count == 0)
                return new List<VolumeMensalFaixaRebateSic>();

            return this.volumeMensalFaixaRebateSicDAO.SelecionarVolumeMensalFaixaPeriodo(
                inicio, fim, listFaixaRebateSic.Select(r => r.NrSeqFaixarebateSic.Value.ToString()).ToList());
        }
        #endregion

        #region SelecionarVolumeMensalFaixaPeriodo (Aditivo)
        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>        
        /// <returns>lista de volume</returns>
        public IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodoAditivo(DateTime inicio, DateTime fim, RebateSic rebateSic)
        {
            //Consistência       
            return this.volumeMensalFaixaRebateSicDAO.SelecionarVolumeMensalFaixaPeriodoAditivo(inicio, fim, rebateSic);
        }
        #endregion

        #region Incluir Lista Transação
        /// <summary>
        /// Incluir Lista de VolumeMensalFaixaRebateSic Transacionado
        /// </summary>		
        public void Incluir(List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic, List<FaixarebateSic> listFaixaRebateSic, bool checarFaixas = true)
        {
            if (listVolumeMensalFaixaRebateSic == null)
                throw (new ArgumentNullException());

            this.volumeMensalFaixaRebateSicDAO.Incluir(listVolumeMensalFaixaRebateSic, listFaixaRebateSic, checarFaixas);
        }
        #endregion Incluir

        #endregion
    }
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IVolumeMensalFaixaRebateSicDAO.cs
// Class Name	        : IVolumeMensalFaixaRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 26/10/2012
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
    /// Representa funcionalidade relacionada a IVolumeMensalFaixaRebateSicDAO
    /// </summary>
    public partial interface IVolumeMensalFaixaRebateSicDAO
    {
        #region Metodos de IVolumeMensalFaixaRebateSicDAO

        #region Selecionar Volume Comprado RBC (Oracle)
        /// <summary>
        /// Seleciona em lote os dados do Volume Comprado RBC (Oracle)
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listIBM">lista de IBMs</param>
        /// <param name="listCdSapProduto">lista de códigos produto</param>
        /// <returns>Lista de VolumeRBC</returns>
        IList<VolumeRbc> SelecionarVolumeRbc(DateTime inicio, DateTime fim, List<string> listIBM);
        #endregion

        #region SelecionarVolumeMensalFaixaPeriodo
        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <param name="listNrFaixaRebate">Lista de strings</param>
        /// <returns>Lista de Volumes</returns>
        IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodo(DateTime inicio, DateTime fim, List<string> listNrFaixaRebate);
        #endregion

        #region Incluir Lista Transação
        /// <summary>
        /// Incluir VolumeMensalFaixaRebateSic
        /// </summary>        
        void Incluir(List<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic, List<FaixarebateSic> listFaixaRebateSic, bool checarFaixas = true);
        #endregion Incluir Lista Transação

        /// <summary>
        /// Selecionar em lote os volumes do periodo para a lista de faixas rebate informada(Aditivo)
        /// </summary>
        /// <param name="inicio">data inicio</param>
        /// <param name="fim">data fim</param>
        /// <returns>Lista de Volumes</returns>
        IList<VolumeMensalFaixaRebateSic> SelecionarVolumeMensalFaixaPeriodoAditivo(DateTime inicio, DateTime fim, RebateSic rebateSic);

        #endregion IVolumeMensalFaixaRebateSicDAO
    }
}

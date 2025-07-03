#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IRebateSicDAO.cs
// Class Name	        : IRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 25/10/2012
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
using COSAN.Framework.DBUtil;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IRebateSicDAO
    /// </summary>
    public partial interface IRebateSicDAO
    {
        #region Metodos de IRebateSicDAO

        #region Selecionar Por Meses Grupo
        /// <summary>
        /// Seleciona Lista de Rebates Vigentes
        /// </summary>
        /// <param name="meses">lista de meses</param>
        /// <returns></returns>
        IList<RebateSic> SelecionarVigentes();
        #endregion Selecionar Por Meses Grupo

        #region Selecionar Rebate Reajuste
        /// <summary>
        /// Seleciona Lista de Rebates Vigentes Reajuste
        /// </summary>
        IList<RebateSic> SelecionarVigentesReajuste();
        #endregion

        #endregion IRebateSicDAO

        #region Selecionar SelecionarRebateRelatorio
        /// <summary>
        /// Seleciona Lista de Rebate Relatorio
        /// </summary>
        IList<InformacaoRebateRel> SelecionarRelatorioInformacoesRebate(InformacaoRebateRelFiltro filtro);
        #endregion

        #region AtualizarComTrasacao
        /// <summary>
        /// Atualizar RebateSic
        /// </summary>
        void AtualizarComTransacao(RebateSic rebateSic, DatabaseManager databaseManager);

        #endregion

        #region Selecionar Volume Comprado
        decimal SelecionarVolumeComprado(string IBM, DateTime? de, DateTime? ate);
        #endregion
    }
}

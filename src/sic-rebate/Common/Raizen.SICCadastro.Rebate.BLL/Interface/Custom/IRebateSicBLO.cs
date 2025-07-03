#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IRebateSicBLO.cs
// Class Name	        : IRebateSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
using System.Text;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IRebateSicBLO
    /// </summary>
    public partial interface IRebateSicBLO
    {
        #region Metodos de IRebateSicBLO

        #region Selecionar Por Grupo Mensal
        /// <summary>
        /// Seleciona Lista de Rebates Vigentes
        /// </summary>
        IList<RebateSic> SelecionarVigentes();
        #endregion

        #region Selecionar Rebate Reajuste
        /// <summary>
        /// Seleciona Lista de Rebates Vigentes Reajuste
        /// </summary>
        IList<RebateSic> SelecionarVigentesReajuste();
        #endregion

        #region Selecionar SelecionarRebateRelatorio
        /// <summary>
        /// Seleciona Lista de Rebate Relatorio
        /// </summary>
        IList<InformacaoRebateRel> SelecionarRelatorioInformacoesRebate(InformacaoRebateRelFiltro filtro);
        #endregion

        #region Selecionar Volume Comprado
        //decimal SelecionarVolumeComprado(string IBM, DateTime de, DateTime ate);
        decimal SelecionarVolumeComprado(RebateSic rebate, DateTime dataAlvo);
        #endregion

        RebateSic Selecionar(string ibm);

        #endregion IRebateSicBLO
    }
}

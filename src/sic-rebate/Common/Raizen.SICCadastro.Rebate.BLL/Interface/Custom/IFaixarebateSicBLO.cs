#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IFaixarebateSicBLO.cs
// Class Name	        : IFaixarebateSicBLO
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
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IFaixarebateSicBLO
	/// </summary>
    public partial interface IFaixarebateSicBLO
	{
		#region Metodos de IFaixarebateSicBLO 
	
        #region Selecionar Faixa Rebate Vigente
        /// <summary>
        /// Selecionar os dados de FaixarebateSic
        /// </summary>
        /// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de FaixarebateSic</returns>
        IList<FaixarebateSic> SelecionarFaixasVigentesRebate(FaixarebateSic faixarebateSic);
        #endregion

        #region Selecionar Lista de Faixas para Cálculo Aditivo
        /// <summary>
        /// Seleciona uma lista de faixa para cálculo do aditivo
        /// </summary>
        IList<FaixarebateSic> SelecionarFaixasAditivo(RebateSic rebateSic, DateTime dataInicioAditivo);
        #endregion

        #region Selecionar Faixas Vigente Lista Rebate
        /// <summary>
        /// Seleciona uma lista de faixa rebate através de umalista de rebates
        /// </summary>
        /// <param name="listRebateSic">lista de rebate</param>
        /// <returns>lista de faixas rebate</returns>
        IList<FaixarebateSic> SelecionarFaixasVigentesListaRebate(IList<RebateSic> listRebateSic);
        #endregion

        #region Selecionar Faixas Historico
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente para Aditivo
        /// </summary>
        IList<FaixarebateSic> SelecionarFaixasHistorico(int NrSeqCalculoRebateSic);
        #endregion

        IList<FaixarebateSic> Selecionar(int nrSeqRebateSic);

        #endregion IFaixarebateSicBLO
    }
}

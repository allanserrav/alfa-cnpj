#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IFaixarebateSicDAO.cs
// Class Name	        : IFaixarebateSicDAO
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
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IFaixarebateSicDAO
	/// </summary>
	public partial interface IFaixarebateSicDAO
	{
		#region Metodos de IFaixarebateSicDAO 
		
        #region Selecionar Faixa Rebate Vigente
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente
        /// </summary>
        /// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de FaixarebateSic</returns>
        IList<FaixarebateSic> SelecionarFaixasVigentesRebate(FaixarebateSic faixarebateSic);
        #endregion
		
        #region Selecionar Faixas para Aditivo
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente para Aditivo
        /// </summary>
        IList<FaixarebateSic> SelecionarFaixasAditivo(RebateSic rebateSic, DateTime dataInicioAditivo);
        #endregion

        #region Selecionar Faixas Historico
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente para Aditivo
        /// </summary>
        IList<FaixarebateSic> SelecionarFaixasHistorico(int NrSeqCalculoRebateSic);
        #endregion


		#endregion IFaixarebateSicDAO
	}
}

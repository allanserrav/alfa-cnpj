#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IRebateSicDAO.cs
// Class Name	        : IRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 25/07/2014
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
	/// Representa funcionalidade relacionada a IRebateSicDAO
	/// </summary>
	public partial interface IRebateSicDAO
	{
		#region Metodos de IRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de RebateSic</returns>
		IList<RebateSic> Selecionar(RebateSic rebateSic, int numeroLinhas, string ordem);

        #endregion Selecionar

        #region Incluir
        /// <summary>
        /// Incluir RebateSic
        /// </summary>
        /// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
        void Incluir(RebateSic rebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		void Atualizar(RebateSic rebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui rebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		void Excluir(RebateSic rebateSic);
        #endregion Excluir

        #region ObterIbmPeloRebate
        /// <summary>
        /// ObterIbmPeloRebate
        /// </summary>
        /// <param name="nrSeqRebate"></param>
        /// <returns></returns>
        string ObterIbmPeloRebate(int nrSeqRebate);

        /// <summary>
        /// ObterParametroSic
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        string ObterParametroSic(string chave);

        #endregion #region ObterIbmPeloRebate

        #endregion IRebateSicDAO
    }
}

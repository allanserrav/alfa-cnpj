#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IVolumeMensalFaixaRebateSicDAO.cs
// Class Name	        : IVolumeMensalFaixaRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 28/01/2013
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
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		IList<VolumeMensalFaixaRebateSic> Selecionar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		void Incluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		void Atualizar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui volumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		void Excluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic);
		#endregion Excluir
		
		#endregion IVolumeMensalFaixaRebateSicDAO
	}
}

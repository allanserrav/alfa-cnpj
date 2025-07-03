#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ISaldoRebateSicDAO.cs
// Class Name	        : ISaldoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	/// Representa funcionalidade relacionada a ISaldoRebateSicDAO
	/// </summary>
	public partial interface ISaldoRebateSicDAO
	{
		#region Metodos de ISaldoRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		IList<SaldoRebateSic> Selecionar(SaldoRebateSic saldoRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		void Incluir(SaldoRebateSic saldoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		void Atualizar(SaldoRebateSic saldoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui saldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		void Excluir(SaldoRebateSic saldoRebateSic);
		#endregion Excluir
		
		#endregion ISaldoRebateSicDAO
	}
}

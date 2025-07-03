#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateSicDAO.cs
// Class Name	        : ICalculoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 08/08/2014
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
	/// Representa funcionalidade relacionada a ICalculoRebateSicDAO
	/// </summary>
	public partial interface ICalculoRebateSicDAO
	{
		#region Metodos de ICalculoRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		IList<CalculoRebateSic> Selecionar(CalculoRebateSic calculoRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		void Incluir(CalculoRebateSic calculoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		void Atualizar(CalculoRebateSic calculoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		void Excluir(CalculoRebateSic calculoRebateSic);
		#endregion Excluir
		
		#endregion ICalculoRebateSicDAO
	}
}

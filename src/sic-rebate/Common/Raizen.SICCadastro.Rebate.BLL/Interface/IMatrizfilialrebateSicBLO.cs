#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IMatrizfilialrebateSicBLO.cs
// Class Name	        : IMatrizfilialrebateSicBLO
// Author		        : Murilo Beltrame
// Creation Date 	    : 29/07/2014
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
	/// Representa funcionalidade relacionada a IMatrizfilialrebateSicBLO
	/// </summary>
	public interface IMatrizfilialrebateSicBLO
	{
		#region Metodos de IMatrizfilialrebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic);
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		IList<MatrizfilialrebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de MatrizfilialrebateSic</returns>
		MatrizfilialrebateSic SelecionarPrimeiro(MatrizfilialrebateSic matrizfilialrebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		void Incluir(MatrizfilialrebateSic matrizfilialrebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		void Atualizar(MatrizfilialrebateSic matrizfilialrebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui matrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		void Excluir(MatrizfilialrebateSic matrizfilialrebateSic);
		#endregion Excluir
		
		#endregion IMatrizfilialrebateSicBLO
	}
}

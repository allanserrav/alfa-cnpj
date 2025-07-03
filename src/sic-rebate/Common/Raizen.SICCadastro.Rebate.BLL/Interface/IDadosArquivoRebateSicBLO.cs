#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDadosArquivoRebateSicBLO.cs
// Class Name	        : IDadosArquivoRebateSicBLO
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 17/01/2013
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
	/// Representa funcionalidade relacionada a IDadosArquivoRebateSicBLO
	/// </summary>
	public partial interface IDadosArquivoRebateSicBLO
	{
		#region Metodos de IDadosArquivoRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic);
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		IList<DadosArquivoRebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de DadosArquivoRebateSic</returns>
		DadosArquivoRebateSic SelecionarPrimeiro(DadosArquivoRebateSic dadosArquivoRebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		void Incluir(DadosArquivoRebateSic dadosArquivoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		void Atualizar(DadosArquivoRebateSic dadosArquivoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui dadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		void Excluir(DadosArquivoRebateSic dadosArquivoRebateSic);
		#endregion Excluir
		
		#endregion IDadosArquivoRebateSicBLO
	}
}

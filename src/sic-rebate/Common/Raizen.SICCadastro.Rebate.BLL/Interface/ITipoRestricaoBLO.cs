#region Cabeçalho do Arquivo
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
	/// Representa funcionalidade relacionada a ITipoRestricaoBLO
	/// </summary>
	public partial interface ITipoRestricaoBLO
	{
		#region Metodos de ITipoRestricaoBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		IList<TipoRestricao> Selecionar(TipoRestricao tepasseSic);
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <returns>Retorna lista de TipoRestricao</returns>
		IList<TipoRestricao> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TipoRestricao</returns>
		TipoRestricao SelecionarPrimeiro(TipoRestricao tipoRestricao);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		void Incluir(TipoRestricao tipoRestricao);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		void Atualizar(TipoRestricao tipoRestricao);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		void Excluir(TipoRestricao tipoRestricao);
		#endregion Excluir
		
		#endregion ITipoRestricaoBLO
	}
}

#region Cabeçalho do Arquivo
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IRestricaoDAO
	/// </summary>
	public partial interface IRestricaoDAO
	{
		#region Metodos de IRestricaoDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <param name="Restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de Restricao</returns>
		IList<Restricao> Selecionar(Restricao restricao, int numeroLinhas, string ordem);
		IList<RestricaoTipoRestricao> SelecionarPorRestricaoId(int restricaoId, int numeroLinhas, string ordem);
		IList<RestricaoExport> SelecionarExport(int numeroLinhas, string ordem);

		#endregion Selecionar

		#region Incluir
		/// <summary>
		/// Incluir Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		void Incluir(Restricao restricao);
		void IncluirTiposRestricoes(RestricaoTipoRestricao tipoRestricao);
		#endregion Incluir

		#region Atualizar
		/// <summary>
		/// Atualiza Restricao
		/// </summary>
		/// <param name="ripoRestricao">Instance of <see cref="Restricao"/></param>
		void Atualizar(Restricao restricao);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		void Excluir(Restricao restricao);

		void ExcluirTiposRestricoes(Restricao restricao);

		#endregion Excluir

		#endregion IRestricaoDAO
	}
}

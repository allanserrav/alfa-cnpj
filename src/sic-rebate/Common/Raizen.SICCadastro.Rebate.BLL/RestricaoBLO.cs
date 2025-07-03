#region Cabeçalho do Arquivo
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  RestricaoBLO
	/// </summary>
	internal partial class RestricaoBLO : IRestricaoBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de RestricaoDAO 
		/// </summary>
		private readonly IRestricaoDAO restricaoDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public RestricaoBLO()
		{
			this.restricaoDAO = Factory.CreateFactoryInstance().CreateInstance<IRestricaoDAO>("RestricaoDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <param name="restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de Restricao</returns>
		public IList<Restricao> Selecionar(Restricao restricao, int numeroLinhas, string ordem)
		{
			return this.restricaoDAO.Selecionar(restricao, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <param name="restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de Restricao</returns>
		public IList<Restricao> Selecionar(Restricao restricao, string ordem)
		{
			return this.Selecionar(restricao, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <param name="restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <returns>Retorna lista de Restricao</returns>
		public IList<Restricao> Selecionar(Restricao restricao)
		{
			return this.Selecionar(restricao, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <returns>Retorna lista de Restricao</returns>
		public IList<Restricao> Selecionar()
		{
			return this.Selecionar(new Restricao(), 0, String.Empty);
		}

		public IList<RestricaoTipoRestricao> SelecionarPorRestricaoId(int restricaoId)
		{
			return this.restricaoDAO.SelecionarPorRestricaoId(restricaoId, 0, String.Empty);
		}

		public IList<RestricaoExport> SelecionarExport()
		{
			return this.restricaoDAO.SelecionarExport(0, String.Empty);
		}
		


		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de Restricao
		/// </summary>
		/// <param name="restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de Restricao</returns>
		public Restricao SelecionarPrimeiro(Restricao restricao)
		{
			IList<Restricao> lista = this.Selecionar(restricao, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new Restricao();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Incluir(Restricao restricao)
		{
			if (null == restricao) throw (new ArgumentNullException());
			this.restricaoDAO.Incluir(restricao);
		}

		public void IncluirTiposRestricoes(RestricaoTipoRestricao tipoRestricao)
		{
			if (null == tipoRestricao) throw (new ArgumentNullException());
			this.restricaoDAO.IncluirTiposRestricoes(tipoRestricao);
		}
		#endregion Incluir

		#region Atualizar
		/// <summary>
		/// Atualizar Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Atualizar(Restricao restricao)
		{
			if (null == restricao) throw (new ArgumentNullException());
			this.restricaoDAO.Atualizar(restricao);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Excluir(Restricao restricao)
		{
			if (null == restricao) throw (new ArgumentNullException());
			this.restricaoDAO.ExcluirTiposRestricoes(restricao);
			this.restricaoDAO.Excluir(restricao);

		}

		public void ExcluirTiposRestricoes(Restricao restricao)
		{
			if (null == restricao) throw (new ArgumentNullException());
			this.restricaoDAO.ExcluirTiposRestricoes(restricao);
		}
		#endregion Excluir

		#endregion Public Methods
	}
}


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
	/// Representa funcionalidade relacionada a  TipoRestricaoBLO
	/// </summary>
	internal partial class TipoRestricaoBLO : ITipoRestricaoBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de TipoRestricaoDAO 
		/// </summary>
		private readonly ITipoRestricaoDAO tipoRestricaoDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public TipoRestricaoBLO()
		{
			this.tipoRestricaoDAO = Factory.CreateFactoryInstance().CreateInstance<ITipoRestricaoDAO>("TipoRestricaoDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		public IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao, int numeroLinhas, string ordem)
		{
			return this.tipoRestricaoDAO.Selecionar(tipoRestricao, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		public IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao, string ordem)
		{
			return this.Selecionar(tipoRestricao, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		public IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao)
		{
			return this.Selecionar(tipoRestricao, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <returns>Retorna lista de TipoRestricao</returns>
		public IList<TipoRestricao> Selecionar()
		{
			return this.Selecionar(new TipoRestricao(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TipoRestricao</returns>
		public TipoRestricao SelecionarPrimeiro(TipoRestricao tipoRestricao)
		{
			IList<TipoRestricao> lista = this.Selecionar(tipoRestricao, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new TipoRestricao();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Incluir(TipoRestricao tipoRestricao)
		{
			if (null == tipoRestricao) throw (new ArgumentNullException());
			this.tipoRestricaoDAO.Incluir(tipoRestricao);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Atualizar(TipoRestricao tipoRestricao)
		{
			if (null == tipoRestricao) throw (new ArgumentNullException());
			this.tipoRestricaoDAO.Atualizar(tipoRestricao);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir tipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Excluir(TipoRestricao tipoRestricao)
		{
			if (null == tipoRestricao) throw (new ArgumentNullException());
			this.tipoRestricaoDAO.Excluir(tipoRestricao);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


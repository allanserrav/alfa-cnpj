#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TiporebateSicBLO.cs
// Class Name	        : TiporebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/05/2012
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
	/// Representa funcionalidade relacionada a  TiporebateSicBLO
	/// </summary>
	internal partial class TiporebateSicBLO : ITiporebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de TiporebateSicDAO 
		/// </summary>
		private readonly ITiporebateSicDAO tiporebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public TiporebateSicBLO()
		{
			this.tiporebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicDAO>("TiporebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		public IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic, int numeroLinhas, string ordem)
		{
			return this.tiporebateSicDAO.Selecionar(tiporebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		public IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic, string ordem)
		{
			return this.Selecionar(tiporebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		public IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic)
		{
			return this.Selecionar(tiporebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <returns>Retorna lista de TiporebateSic</returns>
		public IList<TiporebateSic> Selecionar()
		{
			return this.Selecionar(new TiporebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TiporebateSic</returns>
		public TiporebateSic SelecionarPrimeiro(TiporebateSic tiporebateSic)
		{
			IList<TiporebateSic> lista = this.Selecionar(tiporebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new TiporebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Incluir(TiporebateSic tiporebateSic)
		{
			if (null == tiporebateSic) throw (new ArgumentNullException());
			this.tiporebateSicDAO.Incluir(tiporebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Atualizar(TiporebateSic tiporebateSic)
		{
			if (null == tiporebateSic) throw (new ArgumentNullException());
			this.tiporebateSicDAO.Atualizar(tiporebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir tiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Excluir(TiporebateSic tiporebateSic)
		{
			if (null == tiporebateSic) throw (new ArgumentNullException());
			this.tiporebateSicDAO.Excluir(tiporebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


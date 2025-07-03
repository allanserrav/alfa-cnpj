#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : RebateSicBLO.cs
// Class Name	        : RebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 07/25/2014
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
	/// Representa funcionalidade relacionada a  RebateSicBLO
	/// </summary>
	internal partial class RebateSicBLO : IRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de RebateSicDAO 
		/// </summary>
		private readonly IRebateSicDAO rebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public RebateSicBLO()
		{
			this.rebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IRebateSicDAO>("RebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de RebateSic</returns>
		public IList<RebateSic> Selecionar(RebateSic rebateSic, int numeroLinhas, string ordem)
		{
			return this.rebateSicDAO.Selecionar(rebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de RebateSic</returns>
		public IList<RebateSic> Selecionar(RebateSic rebateSic, string ordem)
		{
			return this.Selecionar(rebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de RebateSic</returns>
		public IList<RebateSic> Selecionar(RebateSic rebateSic)
		{
			return this.Selecionar(rebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <returns>Retorna lista de RebateSic</returns>
		public IList<RebateSic> Selecionar()
		{
			return this.Selecionar(new RebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de RebateSic</returns>
		public RebateSic SelecionarPrimeiro(RebateSic rebateSic)
		{
			IList<RebateSic> lista = this.Selecionar(rebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new RebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Incluir(RebateSic rebateSic)
		{
			if (null == rebateSic) throw (new ArgumentNullException());
			this.rebateSicDAO.Incluir(rebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Atualizar(RebateSic rebateSic)
		{
			if (null == rebateSic) throw (new ArgumentNullException());
			this.rebateSicDAO.Atualizar(rebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir rebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Excluir(RebateSic rebateSic)
		{
			if (null == rebateSic) throw (new ArgumentNullException());
			this.rebateSicDAO.Excluir(rebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


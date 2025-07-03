#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteSicBLO.cs
// Class Name	        : ReajusteSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/08/2013
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
	/// Representa funcionalidade relacionada a  ReajusteSicBLO
	/// </summary>
	internal partial class ReajusteSicBLO : IReajusteSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ReajusteSicDAO 
		/// </summary>
		private readonly IReajusteSicDAO reajusteSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ReajusteSicBLO()
		{
			this.reajusteSicDAO = Factory.CreateFactoryInstance().CreateInstance<IReajusteSicDAO>("ReajusteSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		public IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic, int numeroLinhas, string ordem)
		{
			return this.reajusteSicDAO.Selecionar(reajusteSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		public IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic, string ordem)
		{
			return this.Selecionar(reajusteSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		public IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic)
		{
			return this.Selecionar(reajusteSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteSic</returns>
		public IList<ReajusteSic> Selecionar()
		{
			return this.Selecionar(new ReajusteSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteSic</returns>
		public ReajusteSic SelecionarPrimeiro(ReajusteSic reajusteSic)
		{
			IList<ReajusteSic> lista = this.Selecionar(reajusteSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ReajusteSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Incluir(ReajusteSic reajusteSic)
		{
			if (null == reajusteSic) throw (new ArgumentNullException());
			this.reajusteSicDAO.Incluir(reajusteSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Atualizar(ReajusteSic reajusteSic)
		{
			if (null == reajusteSic) throw (new ArgumentNullException());
			this.reajusteSicDAO.Atualizar(reajusteSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir reajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Excluir(ReajusteSic reajusteSic)
		{
			if (null == reajusteSic) throw (new ArgumentNullException());
			this.reajusteSicDAO.Excluir(reajusteSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


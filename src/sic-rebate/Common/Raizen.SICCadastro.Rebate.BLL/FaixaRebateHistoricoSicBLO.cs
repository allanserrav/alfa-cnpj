#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : FaixaRebateHistoricoSicBLO.cs
// Class Name	        : FaixaRebateHistoricoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/08/2012
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
	/// Representa funcionalidade relacionada a  FaixaRebateHistoricoSicBLO
	/// </summary>
	internal partial class FaixaRebateHistoricoSicBLO : IFaixaRebateHistoricoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de FaixaRebateHistoricoSicDAO 
		/// </summary>
		private readonly IFaixaRebateHistoricoSicDAO faixaRebateHistoricoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public FaixaRebateHistoricoSicBLO()
		{
			this.faixaRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IFaixaRebateHistoricoSicDAO>("FaixaRebateHistoricoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		public IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			return this.faixaRebateHistoricoSicDAO.Selecionar(faixaRebateHistoricoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		public IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, string ordem)
		{
			return this.Selecionar(faixaRebateHistoricoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		public IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			return this.Selecionar(faixaRebateHistoricoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		public IList<FaixaRebateHistoricoSic> Selecionar()
		{
			return this.Selecionar(new FaixaRebateHistoricoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de FaixaRebateHistoricoSic</returns>
		public FaixaRebateHistoricoSic SelecionarPrimeiro(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			IList<FaixaRebateHistoricoSic> lista = this.Selecionar(faixaRebateHistoricoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new FaixaRebateHistoricoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Incluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			if (null == faixaRebateHistoricoSic) throw (new ArgumentNullException());
			this.faixaRebateHistoricoSicDAO.Incluir(faixaRebateHistoricoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Atualizar(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			if (null == faixaRebateHistoricoSic) throw (new ArgumentNullException());
			this.faixaRebateHistoricoSicDAO.Atualizar(faixaRebateHistoricoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir faixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Excluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			if (null == faixaRebateHistoricoSic) throw (new ArgumentNullException());
			this.faixaRebateHistoricoSicDAO.Excluir(faixaRebateHistoricoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


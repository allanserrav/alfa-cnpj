#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : PeriodoProcessamentoSicBLO.cs
// Class Name	        : PeriodoProcessamentoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/18/2013
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
	/// Representa funcionalidade relacionada a  PeriodoProcessamentoSicBLO
	/// </summary>
	internal partial class PeriodoProcessamentoSicBLO : IPeriodoProcessamentoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de PeriodoProcessamentoSicDAO 
		/// </summary>
		private readonly IPeriodoProcessamentoSicDAO periodoProcessamentoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public PeriodoProcessamentoSicBLO()
		{
			this.periodoProcessamentoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IPeriodoProcessamentoSicDAO>("PeriodoProcessamentoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		public IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, int numeroLinhas, string ordem)
		{
			return this.periodoProcessamentoSicDAO.Selecionar(periodoProcessamentoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		public IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, string ordem)
		{
			return this.Selecionar(periodoProcessamentoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		public IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			return this.Selecionar(periodoProcessamentoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		public IList<PeriodoProcessamentoSic> Selecionar()
		{
			return this.Selecionar(new PeriodoProcessamentoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de PeriodoProcessamentoSic</returns>
		public PeriodoProcessamentoSic SelecionarPrimeiro(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			IList<PeriodoProcessamentoSic> lista = this.Selecionar(periodoProcessamentoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new PeriodoProcessamentoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Incluir(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			if (null == periodoProcessamentoSic) throw (new ArgumentNullException());
			this.periodoProcessamentoSicDAO.Incluir(periodoProcessamentoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Atualizar(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			if (null == periodoProcessamentoSic) throw (new ArgumentNullException());
			this.periodoProcessamentoSicDAO.Atualizar(periodoProcessamentoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir periodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Excluir(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			if (null == periodoProcessamentoSic) throw (new ArgumentNullException());
			this.periodoProcessamentoSicDAO.Excluir(periodoProcessamentoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


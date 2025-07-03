#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IgpmPeriodoSicBLO.cs
// Class Name	        : IgpmPeriodoSicBLO
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
	/// Representa funcionalidade relacionada a  IgpmPeriodoSicBLO
	/// </summary>
	internal partial class IgpmPeriodoSicBLO : IIgpmPeriodoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de IgpmPeriodoSicDAO 
		/// </summary>
		private readonly IIgpmPeriodoSicDAO igpmPeriodoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public IgpmPeriodoSicBLO()
		{
			this.igpmPeriodoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IIgpmPeriodoSicDAO>("IgpmPeriodoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		public IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, int numeroLinhas, string ordem)
		{
			return this.igpmPeriodoSicDAO.Selecionar(igpmPeriodoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		public IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, string ordem)
		{
			return this.Selecionar(igpmPeriodoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		public IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic)
		{
			return this.Selecionar(igpmPeriodoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		public IList<IgpmPeriodoSic> Selecionar()
		{
			return this.Selecionar(new IgpmPeriodoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de IgpmPeriodoSic</returns>
		public IgpmPeriodoSic SelecionarPrimeiro(IgpmPeriodoSic igpmPeriodoSic)
		{
			IList<IgpmPeriodoSic> lista = this.Selecionar(igpmPeriodoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new IgpmPeriodoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Incluir(IgpmPeriodoSic igpmPeriodoSic)
		{
			if (null == igpmPeriodoSic) throw (new ArgumentNullException());
			this.igpmPeriodoSicDAO.Incluir(igpmPeriodoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Atualizar(IgpmPeriodoSic igpmPeriodoSic)
		{
			if (null == igpmPeriodoSic) throw (new ArgumentNullException());
			this.igpmPeriodoSicDAO.Atualizar(igpmPeriodoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir igpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Excluir(IgpmPeriodoSic igpmPeriodoSic)
		{
			if (null == igpmPeriodoSic) throw (new ArgumentNullException());
			this.igpmPeriodoSicDAO.Excluir(igpmPeriodoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


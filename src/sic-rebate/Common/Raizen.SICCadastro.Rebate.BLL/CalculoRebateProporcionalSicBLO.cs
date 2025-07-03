#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateProporcionalSicBLO.cs
// Class Name	        : CalculoRebateProporcionalSicBLO
// Author		        : Murilo Beltrame
// Creation Date 	    : 08/22/2014
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
	/// Representa funcionalidade relacionada a  CalculoRebateProporcionalSicBLO
	/// </summary>
	internal partial class CalculoRebateProporcionalSicBLO : ICalculoRebateProporcionalSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CalculoRebateProporcionalSicDAO 
		/// </summary>
		private readonly ICalculoRebateProporcionalSicDAO calculoRebateProporcionalSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public CalculoRebateProporcionalSicBLO()
		{
			this.calculoRebateProporcionalSicDAO = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateProporcionalSicDAO>("CalculoRebateProporcionalSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		public IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, int numeroLinhas, string ordem)
		{
			return this.calculoRebateProporcionalSicDAO.Selecionar(calculoRebateProporcionalSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		public IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, string ordem)
		{
			return this.Selecionar(calculoRebateProporcionalSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		public IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			return this.Selecionar(calculoRebateProporcionalSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		public IList<CalculoRebateProporcionalSic> Selecionar()
		{
			return this.Selecionar(new CalculoRebateProporcionalSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CalculoRebateProporcionalSic</returns>
		public CalculoRebateProporcionalSic SelecionarPrimeiro(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			IList<CalculoRebateProporcionalSic> lista = this.Selecionar(calculoRebateProporcionalSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new CalculoRebateProporcionalSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Incluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			if (null == calculoRebateProporcionalSic) throw (new ArgumentNullException());
			this.calculoRebateProporcionalSicDAO.Incluir(calculoRebateProporcionalSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Atualizar(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			if (null == calculoRebateProporcionalSic) throw (new ArgumentNullException());
			this.calculoRebateProporcionalSicDAO.Atualizar(calculoRebateProporcionalSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir calculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Excluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			if (null == calculoRebateProporcionalSic) throw (new ArgumentNullException());
			this.calculoRebateProporcionalSicDAO.Excluir(calculoRebateProporcionalSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


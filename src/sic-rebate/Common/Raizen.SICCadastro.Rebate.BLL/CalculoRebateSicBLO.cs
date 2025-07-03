#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateSicBLO.cs
// Class Name	        : CalculoRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 08/08/2014
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
	/// Representa funcionalidade relacionada a  CalculoRebateSicBLO
	/// </summary>
	internal partial class CalculoRebateSicBLO : ICalculoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CalculoRebateSicDAO 
		/// </summary>
		private readonly ICalculoRebateSicDAO calculoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public CalculoRebateSicBLO()
		{
			this.calculoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicDAO>("CalculoRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<CalculoRebateSic> Selecionar(CalculoRebateSic calculoRebateSic, int numeroLinhas, string ordem)
		{
			return this.calculoRebateSicDAO.Selecionar(calculoRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<CalculoRebateSic> Selecionar(CalculoRebateSic calculoRebateSic, string ordem)
		{
			return this.Selecionar(calculoRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<CalculoRebateSic> Selecionar(CalculoRebateSic calculoRebateSic)
		{
			return this.Selecionar(calculoRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<CalculoRebateSic> Selecionar()
		{
			return this.Selecionar(new CalculoRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CalculoRebateSic</returns>
		public CalculoRebateSic SelecionarPrimeiro(CalculoRebateSic calculoRebateSic)
		{
			IList<CalculoRebateSic> lista = this.Selecionar(calculoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new CalculoRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Incluir(CalculoRebateSic calculoRebateSic)
		{
			if (null == calculoRebateSic) throw (new ArgumentNullException());
			this.calculoRebateSicDAO.Incluir(calculoRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Atualizar(CalculoRebateSic calculoRebateSic)
		{
			if (null == calculoRebateSic) throw (new ArgumentNullException());
			this.calculoRebateSicDAO.Atualizar(calculoRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir calculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Excluir(CalculoRebateSic calculoRebateSic)
		{
			if (null == calculoRebateSic) throw (new ArgumentNullException());
			this.calculoRebateSicDAO.Excluir(calculoRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


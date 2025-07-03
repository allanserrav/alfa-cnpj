#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateFaixaSicBLO.cs
// Class Name	        : CalculoRebateFaixaSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/04/2013
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
	/// Representa funcionalidade relacionada a  CalculoRebateFaixaSicBLO
	/// </summary>
	internal partial class CalculoRebateFaixaSicBLO : ICalculoRebateFaixaSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CalculoRebateFaixaSicDAO 
		/// </summary>
		private readonly ICalculoRebateFaixaSicDAO calculoRebateFaixaSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public CalculoRebateFaixaSicBLO()
		{
			this.calculoRebateFaixaSicDAO = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateFaixaSicDAO>("CalculoRebateFaixaSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		public IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic, int numeroLinhas, string ordem)
		{
			return this.calculoRebateFaixaSicDAO.Selecionar(calculoRebateFaixaSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		public IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic, string ordem)
		{
			return this.Selecionar(calculoRebateFaixaSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		public IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			return this.Selecionar(calculoRebateFaixaSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		public IList<CalculoRebateFaixaSic> Selecionar()
		{
			return this.Selecionar(new CalculoRebateFaixaSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CalculoRebateFaixaSic</returns>
		public CalculoRebateFaixaSic SelecionarPrimeiro(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			IList<CalculoRebateFaixaSic> lista = this.Selecionar(calculoRebateFaixaSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new CalculoRebateFaixaSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Incluir(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			if (null == calculoRebateFaixaSic) throw (new ArgumentNullException());
			this.calculoRebateFaixaSicDAO.Incluir(calculoRebateFaixaSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Atualizar(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			if (null == calculoRebateFaixaSic) throw (new ArgumentNullException());
			this.calculoRebateFaixaSicDAO.Atualizar(calculoRebateFaixaSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir calculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Excluir(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			if (null == calculoRebateFaixaSic) throw (new ArgumentNullException());
			this.calculoRebateFaixaSicDAO.Excluir(calculoRebateFaixaSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


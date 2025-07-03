#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : SaldoRebateSicBLO.cs
// Class Name	        : SaldoRebateSicBLO
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
	/// Representa funcionalidade relacionada a  SaldoRebateSicBLO
	/// </summary>
	internal partial class SaldoRebateSicBLO : ISaldoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de SaldoRebateSicDAO 
		/// </summary>
		private readonly ISaldoRebateSicDAO saldoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public SaldoRebateSicBLO()
		{
			this.saldoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicDAO>("SaldoRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		public IList<SaldoRebateSic> Selecionar(SaldoRebateSic saldoRebateSic, int numeroLinhas, string ordem)
		{
			return this.saldoRebateSicDAO.Selecionar(saldoRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		public IList<SaldoRebateSic> Selecionar(SaldoRebateSic saldoRebateSic, string ordem)
		{
			return this.Selecionar(saldoRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		public IList<SaldoRebateSic> Selecionar(SaldoRebateSic saldoRebateSic)
		{
			return this.Selecionar(saldoRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		public IList<SaldoRebateSic> Selecionar()
		{
			return this.Selecionar(new SaldoRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de SaldoRebateSic</returns>
		public SaldoRebateSic SelecionarPrimeiro(SaldoRebateSic saldoRebateSic)
		{
			IList<SaldoRebateSic> lista = this.Selecionar(saldoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new SaldoRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Incluir(SaldoRebateSic saldoRebateSic)
		{
			if (null == saldoRebateSic) throw (new ArgumentNullException());
			this.saldoRebateSicDAO.Incluir(saldoRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Atualizar(SaldoRebateSic saldoRebateSic)
		{
			if (null == saldoRebateSic) throw (new ArgumentNullException());
			this.saldoRebateSicDAO.Atualizar(saldoRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir saldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Excluir(SaldoRebateSic saldoRebateSic)
		{
			if (null == saldoRebateSic) throw (new ArgumentNullException());
			this.saldoRebateSicDAO.Excluir(saldoRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


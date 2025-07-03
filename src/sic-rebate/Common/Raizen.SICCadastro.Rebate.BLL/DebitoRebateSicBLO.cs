#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DebitoRebateSicBLO.cs
// Class Name	        : DebitoRebateSicBLO
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
	/// Representa funcionalidade relacionada a  DebitoRebateSicBLO
	/// </summary>
	internal partial class DebitoRebateSicBLO : IDebitoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de DebitoRebateSicDAO 
		/// </summary>
		private readonly IDebitoRebateSicDAO debitoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public DebitoRebateSicBLO()
		{
			this.debitoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IDebitoRebateSicDAO>("DebitoRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		public IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, int numeroLinhas, string ordem)
		{
			return this.debitoRebateSicDAO.Selecionar(debitoRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		public IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, string ordem)
		{
			return this.Selecionar(debitoRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		public IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic)
		{
			return this.Selecionar(debitoRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		public IList<DebitoRebateSic> Selecionar()
		{
			return this.Selecionar(new DebitoRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de DebitoRebateSic</returns>
		public DebitoRebateSic SelecionarPrimeiro(DebitoRebateSic debitoRebateSic)
		{
			IList<DebitoRebateSic> lista = this.Selecionar(debitoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new DebitoRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Incluir(DebitoRebateSic debitoRebateSic)
		{
			if (null == debitoRebateSic) throw (new ArgumentNullException());
			this.debitoRebateSicDAO.Incluir(debitoRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Atualizar(DebitoRebateSic debitoRebateSic)
		{
			if (null == debitoRebateSic) throw (new ArgumentNullException());
			this.debitoRebateSicDAO.Atualizar(debitoRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir debitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Excluir(DebitoRebateSic debitoRebateSic)
		{
			if (null == debitoRebateSic) throw (new ArgumentNullException());
			this.debitoRebateSicDAO.Excluir(debitoRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


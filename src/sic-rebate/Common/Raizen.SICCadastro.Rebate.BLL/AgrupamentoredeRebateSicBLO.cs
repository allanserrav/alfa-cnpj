#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgrupamentoredeRebateSicBLO.cs
// Class Name	        : AgrupamentoredeRebateSicBLO
// Author		        : Murilo Beltrame
// Creation Date 	    : 08/13/2014
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
	/// Representa funcionalidade relacionada a  AgrupamentoredeRebateSicBLO
	/// </summary>
	internal class AgrupamentoredeRebateSicBLO : IAgrupamentoredeRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de AgrupamentoredeRebateSicDAO 
		/// </summary>
		private readonly IAgrupamentoredeRebateSicDAO agrupamentoredeRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public AgrupamentoredeRebateSicBLO()
		{
			this.agrupamentoredeRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IAgrupamentoredeRebateSicDAO>("AgrupamentoredeRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		public IList<AgrupamentoredeRebateSic> Selecionar(AgrupamentoredeRebateSic agrupamentoredeRebateSic, int numeroLinhas, string ordem)
		{
			return this.agrupamentoredeRebateSicDAO.Selecionar(agrupamentoredeRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		public IList<AgrupamentoredeRebateSic> Selecionar(AgrupamentoredeRebateSic agrupamentoredeRebateSic, string ordem)
		{
			return this.Selecionar(agrupamentoredeRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		public IList<AgrupamentoredeRebateSic> Selecionar(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			return this.Selecionar(agrupamentoredeRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		public IList<AgrupamentoredeRebateSic> Selecionar()
		{
			return this.Selecionar(new AgrupamentoredeRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de AgrupamentoredeRebateSic</returns>
		public AgrupamentoredeRebateSic SelecionarPrimeiro(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			IList<AgrupamentoredeRebateSic> lista = this.Selecionar(agrupamentoredeRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new AgrupamentoredeRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Incluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			if (null == agrupamentoredeRebateSic) throw (new ArgumentNullException());
			this.agrupamentoredeRebateSicDAO.Incluir(agrupamentoredeRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Atualizar(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			if (null == agrupamentoredeRebateSic) throw (new ArgumentNullException());
			this.agrupamentoredeRebateSicDAO.Atualizar(agrupamentoredeRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir agrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Excluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			if (null == agrupamentoredeRebateSic) throw (new ArgumentNullException());
			this.agrupamentoredeRebateSicDAO.Excluir(agrupamentoredeRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


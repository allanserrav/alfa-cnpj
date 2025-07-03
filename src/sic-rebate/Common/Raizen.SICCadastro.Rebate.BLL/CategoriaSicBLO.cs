#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CategoriaSicBLO.cs
// Class Name	        : CategoriaSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 10/31/2012
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
	/// Representa funcionalidade relacionada a  CategoriaSicBLO
	/// </summary>
	internal partial class CategoriaSicBLO : ICategoriaSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CategoriaSicDAO 
		/// </summary>
		private readonly ICategoriaSicDAO categoriaSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public CategoriaSicBLO()
		{
			this.categoriaSicDAO = Factory.CreateFactoryInstance().CreateInstance<ICategoriaSicDAO>("CategoriaSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		public IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, int numeroLinhas, string ordem)
		{
			return this.categoriaSicDAO.Selecionar(categoriaSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		public IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, string ordem)
		{
			return this.Selecionar(categoriaSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		public IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic)
		{
			return this.Selecionar(categoriaSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <returns>Retorna lista de CategoriaSic</returns>
		public IList<CategoriaSic> Selecionar()
		{
			return this.Selecionar(new CategoriaSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CategoriaSic</returns>
		public CategoriaSic SelecionarPrimeiro(CategoriaSic categoriaSic)
		{
			IList<CategoriaSic> lista = this.Selecionar(categoriaSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new CategoriaSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Incluir(CategoriaSic categoriaSic)
		{
			if (null == categoriaSic) throw (new ArgumentNullException());
			this.categoriaSicDAO.Incluir(categoriaSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Atualizar(CategoriaSic categoriaSic)
		{
			if (null == categoriaSic) throw (new ArgumentNullException());
			this.categoriaSicDAO.Atualizar(categoriaSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir categoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Excluir(CategoriaSic categoriaSic)
		{
			if (null == categoriaSic) throw (new ArgumentNullException());
			this.categoriaSicDAO.Excluir(categoriaSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


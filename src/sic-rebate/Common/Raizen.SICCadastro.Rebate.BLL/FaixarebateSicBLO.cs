#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : FaixarebateSicBLO.cs
// Class Name	        : FaixarebateSicBLO
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
	/// Representa funcionalidade relacionada a  FaixarebateSicBLO
	/// </summary>
	internal partial class FaixarebateSicBLO : IFaixarebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de FaixarebateSicDAO 
		/// </summary>
		private readonly IFaixarebateSicDAO faixarebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public FaixarebateSicBLO()
		{
			this.faixarebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicDAO>("FaixarebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic, int numeroLinhas, string ordem)
		{
			return this.faixarebateSicDAO.Selecionar(faixarebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic, string ordem)
		{
			return this.Selecionar(faixarebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic)
		{
			return this.Selecionar(faixarebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<FaixarebateSic> Selecionar()
		{
			return this.Selecionar(new FaixarebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de FaixarebateSic</returns>
		public FaixarebateSic SelecionarPrimeiro(FaixarebateSic faixarebateSic)
		{
			IList<FaixarebateSic> lista = this.Selecionar(faixarebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new FaixarebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Incluir(FaixarebateSic faixarebateSic)
		{
			if (null == faixarebateSic) throw (new ArgumentNullException());
			this.faixarebateSicDAO.Incluir(faixarebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Atualizar(FaixarebateSic faixarebateSic)
		{
			if (null == faixarebateSic) throw (new ArgumentNullException());
			this.faixarebateSicDAO.Atualizar(faixarebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir faixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Excluir(FaixarebateSic faixarebateSic)
		{
			if (null == faixarebateSic) throw (new ArgumentNullException());
			this.faixarebateSicDAO.Excluir(faixarebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


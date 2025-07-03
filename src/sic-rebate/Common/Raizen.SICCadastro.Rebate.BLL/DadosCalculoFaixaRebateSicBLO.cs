#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoFaixaRebateSicBLO.cs
// Class Name	        : DadosCalculoFaixaRebateSicBLO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 27/01/2020
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
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  FaixarebateSicBLO
	/// </summary>
	internal partial class DadosCalculoFaixaRebateSicBLO : IDadosCalculoFaixaRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de FaixarebateSicDAO 
		/// </summary>
		private readonly IDadosCalculoFaixaRebateSicDAO dadosCalculoFaixaRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public DadosCalculoFaixaRebateSicBLO()
		{
			this.dadosCalculoFaixaRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoFaixaRebateSicDAO>("DadosCalculoFaixaRebateSicDAO");
		}
		#endregion Construtor

		#region Metodos Publicos

		#region Selecionar
		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, int numeroLinhas, string ordem)
		{
			return this.dadosCalculoFaixaRebateSicDAO.Selecionar(dadosCalculoRebateFaixaSic, numeroLinhas, ordem);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, string ordem)
		{
			return this.Selecionar(dadosCalculoRebateFaixaSic, 0, ordem);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic)
		{
			return this.Selecionar(dadosCalculoRebateFaixaSic, 0, String.Empty);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <returns></returns>
		public IList<DadosCalculoRebateFaixaSic> Selecionar()
		{
			return this.Selecionar(new DadosCalculoRebateFaixaSic(), 0, String.Empty);
		}
		
		
		public DadosCalculoRebateFaixaSic SelecionarPrimeiro(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic)
		{
			IList<DadosCalculoRebateFaixaSic> lista = this.Selecionar(dadosCalculoRebateFaixaSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new DadosCalculoRebateFaixaSic();
		}
		#endregion Selecionar
		
		#endregion Public Methods
	}
}
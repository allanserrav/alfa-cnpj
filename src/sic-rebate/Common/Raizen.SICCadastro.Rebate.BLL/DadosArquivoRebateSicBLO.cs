#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosArquivoRebateSicBLO.cs
// Class Name	        : DadosArquivoRebateSicBLO
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 01/17/2013
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
	/// Representa funcionalidade relacionada a  DadosArquivoRebateSicBLO
	/// </summary>
	internal partial class DadosArquivoRebateSicBLO : IDadosArquivoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de DadosArquivoRebateSicDAO 
		/// </summary>
		private readonly IDadosArquivoRebateSicDAO dadosArquivoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public DadosArquivoRebateSicBLO()
		{
			this.dadosArquivoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IDadosArquivoRebateSicDAO>("DadosArquivoRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		public IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic, int numeroLinhas, string ordem)
		{
			return this.dadosArquivoRebateSicDAO.Selecionar(dadosArquivoRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		public IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic, string ordem)
		{
			return this.Selecionar(dadosArquivoRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		public IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			return this.Selecionar(dadosArquivoRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		public IList<DadosArquivoRebateSic> Selecionar()
		{
			return this.Selecionar(new DadosArquivoRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de DadosArquivoRebateSic</returns>
		public DadosArquivoRebateSic SelecionarPrimeiro(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			IList<DadosArquivoRebateSic> lista = this.Selecionar(dadosArquivoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new DadosArquivoRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Incluir(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			if (null == dadosArquivoRebateSic) throw (new ArgumentNullException());
			this.dadosArquivoRebateSicDAO.Incluir(dadosArquivoRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Atualizar(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			if (null == dadosArquivoRebateSic) throw (new ArgumentNullException());
			this.dadosArquivoRebateSicDAO.Atualizar(dadosArquivoRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir dadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Excluir(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			if (null == dadosArquivoRebateSic) throw (new ArgumentNullException());
			this.dadosArquivoRebateSicDAO.Excluir(dadosArquivoRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


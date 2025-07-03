#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeMensalFaixaRebateSicBLO.cs
// Class Name	        : VolumeMensalFaixaRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/28/2013
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
	/// Representa funcionalidade relacionada a  VolumeMensalFaixaRebateSicBLO
	/// </summary>
	internal partial class VolumeMensalFaixaRebateSicBLO : IVolumeMensalFaixaRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de VolumeMensalFaixaRebateSicDAO 
		/// </summary>
		private readonly IVolumeMensalFaixaRebateSicDAO volumeMensalFaixaRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public VolumeMensalFaixaRebateSicBLO()
		{
			this.volumeMensalFaixaRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IVolumeMensalFaixaRebateSicDAO>("VolumeMensalFaixaRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		public IList<VolumeMensalFaixaRebateSic> Selecionar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, int numeroLinhas, string ordem)
		{
			return this.volumeMensalFaixaRebateSicDAO.Selecionar(volumeMensalFaixaRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		public IList<VolumeMensalFaixaRebateSic> Selecionar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, string ordem)
		{
			return this.Selecionar(volumeMensalFaixaRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		public IList<VolumeMensalFaixaRebateSic> Selecionar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			return this.Selecionar(volumeMensalFaixaRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		public IList<VolumeMensalFaixaRebateSic> Selecionar()
		{
			return this.Selecionar(new VolumeMensalFaixaRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de VolumeMensalFaixaRebateSic</returns>
		public VolumeMensalFaixaRebateSic SelecionarPrimeiro(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			IList<VolumeMensalFaixaRebateSic> lista = this.Selecionar(volumeMensalFaixaRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new VolumeMensalFaixaRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Incluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			if (null == volumeMensalFaixaRebateSic) throw (new ArgumentNullException());
			this.volumeMensalFaixaRebateSicDAO.Incluir(volumeMensalFaixaRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Atualizar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			if (null == volumeMensalFaixaRebateSic) throw (new ArgumentNullException());
			this.volumeMensalFaixaRebateSicDAO.Atualizar(volumeMensalFaixaRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir volumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Excluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			if (null == volumeMensalFaixaRebateSic) throw (new ArgumentNullException());
			this.volumeMensalFaixaRebateSicDAO.Excluir(volumeMensalFaixaRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MotivoRegimeEspecialRebateSicBLO.cs
// Class Name	        : MotivoRegimeEspecialRebateSicBLO
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
	/// Representa funcionalidade relacionada a  MotivoRegimeEspecialRebateSicBLO
	/// </summary>
	internal partial class MotivoRegimeEspecialRebateSicBLO : IMotivoRegimeEspecialRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de MotivoRegimeEspecialRebateSicDAO 
		/// </summary>
		private readonly IMotivoRegimeEspecialRebateSicDAO motivoRegimeEspecialRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public MotivoRegimeEspecialRebateSicBLO()
		{
			this.motivoRegimeEspecialRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IMotivoRegimeEspecialRebateSicDAO>("MotivoRegimeEspecialRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		public IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, int numeroLinhas, string ordem)
		{
			return this.motivoRegimeEspecialRebateSicDAO.Selecionar(motivoRegimeEspecialRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		public IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, string ordem)
		{
			return this.Selecionar(motivoRegimeEspecialRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		public IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			return this.Selecionar(motivoRegimeEspecialRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		public IList<MotivoRegimeEspecialRebateSic> Selecionar()
		{
			return this.Selecionar(new MotivoRegimeEspecialRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de MotivoRegimeEspecialRebateSic</returns>
		public MotivoRegimeEspecialRebateSic SelecionarPrimeiro(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			IList<MotivoRegimeEspecialRebateSic> lista = this.Selecionar(motivoRegimeEspecialRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new MotivoRegimeEspecialRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Incluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			if (null == motivoRegimeEspecialRebateSic) throw (new ArgumentNullException());
			this.motivoRegimeEspecialRebateSicDAO.Incluir(motivoRegimeEspecialRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Atualizar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			if (null == motivoRegimeEspecialRebateSic) throw (new ArgumentNullException());
			this.motivoRegimeEspecialRebateSicDAO.Atualizar(motivoRegimeEspecialRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir motivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Excluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			if (null == motivoRegimeEspecialRebateSic) throw (new ArgumentNullException());
			this.motivoRegimeEspecialRebateSicDAO.Excluir(motivoRegimeEspecialRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


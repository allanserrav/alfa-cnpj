#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AvisoSicBLO.cs
// Class Name	        : AvisoSicBLO
// Author		        : Hélio Jânio Ferreira
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
	/// Representa funcionalidade relacionada a  AvisoSicBLO
	/// </summary>
	internal class AvisoSicBLO : IAvisoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de AvisoSicDAO 
		/// </summary>
		private readonly IAvisoSicDAO avisoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public AvisoSicBLO()
		{
			this.avisoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IAvisoSicDAO>("AvisoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AvisoSic</returns>
		public IList<AvisoSic> Selecionar(AvisoSic avisoSic, int numeroLinhas, string ordem)
		{
			return this.avisoSicDAO.Selecionar(avisoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AvisoSic</returns>
		public IList<AvisoSic> Selecionar(AvisoSic avisoSic, string ordem)
		{
			return this.Selecionar(avisoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de AvisoSic</returns>
		public IList<AvisoSic> Selecionar(AvisoSic avisoSic)
		{
			return this.Selecionar(avisoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <returns>Retorna lista de AvisoSic</returns>
		public IList<AvisoSic> Selecionar()
		{
			return this.Selecionar(new AvisoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de AvisoSic</returns>
		public AvisoSic SelecionarPrimeiro(AvisoSic avisoSic)
		{
			IList<AvisoSic> lista = this.Selecionar(avisoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new AvisoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Incluir(AvisoSic avisoSic)
		{
			if (null == avisoSic) throw (new ArgumentNullException());
			this.avisoSicDAO.Incluir(avisoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Atualizar(AvisoSic avisoSic)
		{
			if (null == avisoSic) throw (new ArgumentNullException());
			this.avisoSicDAO.Atualizar(avisoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir avisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Excluir(AvisoSic avisoSic)
		{
			if (null == avisoSic) throw (new ArgumentNullException());
			this.avisoSicDAO.Excluir(avisoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


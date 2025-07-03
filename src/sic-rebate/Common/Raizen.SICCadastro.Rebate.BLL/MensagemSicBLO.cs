#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MensagemSicBLO.cs
// Class Name	        : MensagemSicBLO
// Author		        : Romildo Cruz
// Creation Date 	    : 10/22/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 18/12/2012
//	Reason for modification : Change namespace SICCadastro to SICCadastro.Rebate
//	Modification Done       : 18/12/2012
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
	/// Representa funcionalidade relacionada a  MensagemSicBLO
	/// </summary>
	internal class MensagemSicBLO : IMensagemSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de MensagemSicDAO 
		/// </summary>
		private readonly IMensagemSicDAO mensagemSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public MensagemSicBLO()
		{
			this.mensagemSicDAO = Factory.CreateFactoryInstance().CreateInstance<IMensagemSicDAO>("MensagemSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MensagemSic</returns>
		public IList<MensagemSic> Selecionar(MensagemSic mensagemSic, int numeroLinhas, string ordem)
		{
			return this.mensagemSicDAO.Selecionar(mensagemSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MensagemSic</returns>
		public IList<MensagemSic> Selecionar(MensagemSic mensagemSic, string ordem)
		{
			return this.Selecionar(mensagemSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de MensagemSic</returns>
		public IList<MensagemSic> Selecionar(MensagemSic mensagemSic)
		{
			return this.Selecionar(mensagemSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <returns>Retorna lista de MensagemSic</returns>
		public IList<MensagemSic> Selecionar()
		{
			return this.Selecionar(new MensagemSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de MensagemSic</returns>
		public MensagemSic SelecionarPrimeiro(MensagemSic mensagemSic)
		{
			IList<MensagemSic> lista = this.Selecionar(mensagemSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new MensagemSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Incluir(MensagemSic mensagemSic)
		{
			if (null == mensagemSic) throw (new ArgumentNullException());
			this.mensagemSicDAO.Incluir(mensagemSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Atualizar(MensagemSic mensagemSic)
		{
			if (null == mensagemSic) throw (new ArgumentNullException());
			this.mensagemSicDAO.Atualizar(mensagemSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir mensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Excluir(MensagemSic mensagemSic)
		{
			if (null == mensagemSic) throw (new ArgumentNullException());
			this.mensagemSicDAO.Excluir(mensagemSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


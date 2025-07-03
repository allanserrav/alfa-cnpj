#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClienteSicBLO.cs
// Class Name	        : ClienteSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 03/21/2013
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
	/// Representa funcionalidade relacionada a  ClienteSicBLO
	/// </summary>
	internal partial class ClienteSicBLO : IClienteSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ClienteSicDAO 
		/// </summary>
		private readonly IClienteSicDAO clienteSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ClienteSicBLO()
		{
			this.clienteSicDAO = Factory.CreateFactoryInstance().CreateInstance<IClienteSicDAO>("ClienteSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClienteSic</returns>
		public IList<ClienteSic> Selecionar(ClienteSic clienteSic, int numeroLinhas, string ordem)
		{
			return this.clienteSicDAO.Selecionar(clienteSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClienteSic</returns>
		public IList<ClienteSic> Selecionar(ClienteSic clienteSic, string ordem)
		{
			return this.Selecionar(clienteSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ClienteSic</returns>
		public IList<ClienteSic> Selecionar(ClienteSic clienteSic)
		{
			return this.Selecionar(clienteSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <returns>Retorna lista de ClienteSic</returns>
		public IList<ClienteSic> Selecionar()
		{
			return this.Selecionar(new ClienteSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ClienteSic</returns>
		public ClienteSic SelecionarPrimeiro(ClienteSic clienteSic)
		{
			IList<ClienteSic> lista = this.Selecionar(clienteSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ClienteSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Incluir(ClienteSic clienteSic)
		{
			if (null == clienteSic) throw (new ArgumentNullException());
			this.clienteSicDAO.Incluir(clienteSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Atualizar(ClienteSic clienteSic)
		{
			if (null == clienteSic) throw (new ArgumentNullException());
			this.clienteSicDAO.Atualizar(clienteSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir clienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Excluir(ClienteSic clienteSic)
		{
			if (null == clienteSic) throw (new ArgumentNullException());
			this.clienteSicDAO.Excluir(clienteSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


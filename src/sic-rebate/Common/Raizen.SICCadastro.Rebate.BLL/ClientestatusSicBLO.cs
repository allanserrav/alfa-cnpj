#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClientestatusSicBLO.cs
// Class Name	        : ClientestatusSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 02/13/2013
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
	/// Representa funcionalidade relacionada a  ClientestatusSicBLO
	/// </summary>
	internal partial class ClientestatusSicBLO : IClientestatusSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ClientestatusSicDAO 
		/// </summary>
		private readonly IClientestatusSicDAO clientestatusSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ClientestatusSicBLO()
		{
			this.clientestatusSicDAO = Factory.CreateFactoryInstance().CreateInstance<IClientestatusSicDAO>("ClientestatusSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instância de <see cref="ClientestatusSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClientestatusSic</returns>
		public IList<ClientestatusSic> Selecionar(ClientestatusSic clientestatusSic, int numeroLinhas, string ordem)
		{
			return this.clientestatusSicDAO.Selecionar(clientestatusSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instância de <see cref="ClientestatusSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClientestatusSic</returns>
		public IList<ClientestatusSic> Selecionar(ClientestatusSic clientestatusSic, string ordem)
		{
			return this.Selecionar(clientestatusSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instância de <see cref="ClientestatusSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ClientestatusSic</returns>
		public IList<ClientestatusSic> Selecionar(ClientestatusSic clientestatusSic)
		{
			return this.Selecionar(clientestatusSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ClientestatusSic
		/// </summary>
		/// <returns>Retorna lista de ClientestatusSic</returns>
		public IList<ClientestatusSic> Selecionar()
		{
			return this.Selecionar(new ClientestatusSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instância de <see cref="ClientestatusSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ClientestatusSic</returns>
		public ClientestatusSic SelecionarPrimeiro(ClientestatusSic clientestatusSic)
		{
			IList<ClientestatusSic> lista = this.Selecionar(clientestatusSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ClientestatusSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Incluir(ClientestatusSic clientestatusSic)
		{
			if (null == clientestatusSic) throw (new ArgumentNullException());
			this.clientestatusSicDAO.Incluir(clientestatusSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Atualizar(ClientestatusSic clientestatusSic)
		{
			if (null == clientestatusSic) throw (new ArgumentNullException());
			this.clientestatusSicDAO.Atualizar(clientestatusSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir clientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Excluir(ClientestatusSic clientestatusSic)
		{
			if (null == clientestatusSic) throw (new ArgumentNullException());
			this.clientestatusSicDAO.Excluir(clientestatusSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


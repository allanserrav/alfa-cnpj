#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IClientestatusSicDAO.cs
// Class Name	        : IClientestatusSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 13/02/2013
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
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IClientestatusSicDAO
	/// </summary>
	public partial interface IClientestatusSicDAO
	{
		#region Metodos de IClientestatusSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instância de <see cref="ClientestatusSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClientestatusSic</returns>
		IList<ClientestatusSic> Selecionar(ClientestatusSic clientestatusSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		void Incluir(ClientestatusSic clientestatusSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		void Atualizar(ClientestatusSic clientestatusSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui clientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		void Excluir(ClientestatusSic clientestatusSic);
		#endregion Excluir
		
		#endregion IClientestatusSicDAO
	}
}

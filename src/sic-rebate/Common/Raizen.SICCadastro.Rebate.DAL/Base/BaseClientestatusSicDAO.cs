#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseClientestatusSicDAO.cs
// Class Name	        : ClientestatusSicDAO
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
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	#region classe base ClientestatusSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ClientestatusSicDAO
	/// </summary>
	internal partial class ClientestatusSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ClientestatusSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqClientestausSic = "NR_SEQ_CLIENTESTAUS_SIC";
		private const string C_NrSeqStatusSic = "NR_SEQ_STATUS_SIC";
		private const string C_NrSeqClienteSic = "NR_SEQ_CLIENTE_SIC";
		private const string C_DtAlteracaoSic = "DT_ALTERACAO_SIC";
		private const string C_NmLoginSic = "NM_LOGIN_SIC";
		private const string C_DsObservacaoSic = "DS_OBSERVACAO_SIC";
		#endregion  Constantes de TbClientestatusSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CLIENTESTATUS_SIC")
		.Append("(")
		.Append("NR_SEQ_STATUS_SIC,NR_SEQ_CLIENTE_SIC,DT_ALTERACAO_SIC,NM_LOGIN_SIC,DS_OBSERVACAO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqStatusSic)
		.Append(", ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(", ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(", ")
		.Append("@" + C_NmLoginSic)
		.Append(", ")
		.Append("@" + C_DsObservacaoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CLIENTESTATUS_SIC SET")
		.Append(" NR_SEQ_STATUS_SIC = ")
		.Append("@" + C_NrSeqStatusSic)
		.Append(",NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(",DT_ALTERACAO_SIC = ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(",NM_LOGIN_SIC = ")
		.Append("@" + C_NmLoginSic)
		.Append(",DS_OBSERVACAO_SIC = ")
		.Append("@" + C_DsObservacaoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTESTAUS_SIC = ")
		.Append("@" + C_NrSeqClientestausSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CLIENTESTATUS_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTESTAUS_SIC = ")
		.Append("@" + C_NrSeqClientestausSic)
		.Append("").ToString();
		#endregion Query Excluir
		
		#region Query retorna Sequence 
		/// <summary>
		/// Strings with retrieve sequence query
		/// </summary>
		private string queryRetornaSequencia = new StringBuilder().Append("SELECT ")
		.Append(" SCOPE_IDENTITY()").ToString();
		#endregion Retrieve Sequence
		
		#region Query Verifica se existe
		/// <summary>
		/// String com a query Verifica se existe
		/// </summary>
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CLIENTESTATUS_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTESTAUS_SIC = ")
		.Append("@" + C_NrSeqClientestausSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Incluir(ClientestatusSic clientestatusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(clientestatusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ClientestatusSic clientestatusSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (clientestatusSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				clientestatusSic.NrSeqClientestausSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, clientestatusSic)));
			else
				clientestatusSic.NrSeqClientestausSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, clientestatusSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Atualizar(ClientestatusSic clientestatusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(clientestatusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ClientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ClientestatusSic clientestatusSic, DatabaseManager databaseManager)
		{
			if (clientestatusSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, clientestatusSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, clientestatusSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui clientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		public void Excluir(ClientestatusSic clientestatusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(clientestatusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui clientestatusSic
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ClientestatusSic clientestatusSic, DatabaseManager databaseManager)
		{
			if (clientestatusSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, clientestatusSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, clientestatusSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ClientestatusSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ClientestatusSic clientestatusSic, DatabaseManager databaseManager)
		{
			if (clientestatusSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, clientestatusSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, clientestatusSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ClientestatusSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ClientestatusSic clientestatusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClientestausSic, clientestatusSic.NrSeqClientestausSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ClientestatusSic clientestatusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusSic, clientestatusSic.NrSeqStatusSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, clientestatusSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, clientestatusSic.DtAlteracaoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLoginSic, clientestatusSic.NmLoginSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObservacaoSic, clientestatusSic.DsObservacaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ClientestatusSic clientestatusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClientestausSic, clientestatusSic.NrSeqClientestausSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusSic, clientestatusSic.NrSeqStatusSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, clientestatusSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, clientestatusSic.DtAlteracaoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLoginSic, clientestatusSic.NmLoginSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObservacaoSic, clientestatusSic.DsObservacaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

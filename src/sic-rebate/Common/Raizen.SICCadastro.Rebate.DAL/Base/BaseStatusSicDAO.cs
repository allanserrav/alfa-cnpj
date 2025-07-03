#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseStatusSicDAO.cs
// Class Name	        : StatusSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/01/2013
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
	#region classe base StatusSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusSicDAO
	/// </summary>
	internal partial class StatusSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public StatusSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqStatusSic = "NR_SEQ_STATUS_SIC";
		private const string C_NmStatusSic = "NM_STATUS_SIC";
		private const string C_DsStatusSic = "DS_STATUS_SIC";
		#endregion  Constantes de TbStatusSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_STATUS_SIC")
		.Append("(")
		.Append("NM_STATUS_SIC,DS_STATUS_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmStatusSic)
		.Append(", ")
		.Append("@" + C_DsStatusSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_STATUS_SIC SET")
		.Append(" NM_STATUS_SIC = ")
		.Append("@" + C_NmStatusSic)
		.Append(",DS_STATUS_SIC = ")
		.Append("@" + C_DsStatusSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_SIC = ")
		.Append("@" + C_NrSeqStatusSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_STATUS_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_SIC = ")
		.Append("@" + C_NrSeqStatusSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_STATUS_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_SIC = ")
		.Append("@" + C_NrSeqStatusSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Incluir(StatusSic statusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(statusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(StatusSic statusSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (statusSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				statusSic.NrSeqStatusSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, statusSic)));
			else
				statusSic.NrSeqStatusSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, statusSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Atualizar(StatusSic statusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(statusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(StatusSic statusSic, DatabaseManager databaseManager)
		{
			if (statusSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Excluir(StatusSic statusSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(statusSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui statusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(StatusSic statusSic, DatabaseManager databaseManager)
		{
			if (statusSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe StatusSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(StatusSic statusSic, DatabaseManager databaseManager)
		{
			if (statusSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe StatusSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, StatusSic statusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusSic, statusSic.NrSeqStatusSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, StatusSic statusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusSic, statusSic.NmStatusSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsStatusSic, statusSic.DsStatusSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, StatusSic statusSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusSic, statusSic.NrSeqStatusSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusSic, statusSic.NmStatusSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsStatusSic, statusSic.DsStatusSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

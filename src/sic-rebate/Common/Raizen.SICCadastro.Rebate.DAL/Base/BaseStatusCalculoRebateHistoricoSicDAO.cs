#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseStatusCalculoRebateHistoricoSicDAO.cs
// Class Name	        : StatusCalculoRebateHistoricoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	#region classe base StatusCalculoRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusCalculoRebateHistoricoSicDAO
	/// </summary>
	internal partial class StatusCalculoRebateHistoricoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public StatusCalculoRebateHistoricoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqStatusCalculoRebateHistoricoSic = "NR_SEQ_STATUS_CALCULO_REBATE_HISTORICO_SIC";
		private const string C_NrSeqCalculoRebateSic = "NR_SEQ_CALCULO_REBATE_SIC";
		private const string C_NrSeqStatusCalculoRebateSic = "NR_SEQ_STATUS_CALCULO_REBATE_SIC";
		private const string C_DtAlteracaoSic = "DT_ALTERACAO_SIC";
		private const string C_NmLoginSic = "NM_LOGIN_SIC";
		private const string C_DsObservacaoSic = "DS_OBSERVACAO_SIC";
		#endregion  Constantes de TbStatusCalculoRebateHistoricoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_STATUS_CALCULO_REBATE_HISTORICO_SIC")
		.Append("(")
		.Append("NR_SEQ_CALCULO_REBATE_SIC,NR_SEQ_STATUS_CALCULO_REBATE_SIC,DT_ALTERACAO_SIC,NM_LOGIN_SIC,DS_OBSERVACAO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
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
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_STATUS_CALCULO_REBATE_HISTORICO_SIC SET")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(",NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(",DT_ALTERACAO_SIC = ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(",NM_LOGIN_SIC = ")
		.Append("@" + C_NmLoginSic)
		.Append(",DS_OBSERVACAO_SIC = ")
		.Append("@" + C_DsObservacaoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_STATUS_CALCULO_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateHistoricoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_STATUS_CALCULO_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Incluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(statusCalculoRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (statusCalculoRebateHistoricoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, statusCalculoRebateHistoricoSic)));
			else
				statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, statusCalculoRebateHistoricoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Atualizar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(statusCalculoRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusCalculoRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusCalculoRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Excluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(statusCalculoRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui statusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusCalculoRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusCalculoRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe StatusCalculoRebateHistoricoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateHistoricoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusCalculoRebateHistoricoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusCalculoRebateHistoricoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe StatusCalculoRebateHistoricoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateHistoricoSic, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, statusCalculoRebateHistoricoSic.NrSeqCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, statusCalculoRebateHistoricoSic.DtAlteracaoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLoginSic, statusCalculoRebateHistoricoSic.NmLoginSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObservacaoSic, statusCalculoRebateHistoricoSic.DsObservacaoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateHistoricoSic, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, statusCalculoRebateHistoricoSic.NrSeqCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, statusCalculoRebateHistoricoSic.DtAlteracaoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLoginSic, statusCalculoRebateHistoricoSic.NmLoginSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObservacaoSic, statusCalculoRebateHistoricoSic.DsObservacaoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

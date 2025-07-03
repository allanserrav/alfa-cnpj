#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseStatusCalculoRebateSicDAO.cs
// Class Name	        : StatusCalculoRebateSicDAO
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
	#region classe base StatusCalculoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusCalculoRebateSicDAO
	/// </summary>
	internal partial class StatusCalculoRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public StatusCalculoRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqStatusCalculoRebateSic = "NR_SEQ_STATUS_CALCULO_REBATE_SIC";
		private const string C_NmStatusCalculoRebateSic = "NM_STATUS_CALCULO_REBATE_SIC";
		private const string C_DsStatusCalculoRebateSic = "DS_STATUS_CALCULO_REBATE_SIC";
		#endregion  Constantes de TbStatusCalculoRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_STATUS_CALCULO_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_STATUS_CALCULO_REBATE_SIC,NM_STATUS_CALCULO_REBATE_SIC,DS_STATUS_CALCULO_REBATE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_NmStatusCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_DsStatusCalculoRebateSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_STATUS_CALCULO_REBATE_SIC SET")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(",NM_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NmStatusCalculoRebateSic)
		.Append(",DS_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_DsStatusCalculoRebateSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_STATUS_CALCULO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append("").ToString();
		#endregion Query Excluir
		
		#region Query Verifica se existe
		/// <summary>
		/// String com a query Verifica se existe
		/// </summary>
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_STATUS_CALCULO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Incluir(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(statusCalculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(StatusCalculoRebateSic statusCalculoRebateSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, statusCalculoRebateSic));
			else
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, statusCalculoRebateSic), databaseManager.Transaction);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Atualizar(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(statusCalculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(StatusCalculoRebateSic statusCalculoRebateSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusCalculoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, statusCalculoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Excluir(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(statusCalculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui statusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(StatusCalculoRebateSic statusCalculoRebateSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusCalculoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, statusCalculoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe StatusCalculoRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(StatusCalculoRebateSic statusCalculoRebateSic, DatabaseManager databaseManager)
		{
			if (statusCalculoRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusCalculoRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, statusCalculoRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe StatusCalculoRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, StatusCalculoRebateSic statusCalculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, statusCalculoRebateSic.NrSeqStatusCalculoRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, StatusCalculoRebateSic statusCalculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, statusCalculoRebateSic.NrSeqStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusCalculoRebateSic, statusCalculoRebateSic.NmStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsStatusCalculoRebateSic, statusCalculoRebateSic.DsStatusCalculoRebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, StatusCalculoRebateSic statusCalculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, statusCalculoRebateSic.NrSeqStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusCalculoRebateSic, statusCalculoRebateSic.NmStatusCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsStatusCalculoRebateSic, statusCalculoRebateSic.DsStatusCalculoRebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

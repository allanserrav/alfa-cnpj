#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateHistoricoSicDAO.cs
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
	#region classe concreta StatusCalculoRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusCalculoRebateHistoricoSicDAO
	/// </summary>
	internal partial class StatusCalculoRebateHistoricoSicDAO : IStatusCalculoRebateHistoricoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbStatusCalculoRebateHistoricoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.NR_SEQ_STATUS_CALCULO_REBATE_HISTORICO_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.NR_SEQ_CALCULO_REBATE_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.NR_SEQ_STATUS_CALCULO_REBATE_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.DT_ALTERACAO_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.NM_LOGIN_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_HISTORICO_SIC.DS_OBSERVACAO_SIC")
		.Append(" FROM TB_STATUS_CALCULO_REBATE_HISTORICO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		public IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic = new List<StatusCalculoRebateHistoricoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, statusCalculoRebateHistoricoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listStatusCalculoRebateHistoricoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listStatusCalculoRebateHistoricoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto StatusCalculoRebateHistoricoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto StatusCalculoRebateHistoricoSic preenchido</returns>
		protected StatusCalculoRebateHistoricoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic = new StatusCalculoRebateHistoricoSic();
			statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic = reader.GetNullableInt32(C_NrSeqStatusCalculoRebateHistoricoSic);
			statusCalculoRebateHistoricoSic.NrSeqCalculoRebateSic = reader.GetNullableInt32(C_NrSeqCalculoRebateSic);
			statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateSic = reader.GetNullableInt32(C_NrSeqStatusCalculoRebateSic);
			statusCalculoRebateHistoricoSic.DtAlteracaoSic = reader.GetNullableDateTime(C_DtAlteracaoSic);
			statusCalculoRebateHistoricoSic.NmLoginSic = reader.GetString(C_NmLoginSic);
			statusCalculoRebateHistoricoSic.DsObservacaoSic = reader.GetString(C_DsObservacaoSic);
			return statusCalculoRebateHistoricoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_NrSeqStatusCalculoRebateHistoricoSic, DatabaseManager.SQLOperation.Equal, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateHistoricoSic, ref where));
			if (statusCalculoRebateHistoricoSic.NrSeqCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_NrSeqCalculoRebateSic, DatabaseManager.SQLOperation.Equal, statusCalculoRebateHistoricoSic.NrSeqCalculoRebateSic, ref where));
			if (statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_NrSeqStatusCalculoRebateSic, DatabaseManager.SQLOperation.Equal, statusCalculoRebateHistoricoSic.NrSeqStatusCalculoRebateSic, ref where));
			if (statusCalculoRebateHistoricoSic.DtAlteracaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_DtAlteracaoSic, DatabaseManager.SQLOperation.Equal, statusCalculoRebateHistoricoSic.DtAlteracaoSic, ref where));
			if (statusCalculoRebateHistoricoSic.NmLoginSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_NmLoginSic, DatabaseManager.SQLOperation.Like, "%" + statusCalculoRebateHistoricoSic.NmLoginSic + "%", ref where));
			if (statusCalculoRebateHistoricoSic.DsObservacaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_CALCULO_REBATE_HISTORICO_SIC", C_DsObservacaoSic, DatabaseManager.SQLOperation.Like, "%" + statusCalculoRebateHistoricoSic.DsObservacaoSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

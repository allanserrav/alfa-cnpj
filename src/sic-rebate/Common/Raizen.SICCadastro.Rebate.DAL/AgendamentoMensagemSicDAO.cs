#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgendamentoMensagemSicDAO.cs
// Class Name	        : AgendamentoMensagemSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 23/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 12/18/2012
//	Reason for modification : Copy class from SICCadastros to SICCadastros.Rebate
//	Modification Done       : 12/18/2012
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
	#region classe concreta AgendamentoMensagemSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AgendamentoMensagemSicDAO
	/// </summary>
	internal partial class AgendamentoMensagemSicDAO : IAgendamentoMensagemSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbAgendamentoMensagemSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_AGENDAMENTO_MENSAGEM_SIC.NR_SEQ_AGENDAMENTO_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.NR_SEQ_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.NM_USER_SOLICITACAO_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.DT_AGENDAMENTO_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.ST_AGENGAMENTO_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.NM_GRUPODE_AGENGAMENTO_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.NM_GRUPOPARA_AGENDAMENTO_MENSAGEM_SIC")
		.Append(",TB_AGENDAMENTO_MENSAGEM_SIC.NM_LINK_AGENDAMENTO_MENSAGEM_SIC")
		.Append(" FROM TB_AGENDAMENTO_MENSAGEM_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		public IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic, int numeroLinhas, string ordem)
		{
			IList<AgendamentoMensagemSic> listAgendamentoMensagemSic = new List<AgendamentoMensagemSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, agendamentoMensagemSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listAgendamentoMensagemSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listAgendamentoMensagemSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto AgendamentoMensagemSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto AgendamentoMensagemSic preenchido</returns>
		protected AgendamentoMensagemSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			AgendamentoMensagemSic agendamentoMensagemSic = new AgendamentoMensagemSic();
			agendamentoMensagemSic.NrSeqAgendamentoMensagemSic = reader.GetNullableInt32(C_NrSeqAgendamentoMensagemSic);
			agendamentoMensagemSic.NrSeqMensagemSic = reader.GetNullableInt32(C_NrSeqMensagemSic);
			agendamentoMensagemSic.NmUserSolicitacaoSic = reader.GetString(C_NmUserSolicitacaoSic);
			agendamentoMensagemSic.DtAgendamentoMensagemSic = reader.GetNullableDateTime(C_DtAgendamentoMensagemSic);
			agendamentoMensagemSic.StAgengamentoMensagemSic = reader.GetNullableBoolean(C_StAgengamentoMensagemSic);
			agendamentoMensagemSic.NmGrupodeAgengamentoMensagemSic = reader.GetString(C_NmGrupodeAgengamentoMensagemSic);
			agendamentoMensagemSic.NmGrupoparaAgendamentoMensagemSic = reader.GetString(C_NmGrupoparaAgendamentoMensagemSic);
			agendamentoMensagemSic.NmLinkAgendamentoMensagemSic = reader.GetString(C_NmLinkAgendamentoMensagemSic);
			return agendamentoMensagemSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, AgendamentoMensagemSic agendamentoMensagemSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (agendamentoMensagemSic.NrSeqAgendamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NrSeqAgendamentoMensagemSic, DatabaseManager.SQLOperation.Equal, agendamentoMensagemSic.NrSeqAgendamentoMensagemSic, ref where));
			if (agendamentoMensagemSic.NrSeqMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NrSeqMensagemSic, DatabaseManager.SQLOperation.Equal, agendamentoMensagemSic.NrSeqMensagemSic, ref where));
			if (agendamentoMensagemSic.NmUserSolicitacaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NmUserSolicitacaoSic, DatabaseManager.SQLOperation.Like, "%" + agendamentoMensagemSic.NmUserSolicitacaoSic + "%", ref where));
			if (agendamentoMensagemSic.DtAgendamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_AGENDAMENTO_MENSAGEM_SIC", C_DtAgendamentoMensagemSic, DatabaseManager.SQLOperation.Equal, agendamentoMensagemSic.DtAgendamentoMensagemSic, ref where));
			if (agendamentoMensagemSic.StAgengamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_AGENDAMENTO_MENSAGEM_SIC", C_StAgengamentoMensagemSic, DatabaseManager.SQLOperation.Equal, agendamentoMensagemSic.StAgengamentoMensagemSic, ref where));
			if (agendamentoMensagemSic.NmGrupodeAgengamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NmGrupodeAgengamentoMensagemSic, DatabaseManager.SQLOperation.Like, "%" + agendamentoMensagemSic.NmGrupodeAgengamentoMensagemSic + "%", ref where));
			if (agendamentoMensagemSic.NmGrupoparaAgendamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NmGrupoparaAgendamentoMensagemSic, DatabaseManager.SQLOperation.Like, "%" + agendamentoMensagemSic.NmGrupoparaAgendamentoMensagemSic + "%", ref where));
			if (agendamentoMensagemSic.NmLinkAgendamentoMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AGENDAMENTO_MENSAGEM_SIC", C_NmLinkAgendamentoMensagemSic, DatabaseManager.SQLOperation.Like, "%" + agendamentoMensagemSic.NmLinkAgendamentoMensagemSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

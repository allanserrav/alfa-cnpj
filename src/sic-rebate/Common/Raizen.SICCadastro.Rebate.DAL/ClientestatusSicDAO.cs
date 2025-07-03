#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClientestatusSicDAO.cs
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
	#region classe concreta ClientestatusSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ClientestatusSicDAO
	/// </summary>
	internal partial class ClientestatusSicDAO : IClientestatusSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbClientestatusSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CLIENTESTATUS_SIC.NR_SEQ_CLIENTESTAUS_SIC")
		.Append(",TB_CLIENTESTATUS_SIC.NR_SEQ_STATUS_SIC")
		.Append(",TB_CLIENTESTATUS_SIC.NR_SEQ_CLIENTE_SIC")
		.Append(",TB_CLIENTESTATUS_SIC.DT_ALTERACAO_SIC")
		.Append(",TB_CLIENTESTATUS_SIC.NM_LOGIN_SIC")
		.Append(",TB_CLIENTESTATUS_SIC.DS_OBSERVACAO_SIC")
		.Append(" FROM TB_CLIENTESTATUS_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
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
			IList<ClientestatusSic> listClientestatusSic = new List<ClientestatusSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, clientestatusSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listClientestatusSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listClientestatusSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ClientestatusSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ClientestatusSic preenchido</returns>
		protected ClientestatusSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ClientestatusSic clientestatusSic = new ClientestatusSic();
			clientestatusSic.NrSeqClientestausSic = reader.GetNullableInt32(C_NrSeqClientestausSic);
			clientestatusSic.NrSeqStatusSic = reader.GetNullableInt32(C_NrSeqStatusSic);
			clientestatusSic.NrSeqClienteSic = reader.GetNullableInt32(C_NrSeqClienteSic);
			clientestatusSic.DtAlteracaoSic = reader.GetNullableDateTime(C_DtAlteracaoSic);
			clientestatusSic.NmLoginSic = reader.GetString(C_NmLoginSic);
			clientestatusSic.DsObservacaoSic = reader.GetString(C_DsObservacaoSic);
			return clientestatusSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clientestatusSic">Instance of <see cref="ClientestatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ClientestatusSic clientestatusSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (clientestatusSic.NrSeqClientestausSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTESTATUS_SIC", C_NrSeqClientestausSic, DatabaseManager.SQLOperation.Equal, clientestatusSic.NrSeqClientestausSic, ref where));
			if (clientestatusSic.NrSeqStatusSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTESTATUS_SIC", C_NrSeqStatusSic, DatabaseManager.SQLOperation.Equal, clientestatusSic.NrSeqStatusSic, ref where));
			if (clientestatusSic.NrSeqClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTESTATUS_SIC", C_NrSeqClienteSic, DatabaseManager.SQLOperation.Equal, clientestatusSic.NrSeqClienteSic, ref where));
			if (clientestatusSic.DtAlteracaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CLIENTESTATUS_SIC", C_DtAlteracaoSic, DatabaseManager.SQLOperation.Equal, clientestatusSic.DtAlteracaoSic, ref where));
			if (clientestatusSic.NmLoginSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTESTATUS_SIC", C_NmLoginSic, DatabaseManager.SQLOperation.Like, "%" + clientestatusSic.NmLoginSic + "%", ref where));
			if (clientestatusSic.DsObservacaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTESTATUS_SIC", C_DsObservacaoSic, DatabaseManager.SQLOperation.Like, "%" + clientestatusSic.DsObservacaoSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

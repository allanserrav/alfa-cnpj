#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusSicDAO.cs
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
	#region classe concreta StatusSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusSicDAO
	/// </summary>
	internal partial class StatusSicDAO : IStatusSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbStatusSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_STATUS_SIC.NR_SEQ_STATUS_SIC")
		.Append(",TB_STATUS_SIC.NM_STATUS_SIC")
		.Append(",TB_STATUS_SIC.DS_STATUS_SIC")
		.Append(" FROM TB_STATUS_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusSic</returns>
		public IList<StatusSic> Selecionar(StatusSic statusSic, int numeroLinhas, string ordem)
		{
			IList<StatusSic> listStatusSic = new List<StatusSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, statusSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listStatusSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listStatusSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto StatusSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto StatusSic preenchido</returns>
		protected StatusSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			StatusSic statusSic = new StatusSic();
			statusSic.NrSeqStatusSic = reader.GetNullableInt32(C_NrSeqStatusSic);
			statusSic.NmStatusSic = reader.GetString(C_NmStatusSic);
			statusSic.DsStatusSic = reader.GetString(C_DsStatusSic);
			return statusSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, StatusSic statusSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (statusSic.NrSeqStatusSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_STATUS_SIC", C_NrSeqStatusSic, DatabaseManager.SQLOperation.Equal, statusSic.NrSeqStatusSic, ref where));
			if (statusSic.NmStatusSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_SIC", C_NmStatusSic, DatabaseManager.SQLOperation.Like, "%" + statusSic.NmStatusSic + "%", ref where));
			if (statusSic.DsStatusSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_SIC", C_DsStatusSic, DatabaseManager.SQLOperation.Like, "%" + statusSic.DsStatusSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

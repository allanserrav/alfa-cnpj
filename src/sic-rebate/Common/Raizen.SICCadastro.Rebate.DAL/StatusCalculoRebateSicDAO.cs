#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateSicDAO.cs
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
	#region classe concreta StatusCalculoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusCalculoRebateSicDAO
	/// </summary>
	internal partial class StatusCalculoRebateSicDAO : IStatusCalculoRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbStatusCalculoRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_STATUS_CALCULO_REBATE_SIC.NR_SEQ_STATUS_CALCULO_REBATE_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_SIC.NM_STATUS_CALCULO_REBATE_SIC")
		.Append(",TB_STATUS_CALCULO_REBATE_SIC.DS_STATUS_CALCULO_REBATE_SIC")
		.Append(" FROM TB_STATUS_CALCULO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		public IList<StatusCalculoRebateSic> Selecionar(StatusCalculoRebateSic statusCalculoRebateSic, int numeroLinhas, string ordem)
		{
			IList<StatusCalculoRebateSic> listStatusCalculoRebateSic = new List<StatusCalculoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, statusCalculoRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listStatusCalculoRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listStatusCalculoRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto StatusCalculoRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto StatusCalculoRebateSic preenchido</returns>
		protected StatusCalculoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			StatusCalculoRebateSic statusCalculoRebateSic = new StatusCalculoRebateSic();
			statusCalculoRebateSic.NrSeqStatusCalculoRebateSic = reader.GetNullableInt32(C_NrSeqStatusCalculoRebateSic);
			statusCalculoRebateSic.NmStatusCalculoRebateSic = reader.GetString(C_NmStatusCalculoRebateSic);
			statusCalculoRebateSic.DsStatusCalculoRebateSic = reader.GetString(C_DsStatusCalculoRebateSic);
			return statusCalculoRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, StatusCalculoRebateSic statusCalculoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (statusCalculoRebateSic.NrSeqStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_STATUS_CALCULO_REBATE_SIC", C_NrSeqStatusCalculoRebateSic, DatabaseManager.SQLOperation.Equal, statusCalculoRebateSic.NrSeqStatusCalculoRebateSic, ref where));
			if (statusCalculoRebateSic.NmStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_CALCULO_REBATE_SIC", C_NmStatusCalculoRebateSic, DatabaseManager.SQLOperation.Like, "%" + statusCalculoRebateSic.NmStatusCalculoRebateSic + "%", ref where));
			if (statusCalculoRebateSic.DsStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_STATUS_CALCULO_REBATE_SIC", C_DsStatusCalculoRebateSic, DatabaseManager.SQLOperation.Like, "%" + statusCalculoRebateSic.DsStatusCalculoRebateSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

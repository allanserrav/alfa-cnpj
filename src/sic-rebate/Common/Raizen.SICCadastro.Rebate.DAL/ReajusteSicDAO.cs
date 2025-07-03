#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteSicDAO.cs
// Class Name	        : ReajusteSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	#region classe concreta ReajusteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteSicDAO
	/// </summary>
	internal partial class ReajusteSicDAO : IReajusteSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbReajusteSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_REAJUSTE_SIC.NR_SEQ_REAJUSTE_SIC")
		.Append(",TB_REAJUSTE_SIC.NM_REAJUSTE_SIC")
		.Append(",TB_REAJUSTE_SIC.VL_PERCENT_REAJUSTE_SIC")
		.Append(",TB_REAJUSTE_SIC.DS_REAJUSTE_SIC")
		.Append(" FROM TB_REAJUSTE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		public IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic, int numeroLinhas, string ordem)
		{
			IList<ReajusteSic> listReajusteSic = new List<ReajusteSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, reajusteSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listReajusteSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listReajusteSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ReajusteSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ReajusteSic preenchido</returns>
		protected ReajusteSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ReajusteSic reajusteSic = new ReajusteSic();
			reajusteSic.NrSeqReajusteSic = reader.GetNullableInt32(C_NrSeqReajusteSic);
			reajusteSic.NmReajusteSic = reader.GetString(C_NmReajusteSic);
			reajusteSic.VlPercentReajusteSic = reader.GetNullableDecimal(C_VlPercentReajusteSic);
			reajusteSic.DsReajusteSic = reader.GetString(C_DsReajusteSic);
			return reajusteSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ReajusteSic reajusteSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (reajusteSic.NrSeqReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_SIC", C_NrSeqReajusteSic, DatabaseManager.SQLOperation.Equal, reajusteSic.NrSeqReajusteSic, ref where));
			if (reajusteSic.NmReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REAJUSTE_SIC", C_NmReajusteSic, DatabaseManager.SQLOperation.Like, "%" + reajusteSic.NmReajusteSic + "%", ref where));
			if (reajusteSic.VlPercentReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REAJUSTE_SIC", C_VlPercentReajusteSic, DatabaseManager.SQLOperation.Equal, reajusteSic.VlPercentReajusteSic, ref where));
			if (reajusteSic.DsReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REAJUSTE_SIC", C_DsReajusteSic, DatabaseManager.SQLOperation.Like, "%" + reajusteSic.DsReajusteSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

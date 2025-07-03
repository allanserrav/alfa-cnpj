#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgrupamentoredeRebateSicDAO.cs
// Class Name	        : AgrupamentoredeRebateSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 13/08/2014
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
	#region classe concreta AgrupamentoredeRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AgrupamentoredeRebateSicDAO
	/// </summary>
	internal partial class AgrupamentoredeRebateSicDAO : IAgrupamentoredeRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbAgrupamentoredeRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_AGRUPAMENTOREDE_REBATE_SIC.NR_SEQ_AGRUPAMENTOREDE_REBATE_SIC")
		.Append(",TB_AGRUPAMENTOREDE_REBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_AGRUPAMENTOREDE_REBATE_SIC.NR_IBM_REBATE_SIC")
		.Append(",TB_AGRUPAMENTOREDE_REBATE_SIC.NR_GRUPOREDE_REBATE_SIC")
		.Append(" FROM TB_AGRUPAMENTOREDE_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		public IList<AgrupamentoredeRebateSic> Selecionar(AgrupamentoredeRebateSic agrupamentoredeRebateSic, int numeroLinhas, string ordem)
		{
			IList<AgrupamentoredeRebateSic> listAgrupamentoredeRebateSic = new List<AgrupamentoredeRebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, agrupamentoredeRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listAgrupamentoredeRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listAgrupamentoredeRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto AgrupamentoredeRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto AgrupamentoredeRebateSic preenchido</returns>
		protected AgrupamentoredeRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			AgrupamentoredeRebateSic agrupamentoredeRebateSic = new AgrupamentoredeRebateSic();
			agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic = reader.GetNullableInt32(C_NrSeqAgrupamentoredeRebateSic);
			agrupamentoredeRebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			agrupamentoredeRebateSic.NrIbmRebateSic = reader.GetString(C_NrIbmRebateSic);
			agrupamentoredeRebateSic.NrGruporedeRebateSic = reader.GetNullableInt32(C_NrGruporedeRebateSic);
			return agrupamentoredeRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, AgrupamentoredeRebateSic agrupamentoredeRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AGRUPAMENTOREDE_REBATE_SIC", C_NrSeqAgrupamentoredeRebateSic, DatabaseManager.SQLOperation.Equal, agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic, ref where));
			if (agrupamentoredeRebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AGRUPAMENTOREDE_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, agrupamentoredeRebateSic.NrSeqRebateSic, ref where));
			if (agrupamentoredeRebateSic.NrIbmRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AGRUPAMENTOREDE_REBATE_SIC", C_NrIbmRebateSic, DatabaseManager.SQLOperation.Like, "%" + agrupamentoredeRebateSic.NrIbmRebateSic + "%", ref where));
			if (agrupamentoredeRebateSic.NrGruporedeRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AGRUPAMENTOREDE_REBATE_SIC", C_NrGruporedeRebateSic, DatabaseManager.SQLOperation.Equal, agrupamentoredeRebateSic.NrGruporedeRebateSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

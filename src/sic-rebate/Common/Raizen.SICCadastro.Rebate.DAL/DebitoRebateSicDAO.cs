#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DebitoRebateSicDAO.cs
// Class Name	        : DebitoRebateSicDAO
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
	#region classe concreta DebitoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DebitoRebateSicDAO
	/// </summary>
	internal partial class DebitoRebateSicDAO : IDebitoRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbDebitoRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_DEBITO_REBATE_SIC.NR_SEQ_DEBITO_REBATE_SIC")
		.Append(",TB_DEBITO_REBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_DEBITO_REBATE_SIC.DT_CONSULTA_SIC")
		.Append(",TB_DEBITO_REBATE_SIC.VL_DEBITO_SIC")
		.Append(" FROM TB_DEBITO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		public IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, int numeroLinhas, string ordem)
		{
			IList<DebitoRebateSic> listDebitoRebateSic = new List<DebitoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, debitoRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listDebitoRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listDebitoRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto DebitoRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto DebitoRebateSic preenchido</returns>
		protected DebitoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			DebitoRebateSic debitoRebateSic = new DebitoRebateSic();
			debitoRebateSic.NrSeqDebitoRebateSic = reader.GetNullableInt32(C_NrSeqDebitoRebateSic);
			debitoRebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			debitoRebateSic.DtConsultaSic = reader.GetNullableDateTime(C_DtConsultaSic);
			debitoRebateSic.VlDebitoSic = reader.GetNullableDecimal(C_VlDebitoSic);
			return debitoRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, DebitoRebateSic debitoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (debitoRebateSic.NrSeqDebitoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DEBITO_REBATE_SIC", C_NrSeqDebitoRebateSic, DatabaseManager.SQLOperation.Equal, debitoRebateSic.NrSeqDebitoRebateSic, ref where));
			if (debitoRebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DEBITO_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, debitoRebateSic.NrSeqRebateSic, ref where));
			if (debitoRebateSic.DtConsultaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_DEBITO_REBATE_SIC", C_DtConsultaSic, DatabaseManager.SQLOperation.Equal, debitoRebateSic.DtConsultaSic, ref where));
			if (debitoRebateSic.VlDebitoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_DEBITO_REBATE_SIC", C_VlDebitoSic, DatabaseManager.SQLOperation.Equal, debitoRebateSic.VlDebitoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

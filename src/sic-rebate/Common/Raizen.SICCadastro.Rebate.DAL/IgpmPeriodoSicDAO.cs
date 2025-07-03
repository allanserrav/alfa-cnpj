#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IgpmPeriodoSicDAO.cs
// Class Name	        : IgpmPeriodoSicDAO
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
	#region classe concreta IgpmPeriodoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a IgpmPeriodoSicDAO
	/// </summary>
	internal partial class IgpmPeriodoSicDAO : IIgpmPeriodoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbIgpmPeriodoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_IGPM_PERIODO_SIC.NR_SEQ_IGPM_PERIODO_SIC")
		.Append(",TB_IGPM_PERIODO_SIC.DT_PERIODO_SIC")
		.Append(",TB_IGPM_PERIODO_SIC.DT_PERIODO_FORMATADO_SIC")
		.Append(",TB_IGPM_PERIODO_SIC.VL_FATOR_SIC")
		.Append(",TB_IGPM_PERIODO_SIC.VL_PERCENTUAL_SIC")
		.Append(",TB_IGPM_PERIODO_SIC.DT_ALTERACAO_SIC")
		.Append(" FROM TB_IGPM_PERIODO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		public IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, int numeroLinhas, string ordem)
		{
			IList<IgpmPeriodoSic> listIgpmPeriodoSic = new List<IgpmPeriodoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, igpmPeriodoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listIgpmPeriodoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listIgpmPeriodoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto IgpmPeriodoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto IgpmPeriodoSic preenchido</returns>
		protected IgpmPeriodoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			IgpmPeriodoSic igpmPeriodoSic = new IgpmPeriodoSic();
			igpmPeriodoSic.NrSeqIgpmPeriodoSic = reader.GetNullableInt32(C_NrSeqIgpmPeriodoSic);
			igpmPeriodoSic.DtPeriodoSic = reader.GetNullableDateTime(C_DtPeriodoSic);
			igpmPeriodoSic.DtPeriodoFormatadoSic = reader.GetString(C_DtPeriodoFormatadoSic);
			igpmPeriodoSic.VlFatorSic = reader.GetNullableDecimal(C_VlFatorSic);
			igpmPeriodoSic.VlPercentualSic = reader.GetNullableDecimal(C_VlPercentualSic);
			igpmPeriodoSic.DtAlteracaoSic = reader.GetNullableDateTime(C_DtAlteracaoSic);
			return igpmPeriodoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, IgpmPeriodoSic igpmPeriodoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (igpmPeriodoSic.NrSeqIgpmPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_IGPM_PERIODO_SIC", C_NrSeqIgpmPeriodoSic, DatabaseManager.SQLOperation.Equal, igpmPeriodoSic.NrSeqIgpmPeriodoSic, ref where));
			if (igpmPeriodoSic.DtPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_IGPM_PERIODO_SIC", C_DtPeriodoSic, DatabaseManager.SQLOperation.Equal, igpmPeriodoSic.DtPeriodoSic, ref where));
			if (igpmPeriodoSic.DtPeriodoFormatadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_IGPM_PERIODO_SIC", C_DtPeriodoFormatadoSic, DatabaseManager.SQLOperation.Like, "%" + igpmPeriodoSic.DtPeriodoFormatadoSic + "%", ref where));
			if (igpmPeriodoSic.VlFatorSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_IGPM_PERIODO_SIC", C_VlFatorSic, DatabaseManager.SQLOperation.Equal, igpmPeriodoSic.VlFatorSic, ref where));
			if (igpmPeriodoSic.VlPercentualSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_IGPM_PERIODO_SIC", C_VlPercentualSic, DatabaseManager.SQLOperation.Equal, igpmPeriodoSic.VlPercentualSic, ref where));
			if (igpmPeriodoSic.DtAlteracaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_IGPM_PERIODO_SIC", C_DtAlteracaoSic, DatabaseManager.SQLOperation.Equal, igpmPeriodoSic.DtAlteracaoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

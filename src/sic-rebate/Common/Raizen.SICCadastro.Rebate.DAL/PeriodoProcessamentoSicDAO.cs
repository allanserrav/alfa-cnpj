#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : PeriodoProcessamentoSicDAO.cs
// Class Name	        : PeriodoProcessamentoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 18/01/2013
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
	#region classe concreta PeriodoProcessamentoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a PeriodoProcessamentoSicDAO
	/// </summary>
	internal partial class PeriodoProcessamentoSicDAO : IPeriodoProcessamentoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbPeriodoProcessamentoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_PERIODO_PROCESSAMENTO_SIC.NR_SEQ_PERIODO_PROCESSAMENTO_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_SEQ_TIPOFRANQUIA_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_SEQ_TIPOREBATE_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_DIA_INICIO_PERIODO_PROCESSAMENTO_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_DIA_FIM_PERIODO_PROCESSAMENTO_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_DIA_INICIO_CALCULO_SIC")
		.Append(",TB_PERIODO_PROCESSAMENTO_SIC.NR_DIA_EMISSAO_COBRANCA")
		.Append(" FROM TB_PERIODO_PROCESSAMENTO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		public IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, int numeroLinhas, string ordem)
		{
			IList<PeriodoProcessamentoSic> listPeriodoProcessamentoSic = new List<PeriodoProcessamentoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, periodoProcessamentoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listPeriodoProcessamentoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listPeriodoProcessamentoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto PeriodoProcessamentoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto PeriodoProcessamentoSic preenchido</returns>
		protected PeriodoProcessamentoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			PeriodoProcessamentoSic periodoProcessamentoSic = new PeriodoProcessamentoSic();
			periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic = reader.GetNullableInt32(C_NrSeqPeriodoProcessamentoSic);
			periodoProcessamentoSic.NrSeqTipofranquiaSic = reader.GetNullableInt32(C_NrSeqTipofranquiaSic);
			periodoProcessamentoSic.NrSeqTiporebateSic = reader.GetNullableInt32(C_NrSeqTiporebateSic);
			periodoProcessamentoSic.NrDiaInicioPeriodoProcessamentoSic = reader.GetNullableInt32(C_NrDiaInicioPeriodoProcessamentoSic);
			periodoProcessamentoSic.NrDiaFimPeriodoProcessamentoSic = reader.GetNullableInt32(C_NrDiaFimPeriodoProcessamentoSic);
			periodoProcessamentoSic.NrDiaInicioCalculoSic = reader.GetNullableInt32(C_NrDiaInicioCalculoSic);
			periodoProcessamentoSic.NrDiaEmissaoCobranca = reader.GetNullableInt32(C_NrDiaEmissaoCobranca);
			return periodoProcessamentoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, PeriodoProcessamentoSic periodoProcessamentoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrSeqPeriodoProcessamentoSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic, ref where));
			if (periodoProcessamentoSic.NrSeqTipofranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrSeqTipofranquiaSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrSeqTipofranquiaSic, ref where));
			if (periodoProcessamentoSic.NrSeqTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrSeqTiporebateSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrSeqTiporebateSic, ref where));
			if (periodoProcessamentoSic.NrDiaInicioPeriodoProcessamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrDiaInicioPeriodoProcessamentoSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrDiaInicioPeriodoProcessamentoSic, ref where));
			if (periodoProcessamentoSic.NrDiaFimPeriodoProcessamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrDiaFimPeriodoProcessamentoSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrDiaFimPeriodoProcessamentoSic, ref where));
			if (periodoProcessamentoSic.NrDiaInicioCalculoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrDiaInicioCalculoSic, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrDiaInicioCalculoSic, ref where));
			if (periodoProcessamentoSic.NrDiaEmissaoCobranca != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PERIODO_PROCESSAMENTO_SIC", C_NrDiaEmissaoCobranca, DatabaseManager.SQLOperation.Equal, periodoProcessamentoSic.NrDiaEmissaoCobranca, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

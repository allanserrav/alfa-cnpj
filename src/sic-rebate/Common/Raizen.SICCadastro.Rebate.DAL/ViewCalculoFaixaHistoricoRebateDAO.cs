#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewCalculoFaixaHistoricoRebateDAO.cs
// Class Name	        : ViewCalculoFaixaHistoricoRebateDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 29/01/2013
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
	#region classe concreta ViewCalculoFaixaHistoricoRebateDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ViewCalculoFaixaHistoricoRebateDAO
	/// </summary>
	internal partial class ViewCalculoFaixaHistoricoRebateDAO : IViewCalculoFaixaHistoricoRebateDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbViewCalculoFaixaHistoricoRebate
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_PERIODO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_BONIFICACAO_TOTAL_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.ST_ADITIVO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_PERIODO_VOLUME")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_FAIXAREBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_CATEGORIA_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_VOLUME_CONTRATADO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_VOLUME_MAXIMO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_VOLUME_MINIMO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_BONIFICACAO_CALCULADO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_INICIOCALCULO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_FIMCALCULO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_VOLUMEMENSAL_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_PERCMINIMO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_PERCMAXIMO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_BONIFICACAO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_RECEBEBONUS_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_CATEGORIA_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_RAZSOCIALLOJA_FRANQUIA_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_IBM_CLIENTE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_CEGRPOSTO_CLIENTE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_GALOJA_CLIENTE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_GTLOJA_CLIENTE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_CANAL_CLIENTE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_CODIGOPAGADOR_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_ASSINATURACONTRATO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_FIMVIGENCIA_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.DT_PAGAMENTO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_TIPOREBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_TIPOREBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_GRUPO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_EMPRESA_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_DEBITO_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NR_SEQ_STATUS_CALCULO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.NM_STATUS_CALCULO_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE.VL_VOLUME_COMPRADO_SIC")
		.Append(" FROM VIEW_CALCULO_FAIXA_HISTORICO_REBATE")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		public IList<ViewCalculoFaixaHistoricoRebate> Selecionar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, int numeroLinhas, string ordem)
		{
			IList<ViewCalculoFaixaHistoricoRebate> listViewCalculoFaixaHistoricoRebate = new List<ViewCalculoFaixaHistoricoRebate>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, viewCalculoFaixaHistoricoRebate, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listViewCalculoFaixaHistoricoRebate.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listViewCalculoFaixaHistoricoRebate;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ViewCalculoFaixaHistoricoRebate a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ViewCalculoFaixaHistoricoRebate preenchido</returns>
		protected ViewCalculoFaixaHistoricoRebate Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate = new ViewCalculoFaixaHistoricoRebate();
			viewCalculoFaixaHistoricoRebate.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			viewCalculoFaixaHistoricoRebate.DtPeriodoSic = reader.GetNullableDateTime(C_DtPeriodoSic);
			viewCalculoFaixaHistoricoRebate.VlBonificacaoTotalSic = reader.GetNullableDecimal(C_VlBonificacaoTotalSic);
			viewCalculoFaixaHistoricoRebate.StAditivoSic = reader.GetNullableBoolean(C_StAditivoSic);
			viewCalculoFaixaHistoricoRebate.DtPeriodoVolume = reader.GetNullableDateTime(C_DtPeriodoVolume);
			viewCalculoFaixaHistoricoRebate.NrSeqFaixarebateSic = reader.GetNullableInt32(C_NrSeqFaixarebateSic);
			viewCalculoFaixaHistoricoRebate.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			viewCalculoFaixaHistoricoRebate.VlVolumeContratadoSic = reader.GetNullableDecimal(C_VlVolumeContratadoSic);
			viewCalculoFaixaHistoricoRebate.VlVolumeMaximoSic = reader.GetNullableDecimal(C_VlVolumeMaximoSic);
			viewCalculoFaixaHistoricoRebate.VlVolumeMinimoSic = reader.GetNullableDecimal(C_VlVolumeMinimoSic);
			viewCalculoFaixaHistoricoRebate.VlBonificacaoCalculadoSic = reader.GetNullableDecimal(C_VlBonificacaoCalculadoSic);
			viewCalculoFaixaHistoricoRebate.DtIniciocalculoRebateSic = reader.GetNullableDateTime(C_DtIniciocalculoRebateSic);
			viewCalculoFaixaHistoricoRebate.DtFimcalculoRebateSic = reader.GetNullableDateTime(C_DtFimcalculoRebateSic);
			viewCalculoFaixaHistoricoRebate.VlVolumemensalRebateSic = reader.GetNullableDecimal(C_VlVolumemensalRebateSic);
			viewCalculoFaixaHistoricoRebate.VlPercminimoRebateSic = reader.GetNullableDecimal(C_VlPercminimoRebateSic);
			viewCalculoFaixaHistoricoRebate.VlPercmaximoRebateSic = reader.GetNullableDecimal(C_VlPercmaximoRebateSic);
			viewCalculoFaixaHistoricoRebate.VlBonificacaoRebateSic = reader.GetNullableDecimal(C_VlBonificacaoRebateSic);
			viewCalculoFaixaHistoricoRebate.VlRecebebonusRebateSic = reader.GetNullableDecimal(C_VlRecebebonusRebateSic);
			viewCalculoFaixaHistoricoRebate.NmCategoriaSic = reader.GetString(C_NmCategoriaSic);
			viewCalculoFaixaHistoricoRebate.NmRazsociallojaFranquiaSic = reader.GetString(C_NmRazsociallojaFranquiaSic);
			viewCalculoFaixaHistoricoRebate.NrIbmClienteSic = reader.GetString(C_NrIbmClienteSic);
			viewCalculoFaixaHistoricoRebate.NrCegrpostoClienteSic = reader.GetString(C_NrCegrpostoClienteSic);
			viewCalculoFaixaHistoricoRebate.NmGalojaClienteSic = reader.GetString(C_NmGalojaClienteSic);
			viewCalculoFaixaHistoricoRebate.NmGtlojaClienteSic = reader.GetString(C_NmGtlojaClienteSic);
			viewCalculoFaixaHistoricoRebate.NmCanalClienteSic = reader.GetString(C_NmCanalClienteSic);
			viewCalculoFaixaHistoricoRebate.NrCodigopagadorRebateSic = reader.GetString(C_NrCodigopagadorRebateSic);
			viewCalculoFaixaHistoricoRebate.NrCodigofornecedorRebateSic = reader.GetString(C_NrCodigofornecedorRebateSic);
			viewCalculoFaixaHistoricoRebate.DtAssinaturacontratoRebateSic = reader.GetNullableDateTime(C_DtAssinaturacontratoRebateSic);
			viewCalculoFaixaHistoricoRebate.DtFimvigenciaRebateSic = reader.GetNullableDateTime(C_DtFimvigenciaRebateSic);
			viewCalculoFaixaHistoricoRebate.DtPagamentoSic = reader.GetNullableDateTime(C_DtPagamentoSic);
			viewCalculoFaixaHistoricoRebate.NrSeqTiporebateSic = reader.GetNullableInt32(C_NrSeqTiporebateSic);
			viewCalculoFaixaHistoricoRebate.NmTiporebateSic = reader.GetString(C_NmTiporebateSic);
			viewCalculoFaixaHistoricoRebate.NrSeqGrupoSic = reader.GetNullableInt32(C_NrSeqGrupoSic);
			viewCalculoFaixaHistoricoRebate.NmEmpresaSic = reader.GetString(C_NmEmpresaSic);
			viewCalculoFaixaHistoricoRebate.VlDebitoSic = reader.GetNullableDecimal(C_VlDebitoSic);
			viewCalculoFaixaHistoricoRebate.NrSeqStatusCalculoRebateSic = reader.GetNullableInt32(C_NrSeqStatusCalculoRebateSic);
			viewCalculoFaixaHistoricoRebate.NmStatusCalculoRebateSic = reader.GetString(C_NmStatusCalculoRebateSic);
			viewCalculoFaixaHistoricoRebate.VlVolumeCompradoSic = reader.GetNullableDecimal(C_VlVolumeCompradoSic);
			return viewCalculoFaixaHistoricoRebate;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (viewCalculoFaixaHistoricoRebate.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtPeriodoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtPeriodoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlBonificacaoTotalSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlBonificacaoTotalSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlBonificacaoTotalSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.StAditivoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_StAditivoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.StAditivoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtPeriodoVolume != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtPeriodoVolume, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtPeriodoVolume, ref where));
			if (viewCalculoFaixaHistoricoRebate.NrSeqFaixarebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqFaixarebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqFaixarebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqCategoriaSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlVolumeContratadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlVolumeContratadoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlVolumeContratadoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlVolumeMaximoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlVolumeMaximoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlVolumeMaximoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlVolumeMinimoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlVolumeMinimoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlVolumeMinimoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlBonificacaoCalculadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlBonificacaoCalculadoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlBonificacaoCalculadoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtIniciocalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtIniciocalculoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtIniciocalculoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtFimcalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtFimcalculoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtFimcalculoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlVolumemensalRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlVolumemensalRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlVolumemensalRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlPercminimoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlPercminimoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlPercminimoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlPercmaximoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlPercmaximoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlPercmaximoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlBonificacaoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlBonificacaoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlBonificacaoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.VlRecebebonusRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlRecebebonusRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlRecebebonusRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NmCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmCategoriaSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmCategoriaSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NmRazsociallojaFranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmRazsociallojaFranquiaSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmRazsociallojaFranquiaSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NrIbmClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrIbmClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NrIbmClienteSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NrCegrpostoClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrCegrpostoClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NrCegrpostoClienteSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NmGalojaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmGalojaClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmGalojaClienteSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NmGtlojaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmGtlojaClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmGtlojaClienteSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NmCanalClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmCanalClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmCanalClienteSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NrCodigopagadorRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrCodigopagadorRebateSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NrCodigopagadorRebateSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NrCodigofornecedorRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrCodigofornecedorRebateSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NrCodigofornecedorRebateSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.DtAssinaturacontratoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtAssinaturacontratoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtAssinaturacontratoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtFimvigenciaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtFimvigenciaRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtFimvigenciaRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.DtPagamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_DtPagamentoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.DtPagamentoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NrSeqTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqTiporebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqTiporebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NmTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmTiporebateSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmTiporebateSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.NrSeqGrupoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqGrupoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqGrupoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NmEmpresaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmEmpresaSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmEmpresaSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.VlDebitoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlDebitoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlDebitoSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NrSeqStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NrSeqStatusCalculoRebateSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.NrSeqStatusCalculoRebateSic, ref where));
			if (viewCalculoFaixaHistoricoRebate.NmStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_NmStatusCalculoRebateSic, DatabaseManager.SQLOperation.Like, "%" + viewCalculoFaixaHistoricoRebate.NmStatusCalculoRebateSic + "%", ref where));
			if (viewCalculoFaixaHistoricoRebate.VlVolumeCompradoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE", C_VlVolumeCompradoSic, DatabaseManager.SQLOperation.Equal, viewCalculoFaixaHistoricoRebate.VlVolumeCompradoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

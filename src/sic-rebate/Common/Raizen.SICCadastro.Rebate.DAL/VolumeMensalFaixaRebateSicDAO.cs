#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeMensalFaixaRebateSicDAO.cs
// Class Name	        : VolumeMensalFaixaRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 28/01/2013
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
	#region classe concreta VolumeMensalFaixaRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a VolumeMensalFaixaRebateSicDAO
	/// </summary>
	internal partial class VolumeMensalFaixaRebateSicDAO : IVolumeMensalFaixaRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbVolumeMensalFaixaRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.NR_SEQ_FAIXAREBATE_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.VL_VOLUME_COMPRADO_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.DT_PERIODO_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.ST_VOLUME_ENCONTRADO")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_VOLUME_MENSAL_FAIXA_REBATE_SIC.DT_GRAVACAO_SIC")
		.Append(" FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instância de <see cref="VolumeMensalFaixaRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeMensalFaixaRebateSic</returns>
		public IList<VolumeMensalFaixaRebateSic> Selecionar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, int numeroLinhas, string ordem)
		{
			IList<VolumeMensalFaixaRebateSic> listVolumeMensalFaixaRebateSic = new List<VolumeMensalFaixaRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, volumeMensalFaixaRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listVolumeMensalFaixaRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listVolumeMensalFaixaRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto VolumeMensalFaixaRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto VolumeMensalFaixaRebateSic preenchido</returns>
		protected VolumeMensalFaixaRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic = new VolumeMensalFaixaRebateSic();
			volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic = reader.GetNullableInt32(C_NrSeqVolumeMensalFaixaRebateSic);
			volumeMensalFaixaRebateSic.NrSeqFaixarebateSic = reader.GetNullableInt32(C_NrSeqFaixarebateSic);
			volumeMensalFaixaRebateSic.NrSeqFaixaRebateHistoricoSic = reader.GetNullableInt32(C_NrSeqFaixaRebateHistoricoSic);
			volumeMensalFaixaRebateSic.VlVolumeCompradoSic = reader.GetNullableDecimal(C_VlVolumeCompradoSic);
			volumeMensalFaixaRebateSic.DtPeriodoSic = reader.GetNullableDateTime(C_DtPeriodoSic);
			volumeMensalFaixaRebateSic.StVolumeEncontrado = reader.GetNullableBoolean(C_StVolumeEncontrado);
			volumeMensalFaixaRebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			volumeMensalFaixaRebateSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			volumeMensalFaixaRebateSic.DtGravacaoSic = reader.GetNullableDateTime(C_DtGravacaoSic);
			return volumeMensalFaixaRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_NrSeqVolumeMensalFaixaRebateSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic, ref where));
			if (volumeMensalFaixaRebateSic.NrSeqFaixarebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_NrSeqFaixarebateSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.NrSeqFaixarebateSic, ref where));
			if (volumeMensalFaixaRebateSic.NrSeqFaixaRebateHistoricoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_NrSeqFaixaRebateHistoricoSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.NrSeqFaixaRebateHistoricoSic, ref where));
			if (volumeMensalFaixaRebateSic.VlVolumeCompradoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_VlVolumeCompradoSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.VlVolumeCompradoSic, ref where));
			if (volumeMensalFaixaRebateSic.DtPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_DtPeriodoSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.DtPeriodoSic, ref where));
			if (volumeMensalFaixaRebateSic.StVolumeEncontrado != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_StVolumeEncontrado, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.StVolumeEncontrado, ref where));
			if (volumeMensalFaixaRebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.NrSeqRebateSic, ref where));
			if (volumeMensalFaixaRebateSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.NrSeqCategoriaSic, ref where));
			if (volumeMensalFaixaRebateSic.DtGravacaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_VOLUME_MENSAL_FAIXA_REBATE_SIC", C_DtGravacaoSic, DatabaseManager.SQLOperation.Equal, volumeMensalFaixaRebateSic.DtGravacaoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateFaixaSicDAO.cs
// Class Name	        : CalculoRebateFaixaSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 04/01/2013
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
	#region classe concreta CalculoRebateFaixaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateFaixaSicDAO
	/// </summary>
	internal partial class CalculoRebateFaixaSicDAO : ICalculoRebateFaixaSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbCalculoRebateFaixaSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CALCULO_REBATE_FAIXA_SIC.NR_SEQ_CALCULO_REBATE_FAIXA_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.NR_SEQ_CALCULO_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.VL_VOLUME_MAXIMO_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.VL_VOLUME_MINIMO_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.VL_VOLUME_CALCULADO_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.VL_BONIFICACAO_CALCULADO_SIC")
		.Append(",TB_CALCULO_REBATE_FAIXA_SIC.VL_VOLUME_CONTRATADO_SIC")
		.Append(" FROM TB_CALCULO_REBATE_FAIXA_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		public IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic, int numeroLinhas, string ordem)
		{
			IList<CalculoRebateFaixaSic> listCalculoRebateFaixaSic = new List<CalculoRebateFaixaSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, calculoRebateFaixaSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listCalculoRebateFaixaSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listCalculoRebateFaixaSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto CalculoRebateFaixaSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto CalculoRebateFaixaSic preenchido</returns>
		protected CalculoRebateFaixaSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			CalculoRebateFaixaSic calculoRebateFaixaSic = new CalculoRebateFaixaSic();
			calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = reader.GetNullableInt32(C_NrSeqCalculoRebateFaixaSic);
			calculoRebateFaixaSic.NrSeqCalculoRebateSic = reader.GetNullableInt32(C_NrSeqCalculoRebateSic);
			calculoRebateFaixaSic.VlVolumeMaximoSic = reader.GetNullableDecimal(C_VlVolumeMaximoSic);
			calculoRebateFaixaSic.VlVolumeMinimoSic = reader.GetNullableDecimal(C_VlVolumeMinimoSic);
			calculoRebateFaixaSic.VlVolumeCalculadoSic = reader.GetNullableDecimal(C_VlVolumeCalculadoSic);
			calculoRebateFaixaSic.VlBonificacaoCalculadoSic = reader.GetNullableDecimal(C_VlBonificacaoCalculadoSic);
			calculoRebateFaixaSic.VlVolumeContratadoSic = reader.GetNullableDecimal(C_VlVolumeContratadoSic);
			return calculoRebateFaixaSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, CalculoRebateFaixaSic calculoRebateFaixaSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_FAIXA_SIC", C_NrSeqCalculoRebateFaixaSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, ref where));
			if (calculoRebateFaixaSic.NrSeqCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_FAIXA_SIC", C_NrSeqCalculoRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.NrSeqCalculoRebateSic, ref where));
			if (calculoRebateFaixaSic.VlVolumeMaximoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_FAIXA_SIC", C_VlVolumeMaximoSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.VlVolumeMaximoSic, ref where));
			if (calculoRebateFaixaSic.VlVolumeMinimoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_FAIXA_SIC", C_VlVolumeMinimoSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.VlVolumeMinimoSic, ref where));
			if (calculoRebateFaixaSic.VlVolumeCalculadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_FAIXA_SIC", C_VlVolumeCalculadoSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.VlVolumeCalculadoSic, ref where));
			if (calculoRebateFaixaSic.VlBonificacaoCalculadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_FAIXA_SIC", C_VlBonificacaoCalculadoSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.VlBonificacaoCalculadoSic, ref where));
			if (calculoRebateFaixaSic.VlVolumeContratadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_FAIXA_SIC", C_VlVolumeContratadoSic, DatabaseManager.SQLOperation.Equal, calculoRebateFaixaSic.VlVolumeContratadoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateProporcionalSicDAO.cs
// Class Name	        : CalculoRebateProporcionalSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 22/08/2014
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
	#region classe concreta CalculoRebateProporcionalSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateProporcionalSicDAO
	/// </summary>
	internal partial class CalculoRebateProporcionalSicDAO : ICalculoRebateProporcionalSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbCalculoRebateProporcionalSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CALCULO_REBATE_PROPORCIONAL_SIC.NR_SEQ_CALCULO_PROPORCIONAL_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.NR_SEQ_CALCULO_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.NR_SEQ_CLIENTE_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.NR_IBM_CLIENTE_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.VL_PROPORCAO_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.VL_VALOR_BONIFICACAO_PROPORCIONAL_SIC")
		.Append(",TB_CALCULO_REBATE_PROPORCIONAL_SIC.VL_VOLUME_CALCULADO_SIC")
		.Append(" FROM TB_CALCULO_REBATE_PROPORCIONAL_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		public IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, int numeroLinhas, string ordem)
		{
			IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic = new List<CalculoRebateProporcionalSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, calculoRebateProporcionalSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listCalculoRebateProporcionalSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listCalculoRebateProporcionalSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto CalculoRebateProporcionalSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto CalculoRebateProporcionalSic preenchido</returns>
		protected CalculoRebateProporcionalSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			CalculoRebateProporcionalSic calculoRebateProporcionalSic = new CalculoRebateProporcionalSic();
			calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic = reader.GetNullableInt32(C_NrSeqCalculoProporcionalRebateSic);
			calculoRebateProporcionalSic.NrSeqCalculoRebateSic = reader.GetNullableInt32(C_NrSeqCalculoRebateSic);
			calculoRebateProporcionalSic.NrSeqClienteSic = reader.GetNullableInt32(C_NrSeqClienteSic);
			calculoRebateProporcionalSic.NrIbmClienteSic = reader.GetString(C_NrIbmClienteSic);
			calculoRebateProporcionalSic.VlProporcaoSic = reader.GetNullableDecimal(C_VlProporcaoSic);
			calculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic = reader.GetNullableDecimal(C_VlValorBonificacaoProporcionalSic);
			calculoRebateProporcionalSic.VlVolumeCalculadoSic = reader.GetNullableDecimal(C_VlVolumeCalculadoSic);
			return calculoRebateProporcionalSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, CalculoRebateProporcionalSic calculoRebateProporcionalSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_NrSeqCalculoProporcionalRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic, ref where));
			if (calculoRebateProporcionalSic.NrSeqCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_NrSeqCalculoRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.NrSeqCalculoRebateSic, ref where));
			if (calculoRebateProporcionalSic.NrSeqClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_NrSeqClienteSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.NrSeqClienteSic, ref where));
			if (calculoRebateProporcionalSic.NrIbmClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_NrIbmClienteSic, DatabaseManager.SQLOperation.Like, "%" + calculoRebateProporcionalSic.NrIbmClienteSic + "%", ref where));
			if (calculoRebateProporcionalSic.VlProporcaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_VlProporcaoSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.VlProporcaoSic, ref where));
			if (calculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_VlValorBonificacaoProporcionalSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic, ref where));
			if (calculoRebateProporcionalSic.VlVolumeCalculadoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_PROPORCIONAL_SIC", C_VlVolumeCalculadoSic, DatabaseManager.SQLOperation.Equal, calculoRebateProporcionalSic.VlVolumeCalculadoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

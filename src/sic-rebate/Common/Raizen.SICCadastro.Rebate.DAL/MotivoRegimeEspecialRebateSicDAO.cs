#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MotivoRegimeEspecialRebateSicDAO.cs
// Class Name	        : MotivoRegimeEspecialRebateSicDAO
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
	#region classe concreta MotivoRegimeEspecialRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MotivoRegimeEspecialRebateSicDAO
	/// </summary>
	internal partial class MotivoRegimeEspecialRebateSicDAO : IMotivoRegimeEspecialRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbMotivoRegimeEspecialRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC.NR_SEQ_MOTIVO_REGIME_ESPECIAL_REBATE_SIC")
		.Append(",TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC.CD_MOTIVO_SIC")
		.Append(",TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC.DS_MOTIVO_SIC")
		.Append(" FROM TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		public IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, int numeroLinhas, string ordem)
		{
			IList<MotivoRegimeEspecialRebateSic> listMotivoRegimeEspecialRebateSic = new List<MotivoRegimeEspecialRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, motivoRegimeEspecialRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listMotivoRegimeEspecialRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listMotivoRegimeEspecialRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto MotivoRegimeEspecialRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto MotivoRegimeEspecialRebateSic preenchido</returns>
		protected MotivoRegimeEspecialRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic = new MotivoRegimeEspecialRebateSic();
			motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic = reader.GetNullableInt32(C_NrSeqMotivoRegimeEspecialRebateSic);
			motivoRegimeEspecialRebateSic.CdMotivoSic = reader.GetString(C_CdMotivoSic);
			motivoRegimeEspecialRebateSic.DsMotivoSic = reader.GetString(C_DsMotivoSic);
			return motivoRegimeEspecialRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC", C_NrSeqMotivoRegimeEspecialRebateSic, DatabaseManager.SQLOperation.Equal, motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic, ref where));
			if (motivoRegimeEspecialRebateSic.CdMotivoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC", C_CdMotivoSic, DatabaseManager.SQLOperation.Like, "%" + motivoRegimeEspecialRebateSic.CdMotivoSic + "%", ref where));
			if (motivoRegimeEspecialRebateSic.DsMotivoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC", C_DsMotivoSic, DatabaseManager.SQLOperation.Like, "%" + motivoRegimeEspecialRebateSic.DsMotivoSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

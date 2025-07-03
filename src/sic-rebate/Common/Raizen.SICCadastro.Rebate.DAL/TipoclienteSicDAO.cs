#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TipoclienteSicDAO.cs
// Class Name	        : TipoclienteSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 26/09/2012
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
	#region classe concreta TipoclienteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TipoclienteSicDAO
	/// </summary>
	internal partial class TipoclienteSicDAO : ITipoclienteSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbTipoclienteSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_TIPOCLIENTE_SIC.NR_SEQ_TIPOCLIENTE_SIC")
		.Append(",TB_TIPOCLIENTE_SIC.NM_TIPOCLIENTE_SIC")
		.Append(",TB_TIPOCLIENTE_SIC.DS_TIPOCLIENTE_SIC")
		.Append(" FROM TB_TIPOCLIENTE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		public IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic, int numeroLinhas, string ordem)
		{
			IList<TipoclienteSic> listTipoclienteSic = new List<TipoclienteSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, tipoclienteSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listTipoclienteSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listTipoclienteSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto TipoclienteSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto TipoclienteSic preenchido</returns>
		protected TipoclienteSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			TipoclienteSic tipoclienteSic = new TipoclienteSic();
			tipoclienteSic.NrSeqTipoclienteSic = reader.GetNullableInt32(C_NrSeqTipoclienteSic);
			tipoclienteSic.NmTipoclienteSic = reader.GetString(C_NmTipoclienteSic);
			tipoclienteSic.DsTipoclienteSic = reader.GetString(C_DsTipoclienteSic);
			return tipoclienteSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, TipoclienteSic tipoclienteSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (tipoclienteSic.NrSeqTipoclienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_TIPOCLIENTE_SIC", C_NrSeqTipoclienteSic, DatabaseManager.SQLOperation.Equal, tipoclienteSic.NrSeqTipoclienteSic, ref where));
			if (tipoclienteSic.NmTipoclienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_TIPOCLIENTE_SIC", C_NmTipoclienteSic, DatabaseManager.SQLOperation.Like, "%" + tipoclienteSic.NmTipoclienteSic + "%", ref where));
			if (tipoclienteSic.DsTipoclienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_TIPOCLIENTE_SIC", C_DsTipoclienteSic, DatabaseManager.SQLOperation.Like, "%" + tipoclienteSic.DsTipoclienteSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

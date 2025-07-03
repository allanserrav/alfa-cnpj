#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MatrizfilialrebateSicDAO.cs
// Class Name	        : MatrizfilialrebateSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 29/07/2014
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
	#region classe concreta MatrizfilialrebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MatrizfilialrebateSicDAO
	/// </summary>
	internal partial class MatrizfilialrebateSicDAO : IMatrizfilialrebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbMatrizfilialrebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_MATRIZFILIALREBATE_SIC.NR_SEQ_MATRIZFILIALREBATE_SIC")
		.Append(",TB_MATRIZFILIALREBATE_SIC.NR_SEQ_REBATEMATRIZ_SIC")
		.Append(",TB_MATRIZFILIALREBATE_SIC.NR_IBM_FILIAL_SIC")
		.Append(",TB_MATRIZFILIALREBATE_SIC.NR_CDFORNECEDOR_FILIAL_SIC")
		.Append(" FROM TB_MATRIZFILIALREBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		public IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic, int numeroLinhas, string ordem)
		{
			IList<MatrizfilialrebateSic> listMatrizfilialrebateSic = new List<MatrizfilialrebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, matrizfilialrebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listMatrizfilialrebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listMatrizfilialrebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto MatrizfilialrebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto MatrizfilialrebateSic preenchido</returns>
		protected MatrizfilialrebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			MatrizfilialrebateSic matrizfilialrebateSic = new MatrizfilialrebateSic();
			matrizfilialrebateSic.NrSeqMatrizfilialrebateSic = reader.GetNullableInt32(C_NrSeqMatrizfilialrebateSic);
			matrizfilialrebateSic.NrSeqRebatematrizSic = reader.GetNullableInt32(C_NrSeqRebatematrizSic);
			matrizfilialrebateSic.NrIbmFilialSic = reader.GetString(C_NrIbmFilialSic);
			matrizfilialrebateSic.NrCdfornecedorFilialSic = reader.GetString(C_NrCdfornecedorFilialSic);
			return matrizfilialrebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, MatrizfilialrebateSic matrizfilialrebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (matrizfilialrebateSic.NrSeqMatrizfilialrebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_MATRIZFILIALREBATE_SIC", C_NrSeqMatrizfilialrebateSic, DatabaseManager.SQLOperation.Equal, matrizfilialrebateSic.NrSeqMatrizfilialrebateSic, ref where));
			if (matrizfilialrebateSic.NrSeqRebatematrizSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_MATRIZFILIALREBATE_SIC", C_NrSeqRebatematrizSic, DatabaseManager.SQLOperation.Equal, matrizfilialrebateSic.NrSeqRebatematrizSic, ref where));
			if (matrizfilialrebateSic.NrIbmFilialSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MATRIZFILIALREBATE_SIC", C_NrIbmFilialSic, DatabaseManager.SQLOperation.Like, "%" + matrizfilialrebateSic.NrIbmFilialSic + "%", ref where));
			if (matrizfilialrebateSic.NrCdfornecedorFilialSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MATRIZFILIALREBATE_SIC", C_NrCdfornecedorFilialSic, DatabaseManager.SQLOperation.Like, "%" + matrizfilialrebateSic.NrCdfornecedorFilialSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

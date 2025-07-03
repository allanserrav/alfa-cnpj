#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ProdutoSicDAO.cs
// Class Name	        : ProdutoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 31/10/2012
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
	#region classe concreta ProdutoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ProdutoSicDAO
	/// </summary>
	internal partial class ProdutoSicDAO : IProdutoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbProdutoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_PRODUTO_SIC.NR_SEQ_PRODUTO_SIC")
		.Append(",TB_PRODUTO_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_PRODUTO_SIC.NM_PRODUTO_SIC")
		.Append(",TB_PRODUTO_SIC.DS_PRODUTO_SIC")
		.Append(",TB_PRODUTO_SIC.CD_SAP_PRODUTO_SIC")
		.Append(",TB_PRODUTO_SIC.CD_BARRA_PRODUTO_SIC")
		.Append(" FROM TB_PRODUTO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		public IList<ProdutoSic> Selecionar(ProdutoSic produtoSic, int numeroLinhas, string ordem)
		{
			IList<ProdutoSic> listProdutoSic = new List<ProdutoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, produtoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listProdutoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listProdutoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ProdutoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ProdutoSic preenchido</returns>
		protected ProdutoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ProdutoSic produtoSic = new ProdutoSic();
			produtoSic.NrSeqProdutoSic = reader.GetNullableInt32(C_NrSeqProdutoSic);
			produtoSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			produtoSic.NmProdutoSic = reader.GetString(C_NmProdutoSic);
			produtoSic.DsProdutoSic = reader.GetString(C_DsProdutoSic);
			produtoSic.CdSapProdutoSic = reader.GetString(C_CdSapProdutoSic);
			produtoSic.CdBarraProdutoSic = reader.GetString(C_CdBarraProdutoSic);
			return produtoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ProdutoSic produtoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (produtoSic.NrSeqProdutoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PRODUTO_SIC", C_NrSeqProdutoSic, DatabaseManager.SQLOperation.Equal, produtoSic.NrSeqProdutoSic, ref where));
			if (produtoSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_PRODUTO_SIC", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, produtoSic.NrSeqCategoriaSic, ref where));
			if (produtoSic.NmProdutoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_PRODUTO_SIC", C_NmProdutoSic, DatabaseManager.SQLOperation.Like, "%" + produtoSic.NmProdutoSic + "%", ref where));
			if (produtoSic.DsProdutoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_PRODUTO_SIC", C_DsProdutoSic, DatabaseManager.SQLOperation.Like, "%" + produtoSic.DsProdutoSic + "%", ref where));
			if (produtoSic.CdSapProdutoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_PRODUTO_SIC", C_CdSapProdutoSic, DatabaseManager.SQLOperation.Like, "%" + produtoSic.CdSapProdutoSic + "%", ref where));
			if (produtoSic.CdBarraProdutoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_PRODUTO_SIC", C_CdBarraProdutoSic, DatabaseManager.SQLOperation.Like, "%" + produtoSic.CdBarraProdutoSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

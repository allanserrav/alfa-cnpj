#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseProdutoSicDAO.cs
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
	#region classe base ProdutoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ProdutoSicDAO
	/// </summary>
	internal partial class ProdutoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ProdutoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqProdutoSic = "NR_SEQ_PRODUTO_SIC";
		private const string C_NrSeqCategoriaSic = "NR_SEQ_CATEGORIA_SIC";
		private const string C_NmProdutoSic = "NM_PRODUTO_SIC";
		private const string C_DsProdutoSic = "DS_PRODUTO_SIC";
		private const string C_CdSapProdutoSic = "CD_SAP_PRODUTO_SIC";
		private const string C_CdBarraProdutoSic = "CD_BARRA_PRODUTO_SIC";
		#endregion  Constantes de TbProdutoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_PRODUTO_SIC")
		.Append("(")
		.Append("NR_SEQ_CATEGORIA_SIC,NM_PRODUTO_SIC,DS_PRODUTO_SIC,CD_SAP_PRODUTO_SIC,CD_BARRA_PRODUTO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(", ")
		.Append("@" + C_NmProdutoSic)
		.Append(", ")
		.Append("@" + C_DsProdutoSic)
		.Append(", ")
		.Append("@" + C_CdSapProdutoSic)
		.Append(", ")
		.Append("@" + C_CdBarraProdutoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_PRODUTO_SIC SET")
		.Append(" NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(",NM_PRODUTO_SIC = ")
		.Append("@" + C_NmProdutoSic)
		.Append(",DS_PRODUTO_SIC = ")
		.Append("@" + C_DsProdutoSic)
		.Append(",CD_SAP_PRODUTO_SIC = ")
		.Append("@" + C_CdSapProdutoSic)
		.Append(",CD_BARRA_PRODUTO_SIC = ")
		.Append("@" + C_CdBarraProdutoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_PRODUTO_SIC = ")
		.Append("@" + C_NrSeqProdutoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_PRODUTO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_PRODUTO_SIC = ")
		.Append("@" + C_NrSeqProdutoSic)
		.Append("").ToString();
		#endregion Query Excluir
		
		#region Query retorna Sequence 
		/// <summary>
		/// Strings with retrieve sequence query
		/// </summary>
		private string queryRetornaSequencia = new StringBuilder().Append("SELECT ")
		.Append(" SCOPE_IDENTITY()").ToString();
		#endregion Retrieve Sequence
		
		#region Query Verifica se existe
		/// <summary>
		/// String com a query Verifica se existe
		/// </summary>
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_PRODUTO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_PRODUTO_SIC = ")
		.Append("@" + C_NrSeqProdutoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Incluir(ProdutoSic produtoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(produtoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ProdutoSic produtoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (produtoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				produtoSic.NrSeqProdutoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, produtoSic)));
			else
				produtoSic.NrSeqProdutoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, produtoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Atualizar(ProdutoSic produtoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(produtoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ProdutoSic produtoSic, DatabaseManager databaseManager)
		{
			if (produtoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, produtoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, produtoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui produtoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Excluir(ProdutoSic produtoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(produtoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui produtoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ProdutoSic produtoSic, DatabaseManager databaseManager)
		{
			if (produtoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, produtoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, produtoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ProdutoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ProdutoSic produtoSic, DatabaseManager databaseManager)
		{
			if (produtoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, produtoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, produtoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ProdutoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ProdutoSic produtoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqProdutoSic, produtoSic.NrSeqProdutoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ProdutoSic produtoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, produtoSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmProdutoSic, produtoSic.NmProdutoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsProdutoSic, produtoSic.DsProdutoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdSapProdutoSic, produtoSic.CdSapProdutoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdBarraProdutoSic, produtoSic.CdBarraProdutoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ProdutoSic produtoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqProdutoSic, produtoSic.NrSeqProdutoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, produtoSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmProdutoSic, produtoSic.NmProdutoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsProdutoSic, produtoSic.DsProdutoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdSapProdutoSic, produtoSic.CdSapProdutoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdBarraProdutoSic, produtoSic.CdBarraProdutoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

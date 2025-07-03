#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseMatrizfilialrebateSicDAO.cs
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
	#region classe base MatrizfilialrebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MatrizfilialrebateSicDAO
	/// </summary>
	internal partial class MatrizfilialrebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public MatrizfilialrebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqMatrizfilialrebateSic = "NR_SEQ_MATRIZFILIALREBATE_SIC";
		private const string C_NrSeqRebatematrizSic = "NR_SEQ_REBATEMATRIZ_SIC";
		private const string C_NrIbmFilialSic = "NR_IBM_FILIAL_SIC";
		private const string C_NrCdfornecedorFilialSic = "NR_CDFORNECEDOR_FILIAL_SIC";
		#endregion  Constantes de TbMatrizfilialrebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_MATRIZFILIALREBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATEMATRIZ_SIC,NR_IBM_FILIAL_SIC,NR_CDFORNECEDOR_FILIAL_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebatematrizSic)
		.Append(", ")
		.Append("@" + C_NrIbmFilialSic)
		.Append(", ")
		.Append("@" + C_NrCdfornecedorFilialSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_MATRIZFILIALREBATE_SIC SET")
		.Append(" NR_SEQ_REBATEMATRIZ_SIC = ")
		.Append("@" + C_NrSeqRebatematrizSic)
		.Append(",NR_IBM_FILIAL_SIC = ")
		.Append("@" + C_NrIbmFilialSic)
		.Append(",NR_CDFORNECEDOR_FILIAL_SIC = ")
		.Append("@" + C_NrCdfornecedorFilialSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_MATRIZFILIALREBATE_SIC = ")
		.Append("@" + C_NrSeqMatrizfilialrebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_MATRIZFILIALREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MATRIZFILIALREBATE_SIC = ")
		.Append("@" + C_NrSeqMatrizfilialrebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_MATRIZFILIALREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MATRIZFILIALREBATE_SIC = ")
		.Append("@" + C_NrSeqMatrizfilialrebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Incluir(MatrizfilialrebateSic matrizfilialrebateSic)
		{
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(matrizfilialrebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(MatrizfilialrebateSic matrizfilialrebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (matrizfilialrebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				matrizfilialrebateSic.NrSeqMatrizfilialrebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, matrizfilialrebateSic)));
			else
				matrizfilialrebateSic.NrSeqMatrizfilialrebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, matrizfilialrebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Atualizar(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager())
			{
				try
				{
					Atualizar(matrizfilialrebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(MatrizfilialrebateSic matrizfilialrebateSic, DatabaseManager databaseManager)
		{
			if (matrizfilialrebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, matrizfilialrebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, matrizfilialrebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui matrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Excluir(MatrizfilialrebateSic matrizfilialrebateSic)
		{
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(matrizfilialrebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui matrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(MatrizfilialrebateSic matrizfilialrebateSic, DatabaseManager databaseManager)
		{
			if (matrizfilialrebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, matrizfilialrebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, matrizfilialrebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe MatrizfilialrebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(MatrizfilialrebateSic matrizfilialrebateSic, DatabaseManager databaseManager)
		{
			if (matrizfilialrebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, matrizfilialrebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, matrizfilialrebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe MatrizfilialrebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, MatrizfilialrebateSic matrizfilialrebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMatrizfilialrebateSic, matrizfilialrebateSic.NrSeqMatrizfilialrebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, MatrizfilialrebateSic matrizfilialrebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebatematrizSic, matrizfilialrebateSic.NrSeqRebatematrizSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmFilialSic, matrizfilialrebateSic.NrIbmFilialSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCdfornecedorFilialSic, matrizfilialrebateSic.NrCdfornecedorFilialSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, MatrizfilialrebateSic matrizfilialrebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMatrizfilialrebateSic, matrizfilialrebateSic.NrSeqMatrizfilialrebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebatematrizSic, matrizfilialrebateSic.NrSeqRebatematrizSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmFilialSic, matrizfilialrebateSic.NrIbmFilialSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCdfornecedorFilialSic, matrizfilialrebateSic.NrCdfornecedorFilialSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

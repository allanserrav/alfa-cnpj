#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseReajusteSicDAO.cs
// Class Name	        : ReajusteSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	#region classe base ReajusteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteSicDAO
	/// </summary>
	internal partial class ReajusteSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ReajusteSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqReajusteSic = "NR_SEQ_REAJUSTE_SIC";
		private const string C_NmReajusteSic = "NM_REAJUSTE_SIC";
		private const string C_VlPercentReajusteSic = "VL_PERCENT_REAJUSTE_SIC";
		private const string C_DsReajusteSic = "DS_REAJUSTE_SIC";
		#endregion  Constantes de TbReajusteSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_REAJUSTE_SIC")
		.Append("(")
		.Append("NM_REAJUSTE_SIC,VL_PERCENT_REAJUSTE_SIC,DS_REAJUSTE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmReajusteSic)
		.Append(", ")
		.Append("@" + C_VlPercentReajusteSic)
		.Append(", ")
		.Append("@" + C_DsReajusteSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_REAJUSTE_SIC SET")
		.Append(" NM_REAJUSTE_SIC = ")
		.Append("@" + C_NmReajusteSic)
		.Append(",VL_PERCENT_REAJUSTE_SIC = ")
		.Append("@" + C_VlPercentReajusteSic)
		.Append(",DS_REAJUSTE_SIC = ")
		.Append("@" + C_DsReajusteSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_SIC = ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_REAJUSTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_SIC = ")
		.Append("@" + C_NrSeqReajusteSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_REAJUSTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_SIC = ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Incluir(ReajusteSic reajusteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(reajusteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ReajusteSic reajusteSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (reajusteSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				reajusteSic.NrSeqReajusteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteSic)));
			else
				reajusteSic.NrSeqReajusteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Atualizar(ReajusteSic reajusteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(reajusteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ReajusteSic reajusteSic, DatabaseManager databaseManager)
		{
			if (reajusteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		public void Excluir(ReajusteSic reajusteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(reajusteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui reajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ReajusteSic reajusteSic, DatabaseManager databaseManager)
		{
			if (reajusteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ReajusteSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ReajusteSic reajusteSic, DatabaseManager databaseManager)
		{
			if (reajusteSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ReajusteSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ReajusteSic reajusteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteSic.NrSeqReajusteSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ReajusteSic reajusteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmReajusteSic, reajusteSic.NmReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercentReajusteSic, reajusteSic.VlPercentReajusteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsReajusteSic, reajusteSic.DsReajusteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ReajusteSic reajusteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteSic.NrSeqReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmReajusteSic, reajusteSic.NmReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercentReajusteSic, reajusteSic.VlPercentReajusteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsReajusteSic, reajusteSic.DsReajusteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseAgrupamentoredeRebateSicDAO.cs
// Class Name	        : AgrupamentoredeRebateSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 13/08/2014
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
	#region classe base AgrupamentoredeRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AgrupamentoredeRebateSicDAO
	/// </summary>
	internal partial class AgrupamentoredeRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public AgrupamentoredeRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqAgrupamentoredeRebateSic = "NR_SEQ_AGRUPAMENTOREDE_REBATE_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrIbmRebateSic = "NR_IBM_REBATE_SIC";
		private const string C_NrGruporedeRebateSic = "NR_GRUPOREDE_REBATE_SIC";
		#endregion  Constantes de TbAgrupamentoredeRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_AGRUPAMENTOREDE_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,NR_IBM_REBATE_SIC,NR_GRUPOREDE_REBATE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_NrIbmRebateSic)
		.Append(", ")
		.Append("@" + C_NrGruporedeRebateSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_AGRUPAMENTOREDE_REBATE_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",NR_IBM_REBATE_SIC = ")
		.Append("@" + C_NrIbmRebateSic)
		.Append(",NR_GRUPOREDE_REBATE_SIC = ")
		.Append("@" + C_NrGruporedeRebateSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_AGRUPAMENTOREDE_REBATE_SIC = ")
		.Append("@" + C_NrSeqAgrupamentoredeRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_AGRUPAMENTOREDE_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AGRUPAMENTOREDE_REBATE_SIC = ")
		.Append("@" + C_NrSeqAgrupamentoredeRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_AGRUPAMENTOREDE_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AGRUPAMENTOREDE_REBATE_SIC = ")
		.Append("@" + C_NrSeqAgrupamentoredeRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Incluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager())
			{
				try
				{
					Incluir(agrupamentoredeRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (agrupamentoredeRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, agrupamentoredeRebateSic)));
			else
				agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, agrupamentoredeRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Atualizar(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager())
			{
				try
				{
					Atualizar(agrupamentoredeRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(AgrupamentoredeRebateSic agrupamentoredeRebateSic, DatabaseManager databaseManager)
		{
			if (agrupamentoredeRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, agrupamentoredeRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, agrupamentoredeRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui agrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		public void Excluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager())
			{
				try
				{
					Excluir(agrupamentoredeRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui agrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic, DatabaseManager databaseManager)
		{
			if (agrupamentoredeRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, agrupamentoredeRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, agrupamentoredeRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe AgrupamentoredeRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(AgrupamentoredeRebateSic agrupamentoredeRebateSic, DatabaseManager databaseManager)
		{
			if (agrupamentoredeRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, agrupamentoredeRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, agrupamentoredeRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe AgrupamentoredeRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAgrupamentoredeRebateSic, agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, agrupamentoredeRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmRebateSic, agrupamentoredeRebateSic.NrIbmRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrGruporedeRebateSic, agrupamentoredeRebateSic.NrGruporedeRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, AgrupamentoredeRebateSic agrupamentoredeRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAgrupamentoredeRebateSic, agrupamentoredeRebateSic.NrSeqAgrupamentoredeRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, agrupamentoredeRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmRebateSic, agrupamentoredeRebateSic.NrIbmRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrGruporedeRebateSic, agrupamentoredeRebateSic.NrGruporedeRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

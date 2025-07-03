#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseTipoclienteSicDAO.cs
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
	#region classe base TipoclienteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TipoclienteSicDAO
	/// </summary>
	internal partial class TipoclienteSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public TipoclienteSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqTipoclienteSic = "NR_SEQ_TIPOCLIENTE_SIC";
		private const string C_NmTipoclienteSic = "NM_TIPOCLIENTE_SIC";
		private const string C_DsTipoclienteSic = "DS_TIPOCLIENTE_SIC";
		#endregion  Constantes de TbTipoclienteSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_TIPOCLIENTE_SIC")
		.Append("(")
		.Append("NM_TIPOCLIENTE_SIC,DS_TIPOCLIENTE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmTipoclienteSic)
		.Append(", ")
		.Append("@" + C_DsTipoclienteSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_TIPOCLIENTE_SIC SET")
		.Append(" NM_TIPOCLIENTE_SIC = ")
		.Append("@" + C_NmTipoclienteSic)
		.Append(",DS_TIPOCLIENTE_SIC = ")
		.Append("@" + C_DsTipoclienteSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOCLIENTE_SIC = ")
		.Append("@" + C_NrSeqTipoclienteSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_TIPOCLIENTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOCLIENTE_SIC = ")
		.Append("@" + C_NrSeqTipoclienteSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_TIPOCLIENTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOCLIENTE_SIC = ")
		.Append("@" + C_NrSeqTipoclienteSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Incluir(TipoclienteSic tipoclienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(tipoclienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(TipoclienteSic tipoclienteSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (tipoclienteSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				tipoclienteSic.NrSeqTipoclienteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tipoclienteSic)));
			else
				tipoclienteSic.NrSeqTipoclienteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tipoclienteSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Atualizar(TipoclienteSic tipoclienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(tipoclienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(TipoclienteSic tipoclienteSic, DatabaseManager databaseManager)
		{
			if (tipoclienteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tipoclienteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tipoclienteSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Excluir(TipoclienteSic tipoclienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(tipoclienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui tipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(TipoclienteSic tipoclienteSic, DatabaseManager databaseManager)
		{
			if (tipoclienteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tipoclienteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tipoclienteSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe TipoclienteSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(TipoclienteSic tipoclienteSic, DatabaseManager databaseManager)
		{
			if (tipoclienteSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tipoclienteSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tipoclienteSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe TipoclienteSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, TipoclienteSic tipoclienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoclienteSic, tipoclienteSic.NrSeqTipoclienteSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, TipoclienteSic tipoclienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTipoclienteSic, tipoclienteSic.NmTipoclienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTipoclienteSic, tipoclienteSic.DsTipoclienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, TipoclienteSic tipoclienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoclienteSic, tipoclienteSic.NrSeqTipoclienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTipoclienteSic, tipoclienteSic.NmTipoclienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTipoclienteSic, tipoclienteSic.DsTipoclienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

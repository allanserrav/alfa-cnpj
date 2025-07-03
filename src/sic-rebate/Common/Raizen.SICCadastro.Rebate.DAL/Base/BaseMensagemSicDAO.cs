#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseMensagemSicDAO.cs
// Class Name	        : MensagemSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 22/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 18/12/2012
//	Reason for modification : Change namespace SICCadastro to SICCadastro.Rebate
//	Modification Done       : 18/12/2012
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
	#region classe base MensagemSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MensagemSicDAO
	/// </summary>
	internal partial class MensagemSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public MensagemSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqMensagemSic = "NR_SEQ_MENSAGEM_SIC";
		private const string C_NmMensagemSic = "NM_MENSAGEM_SIC";
		private const string C_DsMensagemSic = "DS_MENSAGEM_SIC";
		private const string C_DsEmailMensagemSic = "DS_EMAIL_MENSAGEM_SIC";
		#endregion  Constantes de TbMensagemSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_MENSAGEM_SIC")
		.Append("(")
		.Append("NM_MENSAGEM_SIC,DS_MENSAGEM_SIC,DS_EMAIL_MENSAGEM_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmMensagemSic)
		.Append(", ")
		.Append("@" + C_DsMensagemSic)
		.Append(", ")
		.Append("@" + C_DsEmailMensagemSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_MENSAGEM_SIC SET")
		.Append(" NM_MENSAGEM_SIC = ")
		.Append("@" + C_NmMensagemSic)
		.Append(",DS_MENSAGEM_SIC = ")
		.Append("@" + C_DsMensagemSic)
		.Append(",DS_EMAIL_MENSAGEM_SIC = ")
		.Append("@" + C_DsEmailMensagemSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqMensagemSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_MENSAGEM_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqMensagemSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_MENSAGEM_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqMensagemSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Incluir(MensagemSic mensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(mensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(MensagemSic mensagemSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (mensagemSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				mensagemSic.NrSeqMensagemSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, mensagemSic)));
			else
				mensagemSic.NrSeqMensagemSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, mensagemSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Atualizar(MensagemSic mensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(mensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(MensagemSic mensagemSic, DatabaseManager databaseManager)
		{
			if (mensagemSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, mensagemSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, mensagemSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui mensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		public void Excluir(MensagemSic mensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(mensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui mensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(MensagemSic mensagemSic, DatabaseManager databaseManager)
		{
			if (mensagemSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, mensagemSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, mensagemSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe MensagemSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(MensagemSic mensagemSic, DatabaseManager databaseManager)
		{
			if (mensagemSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, mensagemSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, mensagemSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe MensagemSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, MensagemSic mensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMensagemSic, mensagemSic.NrSeqMensagemSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, MensagemSic mensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmMensagemSic, mensagemSic.NmMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMensagemSic, mensagemSic.DsMensagemSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsEmailMensagemSic, mensagemSic.DsEmailMensagemSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, MensagemSic mensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMensagemSic, mensagemSic.NrSeqMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmMensagemSic, mensagemSic.NmMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMensagemSic, mensagemSic.DsMensagemSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsEmailMensagemSic, mensagemSic.DsEmailMensagemSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

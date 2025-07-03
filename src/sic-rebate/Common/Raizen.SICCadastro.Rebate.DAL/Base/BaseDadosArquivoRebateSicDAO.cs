#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseDadosArquivoRebateSicDAO.cs
// Class Name	        : DadosArquivoRebateSicDAO
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 17/01/2013
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
	#region classe base DadosArquivoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DadosArquivoRebateSicDAO
	/// </summary>
	internal partial class DadosArquivoRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public DadosArquivoRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqDadosArquivoRebateSic = "NR_SEQ_DADOS_ARQUIVO_REBATE_SIC";
		private const string C_NrReferenciaSeqSic = "NR_REFERENCIA_SEQ_SIC";
		private const string C_NrArquivoSbopSeqSic = "NR_ARQUIVO_SBOP_SEQ_SIC";
		private const string C_NrArquivoSaabSeqSic = "NR_ARQUIVO_SAAB_SEQ_SIC";
		private const string C_NrArquivoMimeSeqSic = "NR_ARQUIVO_MIME_SEQ_SIC";
		#endregion  Constantes de TbDadosArquivoRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_DADOS_ARQUIVO_REBATE_SIC")
		.Append("(")
		.Append("NR_REFERENCIA_SEQ_SIC,NR_ARQUIVO_SBOP_SEQ_SIC,NR_ARQUIVO_SAAB_SEQ_SIC,NR_ARQUIVO_MIME_SEQ_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrReferenciaSeqSic)
		.Append(", ")
		.Append("@" + C_NrArquivoSbopSeqSic)
		.Append(", ")
		.Append("@" + C_NrArquivoSaabSeqSic)
		.Append(", ")
		.Append("@" + C_NrArquivoMimeSeqSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_DADOS_ARQUIVO_REBATE_SIC SET")
		.Append(" NR_REFERENCIA_SEQ_SIC = ")
		.Append("@" + C_NrReferenciaSeqSic)
		.Append(",NR_ARQUIVO_SBOP_SEQ_SIC = ")
		.Append("@" + C_NrArquivoSbopSeqSic)
		.Append(",NR_ARQUIVO_SAAB_SEQ_SIC = ")
		.Append("@" + C_NrArquivoSaabSeqSic)
		.Append(",NR_ARQUIVO_MIME_SEQ_SIC = ")
		.Append("@" + C_NrArquivoMimeSeqSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_DADOS_ARQUIVO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDadosArquivoRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_DADOS_ARQUIVO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_DADOS_ARQUIVO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDadosArquivoRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_DADOS_ARQUIVO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_DADOS_ARQUIVO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDadosArquivoRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Incluir(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(dadosArquivoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(DadosArquivoRebateSic dadosArquivoRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (dadosArquivoRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, dadosArquivoRebateSic)));
			else
				dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, dadosArquivoRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Atualizar(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(dadosArquivoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(DadosArquivoRebateSic dadosArquivoRebateSic, DatabaseManager databaseManager)
		{
			if (dadosArquivoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, dadosArquivoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, dadosArquivoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui dadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		public void Excluir(DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(dadosArquivoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui dadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(DadosArquivoRebateSic dadosArquivoRebateSic, DatabaseManager databaseManager)
		{
			if (dadosArquivoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, dadosArquivoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, dadosArquivoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe DadosArquivoRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(DadosArquivoRebateSic dadosArquivoRebateSic, DatabaseManager databaseManager)
		{
			if (dadosArquivoRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, dadosArquivoRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, dadosArquivoRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe DadosArquivoRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqDadosArquivoRebateSic, dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrReferenciaSeqSic, dadosArquivoRebateSic.NrReferenciaSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoSbopSeqSic, dadosArquivoRebateSic.NrArquivoSbopSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoSaabSeqSic, dadosArquivoRebateSic.NrArquivoSaabSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoMimeSeqSic, dadosArquivoRebateSic.NrArquivoMimeSeqSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, DadosArquivoRebateSic dadosArquivoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqDadosArquivoRebateSic, dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrReferenciaSeqSic, dadosArquivoRebateSic.NrReferenciaSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoSbopSeqSic, dadosArquivoRebateSic.NrArquivoSbopSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoSaabSeqSic, dadosArquivoRebateSic.NrArquivoSaabSeqSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrArquivoMimeSeqSic, dadosArquivoRebateSic.NrArquivoMimeSeqSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

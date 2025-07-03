#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseAgendamentoMensagemSicDAO.cs
// Class Name	        : AgendamentoMensagemSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 23/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 12/18/2012
//	Reason for modification : Copy class from SICCadastros to SICCadastros.Rebate
//	Modification Done       : 12/18/2012
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
	#region classe base AgendamentoMensagemSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AgendamentoMensagemSicDAO
	/// </summary>
	internal partial class AgendamentoMensagemSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public AgendamentoMensagemSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqAgendamentoMensagemSic = "NR_SEQ_AGENDAMENTO_MENSAGEM_SIC";
		private const string C_NrSeqMensagemSic = "NR_SEQ_MENSAGEM_SIC";
		private const string C_NmUserSolicitacaoSic = "NM_USER_SOLICITACAO_SIC";
		private const string C_DtAgendamentoMensagemSic = "DT_AGENDAMENTO_MENSAGEM_SIC";
		private const string C_StAgengamentoMensagemSic = "ST_AGENGAMENTO_MENSAGEM_SIC";
		private const string C_NmGrupodeAgengamentoMensagemSic = "NM_GRUPODE_AGENGAMENTO_MENSAGEM_SIC";
		private const string C_NmGrupoparaAgendamentoMensagemSic = "NM_GRUPOPARA_AGENDAMENTO_MENSAGEM_SIC";
		private const string C_NmLinkAgendamentoMensagemSic = "NM_LINK_AGENDAMENTO_MENSAGEM_SIC";
		#endregion  Constantes de TbAgendamentoMensagemSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_AGENDAMENTO_MENSAGEM_SIC")
		.Append("(")
		.Append("NR_SEQ_MENSAGEM_SIC,NM_USER_SOLICITACAO_SIC,DT_AGENDAMENTO_MENSAGEM_SIC,ST_AGENGAMENTO_MENSAGEM_SIC,NM_GRUPODE_AGENGAMENTO_MENSAGEM_SIC,NM_GRUPOPARA_AGENDAMENTO_MENSAGEM_SIC,NM_LINK_AGENDAMENTO_MENSAGEM_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqMensagemSic)
		.Append(", ")
		.Append("@" + C_NmUserSolicitacaoSic)
		.Append(", ")
		.Append("@" + C_DtAgendamentoMensagemSic)
		.Append(", ")
		.Append("@" + C_StAgengamentoMensagemSic)
		.Append(", ")
		.Append("@" + C_NmGrupodeAgengamentoMensagemSic)
		.Append(", ")
		.Append("@" + C_NmGrupoparaAgendamentoMensagemSic)
		.Append(", ")
		.Append("@" + C_NmLinkAgendamentoMensagemSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_AGENDAMENTO_MENSAGEM_SIC SET")
		.Append(" NR_SEQ_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqMensagemSic)
		.Append(",NM_USER_SOLICITACAO_SIC = ")
		.Append("@" + C_NmUserSolicitacaoSic)
		.Append(",DT_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_DtAgendamentoMensagemSic)
		.Append(",ST_AGENGAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_StAgengamentoMensagemSic)
		.Append(",NM_GRUPODE_AGENGAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NmGrupodeAgengamentoMensagemSic)
		.Append(",NM_GRUPOPARA_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NmGrupoparaAgendamentoMensagemSic)
		.Append(",NM_LINK_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NmLinkAgendamentoMensagemSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqAgendamentoMensagemSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_AGENDAMENTO_MENSAGEM_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqAgendamentoMensagemSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_AGENDAMENTO_MENSAGEM_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AGENDAMENTO_MENSAGEM_SIC = ")
		.Append("@" + C_NrSeqAgendamentoMensagemSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Incluir(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(agendamentoMensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(AgendamentoMensagemSic agendamentoMensagemSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (agendamentoMensagemSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				agendamentoMensagemSic.NrSeqAgendamentoMensagemSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, agendamentoMensagemSic)));
			else
				agendamentoMensagemSic.NrSeqAgendamentoMensagemSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, agendamentoMensagemSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Atualizar(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(agendamentoMensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(AgendamentoMensagemSic agendamentoMensagemSic, DatabaseManager databaseManager)
		{
			if (agendamentoMensagemSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, agendamentoMensagemSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, agendamentoMensagemSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui agendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Excluir(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(agendamentoMensagemSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui agendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(AgendamentoMensagemSic agendamentoMensagemSic, DatabaseManager databaseManager)
		{
			if (agendamentoMensagemSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, agendamentoMensagemSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, agendamentoMensagemSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe AgendamentoMensagemSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(AgendamentoMensagemSic agendamentoMensagemSic, DatabaseManager databaseManager)
		{
			if (agendamentoMensagemSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, agendamentoMensagemSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, agendamentoMensagemSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe AgendamentoMensagemSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, AgendamentoMensagemSic agendamentoMensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAgendamentoMensagemSic, agendamentoMensagemSic.NrSeqAgendamentoMensagemSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, AgendamentoMensagemSic agendamentoMensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMensagemSic, agendamentoMensagemSic.NrSeqMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUserSolicitacaoSic, agendamentoMensagemSic.NmUserSolicitacaoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAgendamentoMensagemSic, agendamentoMensagemSic.DtAgendamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAgengamentoMensagemSic, agendamentoMensagemSic.StAgengamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGrupodeAgengamentoMensagemSic, agendamentoMensagemSic.NmGrupodeAgengamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGrupoparaAgendamentoMensagemSic, agendamentoMensagemSic.NmGrupoparaAgendamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLinkAgendamentoMensagemSic, agendamentoMensagemSic.NmLinkAgendamentoMensagemSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, AgendamentoMensagemSic agendamentoMensagemSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAgendamentoMensagemSic, agendamentoMensagemSic.NrSeqAgendamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMensagemSic, agendamentoMensagemSic.NrSeqMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUserSolicitacaoSic, agendamentoMensagemSic.NmUserSolicitacaoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAgendamentoMensagemSic, agendamentoMensagemSic.DtAgendamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAgengamentoMensagemSic, agendamentoMensagemSic.StAgengamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGrupodeAgengamentoMensagemSic, agendamentoMensagemSic.NmGrupodeAgengamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGrupoparaAgendamentoMensagemSic, agendamentoMensagemSic.NmGrupoparaAgendamentoMensagemSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmLinkAgendamentoMensagemSic, agendamentoMensagemSic.NmLinkAgendamentoMensagemSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

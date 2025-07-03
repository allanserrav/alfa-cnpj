#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseAvisoSicDAO.cs
// Class Name	        : AvisoSicDAO
// Author		        : Hélio Jânio Ferreira
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
	#region classe base AvisoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AvisoSicDAO
	/// </summary>
	internal partial class AvisoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public AvisoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqAvisoSic = "NR_SEQ_AVISO_SIC";
		private const string C_NrSeqTipoclienteSic = "NR_SEQ_TIPOCLIENTE_SIC";
		private const string C_DsAvisoSic = "DS_AVISO_SIC";
		private const string C_StAvisoSic = "ST_AVISO_SIC";
		private const string C_NmUsuarioexSic = "NM_USUARIOEX_SIC";
		private const string C_DtExclusaoavisoSic = "DT_EXCLUSAOAVISO_SIC";
		private const string C_NrIbmAvisoSic = "NR_IBM_AVISO_SIC";
		private const string C_NrSeqTipoAvisoSic = "NR_SEQ_TIPO_AVISO_SIC";
		private const string C_DtInclusaoavisoSic = "DT_INCLUSAOAVISO_SIC";
		#endregion  Constantes de TbAvisoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_AVISO_SIC")
		.Append("(")
		.Append("NR_SEQ_TIPOCLIENTE_SIC,DS_AVISO_SIC,ST_AVISO_SIC,NM_USUARIOEX_SIC,DT_EXCLUSAOAVISO_SIC,NR_IBM_AVISO_SIC,NR_SEQ_TIPO_AVISO_SIC,DT_INCLUSAOAVISO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqTipoclienteSic)
		.Append(", ")
		.Append("@" + C_DsAvisoSic)
		.Append(", ")
		.Append("@" + C_StAvisoSic)
		.Append(", ")
		.Append("@" + C_NmUsuarioexSic)
		.Append(", ")
		.Append("@" + C_DtExclusaoavisoSic)
		.Append(", ")
		.Append("@" + C_NrIbmAvisoSic)
		.Append(", ")
		.Append("@" + C_NrSeqTipoAvisoSic)
		.Append(", ")
		.Append("@" + C_DtInclusaoavisoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_AVISO_SIC SET")
		.Append(" NR_SEQ_TIPOCLIENTE_SIC = ")
		.Append("@" + C_NrSeqTipoclienteSic)
		.Append(",DS_AVISO_SIC = ")
		.Append("@" + C_DsAvisoSic)
		.Append(",ST_AVISO_SIC = ")
		.Append("@" + C_StAvisoSic)
		.Append(",NM_USUARIOEX_SIC = ")
		.Append("@" + C_NmUsuarioexSic)
		.Append(",DT_EXCLUSAOAVISO_SIC = ")
		.Append("@" + C_DtExclusaoavisoSic)
		.Append(",NR_IBM_AVISO_SIC = ")
		.Append("@" + C_NrIbmAvisoSic)
		.Append(",NR_SEQ_TIPO_AVISO_SIC = ")
		.Append("@" + C_NrSeqTipoAvisoSic)
		.Append(",DT_INCLUSAOAVISO_SIC = ")
		.Append("@" + C_DtInclusaoavisoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_AVISO_SIC = ")
		.Append("@" + C_NrSeqAvisoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_AVISO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AVISO_SIC = ")
		.Append("@" + C_NrSeqAvisoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_AVISO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_AVISO_SIC = ")
		.Append("@" + C_NrSeqAvisoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Incluir(AvisoSic avisoSic)
		{
			using (DatabaseManager databaseManager  = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(avisoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(AvisoSic avisoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (avisoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				avisoSic.NrSeqAvisoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, avisoSic)));
			else
				avisoSic.NrSeqAvisoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, avisoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Atualizar(AvisoSic avisoSic)
		{
			using (DatabaseManager databaseManager  = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(avisoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(AvisoSic avisoSic, DatabaseManager databaseManager)
		{
			if (avisoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, avisoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, avisoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui avisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		public void Excluir(AvisoSic avisoSic)
		{
			using (DatabaseManager databaseManager  = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(avisoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui avisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(AvisoSic avisoSic, DatabaseManager databaseManager)
		{
			if (avisoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, avisoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, avisoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe AvisoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(AvisoSic avisoSic, DatabaseManager databaseManager)
		{
			if (avisoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, avisoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, avisoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe AvisoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, AvisoSic avisoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAvisoSic, avisoSic.NrSeqAvisoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, AvisoSic avisoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoclienteSic, avisoSic.NrSeqTipoclienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsAvisoSic, avisoSic.DsAvisoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAvisoSic, avisoSic.StAvisoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUsuarioexSic, avisoSic.NmUsuarioexSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtExclusaoavisoSic, avisoSic.DtExclusaoavisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmAvisoSic, avisoSic.NrIbmAvisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoAvisoSic, avisoSic.NrSeqTipoAvisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtInclusaoavisoSic, avisoSic.DtInclusaoavisoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, AvisoSic avisoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAvisoSic, avisoSic.NrSeqAvisoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoclienteSic, avisoSic.NrSeqTipoclienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsAvisoSic, avisoSic.DsAvisoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAvisoSic, avisoSic.StAvisoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUsuarioexSic, avisoSic.NmUsuarioexSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtExclusaoavisoSic, avisoSic.DtExclusaoavisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmAvisoSic, avisoSic.NrIbmAvisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoAvisoSic, avisoSic.NrSeqTipoAvisoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtInclusaoavisoSic, avisoSic.DtInclusaoavisoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

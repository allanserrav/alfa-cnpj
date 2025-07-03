#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseMotivoRegimeEspecialRebateSicDAO.cs
// Class Name	        : MotivoRegimeEspecialRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	#region classe base MotivoRegimeEspecialRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MotivoRegimeEspecialRebateSicDAO
	/// </summary>
	internal partial class MotivoRegimeEspecialRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public MotivoRegimeEspecialRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqMotivoRegimeEspecialRebateSic = "NR_SEQ_MOTIVO_REGIME_ESPECIAL_REBATE_SIC";
		private const string C_CdMotivoSic = "CD_MOTIVO_SIC";
		private const string C_DsMotivoSic = "DS_MOTIVO_SIC";
		#endregion  Constantes de TbMotivoRegimeEspecialRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC")
		.Append("(")
		.Append("CD_MOTIVO_SIC,DS_MOTIVO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_CdMotivoSic)
		.Append(", ")
		.Append("@" + C_DsMotivoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC SET")
		.Append(" CD_MOTIVO_SIC = ")
		.Append("@" + C_CdMotivoSic)
		.Append(",DS_MOTIVO_SIC = ")
		.Append("@" + C_DsMotivoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_MOTIVO_REGIME_ESPECIAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqMotivoRegimeEspecialRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MOTIVO_REGIME_ESPECIAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqMotivoRegimeEspecialRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_MOTIVO_REGIME_ESPECIAL_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_MOTIVO_REGIME_ESPECIAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqMotivoRegimeEspecialRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Incluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(motivoRegimeEspecialRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (motivoRegimeEspecialRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, motivoRegimeEspecialRebateSic)));
			else
				motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, motivoRegimeEspecialRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Atualizar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(motivoRegimeEspecialRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, DatabaseManager databaseManager)
		{
			if (motivoRegimeEspecialRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, motivoRegimeEspecialRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, motivoRegimeEspecialRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui motivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		public void Excluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(motivoRegimeEspecialRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui motivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, DatabaseManager databaseManager)
		{
			if (motivoRegimeEspecialRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, motivoRegimeEspecialRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, motivoRegimeEspecialRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe MotivoRegimeEspecialRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, DatabaseManager databaseManager)
		{
			if (motivoRegimeEspecialRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, motivoRegimeEspecialRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, motivoRegimeEspecialRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe MotivoRegimeEspecialRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMotivoRegimeEspecialRebateSic, motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdMotivoSic, motivoRegimeEspecialRebateSic.CdMotivoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMotivoSic, motivoRegimeEspecialRebateSic.DsMotivoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqMotivoRegimeEspecialRebateSic, motivoRegimeEspecialRebateSic.NrSeqMotivoRegimeEspecialRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_CdMotivoSic, motivoRegimeEspecialRebateSic.CdMotivoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMotivoSic, motivoRegimeEspecialRebateSic.DsMotivoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

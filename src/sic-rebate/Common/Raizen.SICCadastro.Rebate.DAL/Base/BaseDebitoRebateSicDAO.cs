#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseDebitoRebateSicDAO.cs
// Class Name	        : DebitoRebateSicDAO
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
	#region classe base DebitoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DebitoRebateSicDAO
	/// </summary>
	internal partial class DebitoRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public DebitoRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqDebitoRebateSic = "NR_SEQ_DEBITO_REBATE_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_DtConsultaSic = "DT_CONSULTA_SIC";
		private const string C_VlDebitoSic = "VL_DEBITO_SIC";
		#endregion  Constantes de TbDebitoRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_DEBITO_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,DT_CONSULTA_SIC,VL_DEBITO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_DtConsultaSic)
		.Append(", ")
		.Append("@" + C_VlDebitoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_DEBITO_REBATE_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",DT_CONSULTA_SIC = ")
		.Append("@" + C_DtConsultaSic)
		.Append(",VL_DEBITO_SIC = ")
		.Append("@" + C_VlDebitoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_DEBITO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDebitoRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_DEBITO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_DEBITO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDebitoRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_DEBITO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_DEBITO_REBATE_SIC = ")
		.Append("@" + C_NrSeqDebitoRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Incluir(DebitoRebateSic debitoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(debitoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (debitoRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				debitoRebateSic.NrSeqDebitoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, debitoRebateSic)));
			else
				debitoRebateSic.NrSeqDebitoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, debitoRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Atualizar(DebitoRebateSic debitoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(debitoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager)
		{
			if (debitoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, debitoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, debitoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui debitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		public void Excluir(DebitoRebateSic debitoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(debitoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui debitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager)
		{
			if (debitoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, debitoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, debitoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe DebitoRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager)
		{
			if (debitoRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, debitoRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, debitoRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe DebitoRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, DebitoRebateSic debitoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqDebitoRebateSic, debitoRebateSic.NrSeqDebitoRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, DebitoRebateSic debitoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, debitoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtConsultaSic, debitoRebateSic.DtConsultaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlDebitoSic, debitoRebateSic.VlDebitoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, DebitoRebateSic debitoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqDebitoRebateSic, debitoRebateSic.NrSeqDebitoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, debitoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtConsultaSic, debitoRebateSic.DtConsultaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlDebitoSic, debitoRebateSic.VlDebitoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

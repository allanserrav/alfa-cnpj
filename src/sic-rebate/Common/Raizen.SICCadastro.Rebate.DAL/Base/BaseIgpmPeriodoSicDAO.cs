#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseIgpmPeriodoSicDAO.cs
// Class Name	        : IgpmPeriodoSicDAO
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
	#region classe base IgpmPeriodoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a IgpmPeriodoSicDAO
	/// </summary>
	internal partial class IgpmPeriodoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public IgpmPeriodoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqIgpmPeriodoSic = "NR_SEQ_IGPM_PERIODO_SIC";
		private const string C_DtPeriodoSic = "DT_PERIODO_SIC";
		private const string C_DtPeriodoFormatadoSic = "DT_PERIODO_FORMATADO_SIC";
		private const string C_VlFatorSic = "VL_FATOR_SIC";
		private const string C_VlPercentualSic = "VL_PERCENTUAL_SIC";
		private const string C_DtAlteracaoSic = "DT_ALTERACAO_SIC";
		#endregion  Constantes de TbIgpmPeriodoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_IGPM_PERIODO_SIC")
		.Append("(")
		.Append("DT_PERIODO_SIC,DT_PERIODO_FORMATADO_SIC,VL_FATOR_SIC,VL_PERCENTUAL_SIC,DT_ALTERACAO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_DtPeriodoSic)
		.Append(", ")
		.Append("@" + C_DtPeriodoFormatadoSic)
		.Append(", ")
		.Append("@" + C_VlFatorSic)
		.Append(", ")
		.Append("@" + C_VlPercentualSic)
		.Append(", ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_IGPM_PERIODO_SIC SET")
		.Append(" DT_PERIODO_SIC = ")
		.Append("@" + C_DtPeriodoSic)
		.Append(",DT_PERIODO_FORMATADO_SIC = ")
		.Append("@" + C_DtPeriodoFormatadoSic)
		.Append(",VL_FATOR_SIC = ")
		.Append("@" + C_VlFatorSic)
		.Append(",VL_PERCENTUAL_SIC = ")
		.Append("@" + C_VlPercentualSic)
		.Append(",DT_ALTERACAO_SIC = ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_IGPM_PERIODO_SIC = ")
		.Append("@" + C_NrSeqIgpmPeriodoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_IGPM_PERIODO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IGPM_PERIODO_SIC = ")
		.Append("@" + C_NrSeqIgpmPeriodoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_IGPM_PERIODO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IGPM_PERIODO_SIC = ")
		.Append("@" + C_NrSeqIgpmPeriodoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Incluir(IgpmPeriodoSic igpmPeriodoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(igpmPeriodoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(IgpmPeriodoSic igpmPeriodoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (igpmPeriodoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				igpmPeriodoSic.NrSeqIgpmPeriodoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, igpmPeriodoSic)));
			else
				igpmPeriodoSic.NrSeqIgpmPeriodoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, igpmPeriodoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Atualizar(IgpmPeriodoSic igpmPeriodoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(igpmPeriodoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(IgpmPeriodoSic igpmPeriodoSic, DatabaseManager databaseManager)
		{
			if (igpmPeriodoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, igpmPeriodoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, igpmPeriodoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui igpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		public void Excluir(IgpmPeriodoSic igpmPeriodoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(igpmPeriodoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui igpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(IgpmPeriodoSic igpmPeriodoSic, DatabaseManager databaseManager)
		{
			if (igpmPeriodoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, igpmPeriodoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, igpmPeriodoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe IgpmPeriodoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(IgpmPeriodoSic igpmPeriodoSic, DatabaseManager databaseManager)
		{
			if (igpmPeriodoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, igpmPeriodoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, igpmPeriodoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe IgpmPeriodoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, IgpmPeriodoSic igpmPeriodoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqIgpmPeriodoSic, igpmPeriodoSic.NrSeqIgpmPeriodoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros verifica se UN_TB_IGPM_PERIODO_SIC_DT_PERIODO_SIC existe 
		/// <summary>
		/// Cria Parametros verifica se UN_TB_IGPM_PERIODO_SIC_DT_PERIODO_SIC existe 
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosVerificaSeExisteUnTbIgpmPeriodoSicDtPeriodoSic(DatabaseManager databaseManager, IgpmPeriodoSic igpmPeriodoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, igpmPeriodoSic.DtPeriodoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqIgpmPeriodoSic, igpmPeriodoSic.NrSeqIgpmPeriodoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros verifica se UN_TB_IGPM_PERIODO_SIC_DT_PERIODO_SIC existe 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, IgpmPeriodoSic igpmPeriodoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, igpmPeriodoSic.DtPeriodoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DtPeriodoFormatadoSic, igpmPeriodoSic.DtPeriodoFormatadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlFatorSic, igpmPeriodoSic.VlFatorSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercentualSic, igpmPeriodoSic.VlPercentualSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, igpmPeriodoSic.DtAlteracaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, IgpmPeriodoSic igpmPeriodoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqIgpmPeriodoSic, igpmPeriodoSic.NrSeqIgpmPeriodoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, igpmPeriodoSic.DtPeriodoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DtPeriodoFormatadoSic, igpmPeriodoSic.DtPeriodoFormatadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlFatorSic, igpmPeriodoSic.VlFatorSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercentualSic, igpmPeriodoSic.VlPercentualSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, igpmPeriodoSic.DtAlteracaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

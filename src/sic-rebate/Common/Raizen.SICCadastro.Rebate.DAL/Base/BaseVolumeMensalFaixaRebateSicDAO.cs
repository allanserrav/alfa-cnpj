#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseVolumeMensalFaixaRebateSicDAO.cs
// Class Name	        : VolumeMensalFaixaRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 28/01/2013
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
	#region classe base VolumeMensalFaixaRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a VolumeMensalFaixaRebateSicDAO
	/// </summary>
	internal partial class VolumeMensalFaixaRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public VolumeMensalFaixaRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqVolumeMensalFaixaRebateSic = "NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC";
		private const string C_NrSeqFaixarebateSic = "NR_SEQ_FAIXAREBATE_SIC";
		private const string C_NrSeqFaixaRebateHistoricoSic = "NR_SEQ_FAIXA_REBATE_HISTORICO_SIC";
		private const string C_VlVolumeCompradoSic = "VL_VOLUME_COMPRADO_SIC";
		private const string C_DtPeriodoSic = "DT_PERIODO_SIC";
		private const string C_StVolumeEncontrado = "ST_VOLUME_ENCONTRADO";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrSeqCategoriaSic = "NR_SEQ_CATEGORIA_SIC";
		private const string C_DtGravacaoSic = "DT_GRAVACAO_SIC";
		#endregion  Constantes de TbVolumeMensalFaixaRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_FAIXAREBATE_SIC,NR_SEQ_FAIXA_REBATE_HISTORICO_SIC,VL_VOLUME_COMPRADO_SIC,DT_PERIODO_SIC,ST_VOLUME_ENCONTRADO,NR_SEQ_REBATE_SIC,NR_SEQ_CATEGORIA_SIC,DT_GRAVACAO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqFaixaRebateHistoricoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeCompradoSic)
		.Append(", ")
		.Append("@" + C_DtPeriodoSic)
		.Append(", ")
		.Append("@" + C_StVolumeEncontrado)
		.Append(", ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(", ")
		.Append("@" + C_DtGravacaoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_VOLUME_MENSAL_FAIXA_REBATE_SIC SET")
		.Append(" NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(",NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqFaixaRebateHistoricoSic)
		.Append(",VL_VOLUME_COMPRADO_SIC = ")
		.Append("@" + C_VlVolumeCompradoSic)
		.Append(",DT_PERIODO_SIC = ")
		.Append("@" + C_DtPeriodoSic)
		.Append(",ST_VOLUME_ENCONTRADO = ")
		.Append("@" + C_StVolumeEncontrado)
		.Append(",NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(",DT_GRAVACAO_SIC = ")
		.Append("@" + C_DtGravacaoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Incluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(volumeMensalFaixaRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (volumeMensalFaixaRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, volumeMensalFaixaRebateSic)));
			else
				volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, volumeMensalFaixaRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Atualizar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(volumeMensalFaixaRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar VolumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, DatabaseManager databaseManager)
		{
			if (volumeMensalFaixaRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, volumeMensalFaixaRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, volumeMensalFaixaRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui volumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		public void Excluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(volumeMensalFaixaRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui volumeMensalFaixaRebateSic
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, DatabaseManager databaseManager)
		{
			if (volumeMensalFaixaRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, volumeMensalFaixaRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, volumeMensalFaixaRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe VolumeMensalFaixaRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic, DatabaseManager databaseManager)
		{
			if (volumeMensalFaixaRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, volumeMensalFaixaRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, volumeMensalFaixaRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe VolumeMensalFaixaRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqVolumeMensalFaixaRebateSic, volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, volumeMensalFaixaRebateSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaRebateHistoricoSic, volumeMensalFaixaRebateSic.NrSeqFaixaRebateHistoricoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCompradoSic, volumeMensalFaixaRebateSic.VlVolumeCompradoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, volumeMensalFaixaRebateSic.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StVolumeEncontrado, volumeMensalFaixaRebateSic.StVolumeEncontrado, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, volumeMensalFaixaRebateSic.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, volumeMensalFaixaRebateSic.NrSeqCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtGravacaoSic, volumeMensalFaixaRebateSic.DtGravacaoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeMensalFaixaRebateSic">Instance of <see cref="VolumeMensalFaixaRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, VolumeMensalFaixaRebateSic volumeMensalFaixaRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqVolumeMensalFaixaRebateSic, volumeMensalFaixaRebateSic.NrSeqVolumeMensalFaixaRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, volumeMensalFaixaRebateSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaRebateHistoricoSic, volumeMensalFaixaRebateSic.NrSeqFaixaRebateHistoricoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCompradoSic, volumeMensalFaixaRebateSic.VlVolumeCompradoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, volumeMensalFaixaRebateSic.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StVolumeEncontrado, volumeMensalFaixaRebateSic.StVolumeEncontrado, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, volumeMensalFaixaRebateSic.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, volumeMensalFaixaRebateSic.NrSeqCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtGravacaoSic, volumeMensalFaixaRebateSic.DtGravacaoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

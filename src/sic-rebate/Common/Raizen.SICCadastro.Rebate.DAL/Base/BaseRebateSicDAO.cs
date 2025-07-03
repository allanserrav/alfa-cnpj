#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseRebateSicDAO.cs
// Class Name	        : RebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 25/07/2014
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
	#region classe base RebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a RebateSicDAO
	/// </summary>
	internal partial class RebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public RebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrSeqTiporebateSic = "NR_SEQ_TIPOREBATE_SIC";
		private const string C_NrSeqClienteSic = "NR_SEQ_CLIENTE_SIC";
		private const string C_NrIbmRebateSic = "NR_IBM_REBATE_SIC";
		private const string C_DtAssinaturacontratoRebateSic = "DT_ASSINATURACONTRATO_REBATE_SIC";
		private const string C_DtIniciovigenciaRebateSic = "DT_INICIOVIGENCIA_REBATE_SIC";
		private const string C_DtFimvigenciaRebateSic = "DT_FIMVIGENCIA_REBATE_SIC";
		private const string C_NrCodigofornecedorRebateSic = "NR_CODIGOFORNECEDOR_REBATE_SIC";
		private const string C_NrCodigopagadorRebateSic = "NR_CODIGOPAGADOR_REBATE_SIC";
		private const string C_StCalculoRebateSic = "ST_CALCULO_REBATE_SIC";
		private const string C_StMatrizRebateSic = "ST_MATRIZ_REBATE_SIC";
		private const string C_DsObsRebate = "DS_OBS_REBATE";
		private const string C_StCalculoRetroativoSic = "ST_CALCULO_RETROATIVO_SIC";
		private const string C_StPossuiCalculoRebateSic = "ST_POSSUI_CALCULO_REBATE_SIC";
		private const string C_StNaoenviarsapRebateSic = "ST_NAOENVIARSAP_REBATE_SIC";
		private const string C_VlVolumecontratadoRebateSic = "VL_VOLUMECONTRATADO_REBATE_SIC";
		private const string C_VlVolumelimiteRebateSic = "VL_VOLUMELIMITE_REBATE_SIC";
		private const string C_StControlevolume = "ST_CONTROLEVOLUME";
		private const string C_StPagamentoProporcional = "ST_PAGAMENTO_PROPORCIONAL";
		#endregion  Constantes de TbRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_TIPOREBATE_SIC,NR_SEQ_CLIENTE_SIC,NR_IBM_REBATE_SIC,DT_ASSINATURACONTRATO_REBATE_SIC,DT_INICIOVIGENCIA_REBATE_SIC,DT_FIMVIGENCIA_REBATE_SIC,NR_CODIGOFORNECEDOR_REBATE_SIC,NR_CODIGOPAGADOR_REBATE_SIC,ST_CALCULO_REBATE_SIC,ST_MATRIZ_REBATE_SIC,DS_OBS_REBATE,ST_CALCULO_RETROATIVO_SIC,ST_POSSUI_CALCULO_REBATE_SIC,ST_NAOENVIARSAP_REBATE_SIC,VL_VOLUMECONTRATADO_REBATE_SIC,VL_VOLUMELIMITE_REBATE_SIC,ST_CONTROLEVOLUME,ST_PAGAMENTO_PROPORCIONAL")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(", ")
		.Append("@" + C_NrIbmRebateSic)
		.Append(", ")
		.Append("@" + C_DtAssinaturacontratoRebateSic)
		.Append(", ")
		.Append("@" + C_DtIniciovigenciaRebateSic)
		.Append(", ")
		.Append("@" + C_DtFimvigenciaRebateSic)
		.Append(", ")
		.Append("@" + C_NrCodigofornecedorRebateSic)
		.Append(", ")
		.Append("@" + C_NrCodigopagadorRebateSic)
		.Append(", ")
		.Append("@" + C_StCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_StMatrizRebateSic)
		.Append(", ")
		.Append("@" + C_DsObsRebate)
		.Append(", ")
		.Append("@" + C_StCalculoRetroativoSic)
		.Append(", ")
		.Append("@" + C_StPossuiCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_StNaoenviarsapRebateSic)
		.Append(", ")
		.Append("@" + C_VlVolumecontratadoRebateSic)
		.Append(", ")
		.Append("@" + C_VlVolumelimiteRebateSic)
		.Append(", ")
		.Append("@" + C_StControlevolume)
		.Append(", ")
		.Append("@" + C_StPagamentoProporcional)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_REBATE_SIC SET")
		.Append(" NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(",NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(",NR_IBM_REBATE_SIC = ")
		.Append("@" + C_NrIbmRebateSic)
		.Append(",DT_ASSINATURACONTRATO_REBATE_SIC = ")
		.Append("@" + C_DtAssinaturacontratoRebateSic)
		.Append(",DT_INICIOVIGENCIA_REBATE_SIC = ")
		.Append("@" + C_DtIniciovigenciaRebateSic)
		.Append(",DT_FIMVIGENCIA_REBATE_SIC = ")
		.Append("@" + C_DtFimvigenciaRebateSic)
		.Append(",NR_CODIGOFORNECEDOR_REBATE_SIC = ")
		.Append("@" + C_NrCodigofornecedorRebateSic)
		.Append(",NR_CODIGOPAGADOR_REBATE_SIC = ")
		.Append("@" + C_NrCodigopagadorRebateSic)
		.Append(",ST_CALCULO_REBATE_SIC = ")
		.Append("@" + C_StCalculoRebateSic)
		.Append(",ST_MATRIZ_REBATE_SIC = ")
		.Append("@" + C_StMatrizRebateSic)
		.Append(",DS_OBS_REBATE = ")
		.Append("@" + C_DsObsRebate)
		.Append(",ST_CALCULO_RETROATIVO_SIC = ")
		.Append("@" + C_StCalculoRetroativoSic)
		.Append(",ST_POSSUI_CALCULO_REBATE_SIC = ")
		.Append("@" + C_StPossuiCalculoRebateSic)
		.Append(",ST_NAOENVIARSAP_REBATE_SIC = ")
		.Append("@" + C_StNaoenviarsapRebateSic)
		.Append(",VL_VOLUMECONTRATADO_REBATE_SIC = ")
		.Append("@" + C_VlVolumecontratadoRebateSic)
		.Append(",VL_VOLUMELIMITE_REBATE_SIC = ")
		.Append("@" + C_VlVolumelimiteRebateSic)
		.Append(",ST_CONTROLEVOLUME = ")
		.Append("@" + C_StControlevolume)
		.Append(",ST_PAGAMENTO_PROPORCIONAL = ")
		.Append("@" + C_StPagamentoProporcional)
		.Append(" WHERE")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Incluir(RebateSic rebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(rebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(RebateSic rebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (rebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				rebateSic.NrSeqRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, rebateSic)));
			else
				rebateSic.NrSeqRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, rebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Atualizar(RebateSic rebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(rebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(RebateSic rebateSic, DatabaseManager databaseManager)
		{
			if (rebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, rebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, rebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui rebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		public void Excluir(RebateSic rebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(rebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui rebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(RebateSic rebateSic, DatabaseManager databaseManager)
		{
			if (rebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, rebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, rebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe RebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(RebateSic rebateSic, DatabaseManager databaseManager)
		{
			if (rebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, rebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, rebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe RebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, RebateSic rebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, rebateSic.NrSeqRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, RebateSic rebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, rebateSic.NrSeqTiporebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, rebateSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmRebateSic, rebateSic.NrIbmRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAssinaturacontratoRebateSic, rebateSic.DtAssinaturacontratoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciovigenciaRebateSic, rebateSic.DtIniciovigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimvigenciaRebateSic, rebateSic.DtFimvigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigofornecedorRebateSic, rebateSic.NrCodigofornecedorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigopagadorRebateSic, rebateSic.NrCodigopagadorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCalculoRebateSic, rebateSic.StCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StMatrizRebateSic, rebateSic.StMatrizRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsRebate, rebateSic.DsObsRebate, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCalculoRetroativoSic, rebateSic.StCalculoRetroativoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPossuiCalculoRebateSic, rebateSic.StPossuiCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StNaoenviarsapRebateSic, rebateSic.StNaoenviarsapRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumecontratadoRebateSic, rebateSic.VlVolumecontratadoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumelimiteRebateSic, rebateSic.VlVolumelimiteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StControlevolume, rebateSic.StControlevolume, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPagamentoProporcional, rebateSic.StPagamentoProporcional, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, RebateSic rebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, rebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, rebateSic.NrSeqTiporebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, rebateSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmRebateSic, rebateSic.NrIbmRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAssinaturacontratoRebateSic, rebateSic.DtAssinaturacontratoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciovigenciaRebateSic, rebateSic.DtIniciovigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimvigenciaRebateSic, rebateSic.DtFimvigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigofornecedorRebateSic, rebateSic.NrCodigofornecedorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigopagadorRebateSic, rebateSic.NrCodigopagadorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCalculoRebateSic, rebateSic.StCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StMatrizRebateSic, rebateSic.StMatrizRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsRebate, rebateSic.DsObsRebate, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCalculoRetroativoSic, rebateSic.StCalculoRetroativoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPossuiCalculoRebateSic, rebateSic.StPossuiCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StNaoenviarsapRebateSic, rebateSic.StNaoenviarsapRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumecontratadoRebateSic, rebateSic.VlVolumecontratadoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumelimiteRebateSic, rebateSic.VlVolumelimiteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StControlevolume, rebateSic.StControlevolume, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPagamentoProporcional, rebateSic.StPagamentoProporcional, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

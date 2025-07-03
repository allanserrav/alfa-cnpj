#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseCalculoRebateFaixaSicDAO.cs
// Class Name	        : CalculoRebateFaixaSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 04/01/2013
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
	#region classe base CalculoRebateFaixaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateFaixaSicDAO
	/// </summary>
	internal partial class CalculoRebateFaixaSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public CalculoRebateFaixaSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqCalculoRebateFaixaSic = "NR_SEQ_CALCULO_REBATE_FAIXA_SIC";
		private const string C_NrSeqCalculoRebateSic = "NR_SEQ_CALCULO_REBATE_SIC";
		private const string C_VlVolumeMaximoSic = "VL_VOLUME_MAXIMO_SIC";
		private const string C_VlVolumeMinimoSic = "VL_VOLUME_MINIMO_SIC";
		private const string C_VlVolumeCalculadoSic = "VL_VOLUME_CALCULADO_SIC";
		private const string C_VlBonificacaoCalculadoSic = "VL_BONIFICACAO_CALCULADO_SIC";
		private const string C_VlVolumeContratadoSic = "VL_VOLUME_CONTRATADO_SIC";
		#endregion  Constantes de TbCalculoRebateFaixaSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CALCULO_REBATE_FAIXA_SIC")
		.Append("(")
		.Append("NR_SEQ_CALCULO_REBATE_SIC,VL_VOLUME_MAXIMO_SIC,VL_VOLUME_MINIMO_SIC,VL_VOLUME_CALCULADO_SIC,VL_BONIFICACAO_CALCULADO_SIC,VL_VOLUME_CONTRATADO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_VlVolumeMaximoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeMinimoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeCalculadoSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoCalculadoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeContratadoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CALCULO_REBATE_FAIXA_SIC SET")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(",VL_VOLUME_MAXIMO_SIC = ")
		.Append("@" + C_VlVolumeMaximoSic)
		.Append(",VL_VOLUME_MINIMO_SIC = ")
		.Append("@" + C_VlVolumeMinimoSic)
		.Append(",VL_VOLUME_CALCULADO_SIC = ")
		.Append("@" + C_VlVolumeCalculadoSic)
		.Append(",VL_BONIFICACAO_CALCULADO_SIC = ")
		.Append("@" + C_VlBonificacaoCalculadoSic)
		.Append(",VL_VOLUME_CONTRATADO_SIC = ")
		.Append("@" + C_VlVolumeContratadoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CALCULO_REBATE_FAIXA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CALCULO_REBATE_FAIXA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Incluir(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(calculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (calculoRebateFaixaSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateFaixaSic)));
			else
				calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateFaixaSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Atualizar(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(calculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (calculoRebateFaixaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateFaixaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateFaixaSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		public void Excluir(CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(calculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui calculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (calculoRebateFaixaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateFaixaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateFaixaSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe CalculoRebateFaixaSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (calculoRebateFaixaSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateFaixaSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateFaixaSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe CalculoRebateFaixaSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateFaixaSic, calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateFaixaSic.NrSeqCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMaximoSic, calculoRebateFaixaSic.VlVolumeMaximoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMinimoSic, calculoRebateFaixaSic.VlVolumeMinimoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCalculadoSic, calculoRebateFaixaSic.VlVolumeCalculadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoCalculadoSic, calculoRebateFaixaSic.VlBonificacaoCalculadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeContratadoSic, calculoRebateFaixaSic.VlVolumeContratadoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, CalculoRebateFaixaSic calculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateFaixaSic, calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateFaixaSic.NrSeqCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMaximoSic, calculoRebateFaixaSic.VlVolumeMaximoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMinimoSic, calculoRebateFaixaSic.VlVolumeMinimoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCalculadoSic, calculoRebateFaixaSic.VlVolumeCalculadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoCalculadoSic, calculoRebateFaixaSic.VlBonificacaoCalculadoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeContratadoSic, calculoRebateFaixaSic.VlVolumeContratadoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

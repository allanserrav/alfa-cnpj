#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseVolumeCalculoRebateFaixaSicDAO.cs
// Class Name	        : VolumeCalculoRebateFaixaSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 19/11/2012
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
	#region classe base VolumeCalculoRebateFaixaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a VolumeCalculoRebateFaixaSicDAO
	/// </summary>
	internal partial class VolumeCalculoRebateFaixaSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public VolumeCalculoRebateFaixaSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqVolumeMensalFaixaRebateSic = "NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC";
		private const string C_NrSeqCalculoRebateFaixaSic = "NR_SEQ_CALCULO_REBATE_FAIXA_SIC";
		#endregion  Constantes de TbVolumeCalculoRebateFaixaSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_VOLUME_CALCULO_REBATE_FAIXA_SIC")
		.Append("(")
		.Append("NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC,NR_SEQ_CALCULO_REBATE_FAIXA_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_VOLUME_CALCULO_REBATE_FAIXA_SIC SET")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append(",NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append(" AND NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_VOLUME_CALCULO_REBATE_FAIXA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append(" AND NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append("").ToString();
		#endregion Query Excluir
		
		#region Query Verifica se existe
		/// <summary>
		/// String com a query Verifica se existe
		/// </summary>
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_VOLUME_CALCULO_REBATE_FAIXA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = ")
		.Append("@" + C_NrSeqVolumeMensalFaixaRebateSic)
		.Append(" AND NR_SEQ_CALCULO_REBATE_FAIXA_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateFaixaSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Incluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(volumeCalculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (volumeCalculoRebateFaixaSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, volumeCalculoRebateFaixaSic));
			else
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, volumeCalculoRebateFaixaSic), databaseManager.Transaction);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Atualizar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(volumeCalculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (volumeCalculoRebateFaixaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, volumeCalculoRebateFaixaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, volumeCalculoRebateFaixaSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui volumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Excluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(volumeCalculoRebateFaixaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui volumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (volumeCalculoRebateFaixaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, volumeCalculoRebateFaixaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, volumeCalculoRebateFaixaSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe VolumeCalculoRebateFaixaSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager)
		{
			if (volumeCalculoRebateFaixaSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, volumeCalculoRebateFaixaSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, volumeCalculoRebateFaixaSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe VolumeCalculoRebateFaixaSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqVolumeMensalFaixaRebateSic, volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateFaixaSic, volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqVolumeMensalFaixaRebateSic, volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateFaixaSic, volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqVolumeMensalFaixaRebateSic, volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateFaixaSic, volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

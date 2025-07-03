#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeCalculoRebateFaixaSicDAO.cs
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
	#region classe concreta VolumeCalculoRebateFaixaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a VolumeCalculoRebateFaixaSicDAO
	/// </summary>
	internal partial class VolumeCalculoRebateFaixaSicDAO : IVolumeCalculoRebateFaixaSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbVolumeCalculoRebateFaixaSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" VIEW_CALCULO_FAIXA_HISTORICO_REBATE_SIC.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC")
		.Append(",VIEW_CALCULO_FAIXA_HISTORICO_REBATE_SIC.NR_SEQ_CALCULO_REBATE_FAIXA_SIC")
		.Append(" FROM VIEW_CALCULO_FAIXA_HISTORICO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instância de <see cref="VolumeCalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeCalculoRebateFaixaSic</returns>
		public IList<VolumeCalculoRebateFaixaSic> Selecionar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, int numeroLinhas, string ordem)
		{
			IList<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic = new List<VolumeCalculoRebateFaixaSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, volumeCalculoRebateFaixaSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listVolumeCalculoRebateFaixaSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listVolumeCalculoRebateFaixaSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto VolumeCalculoRebateFaixaSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto VolumeCalculoRebateFaixaSic preenchido</returns>
		protected VolumeCalculoRebateFaixaSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic = new VolumeCalculoRebateFaixaSic();
			volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic = reader.GetNullableInt32(C_NrSeqVolumeMensalFaixaRebateSic);
			volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic = reader.GetNullableInt32(C_NrSeqCalculoRebateFaixaSic);
			return volumeCalculoRebateFaixaSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE_SIC", C_NrSeqVolumeMensalFaixaRebateSic, DatabaseManager.SQLOperation.Equal, volumeCalculoRebateFaixaSic.NrSeqVolumeMensalFaixaRebateSic, ref where));
			if (volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "VIEW_CALCULO_FAIXA_HISTORICO_REBATE_SIC", C_NrSeqCalculoRebateFaixaSic, DatabaseManager.SQLOperation.Equal, volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

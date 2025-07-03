#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewGaClienteRebateSicDAO.cs
// Class Name	        : ViewGaClienteRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Romildo Cruz
// Creation Date 	    : 24/01/2013
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
	#region classe concreta ViewGaClienteRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ViewGaClienteRebateSicDAO
	/// </summary>
	internal partial class ViewGaClienteRebateSicDAO : IViewGaClienteRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbViewGaClienteRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" View_GA_Cliente_Rebate_SIC.NM_GALOJA_CLIENTE_SIC")
		.Append(" FROM View_GA_Cliente_Rebate_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		public IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic, int numeroLinhas, string ordem)
		{
			IList<ViewGaClienteRebateSic> listViewGaClienteRebateSic = new List<ViewGaClienteRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, viewGaClienteRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listViewGaClienteRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listViewGaClienteRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ViewGaClienteRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ViewGaClienteRebateSic preenchido</returns>
		protected ViewGaClienteRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ViewGaClienteRebateSic viewGaClienteRebateSic = new ViewGaClienteRebateSic();
			viewGaClienteRebateSic.NmGalojaClienteSic = reader.GetString(C_NmGalojaClienteSic);
			return viewGaClienteRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ViewGaClienteRebateSic viewGaClienteRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (viewGaClienteRebateSic.NmGalojaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "View_GA_Cliente_Rebate_SIC", C_NmGalojaClienteSic, DatabaseManager.SQLOperation.Like, "%" + viewGaClienteRebateSic.NmGalojaClienteSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

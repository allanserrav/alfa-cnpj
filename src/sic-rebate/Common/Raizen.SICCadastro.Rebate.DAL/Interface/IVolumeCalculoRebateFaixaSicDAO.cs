#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IVolumeCalculoRebateFaixaSicDAO.cs
// Class Name	        : IVolumeCalculoRebateFaixaSicDAO
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
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IVolumeCalculoRebateFaixaSicDAO
	/// </summary>
	public partial interface IVolumeCalculoRebateFaixaSicDAO
	{
		#region Metodos de IVolumeCalculoRebateFaixaSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instância de <see cref="VolumeCalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeCalculoRebateFaixaSic</returns>
		IList<VolumeCalculoRebateFaixaSic> Selecionar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		void Incluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		void Atualizar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui volumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		void Excluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic);
		#endregion Excluir
		
		#endregion IVolumeCalculoRebateFaixaSicDAO
	}
}

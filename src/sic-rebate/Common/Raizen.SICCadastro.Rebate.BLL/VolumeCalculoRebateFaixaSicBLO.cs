#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeCalculoRebateFaixaSicBLO.cs
// Class Name	        : VolumeCalculoRebateFaixaSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/19/2012
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  VolumeCalculoRebateFaixaSicBLO
	/// </summary>
	internal partial class VolumeCalculoRebateFaixaSicBLO : IVolumeCalculoRebateFaixaSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de VolumeCalculoRebateFaixaSicDAO 
		/// </summary>
		private readonly IVolumeCalculoRebateFaixaSicDAO volumeCalculoRebateFaixaSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public VolumeCalculoRebateFaixaSicBLO()
		{
			this.volumeCalculoRebateFaixaSicDAO = Factory.CreateFactoryInstance().CreateInstance<IVolumeCalculoRebateFaixaSicDAO>("VolumeCalculoRebateFaixaSicDAO");
		}
		#endregion Construtor
		
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
			return this.volumeCalculoRebateFaixaSicDAO.Selecionar(volumeCalculoRebateFaixaSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instância de <see cref="VolumeCalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de VolumeCalculoRebateFaixaSic</returns>
		public IList<VolumeCalculoRebateFaixaSic> Selecionar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, string ordem)
		{
			return this.Selecionar(volumeCalculoRebateFaixaSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instância de <see cref="VolumeCalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de VolumeCalculoRebateFaixaSic</returns>
		public IList<VolumeCalculoRebateFaixaSic> Selecionar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			return this.Selecionar(volumeCalculoRebateFaixaSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <returns>Retorna lista de VolumeCalculoRebateFaixaSic</returns>
		public IList<VolumeCalculoRebateFaixaSic> Selecionar()
		{
			return this.Selecionar(new VolumeCalculoRebateFaixaSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instância de <see cref="VolumeCalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de VolumeCalculoRebateFaixaSic</returns>
		public VolumeCalculoRebateFaixaSic SelecionarPrimeiro(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			IList<VolumeCalculoRebateFaixaSic> lista = this.Selecionar(volumeCalculoRebateFaixaSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new VolumeCalculoRebateFaixaSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Incluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			if (null == volumeCalculoRebateFaixaSic) throw (new ArgumentNullException());
			this.volumeCalculoRebateFaixaSicDAO.Incluir(volumeCalculoRebateFaixaSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar VolumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Atualizar(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			if (null == volumeCalculoRebateFaixaSic) throw (new ArgumentNullException());
			this.volumeCalculoRebateFaixaSicDAO.Atualizar(volumeCalculoRebateFaixaSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir volumeCalculoRebateFaixaSic
		/// </summary>
		/// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
		public void Excluir(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic)
		{
			if (null == volumeCalculoRebateFaixaSic) throw (new ArgumentNullException());
			this.volumeCalculoRebateFaixaSicDAO.Excluir(volumeCalculoRebateFaixaSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


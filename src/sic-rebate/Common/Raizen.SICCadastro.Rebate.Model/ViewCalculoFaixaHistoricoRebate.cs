#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewCalculoFaixaHistoricoRebate.cs
// Class Name	        : ViewCalculoFaixaHistoricoRebate
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 29/01/2013
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
using System.Text;
using System.Data;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.Model
{
	/// <summary>
	/// Entitade Representada por ViewCalculoFaixaHistoricoRebate
	/// </summary>
	[Serializable]
	public class ViewCalculoFaixaHistoricoRebate
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoTotalSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoTotalSic { get; set; }
		/// <summary>
		/// Propriedade StAditivoSic
		/// </summary>
		public Nullable<Boolean> StAditivoSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoVolume
		/// </summary>
		public Nullable<DateTime> DtPeriodoVolume { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixarebateSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixarebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeContratadoSic
		/// </summary>
		public Nullable<decimal> VlVolumeContratadoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeMaximoSic
		/// </summary>
		public Nullable<decimal> VlVolumeMaximoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeMinimoSic
		/// </summary>
		public Nullable<decimal> VlVolumeMinimoSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoCalculadoSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoCalculadoSic { get; set; }
		/// <summary>
		/// Propriedade DtIniciocalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtIniciocalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtFimcalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtFimcalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumemensalRebateSic
		/// </summary>
		public Nullable<decimal> VlVolumemensalRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlPercminimoRebateSic
		/// </summary>
		public Nullable<decimal> VlPercminimoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlPercmaximoRebateSic
		/// </summary>
		public Nullable<decimal> VlPercmaximoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoRebateSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlRecebebonusRebateSic
		/// </summary>
		public Nullable<decimal> VlRecebebonusRebateSic { get; set; }
		/// <summary>
		/// Propriedade NmCategoriaSic
		/// </summary>
		public string NmCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade NmRazsociallojaFranquiaSic
		/// </summary>
		public string NmRazsociallojaFranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmClienteSic
		/// </summary>
		public string NrIbmClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrCegrpostoClienteSic
		/// </summary>
		public string NrCegrpostoClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmGalojaClienteSic
		/// </summary>
		public string NmGalojaClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmGtlojaClienteSic
		/// </summary>
		public string NmGtlojaClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmCanalClienteSic
		/// </summary>
		public string NmCanalClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrCodigopagadorRebateSic
		/// </summary>
		public string NrCodigopagadorRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrCodigofornecedorRebateSic
		/// </summary>
		public string NrCodigofornecedorRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtAssinaturacontratoRebateSic
		/// </summary>
		public Nullable<DateTime> DtAssinaturacontratoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtFimvigenciaRebateSic
		/// </summary>
		public Nullable<DateTime> DtFimvigenciaRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtPagamentoSic
		/// </summary>
		public Nullable<DateTime> DtPagamentoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTiporebateSic
		/// </summary>
		public Nullable<Int32> NrSeqTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade NmTiporebateSic
		/// </summary>
		public string NmTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqGrupoSic
		/// </summary>
		public Nullable<Int32> NrSeqGrupoSic { get; set; }
		/// <summary>
		/// Propriedade NmEmpresaSic
		/// </summary>
		public string NmEmpresaSic { get; set; }
		/// <summary>
		/// Propriedade VlDebitoSic
		/// </summary>
		public Nullable<decimal> VlDebitoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqStatusCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NmStatusCalculoRebateSic
		/// </summary>
		public string NmStatusCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeCompradoSic
		/// </summary>
		public Nullable<decimal> VlVolumeCompradoSic { get; set; }
		#endregion
	}
}

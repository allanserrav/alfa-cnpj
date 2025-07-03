using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.Model.Enum;

namespace Raizen.SICCadastro.Rebate.Api.Models.Response
{ 
    /// <summary>
    /// Estrutura de Rebate
    /// </summary>
    [DataContract]
    public partial class RebateResponse : IEquatable<RebateResponse>
    {
        public RebateResponse()
        {

        }

        public RebateResponse(RebateSic rebateSic, IList<FaixarebateSic> faixarebateSic)
        {
            Ibm = rebateSic.NrIbmRebateSic;
            TipoRebate = rebateSic.DsTipoRebateSic;
            PeriodicidadePagto = rebateSic.StCalculoRebateSic.GetValueOrDefault(false) ? "Trimestral" : "Mensal";
            UltimoPagto = rebateSic.UltimoPagto;
            ValorUltimoPagto = rebateSic.ValorUltimoPagto;
            Produtos = new List<ProdutoResponse>();

            foreach (var item in faixarebateSic)
            {
                var produto = new ProdutoResponse()
                {
                    Descricao = item.DsCategoriaSic,
                    Volume = (rebateSic.NrSeqTiporebateSic != (int)Model.Enum.TipoRebate.Escalonado) ? item.VlVolumemensalRebateSic : null,
                    AlvoMensal = (rebateSic.NrSeqTiporebateSic == (int)Model.Enum.TipoRebate.Escalonado) ? item.VlVolumemensalRebateSic : null,
                    VolumeMaximo = (rebateSic.NrSeqTiporebateSic == (int)Model.Enum.TipoRebate.Escalonado) ? item.VlPercmaximoRebateSic : null,
                    De = item.VlPercminimoRebateSic,
                    Ate = item.VlPercmaximoRebateSic,
                    InicioVigencia = item.DtIniciocalculoRebateSic,
                    FimVigencia = item.DtFimcalculoRebateSic,
                    Bonificacao = item.VlBonificacaoRebateSic,
                    Bonus = (rebateSic.NrSeqTiporebateSic != (int)Model.Enum.TipoRebate.Escalonado) ? item.VlRecebebonusRebateSic : null                    
                };

                Produtos.Add(produto);
            }
        }

        /// <summary>
        /// ibm
        /// </summary>
        /// <value>ibm</value>
        [DataMember(Name="ibm")]
        public string Ibm { get; set; }

        /// <summary>
        /// Gets or Sets TipoRebate
        /// </summary>
        [DataMember(Name="tipoRebate")]
        public string TipoRebate { get; set; }

        /// <summary>
        /// Periodicidade de pagamento
        /// </summary>
        /// <value>Periodicidade de pagamento</value>
        [DataMember(Name="periodicidadePagto")]
        public string PeriodicidadePagto { get; set; }

        /// <summary>
        /// Data do último pagamento (YYYY-MM-DD)
        /// </summary>
        /// <value>Data do último pagamento (YYYY-MM-DD)</value>
        [DataMember(Name="ultimoPagto")]
        public DateTime? UltimoPagto { get; set; }

        /// <summary>
        /// Valor do último pagamento
        /// </summary>
        /// <value>Valor do último pagamento</value>
        [DataMember(Name="valorUltimoPagto")]
        public decimal? ValorUltimoPagto { get; set; }

        /// <summary>
        /// Gets or Sets Produtos
        /// </summary>
        [DataMember(Name="produtos")]
        public List<ProdutoResponse> Produtos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RebateResponse {\n");
            sb.Append("  Ibm: ").Append(Ibm).Append("\n");
            sb.Append("  TipoRebate: ").Append(TipoRebate).Append("\n");
            sb.Append("  PeriodicidadePagto: ").Append(PeriodicidadePagto).Append("\n");
            sb.Append("  UltimoPagto: ").Append(UltimoPagto).Append("\n");
            sb.Append("  ValorUltimoPagto: ").Append(ValorUltimoPagto).Append("\n");
            sb.Append("  Produtos: ").Append(Produtos).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((RebateResponse)obj);
        }

        /// <summary>
        /// Returns true if RebateResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RebateResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RebateResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Ibm == other.Ibm ||
                    Ibm != null &&
                    Ibm.Equals(other.Ibm)
                ) && 
                (
                    TipoRebate == other.TipoRebate ||
                    TipoRebate != null &&
                    TipoRebate.Equals(other.TipoRebate)
                ) && 
                (
                    PeriodicidadePagto == other.PeriodicidadePagto ||
                    PeriodicidadePagto != null &&
                    PeriodicidadePagto.Equals(other.PeriodicidadePagto)
                ) && 
                (
                    UltimoPagto == other.UltimoPagto ||
                    UltimoPagto != null &&
                    UltimoPagto.Equals(other.UltimoPagto)
                ) && 
                (
                    ValorUltimoPagto == other.ValorUltimoPagto ||
                    ValorUltimoPagto != null &&
                    ValorUltimoPagto.Equals(other.ValorUltimoPagto)
                ) && 
                (
                    Produtos == other.Produtos ||
                    Produtos != null &&
                    Produtos.SequenceEqual(other.Produtos)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
#pragma warning disable S2681
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {       
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Ibm != null)
                    hashCode = hashCode * 59 + Ibm.GetHashCode();
                    if (TipoRebate != null)
                    hashCode = hashCode * 59 + TipoRebate.GetHashCode();
                    if (PeriodicidadePagto != null)
                    hashCode = hashCode * 59 + PeriodicidadePagto.GetHashCode();
                    if (UltimoPagto != null)
                    hashCode = hashCode * 59 + UltimoPagto.GetHashCode();
                    if (ValorUltimoPagto != null)
                    hashCode = hashCode * 59 + ValorUltimoPagto.GetHashCode();
                    if (Produtos != null)
                    hashCode = hashCode * 59 + Produtos.GetHashCode();                
                return hashCode;
            }
        }
#pragma warning restore S2681

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(RebateResponse left, RebateResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RebateResponse left, RebateResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

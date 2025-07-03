using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Raizen.SICCadastro.Rebate.Api.Models.Response
{
    /// <summary>
    /// Estrutura de Produto
    /// </summary>
    [DataContract]
    public partial class ProdutoResponse : IEquatable<ProdutoResponse>
    {
        /// <summary>
        /// Descrição do produto
        /// </summary>
        /// <value>Descrição do produto</value>
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        /// <summary>
        /// Volume (m³)
        /// </summary>
        /// <value>Volume (m³)</value>
        [DataMember(Name = "volume")]
        public decimal? Volume { get; set; }

        /// <summary>
        /// Alvo mensal
        /// </summary>
        /// <value>Alvo mensal</value>
        [DataMember(Name = "alvoMensal")]
        public decimal? AlvoMensal { get; set; }

        /// <summary>
        /// Volume Máximo (m³)
        /// </summary>
        /// <value>Volume Máximo (m³)</value>
        [DataMember(Name = "volumeMaximo")]
        public decimal? VolumeMaximo { get; set; }

        /// <summary>
        /// Percentual mínimo para conceder bonificação
        /// </summary>
        /// <value>Percentual mínimo para conceder bonificação</value>
        [DataMember(Name = "de")]
        public decimal? De { get; set; }

        /// <summary>
        /// Percentual máximo para conceder bonificação
        /// </summary>
        /// <value>Percentual máximo para conceder bonificação</value>
        [DataMember(Name = "ate")]
        public decimal? Ate { get; set; }

        /// <summary>
        /// Inicio da vigência (YYYY-MM-DD)
        /// </summary>
        /// <value>Inicio da vigência (YYYY-MM-DD)</value>
        [DataMember(Name = "inicioVigencia")]
        public DateTime? InicioVigencia { get; set; }

        /// <summary>
        /// Fim da vigência (YYYY-MM-DD)
        /// </summary>
        /// <value>Fim da vigência (YYYY-MM-DD)</value>
        [DataMember(Name = "fimVigencia")]
        public DateTime? FimVigencia { get; set; }

        /// <summary>
        /// Valor da bonificação
        /// </summary>
        /// <value>Valor da bonificação</value>
        [DataMember(Name = "bonificacao")]
        public decimal? Bonificacao { get; set; }

        /// <summary>
        /// Valor do bônus
        /// </summary>
        /// <value>Valor do bônus</value>
        [DataMember(Name = "bonus")]
        public decimal? Bonus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProdutoResponse {\n");
            sb.Append("  Descricao: ").Append(Descricao).Append("\n");
            sb.Append("  Volume: ").Append(Volume).Append("\n");
            sb.Append("  AlvoMensal: ").Append(AlvoMensal).Append("\n");
            sb.Append("  VolumeMaximo: ").Append(VolumeMaximo).Append("\n");
            sb.Append("  De: ").Append(De).Append("\n");
            sb.Append("  Ate: ").Append(Ate).Append("\n");
            sb.Append("  InicioVigencia: ").Append(InicioVigencia).Append("\n");
            sb.Append("  FimVigencia: ").Append(FimVigencia).Append("\n");
            sb.Append("  Bonificacao: ").Append(Bonificacao).Append("\n");
            sb.Append("  Bonus: ").Append(Bonus).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ProdutoResponse)obj);
        }

        /// <summary>
        /// Returns true if ProdutoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ProdutoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProdutoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Descricao == other.Descricao ||
                    Descricao != null &&
                    Descricao.Equals(other.Descricao)
                ) &&
                (
                    Volume == other.Volume ||
                    Volume != null &&
                    Volume.Equals(other.Volume)
                ) &&
                (
                    AlvoMensal == other.AlvoMensal ||
                    AlvoMensal != null &&
                    AlvoMensal.Equals(other.AlvoMensal)
                ) &&
                (
                    VolumeMaximo == other.VolumeMaximo ||
                    VolumeMaximo != null &&
                    VolumeMaximo.Equals(other.VolumeMaximo)
                ) &&
                (
                    De == other.De ||
                    De != null &&
                    De.Equals(other.De)
                ) &&
                (
                    Ate == other.Ate ||
                    Ate != null &&
                    Ate.Equals(other.Ate)
                ) &&
                (
                    InicioVigencia == other.InicioVigencia ||
                    InicioVigencia != null &&
                    InicioVigencia.Equals(other.InicioVigencia)
                ) &&
                (
                    FimVigencia == other.FimVigencia ||
                    FimVigencia != null &&
                    FimVigencia.Equals(other.FimVigencia)
                ) &&
                (
                    Bonificacao == other.Bonificacao ||
                    Bonificacao != null &&
                    Bonificacao.Equals(other.Bonificacao)
                ) &&
                (
                    Bonus == other.Bonus ||
                    Bonus != null &&
                    Bonus.Equals(other.Bonus)
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
                if (Descricao != null)
                    hashCode = hashCode * 59 + Descricao.GetHashCode();
                if (Volume != null)
                    hashCode = hashCode * 59 + Volume.GetHashCode();
                if (AlvoMensal != null)
                    hashCode = hashCode * 59 + AlvoMensal.GetHashCode();
                if (VolumeMaximo != null)
                    hashCode = hashCode * 59 + VolumeMaximo.GetHashCode();
                if (De != null)
                    hashCode = hashCode * 59 + De.GetHashCode();
                if (Ate != null)
                    hashCode = hashCode * 59 + Ate.GetHashCode();
                if (InicioVigencia != null)
                    hashCode = hashCode * 59 + InicioVigencia.GetHashCode();
                if (FimVigencia != null)
                    hashCode = hashCode * 59 + FimVigencia.GetHashCode();
                if (Bonificacao != null)
                    hashCode = hashCode * 59 + Bonificacao.GetHashCode();
                if (Bonus != null)
                    hashCode = hashCode * 59 + Bonus.GetHashCode();
                return hashCode;
            }
        }
#pragma warning restore S2681

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ProdutoResponse left, ProdutoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProdutoResponse left, ProdutoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}

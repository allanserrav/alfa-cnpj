using System;

namespace Raizen.SICCadastro.Rebate.Model
{
    public partial class RebateSic
    {
        public decimal? VlVolumeCompradoRebateSic { get; set; }

        public string DsTipoRebateSic { get; set; }

        public DateTime? UltimoPagto { get; set; }

        public decimal? ValorUltimoPagto { get; set; }
    }
}
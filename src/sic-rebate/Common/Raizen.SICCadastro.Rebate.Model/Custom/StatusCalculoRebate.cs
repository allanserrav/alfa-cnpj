using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Representa os tipos de status do calculo rebate
    /// </summary>
    public enum StatusCalculoRebate
    {
        AptoPagamento = 1,
        PendenteDebito = 2,
        Pago = 3,
        InformacoesInconsistentes = 4,
        NaoAtingiuVolumeMinimo = 5,
        EnviadoPagamento = 6,
        Cancelado = 7,
        VerificandoDebitos = 8,
        AcertoBloqueado = 9
    }
}

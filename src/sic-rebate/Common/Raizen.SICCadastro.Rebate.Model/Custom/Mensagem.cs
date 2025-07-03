using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Classe utilitária para mensagens
    /// </summary>
    public class Mensagem
    {
        public string Texto { get; set; }
        public object Objeto { get; set; }
        public TipoMensagem Tipo { get; set; }
    }

    /// <summary>
    /// Enum para o tipo da mensagem
    /// </summary>
    public enum TipoMensagem
    {
        Erro,
        Sucesso
    }
}

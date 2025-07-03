using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Raizen.SICCadastro.Model.Tela
{
    /// <summary>
    /// Tipo de resultado gerado por uma ação do usuario
    /// </summary>
    public enum TipoResultado
    {
        Nada = 0,
        Nao = 1,
        Sim = 2,
        Ok = 3,
        Cancelar = 4,
        Abortar = 5
    }
}

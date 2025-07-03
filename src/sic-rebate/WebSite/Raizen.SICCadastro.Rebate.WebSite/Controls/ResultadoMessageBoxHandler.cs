using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ResultadoMessageBoxHandler(object sender, ResultadoMessageBoxEvent e);

    /// <summary>
    /// 
    /// </summary>
    public class ResultadoMessageBoxEvent
    {
        #region Atributos

        private TipoResultado _tipoResultado;
        private string _ancora;
        private object _referencia;

        #endregion

        #region Propriedades

        public TipoResultado TipoResultado
        {
            get { return this._tipoResultado; }
        }

        public string Ancora
        {
            get { return this._ancora; }
        }

        public object Referencia
        {
            get { return this._referencia; }
        }

        #endregion

        #region Construtor

        public ResultadoMessageBoxEvent(TipoResultado tipoResultado, string ancora, object referencia)
        {
            this._tipoResultado = tipoResultado;
            this._ancora = ancora;
            this._referencia = referencia;
        }

        #endregion

        #region Metodos

        public T ReferenciaCast<T>()
        {
            return (T)this.Referencia;
        }

        #endregion
    }
}

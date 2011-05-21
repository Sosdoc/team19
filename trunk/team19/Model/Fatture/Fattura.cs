using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    abstract class Fattura
    {
        private DateTime _data;
        private int _numero;

        public abstract Currency Importo
        {
            get;
        }

        public Fattura(DateTime data, int numero)
        {
            this._data = data;
            this._numero = numero;
        }
        
    }
}

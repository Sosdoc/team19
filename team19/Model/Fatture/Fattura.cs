using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class Fattura
    {
        private DateTime _data;
        private int _numero;

        public abstract Currency Importo
        {
            get;
        }

        public int NumeroFattura
        {
            get
            {
                return _numero;
            }
        }

        public DateTime Data
        {
            get
            {
                return _data;
            }
        }

        protected Fattura(DateTime data, int numero)
        {
            if (numero <= 0)
                throw new ArgumentException("numero <= 0");

            this._data = data;
            this._numero = numero;
        }
        
    }
}

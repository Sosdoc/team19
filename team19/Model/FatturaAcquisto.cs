using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class FatturaAcquisto: Fattura, Destinazione
    {
        private Currency _importo;

        public override Currency Importo
        {
            get { return _importo; }
        }

        public FatturaAcquisto(DateTime data, int numero, Currency importo)
            :base(data, numero)
        {
            this._importo = importo;
        }
    }
}

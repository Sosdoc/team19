using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;
        private Fornitore _fornitore;
        private Fornitore fornitore;
        private Currency importo;

        public override Currency Importo
        {
            get { return _importo; }
        }

        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data,1, importo);
        }
        private FatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            this._importo = importo;
            this._fornitore = fornitore;
        }

    }
}

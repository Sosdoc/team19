using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;
        private IFornitore _fornitore;

        public FatturaAcquisto(IFornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            if (importo.Value <= 0)
                throw new ArgumentException("importo.Value <= 0");
            if (fornitore == null)
                throw new ArgumentNullException("fornitore");

            this._importo = importo;
            this._fornitore = fornitore;
        }

        public static FatturaAcquisto CreateFatturaAcquisto(IFornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data, numero, importo);
        }

        public IFornitore Fornitore
        {
            get { return _fornitore; }
        }

        public override Currency Importo
        {
            get { return _importo; }
        }


    }
}

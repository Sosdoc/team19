using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Model
{
    public class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;
        private Fornitore _fornitore;

        public FatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            if (importo.Value <= 0)
                throw new ArgumentException("importo.Value <= 0");
            if (fornitore == null)
                throw new ArgumentNullException("fornitore");

            this._importo = importo;
            this._fornitore = fornitore;
        }

        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data, numero, importo);
        }

        public Fornitore Fornitore
        {
            get { return _fornitore; }
        }

        public override Currency Importo
        {
            get { return _importo; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model.Fatture
{
    class FatturaFactory
    {
    }

    #region Fattura di vendita
    private class FatturaVendita : Fattura, ISorgente
    {
        private ElencoProdotti _elencoProdotti;

        public override Currency Importo
        {
            get
            {
                double sum = 0;
                foreach (RigaFattura riga in _elencoProdotti)
                {
                    sum += riga.Quantità * riga.PrezzoUnitario.Value;
                }
                return new Currency(sum);
            }
        }

        public FatturaVendita(DateTime data, int numero, ElencoProdotti elencoProdotti)
            : base(data, numero)
        {
            //nota -- le fatture di vendita devono prendere il numero progressivo da qualche parte: da dove?
            this._elencoProdotti = elencoProdotti;
        }
    }
    #endregion

    #region Fattura d'acquisto
    private class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;

        public override Currency Importo
        {
            get { return _importo; }
        }

        public FatturaAcquisto(DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            this._importo = importo;
        }
    }
    #endregion
}

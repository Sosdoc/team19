using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class FatturaVendita: Fattura, Sorgente
    {
        private ElencoProdotti _elencoProdotti;

        public override Currency Importo
        {
            get 
            { 
                double sum = 0;
                foreach(RigaFattura riga in _elencoProdotti)
                {
                    sum += riga.Quantità * riga.PrezzoUnitario.Value;
                }
                return new Currency(sum);
            }
        }

        public FatturaVendita(DateTime data, int numero, ElencoProdotti elencoProdotti)
            :base(data, numero)
        {
            //nota -- le fatture di vendita devono prendere il numero progressivo da qualche parte: da dove?
            this._elencoProdotti = elencoProdotti;
        }
    }
}

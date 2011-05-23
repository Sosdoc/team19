using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class FatturaFactory
    {
        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {
            return new FatturaVendita(cliente, data, Document.GetInstance().NumeroProssimaFatturaDiVendita(data), elencoProdotti);
        }

        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data, numero, importo);
        }
    }

    public class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;

        internal FatturaVendita(Cliente cliente, DateTime data, int numero, List<RigaFattura> elencoProdotti)
            : base(data, numero)
        {
            this._elencoProdotti = elencoProdotti;
            this._cliente = cliente;
        }

        public IEnumerable<RigaFattura> ElencoProdotti
        {
            get
            {
                return _elencoProdotti;
            }
        }

        public override Currency Importo
        {
            get
            {
                Currency sum = new Currency(0m);
                foreach (RigaFattura riga in _elencoProdotti)
                {
                    sum += riga.PrezzoUnitario * riga.Quantità;
                }
                return sum;
            }
        }
    }

    public class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;
        private Fornitore _fornitore;

        public Fornitore Fornitore
        {
            get { return _fornitore; }
        }

        public override Currency Importo
        {
            get { return _importo; }
        }

        public FatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            if (importo.Value <= 0)
                throw new ArgumentException("importo.Value <= 0");
            if (fornitore == null)
                throw new ArgumentException("fornitore == null");

            this._importo = importo;
            this._fornitore = fornitore;
        }
    }


}

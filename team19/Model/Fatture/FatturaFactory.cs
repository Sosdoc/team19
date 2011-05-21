using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team19.Model.Soggetti;

namespace Team19.Model.Fatture
{
    class FatturaFactory
    {
        private int  _numeroUltimaFatturaEmessa;
        private FatturaFactory _instance;

        public FatturaFactory Instance
        {
            static get
            {
                return _instance;
            }
        }

        public FatturaAcquisto creaFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data, numero, importo);
        }

        public FatturaVendita creaFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elenco)
        {
            //int numeroNuovaFattura = _ultimaFatturaEmessa.NumeroFattura + 1;
            FatturaVendita retval = new FatturaVendita(cliente, data, 1, elenco);
            //Instance._ultimaFatturaEmessa = retval;
            return retval;
        }
    }

    #region Fattura di vendita
    private class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;
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

        public FatturaVendita(Cliente cliente, DateTime data, int numero, List<RigaFattura> elencoProdotti)
            : base(data, numero)
        {
            //nota -- le fatture di vendita devono prendere il numero progressivo da qualche parte: da dove?
            this._elencoProdotti = elencoProdotti;
            this._cliente = cliente;
        }
    }
    #endregion

    #region Fattura d'acquisto
    private class FatturaAcquisto : Fattura, IDestinazione
    {
        private Currency _importo;
        private Fornitore _fornitore;

        public override Currency Importo
        {
            get { return _importo; }
        }

        public FatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            this._importo = importo;
            this._fornitore = fornitore;
        }
    }
    #endregion
}

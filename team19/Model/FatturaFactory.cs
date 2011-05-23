using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class FatturaFactory
    {
        private static FatturaFactory _instance;


        private Fattura _ultimaFattura;



        private FatturaFactory()
        {
            _ultimaFattura = new FatturaVendita(new Cliente("","","","","",new Indirizzo("","","","","","")), DateTime.MinValue, 1, new List<RigaFattura>());
        }

        internal static FatturaFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FatturaFactory();
                return FatturaFactory._instance;
            }
        }

        private Fattura UltimaFattura
        {
            get { return _ultimaFattura; }
            set { _ultimaFattura = value; }
        }

        public FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {
            FatturaVendita nuovaFattura = new FatturaVendita(cliente, data, NumeroProssimaFatturaDiVendita(data), elencoProdotti);
            UltimaFattura = nuovaFattura;
            return nuovaFattura;

        }

        public FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return new FatturaAcquisto(fornitore, data, numero, importo);
        }

        private int NumeroProssimaFatturaDiVendita(DateTime dataNuovaFattura)
        {
            int retval = 1;

            //recupero l'ultima fattura emessa disponibile
            //FatturaVendita ultimaFatturaDiVendita = Document.GetInstance().Fatture.OfType<FatturaVendita>().Last();
            //if (Document.GetInstance().GetFattureVendita().ToArray().Length != 0)
            //{
            //    FatturaVendita ultimaFatturaDiVendita =
            //        (from fattura in Document.GetInstance().GetFattureVendita()
            //         orderby fattura.Data descending
            //         select fattura).First();
            //    //se non è cambiato anno dall'ultima fattura
            //    if (ultimaFatturaDiVendita.Data.Year == dataNuovaFattura.Year)
            //        retval = ultimaFatturaDiVendita.NumeroFattura + 1;
            //}
            if (UltimaFattura.Data.Year == dataNuovaFattura.Year)
                retval = UltimaFattura.NumeroFattura + 1;


            return retval;
        }
    }

    public class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;

        internal FatturaVendita(Cliente cliente, DateTime data, int numero, List<RigaFattura> elencoProdotti)
            : base(data, numero)
        {
            if (elencoProdotti == null)
                throw new ArgumentNullException("elencoProdotti");
            if (cliente == null)
                throw new ArgumentNullException("cliente");

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

        internal FatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
            : base(data, numero)
        {
            if (importo.Value <= 0)
                throw new ArgumentException("importo.Value <= 0");
            if (fornitore == null)
                throw new ArgumentNullException("fornitore");

            this._importo = importo;
            this._fornitore = fornitore;
        }
    }


}

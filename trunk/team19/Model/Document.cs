using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class Document
    {
        private List<MovimentoDiDenaro> _movimenti;
        private List<ContenitoreDiDenaro> _contenitoriDiDenaro;
        private List<Fattura> _fatture;
        private Dictionary<CodiceProdotto, Prodotto> _prodotti; //meglio un dictionary?
        private List<Soggetto> _soggetti;
        //riepiloghi?
        private Cassa _cassa;

        private static Document _instance;

        public static event EventHandler Changed;

        private Document()
        {
        }

        public IEnumerable<MovimentoDiDenaro> Movimenti
        {
            get { return _movimenti; }
        }

        public IEnumerable<ContenitoreDiDenaro> ContenitoriDiDenaro
        {
            get { return _contenitoriDiDenaro; }
        }

        public Cassa Cassa
        {
            get { return _cassa; }
        }

        public IEnumerable<Fattura> Fatture
        {
            get { return _fatture; }
        }

        public IEnumerable<Prodotto> Prodotti
        {
            get { return _prodotti; }
        }

        public IEnumerable<Soggetto> Soggetti
        {
            get { return _soggetti; }
        }

        public static void CreateInstance()
        {
            _instance = new Document();
            _instance.Load();
        }

        public static Document GetInstance()
        {
            if (_instance == null)
                CreateInstance();
            return _instance;
        }

        private void Load()
        {
            //qui inizializzo le liste
            _movimenti = new List<MovimentoDiDenaro>();
            _cassa = new Cassa();
            _contenitoriDiDenaro = new List<ContenitoreDiDenaro>();
            _fatture = new List<Fattura>();
            _prodotti = new Dictionary<CodiceProdotto, Prodotto>();
            _soggetti = new List<Soggetto>();

            Indirizzo i = new Indirizzo("nessuna", "9001", "Quaggiù", "02983", "BOH", "Ailati");
            Cliente c1 = new Cliente("Pinco Pallino", "0", "no", "8301", "PNCPLNlol", i);
            Prodotto p1 = new Prodotto(new Currency(10m), "palla", new CodiceProdotto("PAL", "11400"));



            OnChanged();
        }

        public void Save()
        {
            //questo metodo non fa nulla
        }

        public IEnumerable<FatturaVendita> GetFattureVendita()
        {
            return this.Fatture.OfType<FatturaVendita>();
        }

        public IEnumerable<FatturaAcquisto> GetFattureAcquisto()
        {
            return this.Fatture.OfType<FatturaAcquisto>();
        }        

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
